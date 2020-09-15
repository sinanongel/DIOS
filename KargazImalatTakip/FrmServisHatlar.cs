using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KargazImalatTakip
{
    public partial class FrmServisHatlar : Form
    {
        public FrmServisHatlar()
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
                    SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY dbo.ilce.ILCE_ADI) AS SIRANO, DBO.SERVIS_HATLARI.MSLINK, DBO.SERVIS_HATLARI.SEKTOR, DBO.SERVIS_HATLARI.HAT_MSLINK, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI AS YOL, dbo.yol.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI,FORMNO, CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, DBO.SERVIS_HATLARI.EKIPNO as EKIPNO from dbo.SERVIS_HATLARI, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_HATLARI.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_HATLARI.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_HATLARI.ILCE_KODU = dbo.ilce.ilce_kodu order by ilce_adi, mahalle_adi, yol_adi, YATIRIMYILI, FORMNO", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    gridView1.Columns["SIRANO"].Caption = "SIRA NO"; 
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[13].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
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
                    SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY dbo.ilce.ILCE_ADI) AS SIRANO, DBO.SERVIS_HATLARI.MSLINK, DBO.SERVIS_HATLARI.SEKTOR, DBO.SERVIS_HATLARI.HAT_MSLINK, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI AS YOL, dbo.yol.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI,FORMNO, CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, DBO.SERVIS_HATLARI.EKIPNO as EKIPNO from dbo.SERVIS_HATLARI, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_HATLARI.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_HATLARI.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_HATLARI.ILCE_KODU = dbo.ilce.ilce_kodu order by mslink desc", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[13].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
