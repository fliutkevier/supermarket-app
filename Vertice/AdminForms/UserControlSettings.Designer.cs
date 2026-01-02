namespace WinForms.AdminForms
{
    partial class UserControlSettings
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
            tlpSettings = new TableLayoutPanel();
            lblTitle = new Krypton.Toolkit.KryptonLabel();
            btnRecicle = new Krypton.Toolkit.KryptonButton();
            tlpSettings.SuspendLayout();
            SuspendLayout();
            // 
            // tlpSettings
            // 
            tlpSettings.ColumnCount = 5;
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSettings.Controls.Add(lblTitle, 0, 0);
            tlpSettings.Controls.Add(btnRecicle, 0, 1);
            tlpSettings.Dock = DockStyle.Fill;
            tlpSettings.Location = new Point(0, 0);
            tlpSettings.Name = "tlpSettings";
            tlpSettings.RowCount = 8;
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpSettings.Size = new Size(1280, 655);
            tlpSettings.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            lblTitle.Location = new Point(90, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(76, 29);
            lblTitle.TabIndex = 8;
            lblTitle.Values.Text = "Ajustes";
            // 
            // btnRecicle
            // 
            btnRecicle.Anchor = AnchorStyles.None;
            tlpSettings.SetColumnSpan(btnRecicle, 2);
            btnRecicle.Location = new Point(100, 101);
            btnRecicle.Name = "btnRecicle";
            btnRecicle.Size = new Size(312, 40);
            btnRecicle.StateCommon.Back.Color1 = Color.FromArgb(160, 205, 254);
            btnRecicle.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecicle.TabIndex = 9;
            btnRecicle.Values.DropDownArrowColor = Color.Empty;
            btnRecicle.Values.Text = "PAPELERA DE RECICLAJE";
            btnRecicle.Click += btnRecicle_Click;
            // 
            // UserControlSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpSettings);
            Name = "UserControlSettings";
            Size = new Size(1280, 655);
            tlpSettings.ResumeLayout(false);
            tlpSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpSettings;
        private Krypton.Toolkit.KryptonLabel lblTitle;
        private Krypton.Toolkit.KryptonButton btnRecicle;
    }
}
