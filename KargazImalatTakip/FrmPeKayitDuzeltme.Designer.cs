namespace KargazImalatTakip
{
    partial class FrmPeKayitDuzeltme
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
            this.GrCoHat = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtFormNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtMslink = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TxtYatirimYili = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.TxtImalatTarihi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.TxtSektor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.TxtFormMetraj = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.TxtKaziBoyu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.LblStokKodu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.LblStokAd = new DevExpress.XtraEditors.LabelControl();
            this.CmbBolge = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnListele = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.CmbŞirket = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CmbCap = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.GrCoHat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMslink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYatirimYili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImalatTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSektor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormMetraj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKaziBoyu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBolge.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GrCoHat
            // 
            this.GrCoHat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrCoHat.Location = new System.Drawing.Point(3, 213);
            this.GrCoHat.MainView = this.gridView1;
            this.GrCoHat.Name = "GrCoHat";
            this.GrCoHat.Size = new System.Drawing.Size(1343, 375);
            this.GrCoHat.TabIndex = 14;
            this.GrCoHat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.GrCoHat;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(470, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Mslink No";
            // 
            // TxtFormNo
            // 
            this.TxtFormNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtFormNo.Location = new System.Drawing.Point(810, 23);
            this.TxtFormNo.Name = "TxtFormNo";
            this.TxtFormNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtFormNo.Properties.Appearance.Options.UseFont = true;
            this.TxtFormNo.Size = new System.Drawing.Size(61, 22);
            this.TxtFormNo.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(754, 26);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 16);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Form No";
            // 
            // TxtMslink
            // 
            this.TxtMslink.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtMslink.Enabled = false;
            this.TxtMslink.Location = new System.Drawing.Point(531, 51);
            this.TxtMslink.Name = "TxtMslink";
            this.TxtMslink.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtMslink.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.TxtMslink.Properties.Appearance.Options.UseFont = true;
            this.TxtMslink.Properties.Appearance.Options.UseForeColor = true;
            this.TxtMslink.Size = new System.Drawing.Size(61, 22);
            this.TxtMslink.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(607, 54);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 16);
            this.labelControl4.TabIndex = 37;
            this.labelControl4.Text = "Yatırım Yılı";
            // 
            // TxtYatirimYili
            // 
            this.TxtYatirimYili.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtYatirimYili.Enabled = false;
            this.TxtYatirimYili.Location = new System.Drawing.Point(674, 51);
            this.TxtYatirimYili.Name = "TxtYatirimYili";
            this.TxtYatirimYili.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtYatirimYili.Properties.Appearance.Options.UseFont = true;
            this.TxtYatirimYili.Size = new System.Drawing.Size(49, 22);
            this.TxtYatirimYili.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(779, 54);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 16);
            this.labelControl5.TabIndex = 39;
            this.labelControl5.Text = "İmalat Tarihi";
            // 
            // TxtImalatTarihi
            // 
            this.TxtImalatTarihi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtImalatTarihi.Enabled = false;
            this.TxtImalatTarihi.Location = new System.Drawing.Point(858, 51);
            this.TxtImalatTarihi.Name = "TxtImalatTarihi";
            this.TxtImalatTarihi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtImalatTarihi.Properties.Appearance.Options.UseFont = true;
            this.TxtImalatTarihi.Size = new System.Drawing.Size(76, 22);
            this.TxtImalatTarihi.TabIndex = 8;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(487, 82);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 16);
            this.labelControl8.TabIndex = 41;
            this.labelControl8.Text = "Sektör";
            // 
            // TxtSektor
            // 
            this.TxtSektor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSektor.Enabled = false;
            this.TxtSektor.Location = new System.Drawing.Point(531, 79);
            this.TxtSektor.Name = "TxtSektor";
            this.TxtSektor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtSektor.Properties.Appearance.Options.UseFont = true;
            this.TxtSektor.Size = new System.Drawing.Size(76, 22);
            this.TxtSektor.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(614, 110);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(54, 16);
            this.labelControl7.TabIndex = 45;
            this.labelControl7.Text = "Kazı Boyu";
            // 
            // TxtFormMetraj
            // 
            this.TxtFormMetraj.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtFormMetraj.Location = new System.Drawing.Point(531, 107);
            this.TxtFormMetraj.Name = "TxtFormMetraj";
            this.TxtFormMetraj.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtFormMetraj.Properties.Appearance.Options.UseFont = true;
            this.TxtFormMetraj.Properties.Mask.EditMask = "n";
            this.TxtFormMetraj.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtFormMetraj.Size = new System.Drawing.Size(57, 22);
            this.TxtFormMetraj.TabIndex = 11;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(450, 110);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(74, 16);
            this.labelControl6.TabIndex = 43;
            this.labelControl6.Text = "Form Metrajı";
            // 
            // TxtKaziBoyu
            // 
            this.TxtKaziBoyu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtKaziBoyu.Location = new System.Drawing.Point(674, 107);
            this.TxtKaziBoyu.Name = "TxtKaziBoyu";
            this.TxtKaziBoyu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.TxtKaziBoyu.Properties.Appearance.Options.UseFont = true;
            this.TxtKaziBoyu.Properties.Mask.EditMask = "n";
            this.TxtKaziBoyu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtKaziBoyu.Size = new System.Drawing.Size(57, 22);
            this.TxtKaziBoyu.TabIndex = 12;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(645, 82);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(22, 16);
            this.labelControl10.TabIndex = 51;
            this.labelControl10.Text = "Çap";
            // 
            // LblStokKodu
            // 
            this.LblStokKodu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblStokKodu.Appearance.ForeColor = System.Drawing.Color.Red;
            this.LblStokKodu.Appearance.Options.UseForeColor = true;
            this.LblStokKodu.Location = new System.Drawing.Point(739, 84);
            this.LblStokKodu.Name = "LblStokKodu";
            this.LblStokKodu.Size = new System.Drawing.Size(36, 13);
            this.LblStokKodu.TabIndex = 53;
            this.LblStokKodu.Text = "---------";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.Location = new System.Drawing.Point(783, 84);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(4, 13);
            this.labelControl11.TabIndex = 54;
            this.labelControl11.Text = "-";
            // 
            // LblStokAd
            // 
            this.LblStokAd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblStokAd.Appearance.ForeColor = System.Drawing.Color.Red;
            this.LblStokAd.Appearance.Options.UseForeColor = true;
            this.LblStokAd.Location = new System.Drawing.Point(795, 84);
            this.LblStokAd.Name = "LblStokAd";
            this.LblStokAd.Size = new System.Drawing.Size(96, 13);
            this.LblStokAd.TabIndex = 55;
            this.LblStokAd.Text = "------------------------";
            // 
            // CmbBolge
            // 
            this.CmbBolge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbBolge.Location = new System.Drawing.Point(599, 23);
            this.CmbBolge.Name = "CmbBolge";
            this.CmbBolge.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CmbBolge.Properties.Appearance.Options.UseFont = true;
            this.CmbBolge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbBolge.Size = new System.Drawing.Size(144, 22);
            this.CmbBolge.TabIndex = 62;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(561, 26);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(31, 16);
            this.labelControl13.TabIndex = 61;
            this.labelControl13.Text = "Bölge";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(1028, 28);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(69, 13);
            this.labelControl15.TabIndex = 63;
            this.labelControl15.Text = "labelControl15";
            this.labelControl15.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GrCoHat, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1349, 591);
            this.tableLayoutPanel1.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.CmbCap);
            this.panel2.Controls.Add(this.BtnTemizle);
            this.panel2.Controls.Add(this.BtnSil);
            this.panel2.Controls.Add(this.BtnGuncelle);
            this.panel2.Controls.Add(this.labelControl15);
            this.panel2.Controls.Add(this.LblStokAd);
            this.panel2.Controls.Add(this.BtnListele);
            this.panel2.Controls.Add(this.labelControl11);
            this.panel2.Controls.Add(this.CmbBolge);
            this.panel2.Controls.Add(this.LblStokKodu);
            this.panel2.Controls.Add(this.labelControl9);
            this.panel2.Controls.Add(this.labelControl10);
            this.panel2.Controls.Add(this.labelControl13);
            this.panel2.Controls.Add(this.CmbŞirket);
            this.panel2.Controls.Add(this.labelControl7);
            this.panel2.Controls.Add(this.TxtFormNo);
            this.panel2.Controls.Add(this.TxtFormMetraj);
            this.panel2.Controls.Add(this.labelControl3);
            this.panel2.Controls.Add(this.labelControl6);
            this.panel2.Controls.Add(this.TxtMslink);
            this.panel2.Controls.Add(this.TxtKaziBoyu);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.labelControl4);
            this.panel2.Controls.Add(this.TxtSektor);
            this.panel2.Controls.Add(this.TxtYatirimYili);
            this.panel2.Controls.Add(this.labelControl8);
            this.panel2.Controls.Add(this.labelControl5);
            this.panel2.Controls.Add(this.TxtImalatTarihi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1343, 204);
            this.panel2.TabIndex = 65;
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnTemizle.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.BtnTemizle.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnTemizle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnTemizle.Appearance.Options.UseBackColor = true;
            this.BtnTemizle.Appearance.Options.UseFont = true;
            this.BtnTemizle.Appearance.Options.UseForeColor = true;
            this.BtnTemizle.Location = new System.Drawing.Point(495, 154);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(115, 25);
            this.BtnTemizle.TabIndex = 79;
            this.BtnTemizle.Text = "Temizle";
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSil.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.BtnSil.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnSil.Appearance.Options.UseBackColor = true;
            this.BtnSil.Appearance.Options.UseFont = true;
            this.BtnSil.Location = new System.Drawing.Point(737, 154);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(115, 25);
            this.BtnSil.TabIndex = 78;
            this.BtnSil.Text = "Sil";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuncelle.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.BtnGuncelle.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnGuncelle.Appearance.Options.UseBackColor = true;
            this.BtnGuncelle.Appearance.Options.UseFont = true;
            this.BtnGuncelle.Location = new System.Drawing.Point(616, 154);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(115, 25);
            this.BtnGuncelle.TabIndex = 13;
            this.BtnGuncelle.Text = "Güncelle";
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnListele
            // 
            this.BtnListele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnListele.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.BtnListele.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.BtnListele.Appearance.Options.UseBackColor = true;
            this.BtnListele.Appearance.Options.UseFont = true;
            this.BtnListele.Location = new System.Drawing.Point(887, 23);
            this.BtnListele.Name = "BtnListele";
            this.BtnListele.Size = new System.Drawing.Size(115, 22);
            this.BtnListele.TabIndex = 1;
            this.BtnListele.Text = "Listele";
            this.BtnListele.Click += new System.EventHandler(this.BtnListele_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(398, 26);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(33, 16);
            this.labelControl9.TabIndex = 3;
            this.labelControl9.Text = "Firma";
            // 
            // CmbŞirket
            // 
            this.CmbŞirket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbŞirket.Location = new System.Drawing.Point(436, 23);
            this.CmbŞirket.Name = "CmbŞirket";
            this.CmbŞirket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.CmbŞirket.Properties.Appearance.Options.UseFont = true;
            this.CmbŞirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbŞirket.Properties.Items.AddRange(new object[] {
            "KARGAZ",
            "SERHATGAZ"});
            this.CmbŞirket.Size = new System.Drawing.Size(109, 22);
            this.CmbŞirket.TabIndex = 2;
            this.CmbŞirket.SelectedIndexChanged += new System.EventHandler(this.CmbŞirket_SelectedIndexChanged);
            // 
            // CmbCap
            // 
            this.CmbCap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbCap.Location = new System.Drawing.Point(674, 79);
            this.CmbCap.Name = "CmbCap";
            this.CmbCap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CmbCap.Properties.Appearance.Options.UseFont = true;
            this.CmbCap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbCap.Size = new System.Drawing.Size(57, 22);
            this.CmbCap.TabIndex = 80;
            this.CmbCap.SelectedIndexChanged += new System.EventHandler(this.CmbCap_SelectedIndexChanged);
            // 
            // FrmPeKayitDuzeltme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1349, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1365, 630);
            this.Name = "FrmPeKayitDuzeltme";
            this.Text = "PE Kayıt Düzeltme";
            ((System.ComponentModel.ISupportInitialize)(this.GrCoHat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMslink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtYatirimYili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImalatTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSektor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormMetraj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKaziBoyu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBolge.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbŞirket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCap.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl GrCoHat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtFormNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtMslink;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit TxtYatirimYili;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit TxtImalatTarihi;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit TxtSektor;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit TxtFormMetraj;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit TxtKaziBoyu;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl LblStokKodu;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl LblStokAd;
        private DevExpress.XtraEditors.ComboBoxEdit CmbBolge;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnListele;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit CmbŞirket;
        private DevExpress.XtraEditors.SimpleButton BtnTemizle;
        private DevExpress.XtraEditors.ComboBoxEdit CmbCap;
    }
}