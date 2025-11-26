using Application.Sales.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Interfaces
{
    public interface ISaleService
    {
        Task<int> CreateSaleAsync(CreateSaleDto dto);

        Task<IEnumerable<SaleGridDto>> GetHistoryAsync(DateOnly? fromDate = null, DateOnly? toDate = null);

        Task<IEnumerable<SaleDetailViewDto>> GetSaleDetailsAsync(int saleId);

        Task<IEnumerable<SaleGridDto>> GetSalesBySessionAsync(int sessionId);

        Task<SaleGridDto?> GetSaleHeaderAsync(int saleId);
    }
}
