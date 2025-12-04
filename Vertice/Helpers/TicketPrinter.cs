using Domain.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinForms.Helpers
{
    public class TicketPrinter
    {
        private readonly string _shopName = "VERTICE PROYECTOS SA";
        private readonly string _shopAddress = "Eva Perón 4676";
        private readonly string _shopPhone = "Tel: (011) 6855-8679";
        private readonly string _shopCuit = "30719138825";
        private readonly string _empresaCondicionIva = "IVA RESPONSABLE INSCRIPTO";
        private readonly string _shopLocality = "(1650) Billinghurst, Buenos Aires";
        private readonly string _ingBrutos = "Ing. Brutos: 2023528";
        private readonly string _inicioAct = "Inicio de Act.: 16/09/2025";

        private const int PaperWidth = 270;
        private const int ContentMargin = 2;
        private const int ContentWidth = PaperWidth - (ContentMargin * 2);

        public void PrintTicket(int saleNumber, DateTime date, List<TicketItem> items, decimal total, string paymentMethod, decimal paysWith, decimal change, string nombreImpresora = null)
        {
            PrintDocument pd = CreatePrintDocument(nombreImpresora);
            pd.PrintPage += (sender, e) => ConfigurarPaginaNoFiscal(e, saleNumber, date, items, total, paymentMethod, paysWith, change);
            Print(pd);
        }

        private void ConfigurarPaginaNoFiscal(PrintPageEventArgs e, int saleNumber, DateTime date, List<TicketItem> items, decimal total, string paymentMethod, decimal paysWith, decimal change)
        {
            Graphics g = e.Graphics;
            SetupGraphics(g);

            // Fuentes
            Font fontTitle = new Font("Arial", 11, FontStyle.Bold);
            Font fontSubtitle = new Font("Arial", 10, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 8, FontStyle.Regular);
            Font fontBold = new Font("Arial", 8, FontStyle.Bold);
            Font fontTotal = new Font("Arial", 12, FontStyle.Bold);
            Font fontSmall = new Font("Arial", 7, FontStyle.Regular); // Para detalles chicos

            Brush brush = Brushes.Black;
            float y = 10;

            // Helpers
            Action<string, Font> drawCenter = (txt, fnt) => DrawCentered(g, txt, fnt, brush, ref y);
            Action<string, string, Font> drawDual = (l, r, fnt) => DrawDual(g, l, r, fnt, brush, ContentMargin, ContentWidth, ref y);
            Action drawLine = () => drawCenter(new string('-', 55), fontRegular);

            // 1. CABECERA LIMPIA
            drawCenter("Almacén lo de Ali", fontTitle);
            drawCenter(_shopAddress, fontRegular);
            drawCenter(_shopLocality, fontRegular);
            drawCenter(_shopPhone, fontRegular);
            drawLine();

            // 2. DATOS VENTA
            // Ya no ponemos "TICKET NO FISCAL" aquí arriba para que se vea más limpio
            drawDual($"Venta #: {saleNumber}", $"{date:dd/MM/yyyy}", fontBold);
            drawDual("", $"{date:HH:mm}", fontRegular);
            drawLine();

            // 3. ITEMS
            DrawItemsHeader(g, fontBold, brush, ref y);
            foreach (var item in items)
            {
                DrawItemRow(g, item, fontRegular, brush, ref y);
            }
            drawLine();

            // 4. TOTALES
            drawDual("TOTAL", total.ToString("C2"), fontTotal);
            y += 10;

            if (!string.IsNullOrEmpty(paymentMethod))
            {
                drawDual("Forma de Pago:", paymentMethod.ToUpper(), fontBold);
                if (paysWith > 0)
                {
                    drawDual("Su Pago:", paysWith.ToString("C2"), fontRegular);
                    drawDual("Su Vuelto:", change.ToString("C2"), fontRegular);
                }
            }

            y += 20;
            drawCenter("¡GRACIAS POR SU COMPRA!", fontBold);

            // 5. LEYENDA NO FISCAL (AL FINAL Y CHIQUITO)
            y += 5; // Espacio extra
            drawCenter("Ticket no válido como factura", new Font("Arial", 7, FontStyle.Italic));
        }


        public void ImprimirFactura(AfipQR datosQr, FiscalDocument datosFiscalesBD, string nombreCliente, string docCliente, List<TicketItem> items, DateTime fechaVenta, string nombreImpresora = null)
        {
            PrintDocument pd = CreatePrintDocument(nombreImpresora);
            pd.PrintPage += (sender, e) => ConfigurarPaginaFiscal(e, datosQr, datosFiscalesBD, nombreCliente, docCliente, items, fechaVenta);
            Print(pd);
        }

        private void ConfigurarPaginaFiscal(PrintPageEventArgs e, AfipQR datosQr, FiscalDocument datosFiscalesBD, string nombreCliente, string docCliente, List<TicketItem> items, DateTime fechaVenta)
        {
            Graphics g = e.Graphics;
            SetupGraphics(g);

            // Fuentes 80mm
            Font fontTitle = new Font("Arial", 11, FontStyle.Bold);
            Font fontFactura = new Font("Arial", 12, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 9, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 8, FontStyle.Regular);
            Font fontBold = new Font("Arial", 8, FontStyle.Bold);
            Font fontTotal = new Font("Arial", 14, FontStyle.Bold);
            Font fontAfip = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);

            Brush brush = Brushes.Black;
            float y = 10;
            float left = ContentMargin;

            // Helpers
            Action<string, Font> drawCenter = (txt, fnt) => DrawCentered(g, txt, fnt, brush, ref y);
            Action<string, string, Font> drawDual = (l, r, fnt) => DrawDual(g, l, r, fnt, brush, ContentMargin, ContentWidth, ref y);
            Action drawLine = () => drawCenter(new string('-', 55), fontRegular);

            // 1. CABECERA
            drawCenter(_shopName, fontTitle);
            drawCenter(_shopAddress, fontRegular);
            drawCenter(_shopLocality, fontRegular);
            drawCenter(_shopPhone, fontRegular);
            drawCenter(_empresaCondicionIva, fontBold);
            drawLine();

            // 2. DATOS COMPROBANTE
            string letra = datosFiscalesBD.InvoiceType == 1 ? "A" : "B";
            string codCmp = datosFiscalesBD.InvoiceType.ToString("D3");
            drawCenter($"FACTURA {letra}  (Cód. {codCmp})", fontFactura);

            drawDual($"P.V.: {datosQr.ptoVta:D5}", $"Nro. T.: {datosQr.nroCmp:D8}", fontHeader);

            drawDual($"Fecha: {fechaVenta:dd/MM/yyyy}", $"Hora: {fechaVenta:HH:mm:ss}", fontRegular);

            g.DrawString($"CUIT: {datosQr.cuit}", fontRegular, brush, left, y); y += 14;
            g.DrawString(_ingBrutos, fontRegular, brush, left, y); y += 14;
            g.DrawString(_inicioAct, fontRegular, brush, left, y); y += 18;
            drawLine();

            // 3. CLIENTE (Estilo "A CONSUMIDOR FINAL" destacado)
            // Dibujamos una "caja" visual simple con espaciado
            y += 2;
            g.DrawString("A CONSUMIDOR FINAL", fontBold, brush, left, y);
            y += 18;

            // Si hay datos específicos (Factura A o cliente identificado), los mostramos abajo
            if (datosQr.tipoDocRec != 99 && datosQr.tipoDocRec != 0)
            {
                string tipo = datosQr.tipoDocRec == 80 ? "CUIT" : "DNI";
                g.DrawString($"{tipo}: {docCliente}", fontRegular, brush, left, y);
                y += 14;
                g.DrawString($"Cliente: {nombreCliente}", fontRegular, brush, left, y);
                y += 14;
            }
            else
            {
                // Si es consumidor final, dejamos espacio limpio o ponemos "Sin identificar" si prefieres
            }

            //string condIva = datosFiscalesBD.InvoiceType == 1 ? "Resp. Inscripto" : "Consumidor Final";
            //g.DrawString($"Cond. IVA: {condIva}", fontRegular, brush, left, y); y += 18;

            drawLine();

            // 4. ITEMS
            DrawItemsHeader(g, fontBold, brush, ref y);
            foreach (var item in items)
            {
                DrawItemRow(g, item, fontRegular, brush, ref y);
            }
            drawLine();

            // 5. TOTALES
            if (datosFiscalesBD.InvoiceType == 1) // A
            {
                decimal neto = datosQr.importe / 1.21m;
                decimal iva = datosQr.importe - neto;
                drawDual("Neto Gravado:", neto.ToString("N2"), fontRegular);
                drawDual("IVA 21%:", iva.ToString("N2"), fontRegular);
            }

            y += 5;
            drawDual("TOTAL", datosQr.importe.ToString("C2"), fontTotal);
            y += 5;

            // 6. PIE FISCAL (Lado a Lado para 80mm)
            /*float qrSize = 95;
            Bitmap qrImg = GenerarImagenQrAfip(datosQr);
            g.DrawImage(qrImg, left + 5, y, qrSize, qrSize);

            float textX = left + qrSize + 15; // A la derecha del QR
            float textY = y + 5;

            g.DrawString("AFIP", fontAfip, Brushes.Gray, textX, textY); textY += 25;
            g.DrawString("Comprobante Autorizado", fontBold, brush, textX, textY); textY += 20;

            g.DrawString($"CAE: {datosFiscalesBD.CAE}", fontRegular, brush, textX, textY); textY += 14;
            g.DrawString($"Vto. CAE: {datosFiscalesBD.CAEExpirationDate:dd/MM/yyyy}", fontRegular, brush, textX, textY);

            y += qrSize + 15;
            drawCenter("GRACIAS POR SU COMPRA", fontBold);*/
            drawLine();

            // 1. Textos AFIP Centrados
            drawCenter("AFIP", fontAfip);
            drawCenter("Comprobante Autorizado", fontBold);

            // Datos CAE un poco más grandes y claros
            drawCenter($"CAE: {datosFiscalesBD.CAE}", fontBold);
            drawCenter($"Vto. CAE: {datosFiscalesBD.CAEExpirationDate:dd/MM/yyyy}", fontBold);

            y += 10; // Espacio antes del QR

            // 2. QR GRANDE Y CENTRADO
            // Tamaño: 180px (aprox 60% del ancho del papel, muy legible)
            float qrSize = 180;
            Bitmap qrImg = GenerarImagenQrAfip(datosQr);
            float qrX = (PaperWidth - qrSize) / 2;

            g.DrawImage(qrImg, qrX, y, qrSize, qrSize);
            y += qrSize + 15;

            drawCenter("GRACIAS POR SU COMPRA", fontBold);
            y += 20;
        }

        private void DrawItemsHeader(Graphics g, Font font, Brush brush, ref float y)
        {
            g.DrawString("Cnt", font, brush, ContentMargin, y);
            g.DrawString("Descripción", font, brush, ContentMargin + 30, y);
            
            float wP = g.MeasureString("P.Unit", font).Width;
            g.DrawString("P.Unit", font, brush, ContentWidth - 60 - wP, y); 
            
            float wT = g.MeasureString("Total", font).Width;
            g.DrawString("Total", font, brush, ContentWidth - wT, y); // Pegado a la derecha del ContentWidth (270)
            y += 14;
        }

        private void DrawItemRow(Graphics g, TicketItem item, Font font, Brush brush, ref float y)
        {
            g.DrawString(item.Quantity.ToString(), font, brush, ContentMargin, y);

            decimal pUnit = item.Quantity > 0 ? item.Subtotal / item.Quantity : 0;
            string pUnitStr = pUnit.ToString("N2");
            float wUnit = g.MeasureString(pUnitStr, font).Width;
            g.DrawString(pUnitStr, font, brush, ContentWidth - 60 - wUnit, y);

            string totalStr = item.Subtotal.ToString("N2");
            float wTotal = g.MeasureString(totalStr, font).Width;
            g.DrawString(totalStr, font, brush, ContentWidth - wTotal, y);

            string desc = item.ProductName;
            // Espacio: Total - MargenIzq - PrecioUnit - Total - Margen
            float maxDescWidth = ContentWidth - 30 - 65 - 55;
            if (g.MeasureString(desc, font).Width > maxDescWidth)
            {
                int maxChars = 18;
                if (desc.Length > maxChars) desc = desc.Substring(0, maxChars) + "..";
            }
            g.DrawString(desc, font, brush, ContentMargin + 30, y);
            y += 12;
        }

        private PrintDocument CreatePrintDocument(string nombreImpresora)
        {
            PrintDocument pd = new PrintDocument();
            pd.OriginAtMargins = false;
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            // 300 width = ~80mm
            pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket80mm", PaperWidth, 10000);
            pd.PrintController = new StandardPrintController();

            if (!string.IsNullOrEmpty(nombreImpresora))
            {
                pd.PrinterSettings.PrinterName = nombreImpresora;
                if (!pd.PrinterSettings.IsValid) throw new Exception($"No se encuentra la impresora: '{nombreImpresora}'.");
            }
            return pd;
        }

        private void DrawCentered(Graphics g, string text, Font font, Brush brush, ref float y)
        {
            float w = g.MeasureString(text, font).Width;
            // Centrado matemático exacto en el ancho útil
            float x = (ContentWidth - w) / 2 + ContentMargin;
            if (x < ContentMargin) x = ContentMargin;
            g.DrawString(text, font, brush, x, y);
            y += font.Height + 1;
        }

        private void DrawDual(Graphics g, string l, string r, Font font, Brush brush, float left, float right, ref float y)
        {
            // left y right son los bordes definidos (ContentMargin y ContentMargin+ContentWidth)
            g.DrawString(l, font, brush, left, y);
            float wR = g.MeasureString(r, font).Width;
            g.DrawString(r, font, brush, right - wR, y); // Alineado al borde derecho
            y += font.Height + 1;
        }

        private void SetupGraphics(Graphics g)
        {
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
        }

        private void Print(PrintDocument pd)
        {
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimiendo: " + ex.Message);
            }
        }

        // Método de generación de QR (Igual que antes)
        private Bitmap GenerarImagenQrAfip(AfipQR datos)
        {
            string jsonString = JsonSerializer.Serialize(datos);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
            string base64Json = Convert.ToBase64String(bytes);
            string urlFinal = $"https://www.afip.gob.ar/fe/qr/?p={base64Json}";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                // ECCLevel.M es suficiente para este tamaño y suele ser más fácil de leer
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlFinal, QRCodeGenerator.ECCLevel.M);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    return qrCode.GetGraphic(2);
                }
            }
        }

    }


    public class TicketItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
