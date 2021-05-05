namespace KargazImalatTakip
{
    partial class FrmServisHatlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServisHatlar));
            this.BtnExcelAktar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnKoordinatlıListele = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPdf = new DevExpress.XtraEditors.SimpleButton();
            this.BtnListe = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.CmbŞirket = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BtnForDetay = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExcelAktar
            // 
            this.BtnExcelAktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExcelAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcelAktar.ImageOptions.Image")));
            this.BtnExcelAktar.Location = new System.Drawing.Point(1214, 8);
            this.BtnExcelAktar.Name = "BtnExcelAktar";
            this.BtnExcelAktar.Size = new System.Drawing.Size(34, 34);
            this.BtnExcelAktar.TabIndex = 14;
            this.BtnExcelAktar.Click += new System.EventHandler(this.BtnExcelAktar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1294, 540);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "SERVİS HATTI LİSTESİ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.BtnForDetay);
            this.panel2.Controls.Add(this.BtnKoordinatlıListele);
            this.panel2.Controls.Add(this.BtnExcelAktar);
            this.panel2.Controls.Add(this.BtnPdf);
            this.panel2.Controls.Add(this.BtnListe);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.CmbŞirket);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1293, 50);
            this.panel2.TabIndex = 15;
            // 
            // BtnKoordinatlıListele
            // 
            this.BtnKoordinatlıListele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnKoordinatlıListele.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.BtnKoordinatlıListele.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnKoordinatlıListele.Appearance.Options.UseBackColor = true;
            this.BtnKoordinatlıListele.Appearance.Options.UseFont = true;
            this.BtnKoordinatlıListele.Location = new System.Drawing.Point(1093, 8);
            this.BtnKoordinatlıListele.Name = "BtnKoordinatlıListele";
            this.BtnKoordinatlıListele.Size = new System.Drawing.Size(115, 34);
            this.BtnKoordinatlıListele.TabIndex = 16;
            this.BtnKoordinatlıListele.Text = "Koordinatlı Liste";
            this.BtnKoordinatlıListele.Click += new System.EventHandler(this.BtnKoordinatlıListele_Click);
            // 
            // BtnPdf
            // 
            this.BtnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnPdf.ImageOptions.Image")));
            this.BtnPdf.Location = new System.Drawing.Point(1253, 8);
            this.BtnPdf.Name = "BtnPdf";
            this.BtnPdf.Size = new System.Drawing.Size(34, 34);
            this.BtnPdf.TabIndex = 77;
            this.BtnPdf.Click += new System.EventHandler(this.BtnPdf_Click);
            // 
            // BtnListe
            // 
            this.BtnListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnListe.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.BtnListe.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnListe.Appearance.Options.UseBackColor = true;
            this.BtnListe.Appearance.Options.UseFont = true;
            this.BtnListe.Location = new System.Drawing.Point(972, 8);
            this.BtnListe.Name = "BtnListe";
            this.BtnListe.Size = new System.Drawing.Size(115, 34);
            this.BtnListe.TabIndex = 1;
            this.BtnListe.Text = "Listele";
            this.BtnListe.Click += new System.EventHandler(this.BtnListe_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(18, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 17);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Firma";
            // 
            // CmbŞirket
            // 
            this.CmbŞirket.Location = new System.Drawing.Point(56, 13);
            this.CmbŞirket.Name = "CmbŞirket";
            this.CmbŞirket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.CmbŞirket.Properties.Appearance.Options.UseFont = true;
            this.CmbŞirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbŞirket.Properties.Items.AddRange(new object[] {
            "KARGAZ",
            "SERHATGAZ"});
            this.CmbŞirket.Size = new System.Drawing.Size(109, 24);
            this.CmbŞirket.TabIndex = 2;
            // 
            // BtnForDetay
            // 
            this.BtnForDetay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnForDetay.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.BtnForDetay.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnForDetay.Appearance.Options.UseBackColor = true;
            this.BtnForDetay.Appearance.Options.UseFont = true;
            this.BtnForDetay.Location = new System.Drawing.Point(851, 8);
            this.BtnForDetay.Name = "BtnForDetay";
            this.BtnForDetay.Size = new System.Drawing.Size(115, 34);
            this.BtnForDetay.TabIndex = 79;
            this.BtnForDetay.Text = "Form Detay";
            this.BtnForDetay.Click += new System.EventHandler(this.BtnForDetay_Click);
            // 
            // FrmServisHatlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 591);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmServisHatlar";
            this.Text = "Servis Hatlar";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnExcelAktar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton BtnPdf;
        private DevExpress.XtraEditors.SimpleButton BtnListe;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit CmbŞirket;
        private DevExpress.XtraEditors.SimpleButton BtnKoordinatlıListele;
        private DevExpress.XtraEditors.SimpleButton BtnForDetay;
    }
}