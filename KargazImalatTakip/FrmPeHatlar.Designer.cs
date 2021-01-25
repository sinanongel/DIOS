namespace KargazImalatTakip
{
    partial class FrmPeHatlar
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BtnListele = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExcelAktar = new DevExpress.XtraEditors.SimpleButton();
            this.CmbŞirket = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1294, 537);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // BtnListele
            // 
            this.BtnListele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnListele.Location = new System.Drawing.Point(515, 12);
            this.BtnListele.Name = "BtnListele";
            this.BtnListele.Size = new System.Drawing.Size(188, 24);
            this.BtnListele.TabIndex = 1;
            this.BtnListele.Text = "Listele";
            this.BtnListele.Click += new System.EventHandler(this.BtnListele_Click);
            // 
            // BtnExcelAktar
            // 
            this.BtnExcelAktar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnExcelAktar.Location = new System.Drawing.Point(709, 12);
            this.BtnExcelAktar.Name = "BtnExcelAktar";
            this.BtnExcelAktar.Size = new System.Drawing.Size(188, 24);
            this.BtnExcelAktar.TabIndex = 4;
            this.BtnExcelAktar.Text = "Excel\'e Aktar";
            this.BtnExcelAktar.Click += new System.EventHandler(this.BtnExcelAktar_Click);
            // 
            // CmbŞirket
            // 
            this.CmbŞirket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbŞirket.Location = new System.Drawing.Point(400, 14);
            this.CmbŞirket.Name = "CmbŞirket";
            this.CmbŞirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbŞirket.Properties.Items.AddRange(new object[] {
            "KARGAZ",
            "SERHATGAZ"});
            this.CmbŞirket.Size = new System.Drawing.Size(109, 20);
            this.CmbŞirket.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Location = new System.Drawing.Point(367, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Firma";
            // 
            // FrmPeHatlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 591);
            this.Controls.Add(this.BtnExcelAktar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.CmbŞirket);
            this.Controls.Add(this.BtnListele);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmPeHatlar";
            this.Text = "PE Hatlar";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton BtnListele;
        private DevExpress.XtraEditors.SimpleButton BtnExcelAktar;
        private DevExpress.XtraEditors.ComboBoxEdit CmbŞirket;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}