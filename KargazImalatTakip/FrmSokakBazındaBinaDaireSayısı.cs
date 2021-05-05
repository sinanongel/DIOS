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
    public partial class FrmSokakBazındaBinaDaireSayısı : Form
    {
        public FrmSokakBazındaBinaDaireSayısı()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CASE WHEN I.ILCE_ADI IS NULL THEN 'BİNA BÖLGE BİLGİSİ BOŞ!' ELSE I.ILCE_ADI END AS BOLGE, " +
                        "CASE WHEN M.MAHALLE_ADI IS NULL THEN 'BİNA MAHALLE BİLGİSİ BOŞ!' ELSE M.MAHALLE_ADI END AS MAHALLE, " +
                        "CASE WHEN Y.YOL_ADI IS NULL THEN 'BİNA YOL İLİŞKİSİ YAPILMAMIŞ!' " +
                        "ELSE CAST(Y.YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI END AS YOL, " +
                        "COUNT(B.MSLINK) AS BINA, CASE WHEN SUM(B.DAIRE_SAYISI) IS NOT NULL THEN SUM(B.DAIRE_SAYISI) ELSE 1 END AS DAIRE, " +
                        "COUNT(BS.SERVISKUTUSU_MSLINK) AS KUTU FROM DBO.BINA B " +
                        "LEFT JOIN DBO.YOL Y ON B.YOL_KODU = Y.YOL_KODU " +
                        "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                        "LEFT JOIN DBO.BINA_SERVISKUTUSU BS ON BS.BINA_MSLINK = B.MSLINK " +
                        "GROUP BY I.ILCE_ADI, M.MAHALLE_ADI, Y.YOL_KODU, Y.YOL_ADI, Y.YOL_TIPI ORDER BY YOL_ADI ", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CASE WHEN I.ILCE_ADI IS NULL THEN 'BİNA BÖLGE BİLGİSİ BOŞ!' ELSE I.ILCE_ADI END AS BOLGE, " +
                        "CASE WHEN M.MAHALLE_ADI IS NULL THEN 'BİNA MAHALLE BİLGİSİ BOŞ!' ELSE M.MAHALLE_ADI END AS MAHALLE, " +
                        "CASE WHEN Y.YOL_ADI IS NULL THEN 'BİNA YOL İLİŞKİSİ YAPILMAMIŞ!' " +
                        "ELSE CAST(Y.YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI END AS YOL, " +
                        "COUNT(B.MSLINK) AS BINA, CASE WHEN SUM(B.DAIRE_SAYISI) IS NOT NULL THEN SUM(B.DAIRE_SAYISI) ELSE 1 END AS DAIRE, " +
                        "COUNT(BS.SERVISKUTUSU_MSLINK) AS KUTU FROM DBO.BINA B " +
                        "LEFT JOIN DBO.YOL Y ON B.YOL_KODU = Y.YOL_KODU " +
                        "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                        "LEFT JOIN DBO.BINA_SERVISKUTUSU BS ON BS.BINA_MSLINK = B.MSLINK " +
                        "GROUP BY I.ILCE_ADI, M.MAHALLE_ADI, Y.YOL_KODU, Y.YOL_ADI, Y.YOL_TIPI ORDER BY YOL_ADI  ", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                gridView1.Columns["BOLGE"].Caption = "BÖLGE";
                gridView1.Columns["BINA"].Caption = "BİNA SAYISI";
                gridView1.Columns["DAIRE"].Caption = "DAİRE SAYISI";
                gridView1.Columns["KUTU"].Caption = "KUTU SAYISI";

                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[0].SummaryItem.DisplayFormat = "{0} adet bulundu...";
                
                gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[3].SummaryItem.DisplayFormat = "{0} ADET";
                gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[4].SummaryItem.DisplayFormat = "{0} ADET";
                gridView1.Columns[5].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[5].SummaryItem.DisplayFormat = "{0} ADET";

                gridView1.Columns["BINA"].AppearanceCell.BackColor = Color.PeachPuff;
                gridView1.Columns["DAIRE"].AppearanceCell.BackColor = Color.PaleGoldenrod;
                gridView1.Columns["KUTU"].AppearanceCell.BackColor = Color.PaleGreen;
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Yol Bazında Bina-Daire Sayısı.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Yol Bazında Bina-Daire Sayısı.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        string bolge;
        string mahalle;
        string sokak;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            FrmSokakBinaDetay fd = new FrmSokakBinaDetay();                       

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                bolge = dr["BOLGE"].ToString();
                mahalle = dr["MAHALLE"].ToString();
                sokak = dr["YOL"].ToString();
            }

            if(sokak == "BINA YOL ILISKISI YAPILMAMIS!")
            {
                MessageBox.Show("Yol ilişkilendirmesi yapılmadığından liste gösterilemiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fd.bolge = bolge;
                fd.mahalle = mahalle;
                fd.sokak = sokak;
                fd.firma = CmbŞirket.Text;
                fd.Show();
            }
        }
    }    
}
