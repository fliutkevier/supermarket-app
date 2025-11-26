using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Dtos
{
    public class SaleGridDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Total { get; set; }
        public int ItemCount { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
