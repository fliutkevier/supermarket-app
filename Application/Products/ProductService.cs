using Application.Products.Dtos;
using Application.Products.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            DtoValidator.Validate(dto);

            var existingProduct = await _productRepository.GetByCodeAsync(dto.Code);
            if (existingProduct != null)
            {
                throw new InvalidOperationException($"El producto con código '{dto.Code}' ya existe.");
            }

            var newProduct = new Product
            {
                Code = dto.Code,
                Name = dto.Name,
                CostPrice = dto.CostPrice,
                SalePrice = dto.SalePrice,
                Stock = dto.InitialStock,
                LastStockUpdate = DateTime.Now,
                IsActive = true
            };

            await _productRepository.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductGridDto>> GetAllForGridAsync()
        {
            var products = await _productRepository.GetAsync(p => p.IsActive == true);

            var productDtos = products.Select(p => new ProductGridDto
            {
                Code = p.Code,
                Name = p.Name,
                SalePrice = p.SalePrice,
                CostPrice = p.CostPrice,
                Stock = p.Stock,
                // Ahora sí mapeamos la propiedad real de la entidad
                LastStockUpdate = p.LastStockUpdate
            });

            return productDtos;
        }

        public async Task<ProductDetailDto?> GetProductForEditAsync(string code)
        {
            var product = await _productRepository.GetByCodeAsync(code);
            if (product == null) return null;

            return new ProductDetailDto
            {
                Code = product.Code,
                Name = product.Name,
                SalePrice = product.SalePrice,
                CostPrice = product.CostPrice,
                Stock = product.Stock,
                IsActive = product.IsActive
            };
        }

        public async Task SoftDeleteProductAsync(string code)
        {
            var product = await _productRepository.GetByCodeAsync(code);

            if (product == null)
            {
                throw new InvalidOperationException($"No se encontró el producto con código '{code}'.");
            }

            product.IsActive = false;

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            DtoValidator.Validate(dto);

            var product = await _productRepository.GetByCodeAsync(dto.Code);

            if (product == null)
            {
                throw new InvalidOperationException($"No se encontró el producto con código '{dto.Code}'.");
            }

            product.Name = dto.Name;
            product.SalePrice = dto.SalePrice;
            product.CostPrice = dto.CostPrice;
            product.Stock = dto.Stock;

            product.IsActive = dto.IsActive;
            
            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
