using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Dtos
{
    public class SaleDetailViewDto
    {
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty; // Nombre histórico
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Precio histórico
        public decimal SubTotal { get; set; }
    }
}
