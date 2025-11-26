using Application.Sales.Dtos;
using Application.Sales.Interfaces;
using Domain.Entities;
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

namespace WinForms.PopUps
{
    public partial class FormSaleDetail : Form
    {
        private readonly ISaleService _saleService;
        private int _saleId;

        // Para Imprimir
        private SaleGridDto? _saleHeader;
        private List<SaleDetailViewDto>? _saleDetails;

        public FormSaleDetail(ISaleService saleService)
        {
            InitializeComponent();
            _saleService = saleService;
        }

        private void FormSaleDetail_Load(object sender, EventArgs e)
        {

        }

        public async void LoadData(int saleId)
        {
            _saleId = saleId;
            lblTitle.Text = $"Detalle de Venta #{_saleId}";

            try
            {
                _saleHeader = await _saleService.GetSaleHeaderAsync(_saleId);

                var saleDeatils = await _saleService.GetSaleDetailsAsync(_saleId);
                _saleDetails = saleDeatils.ToList();

                if (_saleHeader == null)
                {
                    MessageBox.Show("No se encontró la venta.");
                    this.Close();
                    return;
                }

                
                lblSaleNumber.Text = $"Nro Venta\n#{_saleHeader.Id}";
                lblSaleDate.Text = $"Fecha\n{_saleHeader.Date.ToString("dd/MM/yyyy HH:mm")}";
                lblSaleUser.Text = $"Usuario\n{_saleHeader.User}";
                lblPaymentMethod.Text = $"Método\n{_saleHeader.PaymentMethod}";
                lblTotal.Text = $"Total\n{_saleHeader.Total.ToString("C2")}";


                //Configurar y Llenar Grilla
                dgvProducts.DataSource = _saleDetails;
                ConfigGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles: " + ex.Message);
                this.Close();
            }
        }

        private void ConfigGrid()
        {
            dgvProducts.AutoGenerateColumns = true;

            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;

            if (dgvProducts.Columns["ProductCode"] != null)
            {
                dgvProducts.Columns["ProductCode"].HeaderText = "Cód.";
            }

            if (dgvProducts.Columns["ProductName"] != null)
            {
                dgvProducts.Columns["ProductName"].HeaderText = "Producto";
            }

            if (dgvProducts.Columns["Quantity"] != null)
            {
                dgvProducts.Columns["Quantity"].HeaderText = "Cant.";
            }

            if (dgvProducts.Columns["UnitPrice"] != null)
            {
                dgvProducts.Columns["UnitPrice"].HeaderText = "Precio Unit.";
                dgvProducts.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
            }

            if (dgvProducts.Columns["SubTotal"] != null)
            {
                dgvProducts.Columns["SubTotal"].HeaderText = "Subtotal";
                dgvProducts.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            if (_saleHeader == null || _saleDetails == null) return;

            try
            {
                var ticketItems = _saleDetails.Select(d => new TicketItem
                {
                    ProductName = d.ProductName,
                    Quantity = d.Quantity,
                    Subtotal = d.SubTotal
                }).ToList();

                var printer = new TicketPrinter();

                decimal total = _saleHeader.Total;
                decimal cash = 0;

                printer.PrintTicket(
                    _saleHeader.Id,
                    _saleHeader.Date,
                    ticketItems,
                    _saleHeader.Total,
                    _saleHeader.PaymentMethod,
                    total,
                    cash
                );

                MessageBox.Show("Ticket enviado a la impresora.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reimprimir: " + ex.Message);
            }
        }
    }
}
