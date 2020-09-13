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
using System.Data.Entity;

namespace KargazImalatTakip
{
    public partial class FrmIcmal : Form
    {
        public FrmIcmal()
        {
            InitializeComponent();
        }

        KargazHaritaEntities db = new KargazHaritaEntities();
        SqlBaglanti bgl = new SqlBaglanti();

        void listele()
        {
            //int indexNo;
            //string secilenAy = CmbAy.Text;

            //ArrayList turkceAylar = new ArrayList();
            //turkceAylar.Add("OCAK");
            //turkceAylar.Add("ŞUBAT");
            //turkceAylar.Add("MART");
            //turkceAylar.Add("NİSAN");
            //turkceAylar.Add("MAYIS");
            //turkceAylar.Add("HAZİRAN");
            //turkceAylar.Add("TEMMUZ");
            //turkceAylar.Add("AĞUSTOS");
            //turkceAylar.Add("EYLÜL");
            //turkceAylar.Add("EKİM");
            //turkceAylar.Add("KASIM");
            //turkceAylar.Add("ARALIK");

            //ArrayList ingilizceAylar = new ArrayList();
            //ingilizceAylar.Add("JANUARY");
            //ingilizceAylar.Add("FEBRUARY");
            //ingilizceAylar.Add("MARCH");
            //ingilizceAylar.Add("APRIL");
            //ingilizceAylar.Add("MAY");
            //ingilizceAylar.Add("JUNE");
            //ingilizceAylar.Add("JULY");
            //ingilizceAylar.Add("AUGUST");
            //ingilizceAylar.Add("SEPTEMBER");
            //ingilizceAylar.Add("OCTOBER");
            //ingilizceAylar.Add("NOVEMBER");
            //ingilizceAylar.Add("DECEMBER");

            //indexNo = turkceAylar.LastIndexOf(CmbAy.Text);
            //string ay = (ingilizceAylar[indexNo]).ToString();

            if (CmbSirket.Text == "KARGAZ")
            {
                //if (CmbBolge.Text == "TÜMÜ")
                //{
                //    SqlDataAdapter daTumPe = new SqlDataAdapter("SELECT NET_BORU_CAPI, SUM(BORU_UZUNLUGU) AS BU, SUM(KAZI_BOYU) KB, SUM(ASBUILT_METRAJ) AS ASM, SUM(YATAY_ASBUILT_METRAJ) AS YAM FROM KARGAZHARITA.DBO.HATLAR WHERE NET_BORU_CAPI NOT LIKE 'TB%' AND MALZEME_CINSI='Polietilen' AND  GROUP BY NET_BORU_CAPI ORDER BY NET_BORU_CAPI", bgl.kargazBaglanti());
                //    DataTable dtTumPe = new DataTable();
                //    daTumPe.Fill(dtTumPe);
                //    gridControl1.DataSource = dtTumPe;
                //} else
                //{
                //    SqlDataAdapter da = new SqlDataAdapter("SELECT NET_BORU_CAPI, sum(BORU_UZUNLUGU), sum(ASBUILT_METRAJ), sum(YATAY_ASBUILT_METRAJ), sum(KAZI_BOYU) FROM KargazHarita.dbo.HATLAR where NET_BORU_CAPI NOT LIKE 'TB%' and MALZEME_CINSI='Polietilen' AND datename(month, IMALAT_TARIHI) = '" + ay + "' AND YATIRIMYILI = " + CmbYil.Text + " group by NET_BORU_CAPI order by NET_BORU_CAPI", bgl.kargazBaglanti());
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    gridControl1.DataSource = dt;
                //}






                //SqlDataAdapter da = new SqlDataAdapter("SELECT NET_BORU_CAPI, sum(BORU_UZUNLUGU), sum(ASBUILT_METRAJ), sum(YATAY_ASBUILT_METRAJ), sum(KAZI_BOYU) FROM KargazHarita.dbo.HATLAR where NET_BORU_CAPI NOT LIKE 'TB%' and MALZEME_CINSI='Polietilen' AND datename(month, IMALAT_TARIHI) = '" + ay + "' AND YATIRIMYILI = " + CmbYil.Text + " group by NET_BORU_CAPI order by NET_BORU_CAPI", bgl.kargazBaglanti());
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //gridControl1.DataSource = dt;
                //var query = from h in db.HATLAR.Where(p => (new string[] { "40", "63", "90", "125" }).Contains(p.NET_BORU_CAPI))

                DateTime tarih1 = DateTime.Parse(DtBaslangicTarihi.Text); //Convert.ToDateTime(DtBaslangicTarihi.Text);
                DateTime tarih2 = DateTime.Parse(DtBitisTarihi.Text); //Convert.ToDateTime(DtBitisTarihi.Text);

                if (CmbBolge.Text == "TÜMÜ")
                {
                    var polietilen = from h in db.HATLAR
                                where h.MALZEME_CINSI=="Polietilen" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2)
                                orderby h.NET_BORU_CAPI
                                group h by new { h.NET_BORU_CAPI } into g
                                select new
                                {
                                    Çap = g.Key.NET_BORU_CAPI,
                                    BoruUzunluğu = g.Sum(t => t.BORU_UZUNLUGU),
                                    KazıBoyu = g.Sum(t => t.KAZI_BOYU),
                                    AsbuiltMetraj = g.Sum(t => t.ASBUILT_METRAJ),
                                    YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                                };
                    gridControl1.DataSource = polietilen.ToList();

                    gridView1.Columns[0].Caption = "ÇAP";
                    gridView1.Columns[1].Caption = "BORU BOYU";
                    gridView1.Columns[2].Caption = "KAZI BOYU";
                    gridView1.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView1.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    var celik = from h in db.HATLAR
                                where h.MALZEME_CINSI == "Çelik" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2)
                                orderby h.NET_BORU_CAPI
                                group h by new { h.NET_BORU_CAPI } into g
                                select new
                                {
                                    Çap = g.Key.NET_BORU_CAPI,
                                    BoruUzunluğu = g.Sum(t => t.BORU_UZUNLUGU),
                                    KazıBoyu = g.Sum(t => t.KAZI_BOYU),
                                    AsbuiltMetraj = g.Sum(t => t.ASBUILT_METRAJ),
                                    YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                                };
                    gridControl2.DataSource = celik.ToList();

                    gridView2.Columns[0].Caption = "ÇAP";
                    gridView2.Columns[1].Caption = "BORU BOYU";
                    gridView2.Columns[2].Caption = "KAZI BOYU";
                    gridView2.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView2.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    var servis = from s in db.SERVIS_HATLARI
                                     where (s.IMALATTARIHI >= tarih1 && s.IMALATTARIHI <= tarih2)
                                     orderby s.CAP
                                     group s by new { s.CAP } into g
                                     select new
                                     {
                                         Çap = g.Key.CAP,
                                         BoruUzunluğu = g.Sum(t => t.BORUBOYU),
                                         KazıBoyu = g.Sum(t => t.KAZIBOYU),
                                         EğikAsbuiltMetraj = g.Sum(t => t.SHATTIMETRAJ),
                                         YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                                     };
                    gridControl3.DataSource = servis.ToList();

                    gridView3.Columns[0].Caption = "ÇAP";
                    gridView3.Columns[1].Caption = "BORU BOYU";
                    gridView3.Columns[2].Caption = "KAZI BOYU";
                    gridView3.Columns[3].Caption = "EĞİK ASBUİLT METRAJ";
                    gridView3.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    gridView3.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    var kutu = from k in db.SERVIS_KUTUSU
                                 where (k.IMALATTARIHI >= tarih1 && k.IMALATTARIHI <= tarih2)
                                 orderby k.CINSI
                                 group k by new { k.CINSI } into g
                                 select new
                                 {
                                     Cinsi = g.Key.CINSI,
                                     Adet = g.Count()
                                 };
                    gridControl4.DataSource = kutu.ToList();

                    gridView4.Columns[0].Caption = "CİNSİ";
                    gridView4.Columns[1].Caption = "ADET";

                    gridView4.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    LblBaslik.Text = CmbSirket.Text + " TÜM BÖLGELER İCMALİ";
                    LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
                }
                else
                {
                    int ilceKodu = Convert.ToInt32(db.ilce.FirstOrDefault(i => i.ilce_adi == CmbBolge.Text).ilce_kodu);
                    var polietilen = from h in db.HATLAR
                                where h.MALZEME_CINSI == "Polietilen" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2) && h.ILCE_KODU == ilceKodu
                                orderby h.NET_BORU_CAPI
                                group h by h.NET_BORU_CAPI into g
                                select new
                                {
                                    Çap = g.Key,
                                    BoruUzunluğu = g.Sum(t => t.BORU_UZUNLUGU),
                                    KazıBoyu = g.Sum(t => t.KAZI_BOYU),
                                    AsbuiltMetraj = g.Sum(t => t.ASBUILT_METRAJ),
                                    YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ),
                                };
                    gridControl1.DataSource = polietilen.ToList();

                    gridView1.Columns[0].Caption = "ÇAP";
                    gridView1.Columns[1].Caption = "BORU BOYU";
                    gridView1.Columns[2].Caption = "KAZI BOYU";
                    gridView1.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView1.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    gridView1.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    var celik = from h in db.HATLAR
                                where h.MALZEME_CINSI == "Çelik" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2) && h.ILCE_KODU == ilceKodu
                                orderby h.NET_BORU_CAPI
                                group h by new { h.NET_BORU_CAPI } into g
                                select new
                                {
                                    Çap = g.Key.NET_BORU_CAPI,
                                    BoruUzunluğu = g.Sum(t => t.BORU_UZUNLUGU),
                                    KazıBoyu = g.Sum(t => t.KAZI_BOYU),
                                    AsbuiltMetraj = g.Sum(t => t.ASBUILT_METRAJ),
                                    YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                                };
                    gridControl2.DataSource = celik.ToList();

                    gridView2.Columns[0].Caption = "ÇAP";
                    gridView2.Columns[1].Caption = "BORU BOYU";
                    gridView2.Columns[2].Caption = "KAZI BOYU";
                    gridView2.Columns[3].Caption = "ASBUILT METRAJ";
                    gridView2.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView2.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    var servis = from s in db.SERVIS_HATLARI
                                 where (s.IMALATTARIHI >= tarih1 && s.IMALATTARIHI <= tarih2) && s.ILCE_KODU == ilceKodu
                                 orderby s.CAP
                                 group s by new { s.CAP } into g
                                 select new
                                 {
                                     Çap = g.Key.CAP,
                                     BoruUzunluğu = g.Sum(t => t.BORUBOYU),
                                     KazıBoyu = g.Sum(t => t.KAZIBOYU),
                                     EğikAsbuiltMetraj = g.Sum(t => t.SHATTIMETRAJ),
                                     YatayAsbuiltMetraj = g.Sum(t => t.YATAY_ASBUILT_METRAJ)
                                 };
                    gridControl3.DataSource = servis.ToList();

                    gridView3.Columns[0].Caption = "ÇAP";
                    gridView3.Columns[1].Caption = "BORU BOYU";
                    gridView3.Columns[2].Caption = "KAZI BOYU";
                    gridView3.Columns[3].Caption = "EĞİK ASBUİLT METRAJ";
                    gridView3.Columns[4].Caption = "YATAY ASBUILT METRAJ";

                    gridView3.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView3.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    var kutu = from k in db.SERVIS_KUTUSU
                               where (k.IMALATTARIHI >= tarih1 && k.IMALATTARIHI <= tarih2) && k.ILCE_KODU == ilceKodu
                               orderby k.CINSI
                               group k by new { k.CINSI } into g
                               select new
                               {
                                   Cinsi = g.Key.CINSI,
                                   Adet = g.Count()
                               };
                    gridControl4.DataSource = kutu.ToList();

                    gridView4.Columns[0].Caption = "CİNSİ";
                    gridView4.Columns[1].Caption = "ADET";

                    gridView4.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    LblBaslik.Text = CmbSirket.Text + " - " + CmbBolge.Text + " İCMALİ";
                    LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
                }
            }
        }
        
        private void BtnIcmalListele_Click(object sender, EventArgs e)
        {
            listele();  
        }

        private void CmbSirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CmbBolge.Text = "";
            //CmbBolge.Properties.Items.Clear();

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
    }
}
