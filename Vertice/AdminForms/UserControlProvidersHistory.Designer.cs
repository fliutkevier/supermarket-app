namespace WinForms
{
    partial class UserControlProvidersHistory
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
            tlpProducts = new TableLayoutPanel();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            dgvProducts = new DataGridView();
            txtFilter = new Krypton.Toolkit.KryptonTextBox();
            btnAdd = new Krypton.Toolkit.KryptonButton();
            btnUpdate = new Krypton.Toolkit.KryptonButton();
            btnDelete = new Krypton.Toolkit.KryptonButton();
            gbxFilters = new GroupBox();
            tlpFilters = new TableLayoutPanel();
            rbtDesDate = new Krypton.Toolkit.KryptonRadioButton();
            rbtDesName = new Krypton.Toolkit.KryptonRadioButton();
            lblSince = new Krypton.Toolkit.KryptonLabel();
            dtpSince = new Krypton.Toolkit.KryptonDateTimePicker();
            lblTo = new Krypton.Toolkit.KryptonLabel();
            dtpTo = new Krypton.Toolkit.KryptonDateTimePicker();
            btnResetFilters = new Krypton.Toolkit.KryptonButton();
            rbtMinStock = new Krypton.Toolkit.KryptonRadioButton();
            rbtMaxStock = new Krypton.Toolkit.KryptonRadioButton();
            tlpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            gbxFilters.SuspendLayout();
            tlpFilters.SuspendLayout();
            SuspendLayout();
            // 
            // tlpProducts
            // 
            tlpProducts.ColumnCount = 9;
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.171875F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.015625F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tlpProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.96875F));
            tlpProducts.Controls.Add(lblTitle, 1, 0);
            tlpProducts.Controls.Add(dgvProducts, 1, 2);
            tlpProducts.Controls.Add(txtFilter, 1, 1);
            tlpProducts.Controls.Add(btnAdd, 3, 1);
            tlpProducts.Controls.Add(gbxFilters, 8, 3);
            tlpProducts.Controls.Add(lblSince, 8, 5);
            tlpProducts.Controls.Add(dtpSince, 8, 6);
            tlpProducts.Controls.Add(lblTo, 8, 7);
            tlpProducts.Controls.Add(dtpTo, 8, 8);
            tlpProducts.Controls.Add(btnResetFilters, 8, 9);
            tlpProducts.Controls.Add(btnUpdate, 4, 1);
            tlpProducts.Controls.Add(btnDelete, 5, 1);
            tlpProducts.Dock = DockStyle.Fill;
            tlpProducts.Location = new Point(0, 0);
            tlpProducts.Name = "tlpProducts";
            tlpProducts.RowCount = 12;
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 29.61832F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 5.34351158F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 4.12213755F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 5.34351158F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 4.4274807F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 5.95419836F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 9.465649F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.87022924F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 3.35877872F));
            tlpProducts.Size = new Size(1280, 655);
            tlpProducts.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            tlpProducts.SetColumnSpan(lblTitle, 2);
            lblTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            lblTitle.Location = new Point(120, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(195, 29);
            lblTitle.TabIndex = 7;
            lblTitle.Values.Text = "Historial de Compras";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpProducts.SetColumnSpan(dgvProducts, 7);
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(17, 111);
            dgvProducts.Name = "dgvProducts";
            tlpProducts.SetRowSpan(dgvProducts, 9);
            dgvProducts.Size = new Size(1029, 514);
            dgvProducts.TabIndex = 8;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.None;
            tlpProducts.SetColumnSpan(txtFilter, 2);
            txtFilter.CueHint.CueHintText = "Buscar";
            txtFilter.Location = new Point(46, 69);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(343, 23);
            txtFilter.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Location = new Point(429, 61);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 40);
            btnAdd.TabIndex = 16;
            btnAdd.Values.DropDownArrowColor = Color.Empty;
            btnAdd.Values.Text = "Agregar Compra";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.None;
            btnUpdate.Location = new Point(570, 61);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 40);
            btnUpdate.TabIndex = 17;
            btnUpdate.Values.DropDownArrowColor = Color.Empty;
            btnUpdate.Values.Text = "Editar";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Location = new Point(713, 61);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(123, 40);
            btnDelete.TabIndex = 18;
            btnDelete.Values.DropDownArrowColor = Color.Empty;
            btnDelete.Values.Text = "Eliminar";
            // 
            // gbxFilters
            // 
            gbxFilters.Controls.Add(tlpFilters);
            gbxFilters.Dock = DockStyle.Fill;
            gbxFilters.Location = new Point(1052, 165);
            gbxFilters.Name = "gbxFilters";
            gbxFilters.Size = new Size(225, 188);
            gbxFilters.TabIndex = 20;
            gbxFilters.TabStop = false;
            // 
            // tlpFilters
            // 
            tlpFilters.ColumnCount = 1;
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFilters.Controls.Add(rbtDesDate, 0, 0);
            tlpFilters.Controls.Add(rbtMaxStock, 0, 3);
            tlpFilters.Controls.Add(rbtDesName, 0, 1);
            tlpFilters.Controls.Add(rbtMinStock, 0, 2);
            tlpFilters.Dock = DockStyle.Fill;
            tlpFilters.Location = new Point(3, 19);
            tlpFilters.Name = "tlpFilters";
            tlpFilters.RowCount = 4;
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.Size = new Size(219, 166);
            tlpFilters.TabIndex = 15;
            // 
            // rbtDesDate
            // 
            rbtDesDate.Anchor = AnchorStyles.None;
            rbtDesDate.Checked = true;
            rbtDesDate.Location = new Point(47, 10);
            rbtDesDate.Name = "rbtDesDate";
            rbtDesDate.Size = new Size(124, 20);
            rbtDesDate.TabIndex = 11;
            rbtDesDate.Values.Text = "Ordenar por Fecha";
            // 
            // rbtDesName
            // 
            rbtDesName.Anchor = AnchorStyles.None;
            rbtDesName.Location = new Point(40, 51);
            rbtDesName.Name = "rbtDesName";
            rbtDesName.Size = new Size(138, 20);
            rbtDesName.TabIndex = 12;
            rbtDesName.Values.Text = "Ordenar por Nombre";
            // 
            // lblSince
            // 
            lblSince.Anchor = AnchorStyles.Bottom;
            lblSince.Location = new Point(1142, 395);
            lblSince.Name = "lblSince";
            lblSince.Size = new Size(45, 20);
            lblSince.TabIndex = 22;
            lblSince.Values.Text = "Desde";
            // 
            // dtpSince
            // 
            dtpSince.Anchor = AnchorStyles.Top;
            dtpSince.CalendarFirstDayOfWeek = Day.Monday;
            dtpSince.Location = new Point(1054, 421);
            dtpSince.Name = "dtpSince";
            dtpSince.Size = new Size(221, 21);
            dtpSince.TabIndex = 23;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Bottom;
            lblTo.Location = new Point(1144, 459);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(41, 20);
            lblTo.TabIndex = 25;
            lblTo.Values.Text = "Hasta";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top;
            dtpTo.CalendarFirstDayOfWeek = Day.Monday;
            dtpTo.Location = new Point(1054, 485);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(221, 21);
            dtpTo.TabIndex = 26;
            // 
            // btnResetFilters
            // 
            btnResetFilters.Anchor = AnchorStyles.Bottom;
            btnResetFilters.Location = new Point(1101, 540);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(127, 40);
            btnResetFilters.TabIndex = 24;
            btnResetFilters.Values.DropDownArrowColor = Color.Empty;
            btnResetFilters.Values.Text = "Reiniciar Filtros";
            // 
            // rbtMinStock
            // 
            rbtMinStock.Anchor = AnchorStyles.None;
            rbtMinStock.Location = new Point(27, 92);
            rbtMinStock.Name = "rbtMinStock";
            rbtMinStock.Size = new Size(164, 20);
            rbtMinStock.TabIndex = 13;
            rbtMinStock.Values.Text = "Ordenar por Menor Gasto";
            // 
            // rbtMaxStock
            // 
            rbtMaxStock.Anchor = AnchorStyles.None;
            rbtMaxStock.Location = new Point(28, 134);
            rbtMaxStock.Name = "rbtMaxStock";
            rbtMaxStock.Size = new Size(163, 20);
            rbtMaxStock.TabIndex = 14;
            rbtMaxStock.Values.Text = "Ordenar por Mayor Gasto";
            // 
            // UserControlProvidersHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpProducts);
            Name = "UserControlProvidersHistory";
            Size = new Size(1280, 655);
            tlpProducts.ResumeLayout(false);
            tlpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            gbxFilters.ResumeLayout(false);
            tlpFilters.ResumeLayout(false);
            tlpFilters.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpProducts;
        private Krypton.Toolkit.KryptonLabel lblTitle;
        private DataGridView dgvProducts;
        private Krypton.Toolkit.KryptonTextBox txtFilter;
        private Krypton.Toolkit.KryptonButton btnUpdate;
        private Krypton.Toolkit.KryptonButton btnAdd;
        private Krypton.Toolkit.KryptonButton btnDelete;
        private GroupBox gbxFilters;
        private TableLayoutPanel tlpFilters;
        private Krypton.Toolkit.KryptonRadioButton rbtDesDate;
        private Krypton.Toolkit.KryptonRadioButton rbtDesName;
        private Krypton.Toolkit.KryptonLabel lblSince;
        private Krypton.Toolkit.KryptonDateTimePicker dtpSince;
        private Krypton.Toolkit.KryptonLabel lblTo;
        private Krypton.Toolkit.KryptonDateTimePicker dtpTo;
        private Krypton.Toolkit.KryptonButton btnResetFilters;
        private Krypton.Toolkit.KryptonRadioButton rbtMaxStock;
        private Krypton.Toolkit.KryptonRadioButton rbtMinStock;
    }
}
