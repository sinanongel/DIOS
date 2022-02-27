using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace KargazImalatTakip
{
    public partial class FrmIcmal : Form
    {
        public FrmIcmal()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void listele()
        {            
            if (CmbSirket.Text == "KARGAZ")
            {                
                DateTime tarih1 = DateTime.Parse(DtBaslangicTarihi.Text);
                DateTime tarih2 = DateTime.Parse(DtBitisTarihi.Text);

                if (CmbBolge.Text == "TÜMÜ")
                {
                    SqlDataAdapter daPh = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(KAZI_BOYU), SUM(ASBUILT_METRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.HATLAR WHERE MALZEME_CINSI = 'Polietilen' AND NET_BORU_CAPI NOT LIKE 'TB%' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'" +
                            "GROUP BY NET_BORU_CAPI", bgl.kargazBaglanti());
                    DataTable dtPh = new DataTable();
                    daPh.Fill(dtPh);
                    gridControl1.DataSource = dtPh;

                    gridView1.Columns[0].Caption = "ÇAP";
                    gridView1.Columns[1].Caption = "BORU BOYU";
                    gridView1.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[2].Caption = "KAZI BOYU";
                    gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView1.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView1.Columns[0].Width = 60;

                    gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daCh = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(KAZI_BOYU), SUM(ASBUILT_METRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.HATLAR WHERE MALZEME_CINSI = 'Çelik' AND NET_BORU_CAPI NOT LIKE 'TB%' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'" +
                            "GROUP BY NET_BORU_CAPI", bgl.kargazBaglanti());
                    DataTable dtCh = new DataTable();
                    daCh.Fill(dtCh);
                    gridControl2.DataSource = dtCh;

                    gridView2.Columns[0].Caption = "ÇAP";
                    gridView2.Columns[1].Caption = "BORU BOYU";
                    gridView2.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[2].Caption = "KAZI BOYU";
                    gridView2.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView2.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView2.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView2.Columns[0].Width = 60;

                    gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daSh = new SqlDataAdapter("SELECT CAP, SUM(BORUBOYU), SUM(KAZIBOYU), SUM(SHATTIMETRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.SERVIS_HATLARI WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY CAP", bgl.kargazBaglanti());
                    DataTable dtSh = new DataTable();
                    daSh.Fill(dtSh);
                    gridControl3.DataSource = dtSh;

                    gridView3.Columns[0].Caption = "ÇAP";
                    gridView3.Columns[1].Caption = "BORU BOYU";
                    gridView3.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[2].Caption = "KAZI BOYU";
                    gridView3.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[3].Caption = "EĞİK ASBUİLT METRAJ";
                    gridView3.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView3.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView3.Columns[0].Width = 60;

                    gridView3.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daBePe = new SqlDataAdapter("SELECT TIPI + ' ' + CAP AS TIP, COUNT(CAP) FROM dbo.BAGLANTI_ELEMANLARI_PE " +
                        "WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY TIPI, CAP ORDER BY TIPI, CAP", bgl.kargazBaglanti());
                    DataTable dtBePe = new DataTable();
                    daBePe.Fill(dtBePe);
                    gridControl7.DataSource = dtBePe;

                    gridView7.Columns[0].Caption = "MALZEME TİPİ";
                    gridView7.Columns[1].Caption = "ADET";

                    gridView7.Columns[1].Width = 50;

                    gridView7.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView7.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daBeCe = new SqlDataAdapter("SELECT TIPI + ' ' + CAP AS TIP, COUNT(CAP) FROM dbo.BAGLANTI_ELEMANLARI_CELIK " +
                        "WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY TIPI, CAP ORDER BY TIPI, CAP", bgl.kargazBaglanti());
                    DataTable dtBeCe = new DataTable();
                    daBeCe.Fill(dtBeCe);
                    gridControl9.DataSource = dtBeCe;

                    gridView9.Columns[0].Caption = "MALZEME TİPİ";
                    gridView9.Columns[1].Caption = "ADET";

                    gridView9.Columns[1].Width = 50;

                    gridView9.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView9.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.VANA WHERE MALZEME_CINSI = 'Polietilen' " +
                        "AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY CAP ORDER BY CAP", bgl.kargazBaglanti());
                    DataTable dtVana = new DataTable();
                    daVana.Fill(dtVana);
                    gridControl6.DataSource = dtVana;

                    gridView6.Columns[0].Caption = "ÇAP";
                    gridView6.Columns[1].Caption = "ADET";

                    gridView6.Columns[1].Width = 50;

                    gridView6.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView6.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daCVana = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.VANA WHERE MALZEME_CINSI = 'Çelik' " +
                        "AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY CAP ORDER BY CAP", bgl.kargazBaglanti());
                    DataTable dtCVana = new DataTable();
                    daCVana.Fill(dtCVana);
                    gridControl8.DataSource = dtCVana;

                    gridView8.Columns[0].Caption = "ÇAP";
                    gridView8.Columns[1].Caption = "ADET";

                    gridView8.Columns[1].Width = 50;

                    gridView8.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView8.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daSe = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.SERVIS_ELEMANLARI WHERE " +
                        "IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY CAP ORDER BY CAP", bgl.kargazBaglanti());
                    DataTable dtSe = new DataTable();
                    daSe.Fill(dtSe);
                    gridControl5.DataSource = dtSe;

                    gridView5.Columns[0].Caption = "ÇAP";
                    gridView5.Columns[1].Caption = "ADET";

                    gridView5.Columns[1].Width = 50;

                    gridView5.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView5.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daSk = new SqlDataAdapter("SELECT CINSI, COUNT(CINSI) FROM dbo.SERVIS_KUTUSU WHERE " +
                        "IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' GROUP BY CINSI ORDER BY CINSI", bgl.kargazBaglanti());
                    DataTable dtSk = new DataTable();
                    daSk.Fill(dtSk);
                    gridControl4.DataSource = dtSk;

                    gridView4.Columns[0].Caption = "CİNSİ";
                    gridView4.Columns[1].Caption = "ADET";

                    gridView4.Columns[1].Width = 50;

                    gridView4.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView4.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    LblBaslik.Text = CmbSirket.Text + " TÜM BÖLGELER İCMALİ";
                    LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
                }
                else
                {
                    SqlCommand daIlceKodu = new SqlCommand("SELECT ILCE_KODU FROM ILCE WHERE ILCE_ADI = @ilce", bgl.kargazBaglanti());
                    daIlceKodu.Parameters.AddWithValue("@ilce", CmbBolge.Text);
                    SqlDataReader drIlceKodu = daIlceKodu.ExecuteReader();
                    while (drIlceKodu.Read())
                    {
                        labelControl7.Text = drIlceKodu[0].ToString();
                    }
                    bgl.kargazBaglanti().Close();

                    int ilceKodu = Convert.ToInt32(labelControl7.Text);

                    SqlDataAdapter daPh = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(KAZI_BOYU), SUM(ASBUILT_METRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.HATLAR WHERE MALZEME_CINSI = 'Polietilen' AND NET_BORU_CAPI NOT LIKE 'TB%' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'" +
                            "AND ILCE_KODU = " + ilceKodu + "GROUP BY NET_BORU_CAPI", bgl.kargazBaglanti());
                    DataTable dtPh = new DataTable();
                    daPh.Fill(dtPh);
                    gridControl1.DataSource = dtPh;

                    gridView1.Columns[0].Caption = "ÇAP";
                    gridView1.Columns[1].Caption = "BORU BOYU";
                    gridView1.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[2].Caption = "KAZI BOYU";
                    gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView1.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView1.Columns[0].Width = 60;

                    gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daCh = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(KAZI_BOYU), SUM(ASBUILT_METRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.HATLAR WHERE MALZEME_CINSI = 'Çelik' AND NET_BORU_CAPI NOT LIKE 'TB%' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'" +
                            "AND ILCE_KODU = " + ilceKodu + "GROUP BY NET_BORU_CAPI", bgl.kargazBaglanti());
                    DataTable dtCh = new DataTable();
                    daCh.Fill(dtCh);
                    gridControl2.DataSource = dtCh;

                    gridView2.Columns[0].Caption = "ÇAP";
                    gridView2.Columns[1].Caption = "BORU BOYU";
                    gridView2.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[2].Caption = "KAZI BOYU";
                    gridView2.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView2.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView2.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView2.Columns[0].Width = 60;

                    gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daSh = new SqlDataAdapter("SELECT CAP, SUM(BORUBOYU), SUM(KAZIBOYU), SUM(SHATTIMETRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.SERVIS_HATLARI WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu + " GROUP BY CAP", bgl.kargazBaglanti());
                    DataTable dtSh = new DataTable();
                    daSh.Fill(dtSh);
                    gridControl3.DataSource = dtSh;

                    gridView3.Columns[0].Caption = "ÇAP";
                    gridView3.Columns[1].Caption = "BORU BOYU";
                    gridView3.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[2].Caption = "KAZI BOYU";
                    gridView3.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[3].Caption = "EĞİK ASBUİLT METRAJ";
                    gridView3.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView3.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView3.Columns[0].Width = 60;

                    gridView3.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daBePe = new SqlDataAdapter("SELECT TIPI + ' ' + CAP AS TIP, COUNT(CAP) FROM dbo.BAGLANTI_ELEMANLARI_PE " +
                        "WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY TIPI, CAP ORDER BY TIPI, CAP", bgl.kargazBaglanti());
                    DataTable dtBePe = new DataTable();
                    daBePe.Fill(dtBePe);
                    gridControl7.DataSource = dtBePe;

                    gridView7.Columns[0].Caption = "MALZEME TİPİ";
                    gridView7.Columns[1].Caption = "ADET";

                    gridView7.Columns[1].Width = 50;

                    gridView7.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView7.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daBeCe = new SqlDataAdapter("SELECT TIPI + ' ' + CAP AS TIP, COUNT(CAP) FROM dbo.BAGLANTI_ELEMANLARI_CELIK " +
                        "WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY TIPI, CAP ORDER BY TIPI, CAP", bgl.kargazBaglanti());
                    DataTable dtBeCe = new DataTable();
                    daBeCe.Fill(dtBeCe);
                    gridControl9.DataSource = dtBeCe;

                    gridView9.Columns[0].Caption = "MALZEME TİPİ";
                    gridView9.Columns[1].Caption = "ADET";

                    gridView9.Columns[1].Width = 50;

                    gridView9.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView9.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.VANA WHERE MALZEME_CINSI = 'Polietilen' " +
                        "AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CAP ORDER BY CAP", bgl.kargazBaglanti());
                    DataTable dtVana = new DataTable();
                    daVana.Fill(dtVana);
                    gridControl6.DataSource = dtVana;

                    gridView6.Columns[0].Caption = "ÇAP";
                    gridView6.Columns[1].Caption = "ADET";

                    gridView6.Columns[1].Width = 50;

                    gridView6.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView6.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daCVana = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.VANA WHERE MALZEME_CINSI = 'Çelik' " +
                        "AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CAP ORDER BY CAP", bgl.kargazBaglanti());
                    DataTable dtCVana = new DataTable();
                    daCVana.Fill(dtCVana);
                    gridControl8.DataSource = dtCVana;

                    gridView8.Columns[0].Caption = "ÇAP";
                    gridView8.Columns[1].Caption = "ADET";

                    gridView8.Columns[1].Width = 50;

                    gridView8.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView8.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daSe = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.SERVIS_ELEMANLARI WHERE " +
                        "IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CAP ORDER BY CAP", bgl.kargazBaglanti());
                    DataTable dtSe = new DataTable();
                    daSe.Fill(dtSe);
                    gridControl5.DataSource = dtSe;

                    gridView5.Columns[0].Caption = "ÇAP";
                    gridView5.Columns[1].Caption = "ADET";

                    gridView5.Columns[1].Width = 50;

                    gridView5.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView5.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daSk = new SqlDataAdapter("SELECT CINSI, COUNT(CINSI) FROM dbo.SERVIS_KUTUSU WHERE " +
                        "IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CINSI ORDER BY CINSI", bgl.kargazBaglanti());
                    DataTable dtSk = new DataTable();
                    daSk.Fill(dtSk);
                    gridControl4.DataSource = dtSk;

                    gridView4.Columns[0].Caption = "CİNSİ";
                    gridView4.Columns[1].Caption = "ADET";

                    gridView4.Columns[1].Width = 50;

                    gridView4.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView4.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    LblBaslik.Text = CmbSirket.Text + " - " + CmbBolge.Text + " İCMALİ";
                    LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
                }
            }

            if (CmbSirket.Text == "SERHATGAZ")
            {
                DateTime tarih1 = DateTime.Parse(DtBaslangicTarihi.Text); 
                DateTime tarih2 = DateTime.Parse(DtBitisTarihi.Text); 

                if (CmbBolge.Text == "TÜMÜ")
                {
                    //var polietilen = from h in dbS.HATLAR
                    //                 where h.MALZEME_CINSI == "Polietilen" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2)
                    //                 orderby h.NET_BORU_CAPI
                    //                 group h by new { h.NET_BORU_CAPI } into g
                    //                 select new
                    //                 {
                    //                     Çap = g.Key.NET_BORU_CAPI,
                    //                     BoruUzunluğu = g.Sum(t => t.BORU_UZUNLUGU),
                    //                     KazıBoyu = g.Sum(t => t.KAZI_BOYU),
                    //                     AsbuiltMetraj = g.Sum(t => t.ASBUILT_METRAJ),
                    //                     YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                    //                 };
                    //gridControl1.DataSource = polietilen.ToList();
                    //SqlDataAdapter da = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(YATAY_ASBUILT_METRAJ), SUM(ASBUILT_METRAJ), SUM(KAZI_BOYU) " +
                    //        "FROM dbo.HATLAR H " +
                    //        "WHERE H.MALZEME_CINSI = 'Polietilen' AND NOT LIKE 'TB%' AND H.IMALAT_TARIHI BETWEEN " + tarih1 + " AND " + tarih2 +
                    //        "GROUP BY H.NET_BORU_CAPI", bgl.serhatgazBaglanti());
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //gridControl1.DataSource = dt;

                    //gridView1.Columns[0].Caption = "ÇAP";
                    //gridView1.Columns[1].Caption = "BORU BOYU";
                    //gridView1.Columns[2].Caption = "KAZI BOYU";
                    //gridView1.Columns[3].Caption = "ASBUILT METRAJ";
                    //gridView1.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    //gridView1.Columns[0].Width = 60;

                    //gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    //var celik = from h in dbS.HATLAR
                    //            where h.MALZEME_CINSI == "Çelik" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2)
                    //            orderby h.NET_BORU_CAPI
                    //            group h by new { h.NET_BORU_CAPI } into g
                    //            select new
                    //            {
                    //                Çap = g.Key.NET_BORU_CAPI,
                    //                BoruUzunluğu = g.Sum(t => t.BORU_UZUNLUGU),
                    //                KazıBoyu = g.Sum(t => t.KAZI_BOYU),
                    //                AsbuiltMetraj = g.Sum(t => t.ASBUILT_METRAJ),
                    //                YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                    //            };
                    //gridControl2.DataSource = celik.ToList();

                    //gridView2.Columns[0].Caption = "ÇAP";
                    //gridView2.Columns[1].Caption = "BORU BOYU";
                    //gridView2.Columns[2].Caption = "KAZI BOYU";
                    //gridView2.Columns[3].Caption = "ASBUILT METRAJ";
                    //gridView2.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    //gridView1.Columns[0].Width = 60;

                    //gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView2.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView2.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    //var servis = from s in dbS.SERVIS_HATLARI
                    //             where (s.IMALATTARIHI >= tarih1 && s.IMALATTARIHI <= tarih2)
                    //             orderby s.CAP
                    //             group s by new { s.CAP } into g
                    //             select new
                    //             {
                    //                 Çap = g.Key.CAP,
                    //                 BoruUzunluğu = g.Sum(t => t.BORUBOYU),
                    //                 KazıBoyu = g.Sum(t => t.KAZIBOYU),
                    //                 EğikAsbuiltMetraj = g.Sum(t => t.SHATTIMETRAJ),
                    //                 YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                    //             };
                    //gridControl3.DataSource = servis.ToList();

                    //gridView3.Columns[0].Caption = "ÇAP";
                    //gridView3.Columns[1].Caption = "BORU BOYU";
                    //gridView3.Columns[2].Caption = "KAZI BOYU";
                    //gridView3.Columns[3].Caption = "EĞİK ASBUİLT METRAJ";
                    //gridView3.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    //gridView1.Columns[0].Width = 60;

                    //gridView3.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView3.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView3.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //gridView3.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    //var kutu = from k in dbS.SERVIS_KUTUSU
                    //           where (k.IMALATTARIHI >= tarih1 && k.IMALATTARIHI <= tarih2)
                    //           orderby k.CINSI
                    //           group k by new { k.CINSI } into g
                    //           select new
                    //           {
                    //               Cinsi = g.Key.CINSI,
                    //               Adet = g.Count()
                    //           };
                    //gridControl4.DataSource = kutu.ToList();

                    //gridView4.Columns[0].Caption = "CİNSİ";
                    //gridView4.Columns[1].Caption = "ADET";

                    //gridView4.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    //LblBaslik.Text = CmbSirket.Text + " TÜM BÖLGELER İCMALİ";
                    //LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
                }
                else
                {
                    SqlCommand daIlceKodu = new SqlCommand("SELECT ILCE_KODU FROM ILCE WHERE ILCE_ADI = @ilce", bgl.serhatgazBaglanti());
                    daIlceKodu.Parameters.AddWithValue("@ilce", CmbBolge.Text);
                    SqlDataReader drIlceKodu = daIlceKodu.ExecuteReader();
                    while (drIlceKodu.Read())
                    {
                        labelControl7.Text = drIlceKodu[0].ToString();
                    }
                    bgl.serhatgazBaglanti().Close();

                    int ilceKodu = Convert.ToInt32(labelControl7.Text);

                    SqlDataAdapter daPh = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(YATAY_ASBUILT_METRAJ), SUM(ASBUILT_METRAJ), SUM(KAZI_BOYU) " +
                            "FROM dbo.HATLAR " +
                            "WHERE MALZEME_CINSI = 'Polietilen' AND NET_BORU_CAPI NOT LIKE 'TB%' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'" +
                            "AND ILCE_KODU = " + ilceKodu + 
                            "GROUP BY NET_BORU_CAPI", bgl.serhatgazBaglanti());
                    DataTable dtPh = new DataTable();
                    daPh.Fill(dtPh);
                    gridControl1.DataSource = dtPh;

                    gridView1.Columns[0].Caption = "ÇAP";
                    gridView1.Columns[1].Caption = "BORU BOYU";
                    gridView1.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[2].Caption = "KAZI BOYU";
                    gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView1.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView1.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView1.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView1.Columns[0].Width = 60;

                    gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daCh = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU), SUM(YATAY_ASBUILT_METRAJ), SUM(ASBUILT_METRAJ), SUM(KAZI_BOYU) " +
                            "FROM dbo.HATLAR " +
                            "WHERE MALZEME_CINSI = 'Çelik' AND NET_BORU_CAPI NOT LIKE 'TB%' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "'" +
                            "AND ILCE_KODU = " + ilceKodu +
                            "GROUP BY NET_BORU_CAPI", bgl.serhatgazBaglanti());
                    DataTable dtCh = new DataTable();
                    daCh.Fill(dtCh);
                    gridControl2.DataSource = dtCh;

                    gridView2.Columns[0].Caption = "ÇAP";
                    gridView2.Columns[1].Caption = "BORU BOYU";
                    gridView2.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[2].Caption = "KAZI BOYU";
                    gridView2.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView2.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView2.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView2.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView2.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView2.Columns[0].Width = 60;

                    gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView2.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daSh = new SqlDataAdapter("SELECT CAP, SUM(BORUBOYU), SUM(KAZIBOYU), SUM(SHATTIMETRAJ), SUM(YATAY_ASBUILT_METRAJ) " +
                            "FROM dbo.SERVIS_HATLARI WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu + " GROUP BY CAP", bgl.serhatgazBaglanti());
                    DataTable dtSh = new DataTable();
                    daSh.Fill(dtSh);
                    gridControl3.DataSource = dtSh;

                    gridView3.Columns[0].Caption = "ÇAP";
                    gridView3.Columns[1].Caption = "BORU BOYU";
                    gridView3.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[1].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[2].Caption = "KAZI BOYU";
                    gridView3.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[2].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[3].Caption = "EĞİK ASBUİLT METRAJ";
                    gridView3.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[3].DisplayFormat.FormatString = "{0:n2}";
                    gridView3.Columns[4].Caption = "YATAY ASBUILT METRAJ";
                    gridView3.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView3.Columns[4].DisplayFormat.FormatString = "{0:n2}";

                    gridView3.Columns[0].Width = 60;

                    gridView3.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[1].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[2].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[3].SummaryItem.DisplayFormat = "{0:0.##}";
                    gridView3.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[4].SummaryItem.DisplayFormat = "{0:0.##}";

                    SqlDataAdapter daBePe = new SqlDataAdapter("SELECT TIPI + ' ' + CAP AS TIP, COUNT(CAP) FROM dbo.BAGLANTI_ELEMANLARI_PE " +
                        "WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu + 
                        " GROUP BY TIPI, CAP ORDER BY TIPI, CAP", bgl.serhatgazBaglanti());
                    DataTable dtBePe = new DataTable();
                    daBePe.Fill(dtBePe);
                    gridControl7.DataSource = dtBePe;

                    gridView7.Columns[0].Caption = "MALZEME TİPİ";
                    gridView7.Columns[1].Caption = "ADET";

                    gridView7.Columns[1].Width = 50;

                    gridView7.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView7.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daBeCe = new SqlDataAdapter("SELECT TIPI + ' ' + CAP AS TIP, COUNT(CAP) FROM dbo.BAGLANTI_ELEMANLARI_CELIK " +
                        "WHERE IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY TIPI, CAP ORDER BY TIPI, CAP", bgl.serhatgazBaglanti());
                    DataTable dtBeCe = new DataTable();
                    daBeCe.Fill(dtBeCe);
                    gridControl9.DataSource = dtBeCe;

                    gridView9.Columns[0].Caption = "MALZEME TİPİ";
                    gridView9.Columns[1].Caption = "ADET";

                    gridView9.Columns[1].Width = 50;

                    gridView9.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView9.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.VANA WHERE MALZEME_CINSI = 'Polietilen' " +
                        "AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CAP ORDER BY CAP", bgl.serhatgazBaglanti());
                    DataTable dtVana = new DataTable();
                    daVana.Fill(dtVana);
                    gridControl6.DataSource = dtVana;

                    gridView6.Columns[0].Caption = "ÇAP";
                    gridView6.Columns[1].Caption = "ADET";

                    gridView6.Columns[1].Width = 50;

                    gridView6.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView6.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daCVana = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.VANA WHERE MALZEME_CINSI = 'Çelik' " +
                        "AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CAP ORDER BY CAP", bgl.serhatgazBaglanti());
                    DataTable dtCVana = new DataTable();
                    daCVana.Fill(dtCVana);
                    gridControl8.DataSource = dtCVana;

                    gridView8.Columns[0].Caption = "ÇAP";
                    gridView8.Columns[1].Caption = "ADET";

                    gridView8.Columns[1].Width = 50;

                    gridView8.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView8.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daSe = new SqlDataAdapter("SELECT CAP, COUNT(CAP) FROM dbo.SERVIS_ELEMANLARI WHERE " +
                        "IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CAP ORDER BY CAP", bgl.serhatgazBaglanti());
                    DataTable dtSe = new DataTable();
                    daSe.Fill(dtSe);
                    gridControl5.DataSource = dtSe;

                    gridView5.Columns[0].Caption = "ÇAP";
                    gridView5.Columns[1].Caption = "ADET";

                    gridView5.Columns[1].Width = 50;

                    gridView5.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView5.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    SqlDataAdapter daSk = new SqlDataAdapter("SELECT CINSI, COUNT(CINSI) FROM dbo.SERVIS_KUTUSU WHERE " +
                        "IMALATTARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' AND ILCE_KODU = " + ilceKodu +
                        " GROUP BY CINSI ORDER BY CINSI", bgl.serhatgazBaglanti());
                    DataTable dtSk = new DataTable();
                    daSk.Fill(dtSk);
                    gridControl4.DataSource = dtSk;

                    gridView4.Columns[0].Caption = "CİNSİ";
                    gridView4.Columns[1].Caption = "ADET";

                    gridView4.Columns[1].Width = 50;

                    gridView4.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView4.Columns[1].SummaryItem.DisplayFormat = "{0}";

                    LblBaslik.Text = CmbSirket.Text + " - " + CmbBolge.Text + " İCMALİ";
                    LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
                }
            }

            if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0 && gridView5.RowCount == 0 && gridView6.RowCount == 0 && gridView7.RowCount == 0 && gridView8.RowCount == 0 && gridView9.RowCount == 0)
            {
                MessageBox.Show("Bu tarihler arasında bir veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void BtnIcmalListele_Click(object sender, EventArgs e)
        {
            listele();  
        }

        private void CmbSirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBolge.Text = "";
            CmbBolge.Properties.Items.Clear();

            if (CmbSirket.Text == "KARGAZ")
            {
                CmbBolge.Properties.Items.Add("TÜMÜ");
                SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbBolge.Properties.Items.Add(dr[0]);
                }
                bgl.kargazBaglanti().Close();
            }
            else if (CmbSirket.Text == "SERHATGAZ")
            {
                //CmbBolge.Properties.Items.Clear();

                SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.serhatgazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbBolge.Properties.Items.Add(dr[0]);
                }
                bgl.serhatgazBaglanti().Close();
            }
        }

        private void FrmIcmal_Load(object sender, EventArgs e)
        {
            DtBitisTarihi.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void BtnPdf_Click(object sender, EventArgs e)
        {
            
        }
    }
}
