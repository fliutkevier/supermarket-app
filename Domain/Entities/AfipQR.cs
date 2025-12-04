using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AfipQR
    {
        public int ver { get; set; } = 1; // Versión del formato (actualmente 1)
        public string fecha { get; set; } // Formato "yyyy-MM-dd"
        public long cuit { get; set; } // CUIT del Emisor
        public int ptoVta { get; set; } // Punto de Venta
        public int tipoCmp { get; set; } // Tipo de Comprobante (1, 6, 11, etc.)
        public int nroCmp { get; set; } // Número de Comprobante
        public decimal importe { get; set; } // Importe Total
        public string moneda { get; set; } = "PES"; // Código de moneda
        public decimal ctz { get; set; } = 1; // Cotización (1 para pesos)
        public int? tipoDocRec { get; set; } // Tipo doc receptor (80=CUIT, 96=DNI, etc.)
        public long? nroDocRec { get; set; } // Número doc receptor
        public string tipoCodAut { get; set; } = "E"; // "E" para CAE
        public long codAut { get; set; } // El CAE
    }
}
