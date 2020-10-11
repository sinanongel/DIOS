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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, SH.MSLINK, SEKTOR, HAT_MSLINK, I.ILCE_ADI, "
                                                            + "M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI AS YOL, Y.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, "
                                                            + "CONVERT(VARCHAR, IMALATTARIHI, 104) AS IMALAT_TARIHI, FORMNO, CAP, KAZIBOYU, BORUBOYU, "
                                                            + "YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, SH.EKIPNO as EKIPNO FROM dbo.SERVIS_HATLARI SH "
                                                            + "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK "
                                                            + "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU "
                                                            + "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU "
                                                            + "ORDER BY SH.MSLINK DESC", bgl.serhatgazBaglanti());
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ROW_NUMBER() OVER(ORDER BY I.ILCE_ADI) AS SIRANO, SH.MSLINK, SEKTOR, HAT_MSLINK, I.ILCE_ADI, "
                                                            + "M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI AS YOL, Y.YOL_TIPI AS YOL_TIPI, YATIRIMYILI, "
                                                            + "CONVERT(VARCHAR, IMALATTARIHI, 104) AS IMALAT_TARIHI, FORMNO, CAP, KAZIBOYU, BORUBOYU, "
                                                            + "YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, SH.EKIPNO as EKIPNO FROM dbo.SERVIS_HATLARI SH "
                                                            + "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK "
                                                            + "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU "
                                                            + "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU "
                                                            + "ORDER BY SH.MSLINK DESC", bgl.serhatgazBaglanti());
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
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
