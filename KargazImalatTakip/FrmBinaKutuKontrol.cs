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
    public partial class FrmBinaKutuKontrol : Form
    {
        public FrmBinaKutuKontrol()
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT BINA_MSLINK, B.BINA_KODU, BI.ILCE_ADI, CAST(YB.YOL_KODU AS NVARCHAR) + ' - ' + YB.YOL_ADI + ' ' + YB.YOL_TIPI AS YOL, " +
                        "SERVISKUTUSU_MSLINK, SI.ILCE_ADI, CAST(YS.YOL_KODU AS NVARCHAR) + ' - ' + YS.YOL_ADI + ' ' + YS.YOL_TIPI AS YOL FROM BINA_SERVISKUTUSU BS " +
                        "LEFT JOIN SERVIS_KUTUSU SK ON SK.MSLINK = BS.SERVISKUTUSU_MSLINK " +
                        "LEFT JOIN YOL YS ON YS.MSLINK = SK.YOL_MSLINK " +
                        "LEFT JOIN ILCE SI ON SI.ILCE_KODU =SK.ILCE_KODU " +
                        "LEFT JOIN BINA B ON B.MSLINK = BS.BINA_MSLINK " +
                        "LEFT JOIN YOL YB ON YB.YOL_KODU = B.YOL_KODU " +
                        "LEFT JOIN ILCE BI ON BI.ILCE_KODU = B.ILCE_KODU " +
                        "ORDER BY YS.YOL_ADI", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT BINA_MSLINK, B.BINA_KODU, BI.ILCE_ADI, CAST(YB.YOL_KODU AS NVARCHAR) + ' - ' + YB.YOL_ADI + ' ' + YB.YOL_TIPI AS YOL, " +
                        "SERVISKUTUSU_MSLINK, SI.ILCE_ADI, CAST(YS.YOL_KODU AS NVARCHAR) + ' - ' + YS.YOL_ADI + ' ' + YS.YOL_TIPI AS YOL FROM BINA_SERVISKUTUSU BS " +
                        "LEFT JOIN SERVIS_KUTUSU SK ON SK.MSLINK = BS.SERVISKUTUSU_MSLINK " +
                        "LEFT JOIN YOL YS ON YS.MSLINK = SK.YOL_MSLINK " +
                        "LEFT JOIN ILCE SI ON SI.ILCE_KODU =SK.ILCE_KODU " +
                        "LEFT JOIN BINA B ON B.MSLINK = BS.BINA_MSLINK " +
                        "LEFT JOIN YOL YB ON YB.YOL_KODU = B.YOL_KODU " +
                        "LEFT JOIN ILCE BI ON BI.ILCE_KODU = B.ILCE_KODU " +
                        "ORDER BY YS.YOL_ADI", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                gridView1.Columns[0].Caption = "BİNA MSLINK";
                gridView1.Columns[1].Caption = "BİNA KODU";
                gridView1.Columns[2].Caption = "BİNA İLÇE ADI";
                gridView1.Columns[3].Caption = "BİNA YOL ADI";
                gridView1.Columns[4].Caption = "SERVİS KUTUSU MSLINK";
                gridView1.Columns[5].Caption = "SERVİS KUTUSU İLÇE ADI";
                gridView1.Columns[6].Caption = "SERVİS KUTUSU YOL ADI";

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
            string yol = "Bina Kutu Adres Kontrol Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Bina Kutu Adres Kontrol Listesi.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
    
}
