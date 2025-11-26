using Application.Providers.Dtos;
using Application.Providers.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Providers
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository repository, IUnitOfWork unitOfWork)
        {
            _providerRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateProviderDto dto)
        {
            DtoValidator.Validate(dto);

            var exists = await _providerRepository.GetByIdAsync(dto.Cuit);
            if (exists != null)
            {
                throw new InvalidOperationException($"Ya existe un proveedor con el CUIT '{dto.Cuit}'.");
            }

            var nameExists = await _providerRepository.GetByNameAsync(dto.Name);
            if (nameExists != null)
            {
                throw new InvalidOperationException($"Ya existe un proveedor con el nombre '{dto.Name}'.");
            }

            var entity = new Provider
            {
                CUIT = dto.Cuit,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                DateAdded = DateTime.Now,
                IsActive = true
            };

            await _providerRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProviderGridDto>> GetAllForGridAsync()
        {
            var providers = await _providerRepository.GetAsync(x => x.IsActive);

            return providers.Select(x => new ProviderGridDto
            {
                Cuit = x.CUIT,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                DateAdded = x.DateAdded
            });
        }

        public async Task<ProviderDetailDto?> GetForEditAsync(string cuit)
        {
            var provider = await _providerRepository.GetByIdAsync(cuit);
            if (provider == null) return null;

            return new ProviderDetailDto
            {
                Cuit = provider.CUIT,
                Name = provider.Name,
                Email = provider.Email,
                Phone = provider.Phone,
                Address = provider.Address,
                DateAdded = provider.DateAdded,
                IsActive = provider.IsActive
            };
        }

        public async Task SoftDeleteAsync(string cuit)
        {
            var provider = await _providerRepository.GetByIdAsync(cuit);
            if (provider == null)
            {
                throw new InvalidOperationException($"No se encontró el proveedor con CUIT {cuit}.");
            }

            provider.IsActive = false;

            _providerRepository.Update(provider);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateProviderDto dto)
        {
            DtoValidator.Validate(dto);

            var provider = await _providerRepository.GetByIdAsync(dto.Cuit);
            if (provider == null)
            {
                throw new InvalidOperationException($"No se encontró el proveedor con CUIT {dto.Cuit}.");
            }

            var nameExists = await _providerRepository.GetByNameAsync(dto.Name);
            if (nameExists != null && nameExists.CUIT != dto.Cuit)
            {
                throw new InvalidOperationException($"Ya existe otro proveedor con el nombre '{dto.Name}'.");
            }

            provider.Name = dto.Name;
            provider.Email = dto.Email;
            provider.Phone = dto.Phone;
            provider.Address = dto.Address;
            provider.IsActive = dto.IsActive;

            _providerRepository.Update(provider);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
