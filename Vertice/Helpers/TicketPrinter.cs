using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Helpers
{
    public class TicketPrinter
    {
        private readonly string _shopName = "VERTICE";
        private readonly string _shopAddress = "Suipacha";
        private readonly string _shopPhone = "1133445566";
        private readonly string _shopCuit = "20-12345678-9";

        private List<TicketItem> _items;
        private decimal _total;
        private string _paymentMethod;
        private decimal _paysWith;
        private decimal _change;
        private int _saleNumber;
        private DateTime _date;

        public void PrintTicket(int saleNumber, DateTime date, List<TicketItem> items, decimal total, string paymentMethod, decimal paysWith, decimal change)
        {
            _saleNumber = saleNumber;
            _date = date;
            _items = items;
            _total = total;
            _paymentMethod = paymentMethod;
            _paysWith = paysWith;
            _change = change;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            // Configuración de papel (Ancho 80mm aprox 300px)
            // El largo se ajusta solo
            pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", 280, 5000);

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir ticket: " + ex.Message);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // FONTS
            Font fontTitle = new Font("Courier New", 12, FontStyle.Bold);
            Font fontHeader = new Font("Courier New", 9, FontStyle.Bold);
            Font fontBody = new Font("Courier New", 8, FontStyle.Regular);
            Font fontBold = new Font("Courier New", 8, FontStyle.Bold);

            Brush brush = Brushes.Black;

            float y = 10;
            float leftMargin = 5;
            float rightMargin = 270;

            // HELPERS

            Action<string, Font, float> drawCentered = (text, font, yPos) =>
            {
                SizeF size = g.MeasureString(text, font);
                float xPos = (280 - size.Width) / 2;
                g.DrawString(text, font, brush, xPos, yPos);
            };

            Action<string, string, Font, float> drawLeftRight = (lText, rText, font, yPos) =>
            {
                g.DrawString(lText, font, brush, leftMargin, yPos);
                float rWidth = g.MeasureString(rText, font).Width;
                g.DrawString(rText, font, brush, rightMargin - rWidth, yPos);
            };

            Action<float> drawLine = (yPos) =>
            {
                g.DrawLine(new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, leftMargin, yPos, rightMargin, yPos);
            };

            // HEADER

            drawCentered(_shopName, fontTitle, y); y += 20;
            drawCentered(_shopAddress, fontBold, y); y += 15;
            drawCentered($"Tel: {_shopPhone}", fontBold, y); y += 15;
            drawCentered($"CUIT: {_shopCuit}", fontBold, y); y += 15;

            drawLine(y); y += 5;

            // DATA

            g.DrawString($"TICKET #{_saleNumber}", fontHeader, brush, leftMargin, y); y += 15;
            g.DrawString($"{_date:dd/MM/yyyy HH:mm}", fontBody, brush, leftMargin, y); y += 15;

            drawLine(y); y += 5;

            // ITEMS

            foreach (var item in _items)
            {
                string nombre = item.ProductName;
                if (nombre.Length > 20) nombre = nombre.Substring(0, 20) + "..";

                string subtotalStr = $"$ {item.Subtotal:N2}";

                drawLeftRight(nombre, subtotalStr, fontBody, y);
                y += 15;

                decimal unitPrice = item.Quantity > 0 ? item.Subtotal / item.Quantity : 0;

                string detalleCant = $"x{item.Quantity} Unid. ($ {unitPrice:N2})";
                g.DrawString(detalleCant, fontBody, brush, leftMargin + 10, y);

                y += 15;
            }

            drawLine(y); y += 5;

            // TOTALES

            drawCentered("Formas de pago", fontBody, y); y += 15;

            // Método de pago
            drawLeftRight(_paymentMethod.ToUpper() + ":", $"$ {_total:N2}", fontBold, y); y += 15;

            // CAMBIO: pago y vuelto
            if (_paysWith > 0 && _change >= 0)
            {
                drawLeftRight("Su Pago:", $"$ {_paysWith:N2}", fontBody, y); y += 15;
                drawLeftRight("Su Vuelto:", $"$ {_change:N2}", fontBody, y); y += 15;
            }
            // -------------------------------------------------

            drawLine(y); y += 5;

            // TOTAL
            drawLeftRight("TOTAL:", $"$ {_total:N2}", fontTitle, y); y += 25;

            // FOOTER

            drawCentered("¡Gracias por su compra!", fontBody, y); y += 15;

            drawLine(y); y += 5;
            drawCentered("Ticket no válido como factura", fontBody, y);
        }
    }

    public class TicketItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
