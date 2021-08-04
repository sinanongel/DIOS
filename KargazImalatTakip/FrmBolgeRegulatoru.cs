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
    public partial class FrmBolgeRegulatoru : Form
    {
        public FrmBolgeRegulatoru()
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
                    SqlDataAdapter da = new SqlDataAdapter("select DBO.BOLGE_REGULATORU.MSLINK, FORMNO, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI AS YOL, dbo.yol.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, REGULATORADI, REGULATORSERINO, REGULATORTIPI,GIRISBASINCI,CIKISBASINCI, GIRISCAPI, CIKISCAPI, MARKA, MODEL  from dbo.BOLGE_REGULATORU, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BOLGE_REGULATORU.YOL_MSLINK = dbo.yol.mslink and dbo.BOLGE_REGULATORU.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BOLGE_REGULATORU.ILCE_KODU = dbo.ilce.ilce_kodu order by ilce_adi, mahalle_adi, yol_adi, YATIRIMYILI, FORMNO", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    //gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                    //gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    //gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    //gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    //gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    //gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    //gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    //gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    //gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    //gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    //gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    //gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    //gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    //gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[13].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
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
                    SqlDataAdapter da = new SqlDataAdapter("select DBO.BOLGE_REGULATORU.MSLINK, FORMNO, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI AS YOL, dbo.yol.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, REGULATORADI, REGULATORSERINO, REGULATORTIPI,GIRISBASINCI,CIKISBASINCI, GIRISCAPI, CIKISCAPI, MARKA, MODEL  from dbo.BOLGE_REGULATORU, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BOLGE_REGULATORU.YOL_MSLINK = dbo.yol.mslink and dbo.BOLGE_REGULATORU.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BOLGE_REGULATORU.ILCE_KODU = dbo.ilce.ilce_kodu order by ilce_adi, mahalle_adi, yol_adi, YATIRIMYILI, FORMNO", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    //gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                    //gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    //gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    //gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    //gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    //gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    //gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    //gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    //gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    //gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    //gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    //gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    //gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    //gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[13].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Bölge Regülatör Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için.
            Process.Start(yol);
        }
    }
}
