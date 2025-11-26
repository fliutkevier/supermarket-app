using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FiscalDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; }


        //AFIP DATA
        public int PointOfSale { get; set; } // Punto de Venta (ej: 1)
        public int InvoiceType { get; set; } //(1=A, 6=B, etc.)
        public long InvoiceNumber { get; set; } // Número (ej: 12345)

        public string CAE { get; set; } = string.Empty;
        public DateTime CAEExpirationDate { get; set; }

        // Datos del cliente fiscal (si aplica)
        public string? CustomerDocType { get; set; } // 80=CUIT, 96=DNI
        public string? CustomerDocNumber { get; set; }
    }
}
