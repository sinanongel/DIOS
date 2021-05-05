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
    public partial class FrmPeFormDetay : Form
    {
        public FrmPeFormDetay()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                    "M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                    "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO FROM dbo.HATLAR H " +
                    "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                    "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE H.MALZEME_CINSI = 'Polietilen' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                    "ORDER BY H.MSLINK", bgl.kargazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl1.DataSource = dtHat;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                    "M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                    "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO FROM dbo.HATLAR H " +
                    "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                    "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE H.MALZEME_CINSI = 'Polietilen' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                    "ORDER BY H.MSLINK", bgl.serhatgazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl1.DataSource = dtHat;
            }

            gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
            gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
            gridView1.Columns["FORMNO"].Caption = "FORM NO";
            gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
            gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
            gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
            gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
            gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";
            gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
            gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

            GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
            boruUzunlugu.FieldName = "BORU_UZUNLUGU";
            boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
            boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORU_UZUNLUGU"];
            gridView1.GroupSummary.Add(boruUzunlugu);

            GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
            yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
            yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
            yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
            gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

            GridGroupSummaryItem asbuiltMetraj = new GridGroupSummaryItem();
            asbuiltMetraj.FieldName = "ASBUILT_METRAJ";
            asbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
            asbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            asbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["ASBUILT_METRAJ"];
            gridView1.GroupSummary.Add(asbuiltMetraj);

            GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
            kaziBoyu.FieldName = "KAZI_BOYU";
            kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
            kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZI_BOYU"];
            gridView1.GroupSummary.Add(kaziBoyu);

            gridView1.Columns[8].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[8].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[9].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[10].SummaryItem.DisplayFormat = "{0:0.##}";
            gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[11].SummaryItem.DisplayFormat = "{0:0.##}";

            //Bağlantı Elemanı Listesi

            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daBe = new SqlDataAdapter("SELECT TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM BAGLANTI_ELEMANLARI_PE B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO ='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY TIPI, CAP ORDER BY TIPI", bgl.kargazBaglanti());
                DataTable dtBe = new DataTable();
                daBe.Fill(dtBe);
                gridControl2.DataSource = dtBe;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daBe = new SqlDataAdapter("SELECT TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM BAGLANTI_ELEMANLARI_PE B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY TIPI, CAP ORDER BY TIPI", bgl.serhatgazBaglanti());
                DataTable dtBe = new DataTable();
                daBe.Fill(dtBe);
                gridControl2.DataSource = dtBe;
            }

            gridView2.Columns["TIPI"].Caption = "TİPİ";
            gridView2.Columns["CAP"].Caption = "ÇAP";

            //Vana Listesi

            if (CmbFirma.Text == "KARGAZ")
            {
                SqlDataAdapter daVana = new SqlDataAdapter("SELECT VANA_TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM VANA B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO ='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY VANA_TIPI, CAP", bgl.kargazBaglanti());
                DataTable dtVana = new DataTable();
                daVana.Fill(dtVana);
                gridControl3.DataSource = dtVana;
            }
            else if (CmbFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter daVana = new SqlDataAdapter("SELECT VANA_TIPI, CAP, COUNT(B.MSLINK) AS ADET FROM VANA B LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE FORMNO='" + TxtFormNo.Text + "' AND I.ILCE_ADI ='" + CmbBolge.Text + "'" + " GROUP BY VANA_TIPI, CAP", bgl.serhatgazBaglanti());
                DataTable dtVana = new DataTable();
                daVana.Fill(dtVana);
                gridControl3.DataSource = dtVana;
            }

            gridView3.Columns["VANA_TIPI"].Caption = "VANA TİPİ";
            gridView3.Columns["CAP"].Caption = "ÇAP";
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
