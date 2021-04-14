using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;

namespace KargazImalatTakip
{
    public partial class FrmPeHatlar : Form
    {
        public FrmPeHatlar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        public string yetkiGrup;

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            //try
            //{
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                            "M.MAHALLE_ADI AS MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YOL_BOYU, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, FORMNO, " +
                            "FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, " +
                            "DOSYA FROM dbo.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE H.MALZEME_CINSI = 'Polietilen' " +
                            "ORDER BY H.MSLINK DESC", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                            "M.MAHALLE_ADI AS MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YOL_BOYU, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, FORMNO, " +
                            "FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, " +
                            "DOSYA FROM dbo.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE H.MALZEME_CINSI = 'Polietilen' " +
                            "ORDER BY H.MSLINK DESC", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView1.Columns["FORMNO"].Caption = "FORM NO";
                gridView1.Columns["FROM_ID"].Caption = "FROM ID";
                gridView1.Columns["FROM_MSLINK"].Caption = "FROM MSLINK";
                gridView1.Columns["TO_ID"].Caption = "TO ID";
                gridView1.Columns["TO_MSLINK"].Caption = "TO MSLINK";
                gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                gridView1.Columns["BORU_UZUNLUGU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["BORU_UZUNLUGU"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                gridView1.Columns["ASBUILT_METRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["ASBUILT_METRAJ"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";
                gridView1.Columns["KAZI_BOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["KAZI_BOYU"].DisplayFormat.FormatString = "{0:n2}";

                RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                //RepositoryItemButtonEdit dosyaYolu = new RepositoryItemButtonEdit();
                //    dosyaYolu.Buttons[0].Kind = ButtonPredefines.Glyph;
                //    dosyaYolu.Buttons[0].Caption = "Get Sql Query";
                //    dosyaYolu.ButtonClick += DosyaYolu_ButtonClick;
                //gridView1.Columns["DOSYA_YOLU"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;


                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[0].SummaryItem.DisplayFormat = "{0:0.##} ADET";
                gridView1.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[6].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[15].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[16].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[17].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[18].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[18].SummaryItem.DisplayFormat = "{0:0.##}";

                GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORU_UZUNLUGU"];
                gridView1.GroupSummary.Add(boruUzunlugu);

                GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
                yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
                yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
                gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

                GridGroupSummaryItem asbuiltMetraj = new GridGroupSummaryItem();
                asbuiltMetraj.FieldName = "ASBUILT_METRAJ";
                asbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                asbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                asbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["ASBUILT_METRAJ"];
                gridView1.GroupSummary.Add(asbuiltMetraj);

                GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                kaziBoyu.FieldName = "KAZI_BOYU";
                kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZI_BOYU"];
                gridView1.GroupSummary.Add(kaziBoyu);
            //}
            //catch
            //{
            //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        string kayitYolu = "";

        private void DosyaYolu_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");

            string yol;
            string bolge;
            string dosya;

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                dosya = dr["DOSYA"].ToString();
                bolge = dr["ILCE_ADI"].ToString();
                kayitYolu = satir[5] + bolge + "\\";
                yol = kayitYolu + dosya;
                //yol = dr["DOSYA_YOLU"].ToString();
                Process.Start(yol);
            }

            //FileInfo dosyaBilgi = new FileInfo();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Hat Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için.
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Hat Listesi.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için.
            Process.Start(yol);
        }

        private void BtnKoordinatlıListele_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                            "M.MAHALLE_ADI AS MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YOL_BOYU, H.YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, H.FORMNO, " +
                            "BF.KONUM_X_KOOR AS FROM_X, BF.KONUM_Y_KOOR AS FROM_Y, BF.DERINLIK AS FROM_Z, " +
                            "BT.KONUM_X_KOOR AS TO_X, BT.KONUM_Y_KOOR AS TO_Y, BT.DERINLIK AS TO_Z, " +
                            "NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU " +
                            "FROM dbo.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "LEFT JOIN DBO.BAGLANTI_ELEMANLARI_PE BF ON H.FROM_MSLINK = BF.MSLINK " +
                            "LEFT JOIN DBO.BAGLANTI_ELEMANLARI_PE BT ON H.TO_MSLINK = BT.MSLINK " +
                            "WHERE H.MALZEME_CINSI = 'Polietilen' " +
                            "ORDER BY H.MSLINK DESC", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                            "M.MAHALLE_ADI AS MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YOL_BOYU, H.YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, H.FORMNO, " +
                            "BF.KONUM_X_KOOR AS FROM_X, BF.KONUM_Y_KOOR AS FROM_Y, BF.DERINLIK AS FROM_Z, " +
                            "BT.KONUM_X_KOOR AS TO_X, BT.KONUM_Y_KOOR AS TO_Y, BT.DERINLIK AS TO_Z, " +
                            "NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU " +
                            "FROM dbo.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "LEFT JOIN DBO.BAGLANTI_ELEMANLARI_PE BF ON H.FROM_MSLINK = BF.MSLINK " +
                            "LEFT JOIN DBO.BAGLANTI_ELEMANLARI_PE BT ON H.TO_MSLINK = BT.MSLINK " +
                            "WHERE H.MALZEME_CINSI = 'Polietilen' " +
                            "ORDER BY H.MSLINK DESC", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView1.Columns["FORMNO"].Caption = "FORM NO";
                gridView1.Columns["FROM_X"].Caption = "FROM X";
                gridView1.Columns["FROM_X"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["FROM_X"].DisplayFormat.FormatString = "{0:n3}";
                gridView1.Columns["FROM_Y"].Caption = "FROM Y";
                gridView1.Columns["FROM_Y"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["FROM_Y"].DisplayFormat.FormatString = "{0:n3}";
                gridView1.Columns["FROM_Z"].Caption = "FROM Z";
                gridView1.Columns["FROM_Z"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["FROM_Z"].DisplayFormat.FormatString = "{0:n3}";
                gridView1.Columns["TO_X"].Caption = "TO X";
                gridView1.Columns["TO_X"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["TO_X"].DisplayFormat.FormatString = "{0:n3}";
                gridView1.Columns["TO_Y"].Caption = "TO Y";
                gridView1.Columns["TO_Y"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["TO_Y"].DisplayFormat.FormatString = "{0:n3}";
                gridView1.Columns["TO_Z"].Caption = "TO Z";
                gridView1.Columns["TO_Z"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["TO_Z"].DisplayFormat.FormatString = "{0:n3}";
                gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                gridView1.Columns["BORU_UZUNLUGU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["BORU_UZUNLUGU"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                gridView1.Columns["ASBUILT_METRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["ASBUILT_METRAJ"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";
                gridView1.Columns["KAZI_BOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["KAZI_BOYU"].DisplayFormat.FormatString = "{0:n2}";

                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[0].SummaryItem.DisplayFormat = "{0:0.##} ADET";
                gridView1.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[6].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[17].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[18].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[18].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[19].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[19].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[20].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[20].SummaryItem.DisplayFormat = "{0:0.##}";

                GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORU_UZUNLUGU"];
                gridView1.GroupSummary.Add(boruUzunlugu);

                GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
                yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
                yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
                gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

                GridGroupSummaryItem asbuiltMetraj = new GridGroupSummaryItem();
                asbuiltMetraj.FieldName = "ASBUILT_METRAJ";
                asbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                asbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                asbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["ASBUILT_METRAJ"];
                gridView1.GroupSummary.Add(asbuiltMetraj);

                GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                kaziBoyu.FieldName = "KAZI_BOYU";
                kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZI_BOYU"];
                gridView1.GroupSummary.Add(kaziBoyu);
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmPeHatlar_Load(object sender, EventArgs e)
        {

        }
    }
}
