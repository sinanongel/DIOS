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
using System.IO;
using DevExpress.XtraEditors.Repository;

namespace KargazImalatTakip
{
    public partial class FrmServisHatlar : Form
    {
        public FrmServisHatlar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();    

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Servis Hattı Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY SH.MSLINK DESC) AS SIRANO, SH.MSLINK, SEKTOR, HAT_MSLINK, I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, " +
                        "CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, YATIRIMYILI, CONVERT(VARCHAR, IMALATTARIHI, 104) AS IMALAT_TARIHI, FORMNO, " +
                        "FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, SH.EKIPNO as EKIPNO, DOSYA FROM dbo.SERVIS_HATLARI SH " +
                        "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                        "ORDER BY SH.MSLINK DESC", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY SH.MSLINK DESC) AS SIRANO, SH.MSLINK, SEKTOR, HAT_MSLINK, I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, " +
                        "CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, YATIRIMYILI, CONVERT(VARCHAR, IMALATTARIHI, 104) AS IMALAT_TARIHI, FORMNO, " +
                        "FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, SH.EKIPNO as EKIPNO, DOSYA FROM dbo.SERVIS_HATLARI SH " +
                        "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                        "ORDER BY SH.MSLINK DESC", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView1.Columns["FORMNO"].Caption = "FORM NO";
                gridView1.Columns["FROM_ID"].Caption = "FROM ID";
                gridView1.Columns["FROM_MSLINK"].Caption = "FROM MSLINK";
                gridView1.Columns["TO_ID"].Caption = "TO ID";
                gridView1.Columns["TO_MSLINK"].Caption = "TO MSLINK";
                gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                gridView1.Columns["KAZIBOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["KAZIBOYU"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                gridView1.Columns["BORUBOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["BORUBOYU"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                gridView1.Columns["SHATTIMETRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["SHATTIMETRAJ"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[0].SummaryItem.DisplayFormat = "{0:0.##} ADET";
                gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[15].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[16].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[17].SummaryItem.DisplayFormat = "{0:0.##}";
                gridView1.Columns[18].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[18].SummaryItem.DisplayFormat = "{0:0.##}";

                GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                boruUzunlugu.FieldName = "BORUBOYU";
                boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORUBOYU"];
                gridView1.GroupSummary.Add(boruUzunlugu);

                GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
                yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
                yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
                gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

                GridGroupSummaryItem sHattiMetraj = new GridGroupSummaryItem();
                sHattiMetraj.FieldName = "SHATTIMETRAJ";
                sHattiMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                sHattiMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                sHattiMetraj.ShowInGroupColumnFooter = gridView1.Columns["SHATTIMETRAJ"];
                gridView1.GroupSummary.Add(sHattiMetraj);

                GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                kaziBoyu.FieldName = "KAZIBOYU";
                kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZIBOYU"];
                gridView1.GroupSummary.Add(kaziBoyu);
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                kayitYolu = satir[5] + bolge + "\\"; //P klasörü
                //kayitYolu = satir[6] + bolge + "\\"; //C klasörü
                yol = kayitYolu + dosya;
                //yol = dr["DOSYA_YOLU"].ToString();
                Process.Start(yol);
            }

            //FileInfo dosyaBilgi = new FileInfo();
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Servis Hattı Listesi.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnKoordinatlıListele_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            if (CmbŞirket.Text == "KARGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY SH.MSLINK DESC) AS SIRANO, SH.MSLINK, SH.SEKTOR, SH.HAT_MSLINK, I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, " +
                    "CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, SH.YATIRIMYILI, CONVERT(VARCHAR, IMALATTARIHI, 104) AS IMALAT_TARIHI, SH.FORMNO, " +
                    "SE.KONUM_X_KOOR AS FROM_X, SE.KONUM_Y_KOOR AS FROM_Y, SE.DERINLIK AS FROM_Z, SH.CAP, KAZIBOYU, BORUBOYU, " +
                    "YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, SH.EKIPNO as EKIPNO, DOSYA FROM dbo.SERVIS_HATLARI SH " +
                    "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                    "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                    "LEFT JOIN DBO.SERVIS_ELEMANLARI SE ON SH.FROM_MSLINK = SE.MSLINK " +
                    "ORDER BY SH.MSLINK DESC", bgl.kargazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY SH.MSLINK DESC) AS SIRANO, SH.MSLINK, SH.SEKTOR, SH.HAT_MSLINK, I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, " +
                    " CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, SH.YATIRIMYILI, CONVERT(VARCHAR, IMALATTARIHI, 104) AS IMALAT_TARIHI, SH.FORMNO, " +
                    "SE.KONUM_X_KOOR AS FROM_X, SE.KONUM_Y_KOOR AS FROM_Y, SE.DERINLIK AS FROM_Z, SH.CAP, KAZIBOYU, BORUBOYU, " +
                    "YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, SH.EKIPNO as EKIPNO FROM dbo.SERVIS_HATLARI SH " +
                    "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                    "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                    "LEFT JOIN DBO.SERVIS_ELEMANLARI SE ON SH.FROM_MSLINK = SE.MSLINK " +
                    "ORDER BY SH.MSLINK DESC", bgl.serhatgazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }

            gridView1.Columns["SIRANO"].Caption = "SIRA NO";
            gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
            gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
            gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
            gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
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
            gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
            gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
            gridView1.Columns["KAZIBOYU"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["KAZIBOYU"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
            gridView1.Columns["BORUBOYU"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["BORUBOYU"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
            gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["YATAY_ASBUILT_METRAJ"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
            gridView1.Columns["SHATTIMETRAJ"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["SHATTIMETRAJ"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "{0:0.##} ADET";
            gridView1.Columns[14].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[14].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[15].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[16].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[17].SummaryItem.DisplayFormat = "{0:0.##}";

            GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
            boruUzunlugu.FieldName = "BORUBOYU";
            boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
            boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORUBOYU"];
            gridView1.GroupSummary.Add(boruUzunlugu);

            GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
            yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
            yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
            yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
            gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

            GridGroupSummaryItem sHattiMetraj = new GridGroupSummaryItem();
            sHattiMetraj.FieldName = "SHATTIMETRAJ";
            sHattiMetraj.DisplayFormat = "TOPLAM={0:0.##}";
            sHattiMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            sHattiMetraj.ShowInGroupColumnFooter = gridView1.Columns["SHATTIMETRAJ"];
            gridView1.GroupSummary.Add(sHattiMetraj);

            GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
            kaziBoyu.FieldName = "KAZIBOYU";
            kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
            kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZIBOYU"];
            gridView1.GroupSummary.Add(kaziBoyu);
        }
    }
}
