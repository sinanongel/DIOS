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

namespace KargazImalatTakip
{
    public partial class FrmPeHatlar : Form
    {
        public FrmPeHatlar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, H.MSLINK, H.SEKTOR, I.ILCE_ADI AS ILCE_ADI, " +
                            "M.MAHALLE_ADI AS MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YOL_BOYU, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, FORMNO, " +
                            "FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU " +
                            "FROM dbo.HATLAR H " +
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
                            "FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU " +
                            "FROM dbo.HATLAR H " +
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
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
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
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[18].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Hat Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için.
            Process.Start(yol);
        }
    }
}
