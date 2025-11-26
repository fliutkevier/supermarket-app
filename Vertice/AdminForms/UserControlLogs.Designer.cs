namespace WinForms
{
    partial class UserControlLogs
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
            tlpHistory = new TableLayoutPanel();
            dgvSessions = new DataGridView();
            txtFilter = new Krypton.Toolkit.KryptonTextBox();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            btnResetFilters = new Krypton.Toolkit.KryptonButton();
            rbtDesDate = new Krypton.Toolkit.KryptonRadioButton();
            rbtDesName = new Krypton.Toolkit.KryptonRadioButton();
            cbxUserFilter = new Krypton.Toolkit.KryptonThemeComboBox();
            lblSince = new Krypton.Toolkit.KryptonLabel();
            dtpSince = new Krypton.Toolkit.KryptonDateTimePicker();
            lblTo = new Krypton.Toolkit.KryptonLabel();
            dtpTo = new Krypton.Toolkit.KryptonDateTimePicker();
            gbxFilters = new GroupBox();
            tlpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxUserFilter).BeginInit();
            gbxFilters.SuspendLayout();
            SuspendLayout();
            // 
            // tlpHistory
            // 
            tlpHistory.ColumnCount = 7;
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.578125F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.765625F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.1601238F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2332916F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2332916F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.2865553F));
            tlpHistory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.6693039F));
            tlpHistory.Controls.Add(dgvSessions, 1, 2);
            tlpHistory.Controls.Add(txtFilter, 1, 1);
            tlpHistory.Controls.Add(lblTitle, 1, 0);
            tlpHistory.Controls.Add(btnResetFilters, 6, 11);
            tlpHistory.Controls.Add(dtpTo, 6, 9);
            tlpHistory.Controls.Add(lblTo, 6, 8);
            tlpHistory.Controls.Add(dtpSince, 6, 7);
            tlpHistory.Controls.Add(lblSince, 6, 6);
            tlpHistory.Controls.Add(cbxUserFilter, 6, 5);
            tlpHistory.Controls.Add(gbxFilters, 6, 4);
            tlpHistory.Dock = DockStyle.Fill;
            tlpHistory.Location = new Point(0, 0);
            tlpHistory.Name = "tlpHistory";
            tlpHistory.RowCount = 14;
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 4.58015251F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 4.27480936F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 13.4351149F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 4.885496F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 9.160305F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 9.770992F));
            tlpHistory.RowStyles.Add(new RowStyle(SizeType.Percent, 3.38235283F));
            tlpHistory.Size = new Size(1280, 655);
            tlpHistory.TabIndex = 1;
            // 
            // dgvSessions
            // 
            dgvSessions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlpHistory.SetColumnSpan(dgvSessions, 5);
            dgvSessions.Location = new Point(36, 97);
            dgvSessions.Name = "dgvSessions";
            tlpHistory.SetRowSpan(dgvSessions, 11);
            dgvSessions.Size = new Size(1013, 531);
            dgvSessions.TabIndex = 9;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.None;
            tlpHistory.SetColumnSpan(txtFilter, 2);
            txtFilter.CueHint.CueHintText = "Buscar";
            txtFilter.Location = new Point(117, 59);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(343, 23);
            txtFilter.TabIndex = 8;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            tlpHistory.SetColumnSpan(lblTitle, 2);
            lblTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            lblTitle.Location = new Point(241, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(94, 29);
            lblTitle.TabIndex = 7;
            lblTitle.Values.Text = "Registros";
            // 
            // btnResetFilters
            // 
            btnResetFilters.Anchor = AnchorStyles.Bottom;
            btnResetFilters.Location = new Point(1102, 524);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(127, 40);
            btnResetFilters.TabIndex = 10;
            btnResetFilters.Values.DropDownArrowColor = Color.Empty;
            btnResetFilters.Values.Text = "Reiniciar Filtros";
            // 
            // rbtDesDate
            // 
            rbtDesDate.Anchor = AnchorStyles.None;
            rbtDesDate.Checked = true;
            rbtDesDate.Location = new Point(47, 22);
            rbtDesDate.Name = "rbtDesDate";
            rbtDesDate.Size = new Size(124, 20);
            rbtDesDate.TabIndex = 11;
            rbtDesDate.Values.Text = "Ordenar por Fecha";
            // 
            // rbtDesName
            // 
            rbtDesName.Anchor = AnchorStyles.None;
            rbtDesName.Location = new Point(47, 56);
            rbtDesName.Name = "rbtDesName";
            rbtDesName.Size = new Size(138, 20);
            rbtDesName.TabIndex = 12;
            rbtDesName.Values.Text = "Ordenar por Nombre";
            // 
            // cbxUserFilter
            // 
            cbxUserFilter.Anchor = AnchorStyles.None;
            cbxUserFilter.CueHint.CueHintText = "Buscar por Usuario";
            cbxUserFilter.DefaultPalette = Krypton.Toolkit.PaletteMode.Microsoft365Blue;
            cbxUserFilter.DropDownWidth = 162;
            cbxUserFilter.Location = new Point(1085, 245);
            cbxUserFilter.Name = "cbxUserFilter";
            cbxUserFilter.Size = new Size(162, 22);
            cbxUserFilter.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            cbxUserFilter.TabIndex = 13;
            // 
            // lblSince
            // 
            lblSince.Anchor = AnchorStyles.Bottom;
            lblSince.Location = new Point(1143, 296);
            lblSince.Name = "lblSince";
            lblSince.Size = new Size(45, 20);
            lblSince.TabIndex = 14;
            lblSince.Values.Text = "Desde";
            // 
            // dtpSince
            // 
            dtpSince.Anchor = AnchorStyles.Top;
            dtpSince.CalendarFirstDayOfWeek = Day.Monday;
            dtpSince.Location = new Point(1055, 322);
            dtpSince.Name = "dtpSince";
            dtpSince.Size = new Size(221, 21);
            dtpSince.TabIndex = 15;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Bottom;
            lblTo.Location = new Point(1145, 390);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(41, 20);
            lblTo.TabIndex = 16;
            lblTo.Values.Text = "Hasta";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top;
            dtpTo.CalendarFirstDayOfWeek = Day.Monday;
            dtpTo.Location = new Point(1055, 416);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(221, 21);
            dtpTo.TabIndex = 17;
            // 
            // gbxFilters
            // 
            gbxFilters.Controls.Add(rbtDesDate);
            gbxFilters.Controls.Add(rbtDesName);
            gbxFilters.Dock = DockStyle.Fill;
            gbxFilters.Location = new Point(1055, 155);
            gbxFilters.Name = "gbxFilters";
            gbxFilters.Size = new Size(222, 82);
            gbxFilters.TabIndex = 18;
            gbxFilters.TabStop = false;
            // 
            // UserControlLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpHistory);
            Name = "UserControlLogs";
            Size = new Size(1280, 655);
            tlpHistory.ResumeLayout(false);
            tlpHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxUserFilter).EndInit();
            gbxFilters.ResumeLayout(false);
            gbxFilters.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpHistory;
        private DataGridView dgvSessions;
        private Krypton.Toolkit.KryptonTextBox txtFilter;
        private Krypton.Toolkit.KryptonLabel lblTitle;
        private Krypton.Toolkit.KryptonButton btnResetFilters;
        private Krypton.Toolkit.KryptonDateTimePicker dtpTo;
        private Krypton.Toolkit.KryptonLabel lblTo;
        private Krypton.Toolkit.KryptonDateTimePicker dtpSince;
        private Krypton.Toolkit.KryptonLabel lblSince;
        private Krypton.Toolkit.KryptonThemeComboBox cbxUserFilter;
        private Krypton.Toolkit.KryptonRadioButton rbtDesName;
        private Krypton.Toolkit.KryptonRadioButton rbtDesDate;
        private GroupBox gbxFilters;
    }
}
