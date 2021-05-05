using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmShFormDetay : Form
    {
        public FrmShFormDetay()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT SH.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, SH.IMALATTARIHI, 104) AS IMALAT_TARIHI, " +
                        "M.MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' + YOL_TIPI AS YOL, SEKTOR, HAT_MSLINK, FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, " +
                        "CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, EKIPNO FROM dbo.SERVIS_HATLARI SH " +
                        "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO = " + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.kargazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl1.DataSource = dtHat;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT SH.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, SH.IMALATTARIHI, 104) AS IMALAT_TARIHI, " +
                       "M.MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' + YOL_TIPI AS YOL, SEKTOR, HAT_MSLINK, FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, " +
                       "CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, EKIPNO FROM dbo.SERVIS_HATLARI SH " +
                       "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                       "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                       "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                       "WHERE FORMNO = " + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.serhatgazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl1.DataSource = dtHat;
            }

            gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
            gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
            gridView1.Columns["FORMNO"].Caption = "FORM NO";
            gridView1.Columns["FROM_ID"].Caption = "FROM ID";
            gridView1.Columns["FROM_MSLINK"].Caption = "FROM MSLINK";
            gridView1.Columns["TO_ID"].Caption = "TO ID";
            gridView1.Columns["TO_MSLINK"].Caption = "TO MSLINK";
            gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
            gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
            gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
            gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
            gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
            gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
            gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
            gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

            gridView1.Columns[13].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[13].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[14].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[14].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[15].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[16].SummaryItem.DisplayFormat = "{0:0.##}";

            //Saddle Listesi

            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daSaddle = new SqlDataAdapter("SELECT TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM SERVIS_ELEMANLARI B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO ='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY TIPI, CAP", bgl.kargazBaglanti());
                DataTable dtSaddle = new DataTable();
                daSaddle.Fill(dtSaddle);
                gridControl2.DataSource = dtSaddle;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daVana = new SqlDataAdapter("SELECT TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM SERVIS_ELEMANLARI B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY TIPI, CAP", bgl.serhatgazBaglanti());
                DataTable dtVana = new DataTable();
                daVana.Fill(dtVana);
                gridControl2.DataSource = dtVana;
            }

            gridView2.Columns["TIPI"].Caption = "TİPİ";
            gridView2.Columns["CAP"].Caption = "ÇAP";

            //Bağlantı Elemanı Listesi

            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daBe = new SqlDataAdapter("SELECT TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM BAGLANTI_ELEMANLARI_PE B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO ='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY TIPI, CAP ORDER BY TIPI", bgl.kargazBaglanti());
                DataTable dtBe = new DataTable();
                daBe.Fill(dtBe);
                gridControl3.DataSource = dtBe;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daBe = new SqlDataAdapter("SELECT TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM BAGLANTI_ELEMANLARI_PE B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY TIPI, CAP ORDER BY TIPI", bgl.serhatgazBaglanti());
                DataTable dtBe = new DataTable();
                daBe.Fill(dtBe);
                gridControl3.DataSource = dtBe;
            }

            gridView3.Columns["TIPI"].Caption = "TİPİ";
            gridView3.Columns["CAP"].Caption = "ÇAP";

            //Servis Kutusu Listesi

            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daSk = new SqlDataAdapter("SELECT KUTU_TIPI, CINSI, SKUTUVANASI, COUNT(SK.MSLINK) AS ADET FROM SERVIS_KUTUSU SK " +
                    "LEFT JOIN DBO.ILCE I ON SK.ILCE_KODU = I.ILCE_KODU WHERE FORMNO ='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + 
                    " GROUP BY KUTU_TIPI, CINSI, SKUTUVANASI", bgl.kargazBaglanti());
                DataTable dtSk = new DataTable();
                daSk.Fill(dtSk);
                gridControl5.DataSource = dtSk;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daBe = new SqlDataAdapter("SELECT KUTU_TIPI, CINSI, SKUTUVANASI, COUNT(SK.MSLINK) AS ADET FROM SERVIS_KUTUSU SK " +
                    "LEFT JOIN DBO.ILCE I ON SK.ILCE_KODU = I.ILCE_KODU WHERE FORMNO='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + 
                    " GROUP BY KUTU_TIPI, CINSI, SKUTUVANASI", bgl.serhatgazBaglanti());
                DataTable dtBe = new DataTable();
                daBe.Fill(dtBe);
                gridControl5.DataSource = dtBe;
            }

            gridView5.Columns["KUTU_TIPI"].Caption = "KUTU TİPİ";
            gridView5.Columns["CINSI"].Caption = "CİNSİ";
            gridView5.Columns["SKUTUVANASI"].Caption = "VANA TİPİ";
        }

        private void CmbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBolge.Text = "";
            CmbBolge.Properties.Items.Clear();

            try
            {
                if (CmbFirma.Text == "KARGAZ")
                {
                    SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        CmbBolge.Properties.Items.Add(dr[0]);
                    }
                    bgl.kargazBaglanti().Close();
                }
                else if (CmbFirma.Text == "SERHATGAZ")
                {
                    SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.serhatgazBaglanti());
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        CmbBolge.Properties.Items.Add(dr[0]);
                    }
                    bgl.serhatgazBaglanti().Close();
                }
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
