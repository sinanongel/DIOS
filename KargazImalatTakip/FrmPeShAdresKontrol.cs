using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmPeShAdresKontrol : Form
    {
        public FrmPeShAdresKontrol()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListe_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            //try
            //{
            if (CmbŞirket.Text == "KARGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SH.MSLINK, SI.ILCE_ADI, MS.MAHALLE_ADI, CAST(SY.YOL_KODU AS NVARCHAR) + ' - ' + SY.YOL_ADI + ' ' + SY.YOL_TIPI AS SERVIS_YOL," +
                    " SH.DURUM, SH.HAT_MSLINK, MH.MAHALLE_ADI, HI.ILCE_ADI, CAST(HY.YOL_KODU AS NVARCHAR) + ' - ' + HY.YOL_ADI + ' ' + HY.YOL_TIPI AS HAT_YOL, H.DURUM FROM SERVIS_HATLARI SH " +
                    "LEFT JOIN HATLAR H ON H.MSLINK = SH.HAT_MSLINK " +
                    "LEFT JOIN MAHALLE MS ON MS.MAHALLE_KODU = SH.MAHALLE_KODU " +
                    "LEFT JOIN MAHALLE MH ON MH.MAHALLE_KODU = H.MAHALLE_KODU " +
                    "LEFT JOIN ILCE SI ON SI.ILCE_KODU = SH.ILCE_KODU " +
                    "LEFT JOIN ILCE HI ON HI.ILCE_KODU = H.ILCE_KODU " +
                    "LEFT JOIN YOL SY ON SY.MSLINK = SH.YOL_MSLINK " +
                    "LEFT JOIN YOL HY ON HY.MSLINK = H.YOL_MSLINK " +
                    "ORDER BY SY.YOL_ADI", bgl.kargazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SH.MSLINK, SI.ILCE_ADI, MS.MAHALLE_ADI, CAST(SY.YOL_KODU AS NVARCHAR) + ' - ' + SY.YOL_ADI + ' ' + SY.YOL_TIPI AS SERVIS_YOL," +
                    " SH.DURUM, SH.HAT_MSLINK, MH.MAHALLE_ADI, HI.ILCE_ADI, CAST(HY.YOL_KODU AS NVARCHAR) + ' - ' + HY.YOL_ADI + ' ' + HY.YOL_TIPI AS HAT_YOL, H.DURUM FROM SERVIS_HATLARI SH " +
                    "LEFT JOIN HATLAR H ON H.MSLINK = SH.HAT_MSLINK " +
                    "LEFT JOIN MAHALLE MS ON MS.MAHALLE_KODU = SH.MAHALLE_KODU " +
                    "LEFT JOIN MAHALLE MH ON MH.MAHALLE_KODU = H.MAHALLE_KODU " +
                    "LEFT JOIN ILCE SI ON SI.ILCE_KODU = SH.ILCE_KODU " +
                    "LEFT JOIN ILCE HI ON HI.ILCE_KODU = H.ILCE_KODU " +
                    "LEFT JOIN YOL SY ON SY.MSLINK = SH.YOL_MSLINK " +
                    "LEFT JOIN YOL HY ON HY.MSLINK = H.YOL_MSLINK " +
                    "ORDER BY SY.YOL_ADI", bgl.serhatgazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }

            gridView1.Columns[0].Caption = "SH MSLINK";
            gridView1.Columns[1].Caption = "SH İLÇE ADI";
            gridView1.Columns[2].Caption = "SH MAHALLE ADI";
            gridView1.Columns[3].Caption = "SH YOL ADI";
            gridView1.Columns[4].Caption = "SH DURUM";
            gridView1.Columns[5].Caption = "PE MSLINK";
            gridView1.Columns[6].Caption = "PE İLÇE ADI";
            gridView1.Columns[7].Caption = "PE MAHALLE ADI";
            gridView1.Columns[8].Caption = "PE YOL ADI";
            gridView1.Columns[9].Caption = "PE DURUM";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "{0:0.##} ADET";
            //}
            //catch
            //{
            //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Pe-Sh Adres Kontrol Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Pe-Sh Adres Kontrol Listesi.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
}
