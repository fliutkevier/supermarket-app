namespace WinForms
{
    partial class UserControlProducts
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tlpProducts = new TableLayoutPanel();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            dgvProducts = new DataGridView();
            txtFilter = new Krypton.Toolkit.KryptonTextBox();
            btnResetFilters = new Krypton.Toolkit.KryptonButton();
            btnAdd = new Krypton.Toolkit.KryptonButton();
            btnAddStock = new Krypton.Toolkit.KryptonButton();
            btn0Stock = new Krypton.Toolkit.KryptonButton();
            btnDelete = new Krypton.Toolkit.KryptonButton();
            btnUpdate = new Krypton.Toolkit.KryptonButton();
            gbxFilters = new GroupBox();
            tlpFilters = new TableLayoutPanel();
            rbtMaxStock = new Krypton.Toolkit.KryptonRadioButton();
            rbtDesDate = new Krypton.Toolkit.KryptonRadioButton();
            rbtDesName = new Krypton.Toolkit.KryptonRadioButton();
            rbtMinStock = new Krypton.Toolkit.KryptonRadioButton();
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
            tlpProducts.Controls.Add(btnAddStock, 3, 0);
            tlpProducts.Controls.Add(btn0Stock, 4, 0);
            tlpProducts.Controls.Add(btnDelete, 5, 1);
            tlpProducts.Controls.Add(btnUpdate, 4, 1);
            tlpProducts.Controls.Add(gbxFilters, 8, 3);
            tlpProducts.Controls.Add(btnResetFilters, 8, 4);
            tlpProducts.Dock = DockStyle.Fill;
            tlpProducts.Location = new Point(0, 0);
            tlpProducts.Name = "tlpProducts";
            tlpProducts.RowCount = 12;
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 29.61832F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 7.93893147F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 1.52671754F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 5.34351158F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 4.4274807F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 5.95419836F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 9.465649F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 6.87022924F));
            tlpProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 3.35877872F));
            tlpProducts.Size = new Size(1280, 655);
            tlpProducts.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            tlpProducts.SetColumnSpan(lblTitle, 2);
            lblTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            lblTitle.Location = new Point(133, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(169, 29);
            lblTitle.TabIndex = 7;
            lblTitle.Values.Text = "Productos y Stock";
            // 
            // dgvProducts
            // 
            dataGridViewCellStyle5.BackColor = Color.FromArgb(238, 239, 249);
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpProducts.SetColumnSpan(dgvProducts, 7);
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = Color.ForestGreen;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle7;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.Location = new Point(17, 111);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle8;
            tlpProducts.SetRowSpan(dgvProducts, 9);
            dgvProducts.RowTemplate.Height = 35;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1029, 514);
            dgvProducts.TabIndex = 8;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.None;
            tlpProducts.SetColumnSpan(txtFilter, 2);
            txtFilter.CueHint.CueHintText = "Nombre o Código";
            txtFilter.CueHint.Padding = new Padding(-1, -1, -1, 2);
            txtFilter.Location = new Point(46, 69);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(343, 23);
            txtFilter.TabIndex = 9;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // btnResetFilters
            // 
            btnResetFilters.Anchor = AnchorStyles.None;
            btnResetFilters.Location = new Point(1101, 362);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(127, 40);
            btnResetFilters.TabIndex = 24;
            btnResetFilters.Values.DropDownArrowColor = Color.Empty;
            btnResetFilters.Values.Text = "Reiniciar Filtros";
            btnResetFilters.Click += btnResetFilters_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Location = new Point(429, 61);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 40);
            btnAdd.TabIndex = 19;
            btnAdd.Values.DropDownArrowColor = Color.Empty;
            btnAdd.Values.Text = "Nuevo Producto";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnAddStock
            // 
            btnAddStock.Anchor = AnchorStyles.None;
            btnAddStock.Location = new Point(429, 7);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(127, 40);
            btnAddStock.TabIndex = 16;
            btnAddStock.Values.DropDownArrowColor = Color.Empty;
            btnAddStock.Values.Text = "Agregar Stock";
            btnAddStock.Click += btnAddStock_Click;
            // 
            // btn0Stock
            // 
            btn0Stock.Anchor = AnchorStyles.None;
            btn0Stock.Location = new Point(570, 7);
            btn0Stock.Name = "btn0Stock";
            btn0Stock.Size = new Size(127, 40);
            btn0Stock.TabIndex = 17;
            btn0Stock.Values.DropDownArrowColor = Color.Empty;
            btn0Stock.Values.Text = "Borrar Stock";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Location = new Point(713, 61);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(123, 40);
            btnDelete.TabIndex = 18;
            btnDelete.Values.DropDownArrowColor = Color.Empty;
            btnDelete.Values.Text = "Eliminar Producto";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.None;
            btnUpdate.Location = new Point(570, 61);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 40);
            btnUpdate.TabIndex = 27;
            btnUpdate.Values.DropDownArrowColor = Color.Empty;
            btnUpdate.Values.Text = "Editar Producto";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // gbxFilters
            // 
            gbxFilters.Controls.Add(tlpFilters);
            gbxFilters.Dock = DockStyle.Fill;
            gbxFilters.Location = new Point(1052, 165);
            gbxFilters.Name = "gbxFilters";
            gbxFilters.Size = new Size(225, 188);
            gbxFilters.TabIndex = 28;
            gbxFilters.TabStop = false;
            // 
            // tlpFilters
            // 
            tlpFilters.ColumnCount = 1;
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFilters.Controls.Add(rbtMaxStock, 0, 3);
            tlpFilters.Controls.Add(rbtDesDate, 0, 0);
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
            // rbtMaxStock
            // 
            rbtMaxStock.Anchor = AnchorStyles.None;
            rbtMaxStock.Location = new Point(29, 134);
            rbtMaxStock.Name = "rbtMaxStock";
            rbtMaxStock.Size = new Size(161, 20);
            rbtMaxStock.TabIndex = 14;
            rbtMaxStock.Values.Text = "Ordenar por Mayor Stock";
            rbtMaxStock.CheckedChanged += rbtMaxStock_CheckedChanged;
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
            rbtDesDate.CheckedChanged += rbtDesDate_CheckedChanged;
            // 
            // rbtDesName
            // 
            rbtDesName.Anchor = AnchorStyles.None;
            rbtDesName.Location = new Point(40, 51);
            rbtDesName.Name = "rbtDesName";
            rbtDesName.Size = new Size(138, 20);
            rbtDesName.TabIndex = 12;
            rbtDesName.Values.Text = "Ordenar por Nombre";
            rbtDesName.CheckedChanged += rbtDesName_CheckedChanged;
            // 
            // rbtMinStock
            // 
            rbtMinStock.Anchor = AnchorStyles.None;
            rbtMinStock.Location = new Point(28, 92);
            rbtMinStock.Name = "rbtMinStock";
            rbtMinStock.Size = new Size(162, 20);
            rbtMinStock.TabIndex = 13;
            rbtMinStock.Values.Text = "Ordenar por Menor Stock";
            rbtMinStock.CheckedChanged += rbtMinStock_CheckedChanged;
            // 
            // UserControlProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpProducts);
            Name = "UserControlProducts";
            Size = new Size(1280, 655);
            Load += UserControlProducts_Load;
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
        private Krypton.Toolkit.KryptonButton btnAddStock;
        private Krypton.Toolkit.KryptonButton btn0Stock;
        private Krypton.Toolkit.KryptonButton btnAdd;
        private Krypton.Toolkit.KryptonButton btnDelete;
        private Krypton.Toolkit.KryptonButton btnResetFilters;
        private Krypton.Toolkit.KryptonRadioButton rbtMaxStock;
        private Krypton.Toolkit.KryptonRadioButton rbtMinStock;
        private Krypton.Toolkit.KryptonButton btnUpdate;
        private GroupBox gbxFilters;
        private TableLayoutPanel tlpFilters;
        private Krypton.Toolkit.KryptonRadioButton rbtDesDate;
        private Krypton.Toolkit.KryptonRadioButton rbtDesName;
    }
}
