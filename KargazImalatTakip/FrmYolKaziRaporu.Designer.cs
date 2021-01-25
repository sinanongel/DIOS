using System;

namespace KargazImalatTakip
{
    partial class FrmYolKaziRaporu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYolKaziRaporu));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.BtnGenelPdf = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGenelExcel = new DevExpress.XtraEditors.SimpleButton();
            this.LblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.BtnGenelListele = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CmbGenelBolge = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.CmbGenelŞirket = new DevExpress.XtraEditors.ComboBoxEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.LblTarihAraligi = new DevExpress.XtraEditors.LabelControl();
            this.DtBitisTarihi = new DevExpress.XtraEditors.DateEdit();
            this.DtBaslangicTarihi = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.BtnDetayPdf = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDetayExcel = new DevExpress.XtraEditors.SimpleButton();
            this.LblDetayBaslik = new DevExpress.XtraEditors.LabelControl();
            this.BtnDetayListele = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.CmbDetayBolge = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.CmbDetaySirket = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbGenelBolge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbGenelŞirket.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtBitisTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBitisTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBaslangicTarihi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBaslangicTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbDetayBolge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbDetaySirket.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1349, 591);
            this.xtraTabControl1.TabIndex = 14;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.BtnGenelPdf);
            this.xtraTabPage1.Controls.Add(this.BtnGenelExcel);
            this.xtraTabPage1.Controls.Add(this.LblBaslik);
            this.xtraTabPage1.Controls.Add(this.BtnGenelListele);
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.CmbGenelBolge);
            this.xtraTabPage1.Controls.Add(this.labelControl13);
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.CmbGenelŞirket);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1347, 566);
            this.xtraTabPage1.Text = "Genel Rapor";
            // 
            // BtnGenelPdf
            // 
            this.BtnGenelPdf.Location = new System.Drawing.Point(22, 243);
            this.BtnGenelPdf.Name = "BtnGenelPdf";
            this.BtnGenelPdf.Size = new System.Drawing.Size(188, 24);
            this.BtnGenelPdf.TabIndex = 67;
            this.BtnGenelPdf.Text = "PDF";
            this.BtnGenelPdf.Click += new System.EventHandler(this.BtnGenelPdf_Click);
            // 
            // BtnGenelExcel
            // 
            this.BtnGenelExcel.Location = new System.Drawing.Point(22, 213);
            this.BtnGenelExcel.Name = "BtnGenelExcel";
            this.BtnGenelExcel.Size = new System.Drawing.Size(188, 24);
            this.BtnGenelExcel.TabIndex = 66;
            this.BtnGenelExcel.Text = "Excel";
            this.BtnGenelExcel.Click += new System.EventHandler(this.BtnGenelExcel_Click);
            // 
            // LblBaslik
            // 
            this.LblBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblBaslik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.LblBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.LblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblBaslik.Appearance.Options.UseBackColor = true;
            this.LblBaslik.Appearance.Options.UseFont = true;
            this.LblBaslik.Appearance.Options.UseForeColor = true;
            this.LblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblBaslik.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.LblBaslik.Location = new System.Drawing.Point(235, 0);
            this.LblBaslik.Name = "LblBaslik";
            this.LblBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LblBaslik.Size = new System.Drawing.Size(1112, 30);
            this.LblBaslik.TabIndex = 65;
            // 
            // BtnGenelListele
            // 
            this.BtnGenelListele.Location = new System.Drawing.Point(22, 183);
            this.BtnGenelListele.Name = "BtnGenelListele";
            this.BtnGenelListele.Size = new System.Drawing.Size(188, 24);
            this.BtnGenelListele.TabIndex = 64;
            this.BtnGenelListele.Text = "Listele";
            this.BtnGenelListele.Click += new System.EventHandler(this.BtnGenelListele_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(235, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1112, 539);
            this.gridControl1.TabIndex = 63;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(83, 86);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 62;
            this.labelControl1.Text = "labelControl15";
            this.labelControl1.Visible = false;
            // 
            // CmbGenelBolge
            // 
            this.CmbGenelBolge.Location = new System.Drawing.Point(70, 58);
            this.CmbGenelBolge.Name = "CmbGenelBolge";
            this.CmbGenelBolge.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CmbGenelBolge.Properties.Appearance.Options.UseFont = true;
            this.CmbGenelBolge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbGenelBolge.Size = new System.Drawing.Size(140, 22);
            this.CmbGenelBolge.TabIndex = 60;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(22, 61);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(31, 16);
            this.labelControl13.TabIndex = 58;
            this.labelControl13.Text = "Bölge";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(22, 37);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(33, 16);
            this.labelControl9.TabIndex = 61;
            this.labelControl9.Text = "Şirket";
            // 
            // CmbGenelŞirket
            // 
            this.CmbGenelŞirket.Location = new System.Drawing.Point(70, 34);
            this.CmbGenelŞirket.Name = "CmbGenelŞirket";
            this.CmbGenelŞirket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CmbGenelŞirket.Properties.Appearance.Options.UseFont = true;
            this.CmbGenelŞirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbGenelŞirket.Properties.Items.AddRange(new object[] {
            "KARGAZ",
            "SERHATGAZ"});
            this.CmbGenelŞirket.Size = new System.Drawing.Size(97, 22);
            this.CmbGenelŞirket.TabIndex = 59;
            this.CmbGenelŞirket.SelectedIndexChanged += new System.EventHandler(this.CmbGenelŞirket_SelectedIndexChanged);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.LblTarihAraligi);
            this.xtraTabPage2.Controls.Add(this.DtBitisTarihi);
            this.xtraTabPage2.Controls.Add(this.DtBaslangicTarihi);
            this.xtraTabPage2.Controls.Add(this.labelControl2);
            this.xtraTabPage2.Controls.Add(this.labelControl6);
            this.xtraTabPage2.Controls.Add(this.BtnDetayPdf);
            this.xtraTabPage2.Controls.Add(this.BtnDetayExcel);
            this.xtraTabPage2.Controls.Add(this.LblDetayBaslik);
            this.xtraTabPage2.Controls.Add(this.BtnDetayListele);
            this.xtraTabPage2.Controls.Add(this.gridControl2);
            this.xtraTabPage2.Controls.Add(this.labelControl3);
            this.xtraTabPage2.Controls.Add(this.CmbDetayBolge);
            this.xtraTabPage2.Controls.Add(this.labelControl4);
            this.xtraTabPage2.Controls.Add(this.labelControl5);
            this.xtraTabPage2.Controls.Add(this.CmbDetaySirket);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1347, 566);
            this.xtraTabPage2.Text = "Detay Rapor";
            this.xtraTabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage2_Paint);
            // 
            // LblTarihAraligi
            // 
            this.LblTarihAraligi.AllowHtmlString = true;
            this.LblTarihAraligi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTarihAraligi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.LblTarihAraligi.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.LblTarihAraligi.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblTarihAraligi.Appearance.Options.UseBackColor = true;
            this.LblTarihAraligi.Appearance.Options.UseFont = true;
            this.LblTarihAraligi.Appearance.Options.UseForeColor = true;
            this.LblTarihAraligi.Appearance.Options.UseTextOptions = true;
            this.LblTarihAraligi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.LblTarihAraligi.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LblTarihAraligi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblTarihAraligi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.LblTarihAraligi.Location = new System.Drawing.Point(948, 42);
            this.LblTarihAraligi.Name = "LblTarihAraligi";
            this.LblTarihAraligi.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.LblTarihAraligi.Size = new System.Drawing.Size(399, 30);
            this.LblTarihAraligi.TabIndex = 80;
            // 
            // DtBitisTarihi
            // 
            this.DtBitisTarihi.EditValue = null;
            this.DtBitisTarihi.Location = new System.Drawing.Point(606, 9);
            this.DtBitisTarihi.Name = "DtBitisTarihi";
            this.DtBitisTarihi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.DtBitisTarihi.Properties.Appearance.Options.UseFont = true;
            this.DtBitisTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtBitisTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtBitisTarihi.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtBitisTarihi.Size = new System.Drawing.Size(90, 22);
            this.DtBitisTarihi.TabIndex = 79;
            // 
            // DtBaslangicTarihi
            // 
            this.DtBaslangicTarihi.EditValue = null;
            this.DtBaslangicTarihi.Location = new System.Drawing.Point(444, 9);
            this.DtBaslangicTarihi.Name = "DtBaslangicTarihi";
            this.DtBaslangicTarihi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.DtBaslangicTarihi.Properties.Appearance.Options.UseFont = true;
            this.DtBaslangicTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtBaslangicTarihi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtBaslangicTarihi.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtBaslangicTarihi.Size = new System.Drawing.Size(90, 22);
            this.DtBaslangicTarihi.TabIndex = 78;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(348, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 16);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "Başlangıç Tarihi";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(540, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 16);
            this.labelControl6.TabIndex = 76;
            this.labelControl6.Text = "Bitiş Tarihi";
            // 
            // BtnDetayPdf
            // 
            this.BtnDetayPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDetayPdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnDetayPdf.ImageOptions.Image")));
            this.BtnDetayPdf.Location = new System.Drawing.Point(1310, 6);
            this.BtnDetayPdf.Name = "BtnDetayPdf";
            this.BtnDetayPdf.Size = new System.Drawing.Size(34, 30);
            this.BtnDetayPdf.TabIndex = 75;
            this.BtnDetayPdf.Click += new System.EventHandler(this.BtnDetayPdf_Click);
            // 
            // BtnDetayExcel
            // 
            this.BtnDetayExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDetayExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnDetayExcel.ImageOptions.Image")));
            this.BtnDetayExcel.Location = new System.Drawing.Point(1270, 6);
            this.BtnDetayExcel.Name = "BtnDetayExcel";
            this.BtnDetayExcel.Size = new System.Drawing.Size(34, 30);
            this.BtnDetayExcel.TabIndex = 74;
            this.BtnDetayExcel.Click += new System.EventHandler(this.BtnDetayExcel_Click);
            // 
            // LblDetayBaslik
            // 
            this.LblDetayBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDetayBaslik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.LblDetayBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.LblDetayBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblDetayBaslik.Appearance.Options.UseBackColor = true;
            this.LblDetayBaslik.Appearance.Options.UseFont = true;
            this.LblDetayBaslik.Appearance.Options.UseForeColor = true;
            this.LblDetayBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblDetayBaslik.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.LblDetayBaslik.Location = new System.Drawing.Point(0, 42);
            this.LblDetayBaslik.Name = "LblDetayBaslik";
            this.LblDetayBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LblDetayBaslik.Size = new System.Drawing.Size(948, 30);
            this.LblDetayBaslik.TabIndex = 73;
            // 
            // BtnDetayListele
            // 
            this.BtnDetayListele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDetayListele.Location = new System.Drawing.Point(1151, 6);
            this.BtnDetayListele.Name = "BtnDetayListele";
            this.BtnDetayListele.Size = new System.Drawing.Size(113, 30);
            this.BtnDetayListele.TabIndex = 72;
            this.BtnDetayListele.Text = "Listele";
            this.BtnDetayListele.Click += new System.EventHandler(this.BtnDetayListele_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(0, 72);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1348, 495);
            this.gridControl2.TabIndex = 71;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView2.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowFooter = true;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(1050, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 70;
            this.labelControl3.Text = "labelControl15";
            this.labelControl3.Visible = false;
            // 
            // CmbDetayBolge
            // 
            this.CmbDetayBolge.Location = new System.Drawing.Point(202, 9);
            this.CmbDetayBolge.Name = "CmbDetayBolge";
            this.CmbDetayBolge.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CmbDetayBolge.Properties.Appearance.Options.UseFont = true;
            this.CmbDetayBolge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbDetayBolge.Size = new System.Drawing.Size(140, 22);
            this.CmbDetayBolge.TabIndex = 68;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(165, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 16);
            this.labelControl4.TabIndex = 66;
            this.labelControl4.Text = "Bölge";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(22, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 16);
            this.labelControl5.TabIndex = 69;
            this.labelControl5.Text = "Şirket";
            // 
            // CmbDetaySirket
            // 
            this.CmbDetaySirket.Location = new System.Drawing.Point(62, 9);
            this.CmbDetaySirket.Name = "CmbDetaySirket";
            this.CmbDetaySirket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CmbDetaySirket.Properties.Appearance.Options.UseFont = true;
            this.CmbDetaySirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbDetaySirket.Properties.Items.AddRange(new object[] {
            "KARGAZ",
            "SERHATGAZ"});
            this.CmbDetaySirket.Size = new System.Drawing.Size(97, 22);
            this.CmbDetaySirket.TabIndex = 67;
            this.CmbDetaySirket.SelectedIndexChanged += new System.EventHandler(this.CmbDetaySirket_SelectedIndexChanged);
            // 
            // FrmYolKaziRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 591);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmYolKaziRaporu";
            this.Text = "Yol/Kazı Raporu";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbGenelBolge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbGenelŞirket.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtBitisTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBitisTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBaslangicTarihi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtBaslangicTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbDetayBolge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbDetaySirket.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit CmbGenelBolge;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit CmbGenelŞirket;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton BtnGenelListele;
        private DevExpress.XtraEditors.LabelControl LblBaslik;
        private DevExpress.XtraEditors.LabelControl LblDetayBaslik;
        private DevExpress.XtraEditors.SimpleButton BtnDetayListele;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit CmbDetayBolge;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit CmbDetaySirket;
        private DevExpress.XtraEditors.SimpleButton BtnGenelExcel;
        private DevExpress.XtraEditors.SimpleButton BtnDetayExcel;
        private DevExpress.XtraEditors.SimpleButton BtnGenelPdf;
        private DevExpress.XtraEditors.SimpleButton BtnDetayPdf;
        private DevExpress.XtraEditors.DateEdit DtBitisTarihi;
        private DevExpress.XtraEditors.DateEdit DtBaslangicTarihi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl LblTarihAraligi;
    }
}