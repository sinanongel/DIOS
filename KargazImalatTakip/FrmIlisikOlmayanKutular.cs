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
    public partial class FrmIlisikOlmayanKutular : Form
    {
        public FrmIlisikOlmayanKutular()
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT SK.MSLINK, SI.ILCE_ADI, MI.MAHALLE_ADI, " +
                    "CAST(YS.YOL_KODU AS NVARCHAR) + ' - ' + YS.YOL_ADI + ' ' + YS.YOL_TIPI AS YOL , DURUM FROM SERVIS_KUTUSU SK " +
                    "LEFT JOIN YOL YS ON YS.MSLINK = SK.YOL_MSLINK " +
                    "LEFT JOIN MAHALLE MI ON MI.MAHALLE_KODU =SK.MAHALLE_KODU " +
                    "LEFT JOIN ILCE SI ON SI.ILCE_KODU =SK.ILCE_KODU " +
                    "WHERE SK.MSLINK NOT IN (SELECT SERVISKUTUSU_MSLINK FROM BINA_SERVISKUTUSU) ORDER BY SK.MSLINK", bgl.kargazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SK.MSLINK, SI.ILCE_ADI, MI.MAHALLE_ADI, " +
                    "CAST(YS.YOL_KODU AS NVARCHAR) + ' - ' + YS.YOL_ADI + ' ' + YS.YOL_TIPI AS YOL , DURUM FROM SERVIS_KUTUSU SK " +
                    "LEFT JOIN YOL YS ON YS.MSLINK = SK.YOL_MSLINK " +
                    "LEFT JOIN MAHALLE MI ON MI.MAHALLE_KODU =SK.MAHALLE_KODU " +
                    "LEFT JOIN ILCE SI ON SI.ILCE_KODU =SK.ILCE_KODU " +
                    "WHERE SK.MSLINK NOT IN (SELECT SERVISKUTUSU_MSLINK FROM BINA_SERVISKUTUSU) ORDER BY SK.MSLINK", bgl.serhatgazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }

            gridView1.Columns[0].Caption = "MSLINK";
            gridView1.Columns[1].Caption = "İL/İLÇE";
            gridView1.Columns[2].Caption = "MAHALLE";
            gridView1.Columns[3].Caption = "BİNA YOL ADI";

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
            string yol = "İlişiği Olmayan Kutu Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "İlişiği Olmayan Kutu Listesi.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
}
