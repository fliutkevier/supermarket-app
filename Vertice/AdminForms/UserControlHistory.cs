using Application.Sales.Dtos;
using Application.Sales.Interfaces;
using Application.Sessions.Dtos;
using Application.Sessions.Interfaces;
using Application.Users.Interfaces;
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
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;

        private List<SessionGridDto> _sessionsLoaded = new List<SessionGridDto>();

        public UserControlHistory(
            ISessionService sessionService,
            ISaleService saleService,
            IUserService userService, // <-- Inyectamos
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _sessionService = sessionService;
            _saleService = saleService;
            _userService = userService;
            _serviceProvider = serviceProvider;
        }

        private async void UserControlHistory_Load(object sender, EventArgs e)
        {
            dtpSince.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;

            if (rbtDesDate != null) rbtDesDate.Checked = true;

            try
            {
                await LoadUsers();
                await LoadSessions(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de inicialización: " + ex.Message);
            }
            ConfigSessionsGrid();
        }

        private async Task LoadUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                // Creamos una lista temporal para agregar la opción "TODOS"
                var userList = users.Select(u => new { u.Username, Display = u.Username }).ToList();
                userList.Insert(0, new { Username = "ALL", Display = "TODOS LOS USUARIOS" });

                cbxUsersFilter.DataSource = userList;
                cbxUsersFilter.DisplayMember = "Display";
                cbxUsersFilter.ValueMember = "Username";
                cbxUsersFilter.SelectedIndex = 0; // Seleccionar TODOS
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
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

            // 1. FILTRO USUARIO (ComboBox)
            if (cbxUsersFilter.SelectedValue != null && cbxUsersFilter.SelectedValue.ToString() != "ALL")
            {
                string userFilter = cbxUsersFilter.SelectedValue.ToString();
                listaFiltrada = listaFiltrada.Where(s => s.Username == userFilter);
            }

            // 2. ORDENAMIENTO
            if (rbtDesDate != null && rbtDesDate.Checked)
            {
                listaFiltrada = listaFiltrada.OrderByDescending(s => s.OpenedAt);
            }
            else if (rbtDesName != null && rbtDesName.Checked)
            {
                listaFiltrada = listaFiltrada.OrderBy(s => s.Username);
            }
            else if (rbtMinMoney != null && rbtMinMoney.Checked)
            {
                listaFiltrada = listaFiltrada.OrderBy(s => s.Total);
            }
            else if (rbtMaxMoney != null && rbtMaxMoney.Checked)
            {
                listaFiltrada = listaFiltrada.OrderByDescending(s => s.Total);
            }

            dgvSessions.DataSource = listaFiltrada.ToList();
        }

        private async void btnResetFilters_Click(object sender, EventArgs e)
        {
            dtpSince.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;

            // Resetear combo y radios
            if (cbxUsersFilter.Items.Count > 0) cbxUsersFilter.SelectedIndex = 0;
            if (rbtDesDate != null) rbtDesDate.Checked = true;

            await LoadSessions(null, null);
        }

        private void cbxUsersFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
        private void rbtDesDate_CheckedChanged(object sender, EventArgs e) { if (rbtDesDate.Checked) ApplyFilters(); }
        private void rbtDesName_CheckedChanged(object sender, EventArgs e) { if (rbtDesName.Checked) ApplyFilters(); }
        private void rbtMinMoney_CheckedChanged(object sender, EventArgs e) { if (rbtMinMoney.Checked) ApplyFilters(); }
        private void rbtMaxMoney_CheckedChanged(object sender, EventArgs e) { if (rbtMaxMoney.Checked) ApplyFilters(); }

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
