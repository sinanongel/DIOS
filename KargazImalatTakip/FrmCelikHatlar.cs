using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;

namespace KargazImalatTakip
{
    public partial class FrmCelikHatlar : Form
    {
        public FrmCelikHatlar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                        "M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI AS YOL, Y.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                        "FORMNO, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, " +
                        "DOSYA FROM dbo.HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE H.MALZEME_CINSI = 'Celik' " +
                        "ORDER BY H.MSLINK DESC", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                    gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";

                    RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                    gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                    dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                        "M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI AS YOL, Y.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                        "FORMNO, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, " +
                        "DOSYA FROM dbo.HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE H.MALZEME_CINSI = 'Celik' " +
                        "ORDER BY H.MSLINK DESC", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                    gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";

                    RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                    gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                    dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                kayitYolu = satir[5] + bolge + "\\";
                yol = kayitYolu + dosya;
                //yol = dr["DOSYA_YOLU"].ToString();
                Process.Start(yol);
            }

            //FileInfo dosyaBilgi = new FileInfo();
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog kayit = new SaveFileDialog();
            if (kayit.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXlsx(kayit.FileName + ".xlsx");
            }
        }
    }
}
