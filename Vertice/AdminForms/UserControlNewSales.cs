using Application.PaymentMethods.Dtos;
using Application.PaymentMethods.Interfaces;
using Application.Products.Interfaces;
using Application.Sales.Dtos;
using Application.Sales.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Helpers;
using WinForms.PopUps;

namespace WinForms
{
    public partial class UserControlNewSales : UserControl
    {
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _config;
        private readonly TicketPrinter _ticketPrinter;

        private BindingList<SaleItemViewModel> _cartItems;
        private List<PaymentMethodGridDto> _paymentMethods = new List<PaymentMethodGridDto>();

        private int? _lastSaleId = null;
        private decimal _currentTotal = 0;
        private const string CODIGO_VARIOS = "VARIOS";

        public UserControlNewSales(
            ISaleService saleService,
            IProductService productService,
            IPaymentMethodService paymentMethodService,
            IServiceProvider serviceProvider,
            IConfiguration config,
            TicketPrinter ticketPrinter)
        {
            InitializeComponent();
            _saleService = saleService;
            _productService = productService;
            _paymentMethodService = paymentMethodService;
            _serviceProvider = serviceProvider;
            _config = config;
            _ticketPrinter = ticketPrinter;

            _cartItems = new BindingList<SaleItemViewModel>();
        }

        private async void UserControlNewSales_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSaleProducts.DataSource = _cartItems;

                ConfigGrid();

                await LoadPaymentMethods();

                txtProduct.Focus();
                UpdateCalcs();
                if (lblLastProduct != null) lblLastProduct.Text = "Listo para vender...";

                CheckPaymentMethodVisibility();

                if (btnShowLastSale != null) btnShowLastSale.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar pantalla de ventas: " + ex.Message);
            }
        }

        private async Task LoadPaymentMethods()
        {
            var methods = await _paymentMethodService.GetAllForGridAsync();
            _paymentMethods = methods.ToList();

            cbxPaymentMethod.DataSource = _paymentMethods;
            cbxPaymentMethod.DisplayMember = "Name";
            cbxPaymentMethod.ValueMember = "Id";

            var efectivo = _paymentMethods.FirstOrDefault(m => m.Name.Trim().Equals("Efectivo", StringComparison.OrdinalIgnoreCase));

            if (efectivo != null)
            {
                cbxPaymentMethod.SelectedValue = efectivo.Id;
            }
            else if (_paymentMethods.Count > 0)
            {
                // Si no hay efectivo, seleccionamos el primero de la lista
                cbxPaymentMethod.SelectedIndex = 0;
            }
        }

        private async void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string input = txtProduct.Text.Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    string code = input;
                    int quantity = 1;

                    //Si el usuario escribió "CANTIDAD * CODIGO" (ej: 6*7791234)
                    if (input.Contains("*"))
                    {
                        var parts = input.Split('*');
                        if (parts.Length == 2 && int.TryParse(parts[0], out int parsedQty))
                        {
                            quantity = parsedQty;
                            code = parts[1].Trim();
                        }
                    }

                    if (quantity > 0 && !string.IsNullOrEmpty(code))
                    {
                        await AddProducts(code, quantity);
                        txtProduct.Text = "";
                        txtProduct.Focus();
                    }
                }
            }
        }

        private async Task AddProducts(string code, int quantityToAdd)
        {
            try
            {
                var product = await _productService.GetProductForEditAsync(code);

                if (product == null)
                {
                    MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!product.IsActive)
                {
                    MessageBox.Show($"El producto '{product.Name}' está inactivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Validación de Stock Acumulado
                var existingItem = _cartItems.FirstOrDefault(x => x.ProductCode == product.Code);
                int currentQtyInCart = existingItem?.Quantity ?? 0;

                //Lo que ya tengo en carrito + Lo que quiero agregar
                bool faltaStock = false;
                if (product.Code != CODIGO_VARIOS)
                {
                    if (currentQtyInCart + quantityToAdd > product.Stock)
                    {
                        faltaStock = true;
                    }
                }

                // Pregunta de Seguridad
                if (faltaStock)
                {
                    var result = MessageBox.Show(
                        $"Stock insuficiente para '{product.Name}'.\n" +
                        $"Stock Real: {product.Stock}\n" +
                        $"En Carrito: {currentQtyInCart}\n" +
                        $"Intentando agregar: {quantityToAdd}\n\n" +
                        "¿Desea venderlo de todas formas? (El stock quedará en 0)",
                        "Falta de Stock",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No) return;
                }

                //Agregar o Actualizar
                if (existingItem != null)
                {
                    existingItem.Quantity += quantityToAdd;
                    _cartItems.ResetItem(_cartItems.IndexOf(existingItem));
                }
                else
                {
                    _cartItems.Add(new SaleItemViewModel
                    {
                        ProductCode = product.Code,
                        ProductName = product.Name,
                        UnitPrice = product.SalePrice,
                        Quantity = quantityToAdd
                    });
                }

                if (lblLastProduct != null)
                {
                    string lastProduct = $"{product.Name} (x{quantityToAdd})".ToUpper();
                    lblLastProduct.Text = lastProduct;
                    //lblLastProduct.ForeColor = System.Drawing.Color.Green;
                    lblLastProduct.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
                }

                UpdateCalcs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto: " + ex.Message);
            }
        }

        private void UpdateCalcs()
        {
            decimal subtotal = _cartItems.Sum(x => x.Subtotal);

            if (lblSubTotal != null) lblSubTotal.Text = $"SUBTOTAL\n {subtotal.ToString("C2")}";

            decimal totalFinal = subtotal;

            if (cbxPaymentMethod.SelectedItem is PaymentMethodGridDto metodo)
            {
                decimal factor = 1 + ((metodo.Recharge - metodo.Discount) / 100m);
                totalFinal = subtotal * factor;
                /*
                if (lblRecargoDescuento != null)
                {
                    if (metodo.Recharge > 0)
                        lblRecargoDescuento.Text = $"Recargo: {metodo.Recharge}%";
                    else if (metodo.Discount > 0)
                        lblRecargoDescuento.Text = $"Descuento: {metodo.Discount}%";
                    else
                        lblRecargoDescuento.Text = "-";
                }*/
            }

            _currentTotal = totalFinal;

            lblTotal.Text = $"TOTAL A PAGAR\n {totalFinal.ToString("C2")}";
            GetChange(totalFinal);
        }

        private void GetChange(decimal total)
        {
            if (txtCash == null || lblChange == null || !txtCash.Visible) return;

            string cashText = txtCash.Text.Replace("$", "").Trim();

            if (decimal.TryParse(cashText, out decimal cash))
            {
                decimal change = cash - total;

                if (cash >= total)
                {
                    lblChange.Text = $"VUELTO\n$ {change.ToString("N2")}";
                    lblChange.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
                }
                else
                {
                    lblChange.Text = $"NO ALCANZA";
                    lblChange.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
                }
            }
            else
            {
                lblChange.Text = $"VUELTO\n$ 0.00";
                lblChange.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            }
        }

        private async void btnSaleTicket_Click(object sender, EventArgs e)
        {
            await MakeSale(true, false);
        }

        private void PrintLocalTicket(string medioPago, decimal total, decimal pagaCon)
        {
            var itemsTicket = _cartItems.Select(x => new TicketItem
            {
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal
            }).ToList();

            string nombreImpresora = _config["AfipSdk:PrinterName"] ?? "Microsoft Print to PDF";
            _ticketPrinter.PrintTicket(0, DateTime.Now, itemsTicket, total, medioPago, pagaCon, pagaCon - total, nombreImpresora);
        }

        private void ConfigGrid()
        {
            dgvSaleProducts.AllowUserToAddRows = false;
            dgvSaleProducts.AllowUserToDeleteRows = false;
            dgvSaleProducts.RowHeadersVisible = false;
            dgvSaleProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleProducts.ReadOnly = true;

            if (dgvSaleProducts.Columns["ProductCode"] != null)
            {
                dgvSaleProducts.Columns["ProductCode"].HeaderText = "Cód.";
                dgvSaleProducts.Columns["ProductCode"].Width = 80;
            }

            if (dgvSaleProducts.Columns["ProductName"] != null)
            {
                dgvSaleProducts.Columns["ProductName"].HeaderText = "Producto";
                dgvSaleProducts.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvSaleProducts.Columns["UnitPrice"] != null)
            {
                dgvSaleProducts.Columns["UnitPrice"].HeaderText = "Precio";
                dgvSaleProducts.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                dgvSaleProducts.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSaleProducts.Columns["UnitPrice"].Width = 100;
            }

            if (dgvSaleProducts.Columns["Quantity"] != null)
            {
                dgvSaleProducts.Columns["Quantity"].HeaderText = "Cant.";
                dgvSaleProducts.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSaleProducts.Columns["Quantity"].Width = 60;
            }

            if (dgvSaleProducts.Columns["Subtotal"] != null)
            {
                dgvSaleProducts.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvSaleProducts.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                dgvSaleProducts.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSaleProducts.Columns["Subtotal"].Width = 100;
            }

            dgvSaleProducts.RowHeadersVisible = false;
            dgvSaleProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleProducts.ReadOnly = true;
        }

        private void dgvSaleProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) DeleteSelected();
        }

        private void DeleteSelected()
        {
            if (dgvSaleProducts.CurrentRow?.DataBoundItem is SaleItemViewModel item)
            {
                _cartItems.Remove(item);
                UpdateCalcs();
                txtProduct.Focus();
            }
        }

        private async void btnOnlySale_Click(object sender, EventArgs e)
        {
            await MakeSale(false, false);
        }

        private void cbxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPaymentMethodVisibility();
            UpdateCalcs();
        }

        private void CheckPaymentMethodVisibility()
        {
            if (cbxPaymentMethod.SelectedItem is PaymentMethodGridDto method)
            {
                bool isCash = method.Name.Trim().Equals("Efectivo", StringComparison.OrdinalIgnoreCase);

                if (txtCash != null)
                {
                    txtCash.Visible = isCash;
                    if (!isCash) txtCash.Text = "";
                }

                if (lblChange != null) lblChange.Visible = isCash;
            }
        }

        private async Task MakeSale(bool ticket, bool isFiscal)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("No hay productos leídos.");
                txtProduct.Focus();
                return;
            }

            if (cbxPaymentMethod.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            btnSaleTicket.Enabled = false;
            if (btnOnlySale != null) btnOnlySale.Enabled = false;
            if (btnSale != null) btnSale.Enabled = false;
            if (btnSaleAFIP != null) btnSaleAFIP.Enabled = false;

            try
            {
                var paymentMethod = (PaymentMethodGridDto)cbxPaymentMethod.SelectedItem;

                var saleDto = new CreateSaleDto
                {
                    PaymentMethodId = paymentMethod.Id,
                    Items = _cartItems.Select(x => new SaleDetailDto
                    {
                        ProductCode = x.ProductCode,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice
                    }).ToList(),
                    IsFiscal = isFiscal
                };

                SaleResultDto result = await _saleService.CreateSaleAsync(saleDto);

                _lastSaleId = result.SaleId;
                if (btnShowLastSale != null) btnShowLastSale.Enabled = true;
                decimal totalImpresion = _currentTotal;

                decimal paysWith = 0;
                if (txtCash.Visible)
                    decimal.TryParse(txtCash.Text.Replace("$", "").Trim(), out paysWith);

                // Print
                if (ticket)
                {
                    if (isFiscal && result.FiscalData != null)
                    {
                        long cuitEmisor = long.Parse(_config["AfipSdk:Cuit"]);

                        var datosQr = new AfipQR
                        {
                            fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                            cuit = cuitEmisor,
                            ptoVta = result.FiscalData.PointOfSale, //
                            tipoCmp = result.FiscalData.InvoiceType, //
                            nroCmp = (int)result.FiscalData.InvoiceNumber, //
                            importe = _currentTotal, // Importe total de la venta
                            moneda = "PES",
                            ctz = 1,
                            // Si CustomerDocType es nulo (consumidor final sin ident.), usa 99 y doc 0
                            tipoDocRec = int.Parse(result.FiscalData.CustomerDocType ?? "99"),
                            nroDocRec = long.Parse(result.FiscalData.CustomerDocNumber ?? "0"),
                            tipoCodAut = "E",
                            codAut = long.Parse(result.FiscalData.CAE)
                        };

                        // Lista de items para el ticket visual
                        var itemsTicket = _cartItems.Select(x => new TicketItem
                        {
                            ProductName = x.ProductName,
                            Quantity = x.Quantity,
                            Subtotal = x.Subtotal
                        }).ToList();


                        string nombreImpresora = _config["AfipSdk:PrinterName"] ?? "Microsoft Print to PDF";
                        // Imprimimos pasando los datos QR y la lista visual
                        _ticketPrinter.ImprimirFactura(
                            datosQr,
                            result.FiscalData,
                            "CONSUMIDOR FINAL",
                            "0",
                            itemsTicket,
                            DateTime.Now, // <--- Agregar este parámetro
                            nombreImpresora
                        );
                    }
                    else
                    {
                        // Ticket no fiscal
                        PrintLocalTicket(paymentMethod.Name, totalImpresion, paysWith);
                    }
                }

                // Reset UI
                _cartItems.Clear();
                if (txtCash != null) txtCash.Text = "";
                if (lblLastProduct != null) lblLastProduct.Text = "";
                _currentTotal = 0;

                UpdateCalcs();

                string msg = ticket ? "¡Venta registrada e impresa!" : "¡Venta registrada!";
                MessageBox.Show(msg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isFiscal)
                {
                    MessageBox.Show("¡Venta Fiscal Autorizada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                txtProduct.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cobrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSaleTicket.Enabled = true;
                if (btnOnlySale != null) btnOnlySale.Enabled = true;
                if (btnSaleAFIP != null) btnSaleAFIP.Enabled = true;
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            UpdateCalcs();
        }

        private void btnAddVarious_Click(object sender, EventArgs e)
        {
            string txtAmount = txtVariosAmount.Text.Trim();
            if (string.IsNullOrEmpty(txtAmount)) return;

            if (!decimal.TryParse(txtAmount, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a 0.");
                return;
            }

            // Acumular
            var itemVarios = _cartItems.FirstOrDefault(x => x.ProductCode == CODIGO_VARIOS);

            if (itemVarios != null)
            {
                // Si ya existe, acumula
                itemVarios.UnitPrice += amount;
                _cartItems.ResetItem(_cartItems.IndexOf(itemVarios));
            }
            else
            {
                // Si no existe, se crea.
                _cartItems.Add(new SaleItemViewModel
                {
                    ProductCode = CODIGO_VARIOS,
                    ProductName = "Varios/Fiambrería",
                    Quantity = 1,
                    UnitPrice = amount
                });
            }

            UpdateCalcs();
            txtVariosAmount.Text = "";
            txtProduct.Focus();
        }

        private void btnShowLastSale_Click(object sender, EventArgs e)
        {
            if (_lastSaleId.HasValue)
            {
                var formDetalle = _serviceProvider.GetRequiredService<FormSaleDetail>();

                formDetalle.LoadData(_lastSaleId.Value);
                formDetalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay venta reciente en esta sesión de pantalla.");
            }
        }

        private async void btnSaleAFIP_Click(object sender, EventArgs e)
        {
            await MakeSale(true, true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _cartItems.Clear();
            if (txtCash != null) txtCash.Text = "";
            if (lblLastProduct != null) lblLastProduct.Text = "";
            _currentTotal = 0;

            UpdateCalcs();
            txtProduct.Focus();
        }

        private void txtVariosAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAddVarious_Click(sender, e);
            }
        }
    }
}
