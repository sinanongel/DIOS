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
        SerhatgazHaritaEntities dbS = new SerhatgazHaritaEntities();
        SqlBaglanti bgl = new SqlBaglanti();

        void listele()
        {            
            if (CmbSirket.Text == "KARGAZ")
            {                
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

            if (CmbSirket.Text == "SERHATGAZ")
            {
                DateTime tarih1 = DateTime.Parse(DtBaslangicTarihi.Text); //Convert.ToDateTime(DtBaslangicTarihi.Text);
                DateTime tarih2 = DateTime.Parse(DtBitisTarihi.Text); //Convert.ToDateTime(DtBitisTarihi.Text);

                if (CmbBolge.Text == "TÜMÜ")
                {
                    var polietilen = from h in dbS.HATLAR
                                     where h.MALZEME_CINSI == "Polietilen" && !h.NET_BORU_CAPI.Contains("TB") && (h.IMALAT_TARIHI >= tarih1 && h.IMALAT_TARIHI <= tarih2)
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

                    var celik = from h in dbS.HATLAR
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

                    var servis = from s in dbS.SERVIS_HATLARI
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

                    var kutu = from k in dbS.SERVIS_KUTUSU
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
                    int ilceKodu = Convert.ToInt32(dbS.ilce.FirstOrDefault(i => i.ilce_adi == CmbBolge.Text).ilce_kodu);
                    var polietilen = from h in dbS.HATLAR
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

                    var celik = from h in dbS.HATLAR
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

                    var servis = from s in dbS.SERVIS_HATLARI
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

                    var kutu = from k in dbS.SERVIS_KUTUSU
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
