namespace WinForms
{
    partial class UserControlNewSales
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tlpSales = new TableLayoutPanel();
            dgvSaleProducts = new DataGridView();
            lblSubTotal = new Krypton.Toolkit.KryptonLabel();
            lblTotal = new Krypton.Toolkit.KryptonLabel();
            lblChange = new Krypton.Toolkit.KryptonLabel();
            btnOnlySale = new Krypton.Toolkit.KryptonButton();
            btnSaleTicket = new Krypton.Toolkit.KryptonButton();
            btnSaleAFIP = new Krypton.Toolkit.KryptonButton();
            btnShowLastSale = new Krypton.Toolkit.KryptonButton();
            txtProduct = new Krypton.Toolkit.KryptonTextBox();
            lblLastProduct = new Krypton.Toolkit.KryptonLabel();
            cbxPaymentMethod = new Krypton.Toolkit.KryptonComboBox();
            txtCash = new Krypton.Toolkit.KryptonTextBox();
            txtVariosAmount = new Krypton.Toolkit.KryptonTextBox();
            btnAddVarious = new Krypton.Toolkit.KryptonButton();
            tlpSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSaleProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxPaymentMethod).BeginInit();
            SuspendLayout();
            // 
            // tlpSales
            // 
            tlpSales.ColumnCount = 8;
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.71875F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.28125F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.046875F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.9375F));
            tlpSales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.515625F));
            tlpSales.Controls.Add(dgvSaleProducts, 1, 3);
            tlpSales.Controls.Add(lblSubTotal, 5, 8);
            tlpSales.Controls.Add(lblTotal, 5, 2);
            tlpSales.Controls.Add(lblChange, 6, 8);
            tlpSales.Controls.Add(btnOnlySale, 5, 10);
            tlpSales.Controls.Add(btnSaleTicket, 5, 11);
            tlpSales.Controls.Add(btnSaleAFIP, 5, 12);
            tlpSales.Controls.Add(btnShowLastSale, 1, 12);
            tlpSales.Controls.Add(txtProduct, 1, 1);
            tlpSales.Controls.Add(lblLastProduct, 1, 2);
            tlpSales.Controls.Add(cbxPaymentMethod, 5, 4);
            tlpSales.Controls.Add(txtCash, 5, 5);
            tlpSales.Controls.Add(txtVariosAmount, 5, 6);
            tlpSales.Controls.Add(btnAddVarious, 6, 6);
            tlpSales.Dock = DockStyle.Fill;
            tlpSales.Location = new Point(0, 0);
            tlpSales.Name = "tlpSales";
            tlpSales.RowCount = 14;
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 1.241691F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 12.66639F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 9.731494F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.989902F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.989902F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.989902F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.989902F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.989902F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.989902F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.41447163F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 5.715322F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 7.450147F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 6.82930231F));
            tlpSales.RowStyles.Add(new RowStyle(SizeType.Percent, 1.01176643F));
            tlpSales.Size = new Size(1280, 655);
            tlpSales.TabIndex = 0;
            // 
            // dgvSaleProducts
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 239, 249);
            dgvSaleProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSaleProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSaleProducts.BorderStyle = BorderStyle.None;
            dgvSaleProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSaleProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSaleProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpSales.SetColumnSpan(dgvSaleProducts, 4);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSaleProducts.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSaleProducts.Dock = DockStyle.Fill;
            dgvSaleProducts.EnableHeadersVisualStyles = false;
            dgvSaleProducts.Location = new Point(25, 156);
            dgvSaleProducts.MultiSelect = false;
            dgvSaleProducts.Name = "dgvSaleProducts";
            dgvSaleProducts.ReadOnly = true;
            dgvSaleProducts.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvSaleProducts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            tlpSales.SetRowSpan(dgvSaleProducts, 7);
            dgvSaleProducts.RowTemplate.Height = 35;
            dgvSaleProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleProducts.Size = new Size(772, 354);
            dgvSaleProducts.TabIndex = 23;
            dgvSaleProducts.KeyDown += dgvSaleProducts_KeyDown;
            // 
            // lblSubTotal
            // 
            lblSubTotal.Anchor = AnchorStyles.Top;
            lblSubTotal.Location = new Point(853, 416);
            lblSubTotal.Name = "lblSubTotal";
            tlpSales.SetRowSpan(lblSubTotal, 2);
            lblSubTotal.Size = new Size(125, 33);
            lblSubTotal.StateCommon.ShortText.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubTotal.TabIndex = 13;
            lblSubTotal.Values.Text = "SUBTOTAL";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top;
            tlpSales.SetColumnSpan(lblTotal, 2);
            lblTotal.Location = new Point(887, 93);
            lblTotal.Name = "lblTotal";
            tlpSales.SetRowSpan(lblTotal, 2);
            lblTotal.Size = new Size(261, 47);
            lblTotal.StateCommon.ShortText.Font = new Font("Arial Narrow", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.TabIndex = 12;
            lblTotal.Values.Text = "TOTAL A PAGAR";
            // 
            // lblChange
            // 
            lblChange.Anchor = AnchorStyles.Top;
            lblChange.Location = new Point(1084, 416);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(97, 33);
            lblChange.StateCommon.ShortText.Font = new Font("Arial Narrow", 18F, FontStyle.Bold);
            lblChange.TabIndex = 15;
            lblChange.Values.Text = "VUELTO";
            // 
            // btnOnlySale
            // 
            btnOnlySale.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(btnOnlySale, 2);
            btnOnlySale.Location = new Point(937, 516);
            btnOnlySale.Name = "btnOnlySale";
            btnOnlySale.Size = new Size(160, 31);
            btnOnlySale.StateCommon.Back.Color1 = Color.FromArgb(160, 205, 254);
            btnOnlySale.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOnlySale.TabIndex = 37;
            btnOnlySale.Values.DropDownArrowColor = Color.Empty;
            btnOnlySale.Values.Text = "REALIZAR VENTA";
            btnOnlySale.Click += btnOnlySale_Click;
            // 
            // btnSaleTicket
            // 
            btnSaleTicket.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(btnSaleTicket, 2);
            btnSaleTicket.Location = new Point(937, 554);
            btnSaleTicket.Name = "btnSaleTicket";
            btnSaleTicket.Size = new Size(160, 40);
            btnSaleTicket.StateCommon.Back.Color1 = Color.FromArgb(160, 205, 254);
            btnSaleTicket.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaleTicket.TabIndex = 38;
            btnSaleTicket.Values.DropDownArrowColor = Color.Empty;
            btnSaleTicket.Values.Text = "VENTA + TICKET";
            btnSaleTicket.Click += btnSaleTicket_Click;
            // 
            // btnSaleAFIP
            // 
            btnSaleAFIP.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(btnSaleAFIP, 2);
            btnSaleAFIP.Location = new Point(937, 601);
            btnSaleAFIP.Name = "btnSaleAFIP";
            btnSaleAFIP.Size = new Size(160, 38);
            btnSaleAFIP.StateCommon.Back.Color1 = Color.FromArgb(160, 205, 254);
            btnSaleAFIP.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaleAFIP.TabIndex = 39;
            btnSaleAFIP.Values.DropDownArrowColor = Color.Empty;
            btnSaleAFIP.Values.Text = "FACTURAR";
            // 
            // btnShowLastSale
            // 
            btnShowLastSale.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(btnShowLastSale, 2);
            btnShowLastSale.Location = new Point(87, 601);
            btnShowLastSale.Name = "btnShowLastSale";
            btnShowLastSale.Size = new Size(328, 38);
            btnShowLastSale.StateCommon.Back.Color1 = Color.FromArgb(160, 205, 254);
            btnShowLastSale.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShowLastSale.TabIndex = 41;
            btnShowLastSale.Values.DropDownArrowColor = Color.Empty;
            btnShowLastSale.Values.Text = "MOSTRAR ÚLTIMA VENTA";
            btnShowLastSale.Click += btnShowLastSale_Click;
            // 
            // txtProduct
            // 
            tlpSales.SetColumnSpan(txtProduct, 4);
            txtProduct.CueHint.CueHintText = "PRODUCTO";
            txtProduct.CueHint.Font = new Font("Arial Narrow", 20F, FontStyle.Bold);
            txtProduct.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            txtProduct.Dock = DockStyle.Fill;
            txtProduct.Location = new Point(25, 11);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(772, 79);
            txtProduct.StateActive.Content.Font = new Font("Arial Narrow", 50F, FontStyle.Bold);
            txtProduct.StateCommon.Border.Color1 = Color.FromArgb(48, 159, 250);
            txtProduct.StateCommon.Border.Width = 2;
            txtProduct.StateCommon.Content.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProduct.StateCommon.Content.Padding = new Padding(1, 1, 1, -3);
            txtProduct.StateNormal.Content.Font = new Font("Arial", 36F, FontStyle.Bold);
            txtProduct.TabIndex = 42;
            txtProduct.TextAlign = HorizontalAlignment.Center;
            txtProduct.KeyDown += txtProduct_KeyDown;
            // 
            // lblLastProduct
            // 
            lblLastProduct.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(lblLastProduct, 4);
            lblLastProduct.Location = new Point(408, 119);
            lblLastProduct.Name = "lblLastProduct";
            lblLastProduct.Size = new Size(6, 5);
            lblLastProduct.StateCommon.Padding = new Padding(-1, 4, -1, 1);
            lblLastProduct.StateCommon.ShortText.Font = new Font("Arial Narrow", 50F, FontStyle.Bold);
            lblLastProduct.TabIndex = 43;
            lblLastProduct.Values.Text = "";
            // 
            // cbxPaymentMethod
            // 
            cbxPaymentMethod.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(cbxPaymentMethod, 2);
            cbxPaymentMethod.DropDownWidth = 152;
            cbxPaymentMethod.Location = new Point(935, 220);
            cbxPaymentMethod.Name = "cbxPaymentMethod";
            cbxPaymentMethod.Size = new Size(164, 22);
            cbxPaymentMethod.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cbxPaymentMethod.TabIndex = 11;
            cbxPaymentMethod.Text = "Método de pago";
            cbxPaymentMethod.SelectedIndexChanged += cbxPaymentMethod_SelectedIndexChanged;
            // 
            // txtCash
            // 
            txtCash.Anchor = AnchorStyles.None;
            tlpSales.SetColumnSpan(txtCash, 2);
            txtCash.CueHint.CueHintText = "INGRESAR EFECTIVO";
            txtCash.CueHint.Font = new Font("Arial Narrow", 11.75F, FontStyle.Bold);
            txtCash.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            txtCash.Location = new Point(887, 260);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(260, 47);
            txtCash.StateActive.Content.Font = new Font("Arial Narrow", 15F, FontStyle.Bold);
            txtCash.StateCommon.Border.Color1 = Color.FromArgb(48, 159, 250);
            txtCash.StateCommon.Border.Width = 2;
            txtCash.StateCommon.Content.Font = new Font("Arial Narrow", 11.75F, FontStyle.Bold);
            txtCash.StateCommon.Content.Padding = new Padding(1, 10, 1, 10);
            txtCash.TabIndex = 36;
            txtCash.TextAlign = HorizontalAlignment.Center;
            txtCash.TextChanged += txtCash_TextChanged;
            // 
            // txtVariosAmount
            // 
            txtVariosAmount.Anchor = AnchorStyles.Right;
            txtVariosAmount.CueHint.CueHintText = "INGRESAR PRECIO";
            txtVariosAmount.CueHint.Font = new Font("Arial Narrow", 11.75F, FontStyle.Bold);
            txtVariosAmount.CueHint.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            txtVariosAmount.Location = new Point(839, 312);
            txtVariosAmount.Name = "txtVariosAmount";
            txtVariosAmount.Size = new Size(189, 47);
            txtVariosAmount.StateActive.Content.Font = new Font("Arial Narrow", 15F, FontStyle.Bold);
            txtVariosAmount.StateCommon.Border.Color1 = Color.FromArgb(48, 159, 250);
            txtVariosAmount.StateCommon.Border.Width = 2;
            txtVariosAmount.StateCommon.Content.Font = new Font("Arial Narrow", 11.75F, FontStyle.Bold);
            txtVariosAmount.StateCommon.Content.Padding = new Padding(1, 10, 1, 10);
            txtVariosAmount.TabIndex = 44;
            txtVariosAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddVarious
            // 
            btnAddVarious.Anchor = AnchorStyles.Left;
            btnAddVarious.Location = new Point(1034, 319);
            btnAddVarious.Name = "btnAddVarious";
            btnAddVarious.Size = new Size(46, 31);
            btnAddVarious.StateCommon.Back.Color1 = Color.FromArgb(160, 205, 254);
            btnAddVarious.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddVarious.TabIndex = 45;
            btnAddVarious.Values.DropDownArrowColor = Color.Empty;
            btnAddVarious.Values.Text = "+";
            btnAddVarious.Click += btnAddVarious_Click;
            // 
            // UserControlNewSales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpSales);
            Name = "UserControlNewSales";
            Size = new Size(1280, 655);
            Load += UserControlNewSales_Load;
            tlpSales.ResumeLayout(false);
            tlpSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSaleProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxPaymentMethod).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpSales;
        private Krypton.Toolkit.KryptonComboBox cbxPaymentMethod;
        private Krypton.Toolkit.KryptonLabel lblSubTotal;
        private Krypton.Toolkit.KryptonLabel lblTotal;
        private Krypton.Toolkit.KryptonLabel lblChange;
        private Krypton.Toolkit.KryptonButton btnSale;
        private Krypton.Toolkit.KryptonButton btnSaleTicket;
        private Krypton.Toolkit.KryptonButton btnSaleAFIP;
        private Krypton.Toolkit.KryptonButton btnShowLastSale;
        private DataGridView dgvSaleProducts;
        private Krypton.Toolkit.KryptonTextBox txtCash;
        private Krypton.Toolkit.KryptonButton btnOnlySale;
        private Krypton.Toolkit.KryptonTextBox txtProduct;
        private Krypton.Toolkit.KryptonLabel lblLastProduct;
        private Krypton.Toolkit.KryptonTextBox txtVariosAmount;
        private Krypton.Toolkit.KryptonButton btnAddVarious;
    }
}
