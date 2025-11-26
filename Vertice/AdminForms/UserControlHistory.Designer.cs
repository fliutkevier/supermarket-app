namespace WinForms
{
    partial class UserControlHistory
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tlpHistory = new TableLayoutPanel();
            txtFilter = new Krypton.Toolkit.KryptonTextBox();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            dgvSessions = new DataGridView();
            dgvSales = new DataGridView();
            lblSellsTitle = new Krypton.Toolkit.KryptonLabel();
            btnShowDetails = new Krypton.Toolkit.KryptonButton();
            cbxUserFilter = new Krypton.Toolkit.KryptonThemeComboBox();
            lblSince = new Krypton.Toolkit.KryptonLabel();
            dtpSince = new Krypton.Toolkit.KryptonDateTimePicker();
            lblTo = new Krypton.Toolkit.KryptonLabel();
            dtpTo = new Krypton.Toolkit.KryptonDateTimePicker();
            btnSearch = new Krypton.Toolkit.KryptonButton();
            btnResetFilters = new Krypton.Toolkit.KryptonButton();
            gbxFilters = new GroupBox();
            tlpFilters = new TableLayoutPanel();
            rbtDesDate = new Krypton.Toolkit.KryptonRadioButton();
            rbtDesName = new Krypton.Toolkit.KryptonRadioButton();
            tlpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxUserFilter).BeginInit();
            gbxFilters.SuspendLayout();
            tlpFilters.SuspendLayout();
            SuspendLayout();
            // 
            // tlpHistory
            // 
            tlpHistory.ColumnCount = 8;
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.859375F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.984375F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.078125F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.375F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.625F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.515625F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.390625F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.09375F));
            tlpHistory.Controls.Add(txtFilter, 1, 1);
            tlpHistory.Controls.Add(lblTitle, 1, 0);
            tlpHistory.Controls.Add(dgvSessions, 1, 2);
            tlpHistory.Controls.Add(dgvSales, 4, 2);
            tlpHistory.Controls.Add(lblSellsTitle, 5, 1);
            tlpHistory.Controls.Add(btnShowDetails, 6, 1);
            tlpHistory.Controls.Add(cbxUserFilter, 3, 3);
            tlpHistory.Controls.Add(lblSince, 3, 5);
            tlpHistory.Controls.Add(dtpSince, 3, 6);
            tlpHistory.Controls.Add(lblTo, 3, 7);
            tlpHistory.Controls.Add(dtpTo, 3, 8);
            tlpHistory.Controls.Add(btnSearch, 3, 9);
            tlpHistory.Controls.Add(btnResetFilters, 3, 10);
            tlpHistory.Controls.Add(gbxFilters, 3, 4);
            tlpHistory.Dock = DockStyle.Fill;
            tlpHistory.Location = new Point(0, 0);
            tlpHistory.Name = "tlpHistory";
            tlpHistory.RowCount = 14;
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.07154655F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.07154655F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.07154655F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.07154655F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 21.8320618F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 5.038168F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 5.34351158F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 4.73282433F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 4.73282433F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 8.091603F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.480916F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 4.4274807F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 6.259542F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 3.34858537F));
            tlpHistory.Size = new Size(1280, 655);
            tlpHistory.TabIndex = 0;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.None;
            tlpHistory.SetColumnSpan(txtFilter, 2);
            txtFilter.CueHint.CueHintText = "Buscar";
            txtFilter.Location = new Point(121, 57);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(343, 23);
            txtFilter.TabIndex = 8;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            tlpHistory.SetColumnSpan(lblTitle, 2);
            lblTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            lblTitle.Location = new Point(211, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(163, 29);
            lblTitle.TabIndex = 7;
            lblTitle.Values.Text = "Historial de Cajas";
            // 
            // dgvSessions
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 239, 249);
            dgvSessions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSessions.BorderStyle = BorderStyle.None;
            dgvSessions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSessions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpHistory.SetColumnSpan(dgvSessions, 2);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSessions.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSessions.Dock = DockStyle.Fill;
            dgvSessions.EnableHeadersVisualStyles = false;
            dgvSessions.Location = new Point(14, 95);
            dgvSessions.MultiSelect = false;
            dgvSessions.Name = "dgvSessions";
            dgvSessions.ReadOnly = true;
            dgvSessions.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvSessions.RowsDefaultCellStyle = dataGridViewCellStyle4;
            tlpHistory.SetRowSpan(dgvSessions, 11);
            dgvSessions.RowTemplate.Height = 35;
            dgvSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSessions.Size = new Size(558, 531);
            dgvSessions.TabIndex = 18;
            dgvSessions.SelectionChanged += dgvSessions_SelectionChanged;
            // 
            // dgvSales
            // 
            dataGridViewCellStyle5.BackColor = Color.FromArgb(238, 239, 249);
            dgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.BorderStyle = BorderStyle.None;
            dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(20, 25, 70);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpHistory.SetColumnSpan(dgvSales, 3);
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = Color.ForestGreen;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvSales.DefaultCellStyle = dataGridViewCellStyle7;
            dgvSales.Dock = DockStyle.Fill;
            dgvSales.EnableHeadersVisualStyles = false;
            dgvSales.Location = new Point(762, 95);
            dgvSales.MultiSelect = false;
            dgvSales.Name = "dgvSales";
            dgvSales.ReadOnly = true;
            dgvSales.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvSales.RowsDefaultCellStyle = dataGridViewCellStyle8;
            tlpHistory.SetRowSpan(dgvSales, 11);
            dgvSales.RowTemplate.Height = 35;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.Size = new Size(500, 531);
            dgvSales.TabIndex = 20;
            // 
            // lblSellsTitle
            // 
            lblSellsTitle.Anchor = AnchorStyles.None;
            lblSellsTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            lblSellsTitle.Location = new Point(978, 54);
            lblSellsTitle.Name = "lblSellsTitle";
            lblSellsTitle.Size = new Size(71, 29);
            lblSellsTitle.TabIndex = 21;
            lblSellsTitle.Values.Text = "Ventas";
            // 
            // btnShowDetails
            // 
            btnShowDetails.Anchor = AnchorStyles.Bottom;
            btnShowDetails.Location = new Point(1135, 49);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(127, 40);
            btnShowDetails.TabIndex = 22;
            btnShowDetails.Values.DropDownArrowColor = Color.Empty;
            btnShowDetails.Values.Text = "Ver Detalle";
            btnShowDetails.Click += btnShowDetails_Click;
            // 
            // cbxUserFilter
            // 
            cbxUserFilter.Anchor = AnchorStyles.None;
            cbxUserFilter.CueHint.CueHintText = "Buscar por Usuario";
            cbxUserFilter.DefaultPalette = Krypton.Toolkit.PaletteMode.Microsoft365Blue;
            cbxUserFilter.DropDownWidth = 162;
            cbxUserFilter.Location = new Point(591, 150);
            cbxUserFilter.Name = "cbxUserFilter";
            cbxUserFilter.Size = new Size(152, 22);
            cbxUserFilter.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cbxUserFilter.TabIndex = 13;
            // 
            // lblSince
            // 
            lblSince.Anchor = AnchorStyles.Bottom;
            lblSince.Location = new Point(644, 337);
            lblSince.Name = "lblSince";
            lblSince.Size = new Size(45, 20);
            lblSince.TabIndex = 14;
            lblSince.Values.Text = "Desde";
            // 
            // dtpSince
            // 
            dtpSince.Anchor = AnchorStyles.Top;
            dtpSince.CalendarFirstDayOfWeek = Day.Monday;
            dtpSince.Location = new Point(591, 363);
            dtpSince.Name = "dtpSince";
            dtpSince.Size = new Size(152, 21);
            dtpSince.TabIndex = 15;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Bottom;
            lblTo.Location = new Point(646, 403);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(41, 20);
            lblTo.TabIndex = 16;
            lblTo.Values.Text = "Hasta";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top;
            dtpTo.CalendarFirstDayOfWeek = Day.Monday;
            dtpTo.Location = new Point(591, 429);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(152, 21);
            dtpTo.TabIndex = 17;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom;
            btnSearch.Location = new Point(603, 467);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(127, 40);
            btnSearch.TabIndex = 19;
            btnSearch.Values.DropDownArrowColor = Color.Empty;
            btnSearch.Values.Text = "Buscar";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnResetFilters
            // 
            btnResetFilters.Anchor = AnchorStyles.Bottom;
            btnResetFilters.Location = new Point(603, 516);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(127, 40);
            btnResetFilters.TabIndex = 10;
            btnResetFilters.Values.DropDownArrowColor = Color.Empty;
            btnResetFilters.Values.Text = "Reiniciar Filtros";
            btnResetFilters.Click += btnResetFilters_Click;
            // 
            // gbxFilters
            // 
            gbxFilters.Controls.Add(tlpFilters);
            gbxFilters.Dock = DockStyle.Fill;
            gbxFilters.Location = new Point(578, 187);
            gbxFilters.Name = "gbxFilters";
            gbxFilters.Size = new Size(178, 137);
            gbxFilters.TabIndex = 23;
            gbxFilters.TabStop = false;
            // 
            // tlpFilters
            // 
            tlpFilters.ColumnCount = 1;
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFilters.Controls.Add(rbtDesDate, 0, 0);
            tlpFilters.Controls.Add(rbtDesName, 0, 1);
            tlpFilters.Dock = DockStyle.Fill;
            tlpFilters.Location = new Point(3, 19);
            tlpFilters.Name = "tlpFilters";
            tlpFilters.RowCount = 2;
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpFilters.Size = new Size(172, 115);
            tlpFilters.TabIndex = 15;
            // 
            // rbtDesDate
            // 
            rbtDesDate.Anchor = AnchorStyles.None;
            rbtDesDate.Checked = true;
            rbtDesDate.Location = new Point(24, 18);
            rbtDesDate.Name = "rbtDesDate";
            rbtDesDate.Size = new Size(124, 20);
            rbtDesDate.TabIndex = 11;
            rbtDesDate.Values.Text = "Ordenar por Fecha";
            // 
            // rbtDesName
            // 
            rbtDesName.Anchor = AnchorStyles.None;
            rbtDesName.Location = new Point(17, 76);
            rbtDesName.Name = "rbtDesName";
            rbtDesName.Size = new Size(138, 20);
            rbtDesName.TabIndex = 12;
            rbtDesName.Values.Text = "Ordenar por Nombre";
            // 
            // UserControlHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpHistory);
            Name = "UserControlHistory";
            Size = new Size(1280, 655);
            Load += UserControlHistory_Load;
            tlpHistory.ResumeLayout(false);
            tlpHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxUserFilter).EndInit();
            gbxFilters.ResumeLayout(false);
            tlpFilters.ResumeLayout(false);
            tlpFilters.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpHistory;
        private Krypton.Toolkit.KryptonLabel lblTitle;
        private Krypton.Toolkit.KryptonTextBox txtFilter;
        private Krypton.Toolkit.KryptonButton btnResetFilters;
        private Krypton.Toolkit.KryptonThemeComboBox cbxUserFilter;
        private Krypton.Toolkit.KryptonLabel lblSince;
        private Krypton.Toolkit.KryptonDateTimePicker dtpSince;
        private Krypton.Toolkit.KryptonLabel lblTo;
        private Krypton.Toolkit.KryptonDateTimePicker dtpTo;
        private DataGridView dgvSessions;
        private DataGridView dgvSales;
        private Krypton.Toolkit.KryptonLabel lblSellsTitle;
        private Krypton.Toolkit.KryptonButton btnSearch;
        private Krypton.Toolkit.KryptonButton btnShowDetails;
        private GroupBox gbxFilters;
        private TableLayoutPanel tlpFilters;
        private Krypton.Toolkit.KryptonRadioButton rbtDesDate;
        private Krypton.Toolkit.KryptonRadioButton rbtDesName;
    }
}
