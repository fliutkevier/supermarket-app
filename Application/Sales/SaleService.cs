using Application.Sales.Dtos;
using Application.Sales.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleDetailRepository _saleDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserSessionService _userSessionService;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFiscalService _fiscalService;
        private readonly IRepository<FiscalDocument> _fiscalDocRepository; // Repositorio genérico para guardar el CAE

        public SaleService(
            ISaleRepository saleRepository,
            ISaleDetailRepository saleDetailRepository,
            IProductRepository productRepository,
            ISessionRepository sessionRepository,
            IUserSessionService userSessionService,
            IPaymentMethodRepository paymentMethodRepository,
            IUnitOfWork unitOfWork,
            IFiscalService fiscalService,
            IRepository<FiscalDocument> fiscalDocRepository)
        {
            _saleRepository = saleRepository;
            _saleDetailRepository = saleDetailRepository;
            _productRepository = productRepository;
            _sessionRepository = sessionRepository;
            _userSessionService = userSessionService;
            _paymentMethodRepository = paymentMethodRepository;
            _unitOfWork = unitOfWork;
            _fiscalService = fiscalService;
            _fiscalDocRepository = fiscalDocRepository;
        }

        public async Task<SaleResultDto> CreateSaleAsync(CreateSaleDto dto)
        {
            DtoValidator.Validate(dto);

            string currentUsername = _userSessionService.Username ?? throw new InvalidOperationException("No hay usuario.");
            var currentSession = await _sessionRepository.GetOpenSessionByUserAsync(currentUsername);
            if (currentSession == null) throw new InvalidOperationException("Caja cerrada.");

            //Método de Pago para calcular recargos/descuentos
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(dto.PaymentMethodId);
            if (paymentMethod == null) throw new InvalidOperationException("Método de pago no válido.");

            var newSale = new Sale
            {
                DateAndTime = DateTime.Now,
                SessionId = currentSession.Id,
                PaymentMethodId = dto.PaymentMethodId,
                SaleDetails = new List<SaleDetail>(),
                Total = 0
            };

            decimal subTotalProductos = 0;

            foreach (var itemDto in dto.Items)
            {
                var product = await _productRepository.GetByCodeAsync(itemDto.ProductCode);

                if (product == null) throw new InvalidOperationException($"El producto '{itemDto.ProductCode}' no existe.");
                if (!product.IsActive) throw new InvalidOperationException($"El producto '{product.Name}' está inactivo.");

                decimal finalPrice = product.SalePrice;

                // Lógica de Precio Abierto (VARIOS)
                if (product.IsOpenPrice && itemDto.UnitPrice.HasValue)
                {
                    finalPrice = itemDto.UnitPrice.Value;
                }

                // Descuento si NO es precio abierto
                if (!product.IsOpenPrice)
                {
                    int nuevoStock = product.Stock - itemDto.Quantity;

                    // Si el nuevo stock es negativo, lo dejamos en 0 (pero vendemos igual)
                    if (nuevoStock < 0) nuevoStock = 0;

                    product.Stock = nuevoStock;
                    product.LastStockUpdate = DateTime.Now;
                    _productRepository.Update(product);
                }

                var detail = new SaleDetail
                {
                    ProductCode = product.Code,
                    ProductName = product.Name,
                    Quantity = itemDto.Quantity,
                    UnitPrice = finalPrice,
                    SubTotal = finalPrice * itemDto.Quantity
                };

                subTotalProductos += detail.SubTotal;
                newSale.SaleDetails.Add(detail);
            }

            //Total = Subtotal * (1 + (Recargo% - Descuento%) / 100)
            decimal factor = 1 + ((paymentMethod.Recharge - paymentMethod.Discount) / 100m);
            newSale.Total = subTotalProductos * factor;

            //Actualizar sesión
            currentSession.Total += newSale.Total;
            _sessionRepository.Update(currentSession);

            await _saleRepository.AddAsync(newSale);
            await _unitOfWork.SaveChangesAsync();

            FiscalDocument? fiscalDoc = null;

            //LÓGICA FISCAL
            if (dto.IsFiscal)
            {
                try
                {
                    // Llamada a AFIP
                    fiscalDoc = await _fiscalService.GenerateInvoiceAsync(newSale);

                    // --- VALIDACIÓN DE NULIDAD ---
                    if (fiscalDoc == null)
                    {
                        throw new Exception("El servicio de AFIP no devolvió ningún documento (retornó null).");
                    }
                    // -----------------------------

                    // Vincular con la venta local
                    fiscalDoc.SaleId = newSale.Id;

                    // Guardar el CAE
                    await _fiscalDocRepository.AddAsync(fiscalDoc);
                    await _unitOfWork.SaveChangesAsync();

                    // (Opcional) Capturar datos para devolver en el DTO si querés mostrarlos
                    // cae = fiscalDoc.CAE; 
                }
                catch (Exception ex)
                {
                    // IMPORTANTE: La venta local YA SE HIZO. 
                    // Avisamos al usuario que falló la parte fiscal.
                    throw new Exception($"Venta #{newSale.Id} registrada, pero falló AFIP: {ex.Message}");
                }
            }

            return new SaleResultDto
            {
                SaleId = newSale.Id, // El ID que ya tenías
                FiscalData = fiscalDoc // El objeto con CAE, Nro, etc. (o null)
            };
        }

        public async Task<FiscalDocument?> GetFiscalDocumentBySaleIdAsync(int saleId)
        {
            // Asumiendo que tu repositorio genérico tiene un método para filtrar
            // Si usas EF Core directo o un repositorio genérico estándar:
            var docs = await _fiscalDocRepository.GetAsync(x => x.SaleId == saleId);
            return docs.FirstOrDefault();
        }

        public async Task<IEnumerable<SaleGridDto>> GetHistoryAsync(DateOnly? fromDate = null, DateOnly? toDate = null)
        {
            var sales = await _saleRepository.GetSalesWithDetailsAsync(fromDate, toDate);

            return sales.Select(s => new SaleGridDto
            {
                Id = s.Id,
                Date = s.DateAndTime,
                Total = s.Total,
                PaymentMethod = s.PaymentMethod?.Name ?? "Desconocido",
                ItemCount = s.SaleDetails.Count,
                User = s.Session?.Username ?? "Desconocido"
            });
        }

        public async Task<IEnumerable<SaleDetailViewDto>> GetSaleDetailsAsync(int saleId)
        {
            var details = await _saleDetailRepository.GetAsync(d => d.SaleId == saleId);

            return details.Select(d => new SaleDetailViewDto
            {
                ProductCode = d.ProductCode,
                ProductName = d.ProductName,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice,
                SubTotal = d.SubTotal
            });
        }

        public async Task<IEnumerable<SaleGridDto>> GetSalesBySessionAsync(int sessionId)
        {
            var sales = await _saleRepository.GetSalesBySessionIdAsync(sessionId);
            return MapToGridDto(sales);
        }

        private IEnumerable<SaleGridDto> MapToGridDto(IEnumerable<Sale> sales)
        {
            return sales.Select(s => new SaleGridDto
            {
                Id = s.Id,
                Date = s.DateAndTime,
                Total = s.Total,
                PaymentMethod = s.PaymentMethod?.Name ?? "Desconocido",

                ItemCount = s.SaleDetails.Sum(d => d.Quantity),

                User = s.Session?.Username ?? "Desconocido"
            });
        }

        public async Task<SaleGridDto?> GetSaleHeaderAsync(int saleId)
        {
            var sale = await _saleRepository.GetSaleWithRelationsByIdAsync(saleId);

            if (sale == null) return null;

            return new SaleGridDto
            {
                Id = sale.Id,
                Date = sale.DateAndTime,
                Total = sale.Total,
                PaymentMethod = sale.PaymentMethod?.Name ?? "Desconocido",
                ItemCount = sale.SaleDetails?.Sum(d => d.Quantity) ?? 0,
                User = sale.Session?.Username ?? "Desconocido"
            };
        }
    }
}
