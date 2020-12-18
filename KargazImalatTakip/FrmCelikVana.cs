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
    public partial class FrmCelikVana : Form
    {
        public FrmCelikVana()
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
                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT dbo.VANA.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA, dbo.yol, dbo.mahalle, dbo.ilce where dbo.VANA.YOL_MSLINK = dbo.yol.mslink and dbo.VANA.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.VANA.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO LIKE 'C%' ORDER BY MSLINK ", bgl.kargazBaglanti());
                    DataTable dtVana = new DataTable();
                    daVana.Fill(dtVana);
                    gridControl1.DataSource = dtVana;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["VANA_NO"].Caption = "VANA NO";
                    gridView1.Columns["BOLGE"].Caption = "BÖLGE";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["VANA_TIPI"].Caption = "VANA TİPİ";
                    gridView1.Columns["CAP"].Caption = "ÇAP";

                    gridView1.Columns["MSLINK"].Width = 50;
                    gridView1.Columns["FORMNO"].Width = 50;
                    gridView1.Columns["YATIRIMYILI"].Width = 70;
                    gridView1.Columns["IMALAT_TARIHI"].Width = 100;
                    gridView1.Columns["VANA_NO"].Width = 100;
                    gridView1.Columns["BOLGE"].Width = 100;
                    gridView1.Columns["SEKTOR"].Width = 100;
                    gridView1.Columns["VANA_TIPI"].Width = 100;
                    gridView1.Columns["CAP"].Width = 100;

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
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
                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT dbo.VANA.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA, dbo.yol, dbo.mahalle, dbo.ilce where dbo.VANA.YOL_MSLINK = dbo.yol.mslink and dbo.VANA.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.VANA.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO LIKE 'C%' ORDER BY MSLINK ", bgl.serhatgazBaglanti());
                    DataTable dtVana = new DataTable();
                    daVana.Fill(dtVana);
                    gridControl1.DataSource = dtVana;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["VANA_NO"].Caption = "VANA NO";
                    gridView1.Columns["BOLGE"].Caption = "BÖLGE";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["VANA_TIPI"].Caption = "VANA TİPİ";
                    gridView1.Columns["CAP"].Caption = "ÇAP";

                    gridView1.Columns["MSLINK"].Width = 50;
                    gridView1.Columns["FORMNO"].Width = 50;
                    gridView1.Columns["YATIRIMYILI"].Width = 70;
                    gridView1.Columns["IMALAT_TARIHI"].Width = 100;
                    gridView1.Columns["VANA_NO"].Width = 100;
                    gridView1.Columns["BOLGE"].Width = 100;
                    gridView1.Columns["SEKTOR"].Width = 100;
                    gridView1.Columns["VANA_TIPI"].Width = 100;
                    gridView1.Columns["CAP"].Width = 100;

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Çelik Vana Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
}
