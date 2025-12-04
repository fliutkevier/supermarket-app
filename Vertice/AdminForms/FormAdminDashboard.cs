using Application.Sessions.Interfaces;
using Domain.RepositoryInterfaces;
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

namespace WinForms.AdminForms
{
    public partial class FormAdminDashboard : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserSessionService _userSessionService;
        private readonly ISessionService _sessionService;

        private Control? _activeControl;

        public FormAdminDashboard(
            IServiceProvider serviceProvider,
            IUserSessionService userSessionService,
            ISessionService sessionService)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _serviceProvider = serviceProvider;
            _userSessionService = userSessionService;
            _sessionService = sessionService;

            this.KeyPreview = true; //El form captura teclas antes que los controles
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Si ya se manejó la tecla, salimos
            if (e.Handled) return;

            switch (e.KeyCode)
            {
                case Keys.F1:
                    e.Handled = true;
                    // Simulamos clic en el botón (o llamamos a la lógica directa)
                    if (btnSellNavbar != null && btnSellNavbar.Enabled)
                        btnSellNavbar.PerformClick();
                    break;

                case Keys.F2: // Productos
                    e.Handled = true;
                    if (btnProductsNavbar != null && btnProductsNavbar.Enabled)
                        btnProductsNavbar.PerformClick();
                    break;

                case Keys.F3: // Historial Ventas
                    e.Handled = true;
                    if (btnHistoryNavbar != null && btnHistoryNavbar.Enabled)
                        btnHistoryNavbar.PerformClick();
                    break;

                case Keys.F4: // Caja
                    e.Handled = true;
                    if (btnInitSession != null && btnInitSession.Enabled)
                        btnInitSession.PerformClick();
                    break;

                case Keys.F10: // Cerrar Sesión
                    e.Handled = true;
                    if (btnLogOutNavbar != null && btnLogOutNavbar.Enabled)
                        btnLogOutNavbar.PerformClick();
                    break;

                case Keys.Escape: // Volver al Home (Si no estamos en Home)
                    // Solo si el menú está oculto (significa que hay un control abierto)
                    if (!pnlMenu.Visible)
                    {
                        e.Handled = true;
                        btnHome_Click_1(this, EventArgs.Empty);
                    }
                    break;
            }
        }

        private void OpenControl(Control childControl)
        {
            this.pnlMenu.Visible = false;
            ShowNavbar();

            if (_activeControl != null)
            {
                this.pnlContent.Controls.Remove(_activeControl);
                _activeControl.Dispose();
            }

            _activeControl = childControl;
            childControl.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(childControl);
            childControl.BringToFront();
        }

        private void ShowNavbar()
        {
            btnHome.Visible = true;
            btnHome.Enabled = true;
            btnSellNavbar.Visible = true;
            btnProductsNavbar.Visible = true;
            btnHistoryNavbar.Visible = true;
            btnLogOutNavbar.Visible = true;
            btnSellNavbar.Enabled = true;
            btnProductsNavbar.Enabled = true;
            btnHistoryNavbar.Enabled = true;
            btnLogOutNavbar.Enabled = true;
        }

        private void HideNavbar()
        {
            btnHome.Visible = false;
            btnSellNavbar.Visible = false;
            btnProductsNavbar.Visible = false;
            btnHistoryNavbar.Visible = false;
            btnLogOutNavbar.Visible = false;
            btnHome.Enabled = false;
            btnSellNavbar.Enabled = false;
            btnProductsNavbar.Enabled = false;
            btnHistoryNavbar.Enabled = false;
            btnLogOutNavbar.Enabled = false;
        }

        private async void FormAdminDashboard_Load(object sender, EventArgs e)
        {
            btnHome_Click_1(sender, e);
            HideNavbar();
            string username = $"Usuario: {_userSessionService.Username}";
            lblUsername.Text = username;
            lblUserFooter.Text = username;

            await VerifySessionState();
        }

        private async Task VerifySessionState()
        {
            try
            {
                string username = _userSessionService.Username;

                // zombie session?
                var currentSession = await _sessionService.GetCurrentSessionAsync(username);

                if (currentSession != null)
                {
                    var fechaSesion = currentSession.Date;
                    var fechaHoy = DateOnly.FromDateTime(DateTime.Now);

                    if (fechaSesion < fechaHoy)
                    {
                        var result = MessageBox.Show(
                            $"Tenés una caja abierta del día {fechaSesion} sin cerrar.\n¿Querés continuarla o cerrarla?\n\nSI: Continuar\nNO: Cerrar ahora",
                            "Caja Pendiente",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            await _sessionService.CloseSessionAsync(username);
                            MessageBox.Show("La caja anterior se cerró. Podés abrir una nueva.", "Caja Cerrada");
                        }
                    }
                }

                await UpdateSessionButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar estado de caja: " + ex.Message);
            }
        }

        private async Task UpdateSessionButton()
        {
            try
            {
                bool isOpen = await _sessionService.HasOpenSessionAsync(_userSessionService.Username);

                if (isOpen)
                {
                    btnInitSession.Text = "CERRAR CAJA [F4]";
                    btnInitSession.BackColor = Color.Salmon;
                }
                else
                {
                    btnInitSession.Text = "ABRIR CAJA [F4]";
                    btnInitSession.BackColor = Color.LightGreen;
                }
            }
            catch { }
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            // Formato: 14/11/2025 19:16:03
            //lblTime.Text = DateTime.Now.ToString("G");

            // O si preferís solo la hora con segundos:
            // lblReloj.Text = DateTime.Now.ToString("T"); // 19:16:03
            lblTime.Text = DateTime.Now.ToString("HH:mm");
        }


        private void btnInitSellMenu_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlNewSales>());
        }

        private void btnProductsMenu_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlProducts>());
        }

        private void btnSalesHistory_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlHistory>());
        }

        private void btnProvidersMenu_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlProviders>());
        }

        private void btnEmployeesMenu_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlEmployees>());
        }

        private void btnLogsMenu_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlLogs>());
        }

        private void btnPaymentMethodsMenu_Click(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlPaymentMethods>());
        }

        private void btnPurchaseHistory_Click_1(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlProvidersHistory>());
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            if (_activeControl != null)
            {
                this.pnlContent.Controls.Remove(_activeControl);
                _activeControl.Dispose();
                _activeControl = null;
            }

            this.pnlMenu.Visible = true;
            HideNavbar();
        }

        private void btnLogOutNavbar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogOutMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnInitSession_Click(object sender, EventArgs e)
        {
            try
            {
                string username = _userSessionService.Username;
                bool isOpen = await _sessionService.HasOpenSessionAsync(username);

                if (isOpen)
                {
                    // Si está abierta -> Intentar cerrar
                    var confirm = MessageBox.Show("¿Desea cerrar la caja actual?", "Cerrar Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        await _sessionService.CloseSessionAsync(username);
                        MessageBox.Show("Caja cerrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await UpdateSessionButton();
                    }
                }
                else
                {
                    // Si está cerrada -> Intentar abrir
                    var confirm = MessageBox.Show("¿Desea abrir una nueva caja?", "Abrir Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        await _sessionService.OpenSessionAsync(username);
                        MessageBox.Show("Caja abierta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await UpdateSessionButton();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar estado de caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsersMenu_Click(object sender, EventArgs e)
        {
            OpenControl(_serviceProvider.GetRequiredService<UserControlUsers>());
        }

        private void btnSellNavbar_Click(object sender, EventArgs e)
        {
            btnInitSellMenu_Click_1(sender, e);
        }

        private void btnProductsNavbar_Click(object sender, EventArgs e)
        {
            btnProductsMenu_Click_1(sender, e);
        }

        private void btnHistoryNavbar_Click(object sender, EventArgs e)
        {
            btnSalesHistory_Click_1(sender, e);
        }
    }
}
