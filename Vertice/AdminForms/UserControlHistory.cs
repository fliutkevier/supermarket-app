using Application.Sales.Dtos;
using Application.Sales.Interfaces;
using Application.Sessions.Dtos;
using Application.Sessions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.PopUps;

namespace WinForms
{
    public partial class UserControlHistory : UserControl
    {
        private readonly ISessionService _sessionService;
        private readonly ISaleService _saleService;
        private readonly IServiceProvider _serviceProvider;

        private List<SessionGridDto> _sessionsLoaded = new List<SessionGridDto>();

        public UserControlHistory(
            ISessionService sessionService,
            ISaleService saleService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _sessionService = sessionService;
            _saleService = saleService;
            _serviceProvider = serviceProvider;
        }

        private async void UserControlHistory_Load(object sender, EventArgs e)
        {
            dtpSince.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;


            //todas las sesiones sin filtro.
            await LoadSessions(null, null);
            ConfigSessionsGrid();
        }

        private void ConfigSalesGrid()
        {
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.MultiSelect = false;
            dgvSales.RowHeadersVisible = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvSales.Columns.Count == 0) return;

            if (dgvSales.Columns["Id"] != null)
            {
                dgvSales.Columns["Id"].HeaderText = "Nro. Venta";
            }

            if (dgvSales.Columns["Date"] != null)
            {
                dgvSales.Columns["Date"].HeaderText = "Hora";
                dgvSales.Columns["Date"].DefaultCellStyle.Format = "T"; // Hora larga con segundos
            }

            if (dgvSales.Columns["PaymentMethod"] != null)
            {
                dgvSales.Columns["PaymentMethod"].HeaderText = "Forma de Pago";
            }

            if (dgvSales.Columns["ItemCount"] != null)
            {
                dgvSales.Columns["ItemCount"].HeaderText = "Productos";
                dgvSales.Columns["ItemCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvSales.Columns["Total"] != null)
            {
                dgvSales.Columns["Total"].HeaderText = "Total";
                dgvSales.Columns["Total"].DefaultCellStyle.Format = "C2";
                dgvSales.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // oculto
            if (dgvSales.Columns["User"] != null) dgvSales.Columns["User"].Visible = false;
        }

        private void ConfigSessionsGrid()
        {
            dgvSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSessions.MultiSelect = false;
            dgvSessions.RowHeadersVisible = false;
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Validamos que existan las columnas antes de tocarlas
            if (dgvSessions.Columns.Count == 0) return;

            if (dgvSessions.Columns["Id"] != null)
            {
                dgvSessions.Columns["Id"].HeaderText = "Nro. Caja";
                dgvSessions.Columns["Id"].Width = 80;
            }

            if (dgvSessions.Columns["Date"] != null)
            {
                dgvSessions.Columns["Date"].HeaderText = "Fecha";
            }

            if (dgvSessions.Columns["Username"] != null)
            {
                dgvSessions.Columns["Username"].HeaderText = "Usuario";
            }

            if (dgvSessions.Columns["OpenedAt"] != null)
            {
                dgvSessions.Columns["OpenedAt"].HeaderText = "Apertura";
                dgvSessions.Columns["OpenedAt"].DefaultCellStyle.Format = "t";
            }

            if (dgvSessions.Columns["ClosedAt"] != null)
            {
                dgvSessions.Columns["ClosedAt"].HeaderText = "Cierre";
                dgvSessions.Columns["ClosedAt"].DefaultCellStyle.Format = "t";
                dgvSessions.Columns["ClosedAt"].DefaultCellStyle.NullValue = "- ABIERTA -";
            }

            if (dgvSessions.Columns["Total"] != null)
            {
                dgvSessions.Columns["Total"].HeaderText = "Total Acum.";
                dgvSessions.Columns["Total"].DefaultCellStyle.Format = "C2";
            }

            // Oculto
            if (dgvSessions.Columns["Duration"] != null) dgvSessions.Columns["Duration"].Visible = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var from = DateOnly.FromDateTime(dtpSince.Value);
            var to = DateOnly.FromDateTime(dtpTo.Value);

            await LoadSessions(from, to);
        }

        private async Task LoadSessions(DateOnly? from, DateOnly? to)
        {
            try
            {
                var sesiones = await _sessionService.GetAllForGridAsync(from, to);

                _sessionsLoaded = sesiones.ToList();

                ApplyFilters();

                dgvSales.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        private void ApplyFilters()
        {
            if (_sessionsLoaded == null) return;

            var listaFiltrada = _sessionsLoaded.AsEnumerable();

            // Filter text
            string busqueda = txtFilter.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(busqueda))
            {
                listaFiltrada = listaFiltrada.Where(s =>
                    s.Username.ToLower().Contains(busqueda) ||
                    s.Id.ToString().Contains(busqueda));
            }

            // Order
            if (rbtDesDate != null && rbtDesDate.Checked)
            {
                listaFiltrada = listaFiltrada.OrderByDescending(s => s.OpenedAt);
            }
            else if (rbtDesName != null && rbtDesName.Checked)
            {
                listaFiltrada = listaFiltrada.OrderBy(s => s.Username);
            }

            dgvSessions.DataSource = listaFiltrada.ToList();
        }

        private async void btnResetFilters_Click(object sender, EventArgs e)
        {
            dtpSince.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            txtFilter.Text = "";
            if (rbtDesDate != null) rbtDesDate.Checked = true;

            await LoadSessions(null, null);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e) => ApplyFilters();
        private void rbtDesDate_CheckedChanged(object sender, EventArgs e) { if (rbtDesDate.Checked) ApplyFilters(); }
        private void rbtDesName_CheckedChanged(object sender, EventArgs e) { if (rbtDesName.Checked) ApplyFilters(); }

        private async void dgvSessions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSessions.CurrentRow == null)
            {
                dgvSales.DataSource = null;
                return;
            }

            try
            {
                var sesion = (SessionGridDto)dgvSessions.CurrentRow.DataBoundItem;
                var ventas = await _saleService.GetSalesBySessionAsync(sesion.Id);
                dgvSales.DataSource = ventas.ToList();
                ConfigSalesGrid();
            }
            catch (Exception) { }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para ver el detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = (SaleGridDto)dgvSales.CurrentRow.DataBoundItem;
            var formDetalle = _serviceProvider.GetRequiredService<FormSaleDetail>();
            formDetalle.LoadData(venta.Id);
            formDetalle.ShowDialog();
        }
    }
}
