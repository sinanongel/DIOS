namespace KargazImalatTakip
{
    partial class FrmTumImalat
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnExcelAktar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CmbŞirket = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BtnListele = new DevExpress.XtraEditors.SimpleButton();
            this.GrCoForm = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCoForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExcelAktar
            // 
            this.BtnExcelAktar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnExcelAktar.Location = new System.Drawing.Point(712, 6);
            this.BtnExcelAktar.Name = "BtnExcelAktar";
            this.BtnExcelAktar.Size = new System.Drawing.Size(188, 24);
            this.BtnExcelAktar.TabIndex = 19;
            this.BtnExcelAktar.Text = "Excel\'e Aktar";
            this.BtnExcelAktar.Click += new System.EventHandler(this.BtnExcelAktar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Location = new System.Drawing.Point(370, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Şirket";
            // 
            // CmbŞirket
            // 
            this.CmbŞirket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbŞirket.Location = new System.Drawing.Point(403, 8);
            this.CmbŞirket.Name = "CmbŞirket";
            this.CmbŞirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbŞirket.Properties.Items.AddRange(new object[] {
            "KARGAZ",
            "SERHATGAZ"});
            this.CmbŞirket.Size = new System.Drawing.Size(109, 20);
            this.CmbŞirket.TabIndex = 17;
            // 
            // BtnListele
            // 
            this.BtnListele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnListele.Location = new System.Drawing.Point(518, 6);
            this.BtnListele.Name = "BtnListele";
            this.BtnListele.Size = new System.Drawing.Size(188, 24);
            this.BtnListele.TabIndex = 16;
            this.BtnListele.Text = "Listele";
            this.BtnListele.Click += new System.EventHandler(this.BtnListele_Click);
            // 
            // GrCoForm
            // 
            this.GrCoForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrCoForm.Location = new System.Drawing.Point(0, 39);
            this.GrCoForm.MainView = this.gridView1;
            this.GrCoForm.Name = "GrCoForm";
            this.GrCoForm.Size = new System.Drawing.Size(1294, 545);
            this.GrCoForm.TabIndex = 15;
            this.GrCoForm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.GrCoForm;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView1_CustomColumnSort);
            // 
            // FrmTumImalat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 591);
            this.Controls.Add(this.BtnExcelAktar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.CmbŞirket);
            this.Controls.Add(this.BtnListele);
            this.Controls.Add(this.GrCoForm);
            this.Name = "FrmTumImalat";
            this.Text = "FrmTumImalat";
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCoForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnExcelAktar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit CmbŞirket;
        private DevExpress.XtraEditors.SimpleButton BtnListele;
        private DevExpress.XtraGrid.GridControl GrCoForm;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}