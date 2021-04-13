using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;

namespace KargazImalatTakip
{
    public partial class FrmStFormDuzeltme : Form
    {
        public FrmStFormDuzeltme()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtFormNoYeni.Text = "";
            TxtYatirimYili.Text = "";
            TxtImalatTarihi.Text = "";
            TxtBolge.Text = "";
            TxtSektor.Text = "";
            TxtVanaNo.Text = "";

            gridView1.Columns.Clear();
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();
            gridView5.Columns.Clear();

            CheTumunuSec.Checked = false;
        }

        void listele()
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                        "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                        "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO, DOSYA FROM dbo.HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE H.MALZEME_CINSI = 'Celik' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                        "ORDER BY H.MSLINK", bgl.kargazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

                    gridView1.Columns["ILCE_ADI"].Width = 100;
                    gridView1.Columns["MAHALLE"].Width = 100;
                    gridView1.Columns["YOL"].Width = 200;

                    gridView1.Columns["YATIRIMYILI"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
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

                    RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                    gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                    dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT B.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, B.IMALATTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_CELIK B " +
                        "LEFT JOIN DBO.YOL Y ON B.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO = '" + TxtFormNo.Text + "'" + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
                        "ORDER BY B.MSLINK", bgl.kargazBaglanti());
                    DataTable dtMalzeme = new DataTable();
                    daMalzeme.Fill(dtMalzeme);
                    GrCoMalzeme.DataSource = dtMalzeme;

                    gridView2.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView2.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView2.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView2.Columns["FORMNO"].Caption = "FORM NO";
                    gridView2.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView2.Columns["TIPI"].Caption = "TİPİ";
                    gridView2.Columns["CAP"].Caption = "ÇAP";
                    gridView2.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    SqlDataAdapter daKaynak = new SqlDataAdapter("SELECT K.MSLINK, FORMNO, K.KAYNAKNO, YATIRIMYILI, convert(varchar, KAYNAKTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, KAYNAKNO, CAP FROM dbo.KAYNAK K " +
                        "LEFT JOIN DBO.YOL Y ON K.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON K.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON K.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
                        "ORDER BY K.MSLINK", bgl.kargazBaglanti());
                    DataTable dtKaynak = new DataTable();
                    daKaynak.Fill(dtKaynak);
                    GrCoKaynak.DataSource = dtKaynak;

                    gridView4.Columns["KAYNAKNO"].Caption = "KAYNAK NO";
                    gridView4.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView4.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView4.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView4.Columns["FORMNO"].Caption = "FORM NO";
                    gridView4.Columns["KAYNAKNO"].Caption = "KAYNAK NO";
                    gridView4.Columns["CAP"].Caption = "ÇAP";

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT V.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, V.IMALAT_TARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA V " +
                        "LEFT JOIN DBO.YOL Y ON V.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON V.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON V.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =  'C" + TxtFormNo.Text + "'" + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
                        "ORDER BY V.MSLINK", bgl.kargazBaglanti());
                    DataTable dtVana = new DataTable();
                    daVana.Fill(dtVana);
                    GrCoVana.DataSource = dtVana;

                    gridView3.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView3.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView3.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView3.Columns["FORMNO"].Caption = "FORM NO";
                    gridView3.Columns["VANA_NO"].Caption = "VANA NO";
                    gridView3.Columns["BOLGE"].Caption = "BÖLGE";
                    gridView3.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView3.Columns["VANA_TIPI"].Caption = "VANA TİPİ";
                    gridView3.Columns["CAP"].Caption = "ÇAP";

                    SqlDataAdapter daBr = new SqlDataAdapter("SELECT B.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, REGULATORADI, REGULATORTIPI FROM dbo.BOLGE_REGULATORU B " +
                            "LEFT JOIN DBO.YOL Y ON B.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' ", bgl.kargazBaglanti());
                    DataTable dtBr = new DataTable();
                    daBr.Fill(dtBr);
                    GrCoBr.DataSource = dtBr;

                    gridView5.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView5.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView5.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView5.Columns["FORMNO"].Caption = "FORM NO";
                    gridView5.Columns["REGULATORADI"].Caption = "REGÜLATÖR ADI";
                    gridView5.Columns["REGULATORTIPI"].Caption = "REGÜLATÖR TİPİ";
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                //try
                //{
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                        "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                        "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO, DOSYA FROM dbo.HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE H.MALZEME_CINSI = 'Celik' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                        "ORDER BY H.MSLINK", bgl.serhatgazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                GrCoHat.DataSource = dtHat;

                gridView1.Columns["ILCE_ADI"].Width = 100;
                gridView1.Columns["MAHALLE"].Width = 100;
                gridView1.Columns["YOL"].Width = 200;

                gridView1.Columns["YATIRIMYILI"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
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

                RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT B.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, B.IMALATTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_CELIK B " +
                        "LEFT JOIN DBO.YOL Y ON B.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO = '" + TxtFormNo.Text + "'" + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
                        "ORDER BY B.MSLINK", bgl.serhatgazBaglanti());
                DataTable dtMalzeme = new DataTable();
                daMalzeme.Fill(dtMalzeme);
                GrCoMalzeme.DataSource = dtMalzeme;

                gridView2.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView2.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView2.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView2.Columns["FORMNO"].Caption = "FORM NO";
                gridView2.Columns["SEKTOR"].Caption = "SEKTÖR";
                gridView2.Columns["TIPI"].Caption = "TİPİ";
                gridView2.Columns["CAP"].Caption = "ÇAP";
                gridView2.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                SqlDataAdapter daVana = new SqlDataAdapter("SELECT V.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, V.IMALAT_TARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA V " +
                        "LEFT JOIN DBO.YOL Y ON V.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON V.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON V.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =  'C" + TxtFormNo.Text + "'" + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
                        "ORDER BY V.MSLINK", bgl.serhatgazBaglanti());
                DataTable dtVana = new DataTable();
                daVana.Fill(dtVana);
                GrCoVana.DataSource = dtVana;

                gridView3.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView3.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView3.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView3.Columns["FORMNO"].Caption = "FORM NO";
                gridView3.Columns["VANA_NO"].Caption = "VANA NO";
                gridView3.Columns["BOLGE"].Caption = "BÖLGE";
                gridView3.Columns["SEKTOR"].Caption = "SEKTÖR";
                gridView3.Columns["VANA_TIPI"].Caption = "VANA TİPİ";
                gridView3.Columns["CAP"].Caption = "ÇAP";

                SqlDataAdapter daKaynak = new SqlDataAdapter("SELECT K.MSLINK, FORMNO, K.KAYNAKNO, YATIRIMYILI, convert(varchar, KAYNAKTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, KAYNAKNO, CAP FROM dbo.KAYNAK K " +
                        "LEFT JOIN DBO.YOL Y ON K.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON K.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON K.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
                        "ORDER BY K.MSLINK", bgl.serhatgazBaglanti());
                DataTable dtKaynak = new DataTable();
                daKaynak.Fill(dtKaynak);
                GrCoKaynak.DataSource = dtKaynak;

                gridView4.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView4.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView4.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView4.Columns["FORMNO"].Caption = "FORM NO";
                gridView4.Columns["KAYNAKNO"].Caption = "KAYNAK NO";
                gridView4.Columns["CAP"].Caption = "ÇAP";

                SqlDataAdapter daBr = new SqlDataAdapter("SELECT B.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, REGULATORADI, REGULATORTIPI FROM dbo.BOLGE_REGULATORU B " +
                            "LEFT JOIN DBO.YOL Y ON B.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' ", bgl.serhatgazBaglanti());
                DataTable dtBr = new DataTable();
                daBr.Fill(dtBr);
                GrCoBr.DataSource = dtBr;

                gridView5.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView5.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView5.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView5.Columns["FORMNO"].Caption = "FORM NO";
                gridView5.Columns["REGULATORADI"].Caption = "REGÜLATÖR ADI";
                gridView5.Columns["REGULATORTIPI"].Caption = "REGÜLATÖR TİPİ";
                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            listele();

            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    if (gridView1.RowCount != 0)
                    {
                        SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR, BORU_UZUNLUGU, KAZI_BOYU" +
                            " FROM DBO.HATLAR H WHERE MALZEME_CINSI='Celik' AND FORMNO=@P1 AND H.ILCE_KODU=@P2", bgl.kargazBaglanti());
                        komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                        komutHat.Parameters.AddWithValue("@P2", labelControl15.Text);
                        SqlDataReader drHat = komutHat.ExecuteReader();
                        while (drHat.Read())
                        {
                            TxtFormNoYeni.Text = drHat[0].ToString();
                            TxtYatirimYili.Text = drHat[1].ToString();
                            TxtImalatTarihi.Text = drHat[2].ToString();
                            TxtSektor.Text = drHat[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA V WHERE FORMNO=@P3 AND V.ILCE_KODU=@P4", bgl.kargazBaglanti());
                        komutVana.Parameters.AddWithValue("@P3", "C" + TxtFormNo.Text);
                        komutVana.Parameters.AddWithValue("@P4", labelControl15.Text);
                        SqlDataReader drVana = komutVana.ExecuteReader();
                        while (drVana.Read())
                        {
                            TxtBolge.Text = drVana[0].ToString();
                            TxtVanaNo.Text = drVana[1].ToString();
                        }
                        bgl.kargazBaglanti().Close();
                    }
                    else
                    {
                        SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR " +
                            "FROM dbo.BAGLANTI_ELEMANLARI_CELIK B WHERE FORMNO=@P1 AND B.ILCE_KODU=@P4", bgl.kargazBaglanti());
                        komutMalzeme.Parameters.AddWithValue("@P5", TxtFormNo.Text);
                        komutMalzeme.Parameters.AddWithValue("@P6", labelControl15.Text);
                        SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                        while (drMalzeme.Read())

                        {
                            TxtFormNoYeni.Text = drMalzeme[0].ToString();
                            TxtYatirimYili.Text = drMalzeme[1].ToString();
                            TxtImalatTarihi.Text = drMalzeme[2].ToString();
                            TxtSektor.Text = drMalzeme[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA V WHERE FORMNO=@P7 AND V.ILCE_KODU=@P8", bgl.kargazBaglanti());
                        komutVana.Parameters.AddWithValue("@P7", "C" + TxtFormNo.Text);
                        komutVana.Parameters.AddWithValue("@P8", labelControl15.Text);
                        SqlDataReader drVana = komutVana.ExecuteReader();
                        while (drVana.Read())
                        {
                            TxtBolge.Text = drVana[0].ToString();
                            TxtVanaNo.Text = drVana[1].ToString();
                        }
                        bgl.kargazBaglanti().Close();
                    }
                    if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0)
                    {
                        SqlCommand komutBr = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI FROM dbo.BOLGE_REGULATORU " +
                            "WHERE FORMNO=@P9 AND B.ILCE_KODU=@P10", bgl.kargazBaglanti());
                        komutBr.Parameters.AddWithValue("@P9", TxtFormNo.Text);
                        komutBr.Parameters.AddWithValue("@P10", labelControl15.Text);
                        SqlDataReader drBr = komutBr.ExecuteReader();
                        while (drBr.Read())
                        {
                            TxtFormNoYeni.Text = drBr[0].ToString();
                            TxtYatirimYili.Text = drBr[1].ToString();
                            TxtImalatTarihi.Text = drBr[2].ToString();
                        }
                        bgl.serhatgazBaglanti().Close();
                    }
                    if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0)
                    {
                        MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                    if (gridView1.RowCount != 0)
                    {
                        SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR, BORU_UZUNLUGU, KAZI_BOYU" +
                            " FROM DBO.HATLAR H WHERE MALZEME_CINSI='Celik' AND FORMNO=@P1 AND H.ILCE_KODU=@P2", bgl.serhatgazBaglanti());
                        komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                        komutHat.Parameters.AddWithValue("@P2", labelControl15.Text);
                        SqlDataReader drHat = komutHat.ExecuteReader();
                        while (drHat.Read())
                        {
                            TxtFormNoYeni.Text = drHat[0].ToString();
                            TxtYatirimYili.Text = drHat[1].ToString();
                            TxtImalatTarihi.Text = drHat[2].ToString();
                            TxtSektor.Text = drHat[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA V WHERE FORMNO=@P3 AND V.ILCE_KODU=@P4", bgl.serhatgazBaglanti());
                        komutVana.Parameters.AddWithValue("@P3", "C" + TxtFormNo.Text);
                        komutVana.Parameters.AddWithValue("@P4", labelControl15.Text);
                        SqlDataReader drVana = komutVana.ExecuteReader();
                        while (drVana.Read())
                        {
                            TxtBolge.Text = drVana[0].ToString();
                            TxtVanaNo.Text = drVana[1].ToString();
                        }
                        bgl.kargazBaglanti().Close();
                    }
                    else
                    {
                        SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR " +
                            "FROM dbo.BAGLANTI_ELEMANLARI_CELIK B WHERE FORMNO=@P1 AND B.ILCE_KODU=@P4", bgl.serhatgazBaglanti());
                        komutMalzeme.Parameters.AddWithValue("@P5", TxtFormNo.Text);
                        komutMalzeme.Parameters.AddWithValue("@P6", labelControl15.Text);
                        SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                        while (drMalzeme.Read())

                        {
                            TxtFormNoYeni.Text = drMalzeme[0].ToString();
                            TxtYatirimYili.Text = drMalzeme[1].ToString();
                            TxtImalatTarihi.Text = drMalzeme[2].ToString();
                            TxtSektor.Text = drMalzeme[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA V WHERE FORMNO=@P7 AND V.ILCE_KODU=@P8", bgl.serhatgazBaglanti());
                        komutVana.Parameters.AddWithValue("@P7", "C" + TxtFormNo.Text);
                        komutVana.Parameters.AddWithValue("@P8", labelControl15.Text);
                        SqlDataReader drVana = komutVana.ExecuteReader();
                        while (drVana.Read())
                        {
                            TxtBolge.Text = drVana[0].ToString();
                            TxtVanaNo.Text = drVana[1].ToString();
                        }
                        bgl.kargazBaglanti().Close();
                    }
                    if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0)
                    {
                        SqlCommand komutBr = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI FROM dbo.BOLGE_REGULATORU " +
                            "WHERE FORMNO=@P9 AND B.ILCE_KODU=@P10", bgl.serhatgazBaglanti());
                        komutBr.Parameters.AddWithValue("@P9", TxtFormNo.Text);
                        komutBr.Parameters.AddWithValue("@P10", labelControl15.Text);
                        SqlDataReader drBr = komutBr.ExecuteReader();
                        while (drBr.Read())
                        {
                            TxtFormNoYeni.Text = drBr[0].ToString();
                            TxtYatirimYili.Text = drBr[1].ToString();
                            TxtImalatTarihi.Text = drBr[2].ToString();
                        }
                        bgl.serhatgazBaglanti().Close();
                    }
                    if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0 && gridView5.RowCount == 0)
                    {
                        MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        string dosyaYolu = "";
        private void DosyaYolu_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");

            string yol;
            string bolge;
            string dosya;

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                dosya = dr["DOSYA"].ToString();
                bolge = dr["ILCE_ADI"].ToString();
                dosyaYolu = satir[5] + bolge + "\\";
                yol = dosyaYolu + dosya;
                Process.Start(yol);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    var secHat = gridView1.GetSelectedRows();
                    List<int> secHatMslink = new List<int>();
                    foreach (int handle in secHat)
                    {
                        secHatMslink.Add(Convert.ToInt32(gridView1.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secMalzeme = gridView2.GetSelectedRows();
                    List<int> secMalzemeMslink = new List<int>();
                    foreach (int handle in secMalzeme)
                    {
                        secMalzemeMslink.Add(Convert.ToInt32(gridView2.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secVana = gridView3.GetSelectedRows();
                    List<int> secVanaMslink = new List<int>();
                    foreach (int handle in secVana)
                    {
                        secVanaMslink.Add(Convert.ToInt32(gridView3.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secKaynak = gridView4.GetSelectedRows();
                    List<int> secKaynakMslink = new List<int>();
                    foreach (int handle in secKaynak)
                    {
                        secKaynakMslink.Add(Convert.ToInt32(gridView4.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secBr = gridView5.GetSelectedRows();
                    List<int> secBrMslink = new List<int>();
                    foreach (int handle in secBr)
                    {
                        secBrMslink.Add(Convert.ToInt32(gridView5.GetRowCellValue(handle, "MSLINK")));
                    }

                    if (secHatMslink.Count == 0 && secMalzemeMslink.Count == 0 && secVanaMslink.Count == 0)
                    {
                        MessageBox.Show("Lütfen bir seçim yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult soru;
                        soru = MessageBox.Show("Bu bilgileri güncellemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (soru == DialogResult.Yes)
                        {
                            foreach (int hatMslink in secHatMslink)
                            {
                                SqlCommand komutHat = new SqlCommand("UPDATE dbo.HATLAR SET FORMNO=@p1, YATIRIMYILI=@p2, IMALAT_TARIHI=@p3, SEKTOR=@p4 where MSLINK=" + hatMslink, bgl.kargazBaglanti());
                                komutHat.Parameters.AddWithValue("@p1", TxtFormNoYeni.Text);
                                komutHat.Parameters.AddWithValue("@p2", TxtYatirimYili.Text);
                                komutHat.Parameters.AddWithValue("@p3", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutHat.Parameters.AddWithValue("@p4", TxtSektor.Text);
                                komutHat.ExecuteNonQuery();
                                bgl.kargazBaglanti().Close();
                            }
                            foreach (int malzemeMslink in secMalzemeMslink)
                            {
                                SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_CELIK SET FORMNO=@p5, YATIRIMYILI=@p6, IMALATTARIHI=@p7, SEKTOR=@p9 where MSLINK=" + malzemeMslink, bgl.kargazBaglanti());
                                komutMalzeme.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                                komutMalzeme.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                                komutMalzeme.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutMalzeme.Parameters.AddWithValue("@p9", TxtSektor.Text);
                                komutMalzeme.ExecuteNonQuery();
                                bgl.kargazBaglanti().Close();
                            }
                            foreach (int kaynakMslink in secKaynakMslink)
                            {
                                SqlCommand komutKaynak = new SqlCommand("UPDATE dbo.KAYNAK SET FORMNO=@p16, YATIRIMYILI=@p17, KAYNAKTARIHI=@p18 where MSLINK=" + kaynakMslink, bgl.kargazBaglanti());
                                komutKaynak.Parameters.AddWithValue("@p16", TxtFormNoYeni.Text);
                                komutKaynak.Parameters.AddWithValue("@p17", TxtYatirimYili.Text);
                                komutKaynak.Parameters.AddWithValue("@p18", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutKaynak.ExecuteNonQuery();
                                bgl.kargazBaglanti().Close();
                            }
                            foreach (int vanaMslink in secVanaMslink)
                            {
                                SqlCommand komutVana = new SqlCommand("UPDATE dbo.VANA SET FORMNO=@p10, YATIRIMYILI=@p11, IMALAT_TARIHI=@p12, VANA_NO=@p13, BOLGE=@p14, SEKTOR=@p15 where MSLINK=" + vanaMslink, bgl.kargazBaglanti());
                                komutVana.Parameters.AddWithValue("@p10", "C" + TxtFormNoYeni.Text);
                                komutVana.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                                komutVana.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutVana.Parameters.AddWithValue("@p13", TxtVanaNo.Text);
                                komutVana.Parameters.AddWithValue("@p14", TxtBolge.Text);
                                komutVana.Parameters.AddWithValue("@p15", TxtSektor.Text);
                                komutVana.ExecuteNonQuery();
                                bgl.kargazBaglanti().Close();
                            }
                            foreach (int brMslink in secBrMslink)
                            {
                                SqlCommand komutBr = new SqlCommand("UPDATE dbo.VANA SET FORMNO=@p19, YATIRIMYILI=@p20, IMALAT_TARIHI=@p21 where MSLINK=" + brMslink, bgl.kargazBaglanti());
                                komutBr.Parameters.AddWithValue("@p19", TxtFormNoYeni.Text);
                                komutBr.Parameters.AddWithValue("@p20", TxtYatirimYili.Text);
                                komutBr.Parameters.AddWithValue("@p21", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutBr.ExecuteNonQuery();
                                bgl.kargazBaglanti().Close();
                            }
                            listele();
                            MessageBox.Show("Tüm Bilgiler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
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
                    var secHat = gridView1.GetSelectedRows();
                    List<int> secHatMslink = new List<int>();
                    foreach (int handle in secHat)
                    {
                        secHatMslink.Add(Convert.ToInt32(gridView1.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secMalzeme = gridView2.GetSelectedRows();
                    List<int> secMalzemeMslink = new List<int>();
                    foreach (int handle in secMalzeme)
                    {
                        secMalzemeMslink.Add(Convert.ToInt32(gridView2.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secVana = gridView3.GetSelectedRows();
                    List<int> secVanaMslink = new List<int>();
                    foreach (int handle in secVana)
                    {
                        secVanaMslink.Add(Convert.ToInt32(gridView3.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secKaynak = gridView4.GetSelectedRows();
                    List<int> secKaynakMslink = new List<int>();
                    foreach (int handle in secKaynak)
                    {
                        secKaynakMslink.Add(Convert.ToInt32(gridView4.GetRowCellValue(handle, "MSLINK")));
                    }

                    var secBr = gridView5.GetSelectedRows();
                    List<int> secBrMslink = new List<int>();
                    foreach (int handle in secBr)
                    {
                        secBrMslink.Add(Convert.ToInt32(gridView5.GetRowCellValue(handle, "MSLINK")));
                    }

                    if (secHatMslink.Count == 0 && secMalzemeMslink.Count == 0 && secVanaMslink.Count == 0 && secKaynakMslink.Count == 0 && secBrMslink.Count == 0)
                    {
                        MessageBox.Show("Lütfen bir seçim yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult soru;
                        soru = MessageBox.Show("Bu bilgileri güncellemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (soru == DialogResult.Yes)
                        {
                            foreach (int hatMslink in secHatMslink)
                            {
                                SqlCommand komutHat = new SqlCommand("UPDATE dbo.HATLAR SET FORMNO=@p1, YATIRIMYILI=@p2, IMALAT_TARIHI=@p3, SEKTOR=@p4, ESKIFORMNO=@p5 where MSLINK=" + hatMslink, bgl.serhatgazBaglanti());
                                komutHat.Parameters.AddWithValue("@p1", TxtFormNoYeni.Text);
                                komutHat.Parameters.AddWithValue("@p2", TxtYatirimYili.Text);
                                komutHat.Parameters.AddWithValue("@p3", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutHat.Parameters.AddWithValue("@p4", TxtSektor.Text);
                                komutHat.Parameters.AddWithValue("@p5", TxtFormNo.Text);
                                komutHat.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            foreach (int malzemeMslink in secMalzemeMslink)
                            {
                                SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_CELIK SET FORMNO=@p5, YATIRIMYILI=@p6, IMALATTARIHI=@p7, SEKTOR=@p9, ESKIFORMNO=@p10 where MSLINK=" + malzemeMslink, bgl.serhatgazBaglanti());
                                komutMalzeme.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                                komutMalzeme.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                                komutMalzeme.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutMalzeme.Parameters.AddWithValue("@p9", TxtSektor.Text);
                                komutMalzeme.Parameters.AddWithValue("@p10", TxtFormNo.Text);
                                komutMalzeme.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            foreach (int vanaMslink in secVanaMslink)
                            {
                                SqlCommand komutVana = new SqlCommand("UPDATE dbo.VANA SET FORMNO=@p10, YATIRIMYILI=@p11, IMALAT_TARIHI=@p12,  VANA_NO=@p13, BOLGE=@p14, SEKTOR=@p15, ESKIFORMNO=@p16 where MSLINK=" + vanaMslink, bgl.serhatgazBaglanti());
                                komutVana.Parameters.AddWithValue("@p10", "C" + TxtFormNoYeni.Text);
                                komutVana.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                                komutVana.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutVana.Parameters.AddWithValue("@p13", TxtVanaNo.Text);
                                komutVana.Parameters.AddWithValue("@p14", TxtBolge.Text);
                                komutVana.Parameters.AddWithValue("@p15", TxtSektor.Text);
                                komutVana.Parameters.AddWithValue("@p16", TxtFormNo.Text);
                                komutVana.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            foreach (int kaynakMslink in secKaynakMslink)
                            {
                                SqlCommand komutKaynak = new SqlCommand("UPDATE dbo.KAYNAK SET FORMNO=@p17, YATIRIMYILI=@p18, KAYNAKTARIHI=@p19, ESKIFORMNO=@p20 where MSLINK=" + kaynakMslink, bgl.serhatgazBaglanti());
                                komutKaynak.Parameters.AddWithValue("@p17", TxtFormNoYeni.Text);
                                komutKaynak.Parameters.AddWithValue("@p18", TxtYatirimYili.Text);
                                komutKaynak.Parameters.AddWithValue("@p19", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutKaynak.Parameters.AddWithValue("@p20", TxtFormNo.Text);
                                komutKaynak.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            foreach (int brMslink in secBrMslink)
                            {
                                SqlCommand komutBr = new SqlCommand("UPDATE dbo.BOLGE_REGULATORU SET FORMNO=@p21, YATIRIMYILI=@p22, IMALATTARIHI=@p23, ESKIFORMNO=@p24 where MSLINK=" + brMslink, bgl.serhatgazBaglanti());
                                komutBr.Parameters.AddWithValue("@p21", TxtFormNoYeni.Text);
                                komutBr.Parameters.AddWithValue("@p22", TxtYatirimYili.Text);
                                komutBr.Parameters.AddWithValue("@p23", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutBr.Parameters.AddWithValue("@p24", TxtFormNo.Text);
                                komutBr.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            listele();
                            MessageBox.Show("Tüm Bilgiler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CheTumunuSec_CheckedChanged(object sender, EventArgs e)
        {
            if (CheTumunuSec.Checked == false)
            {
                gridView1.ClearSelection();
                gridView2.ClearSelection();
                gridView3.ClearSelection();
                gridView4.ClearSelection();
                gridView5.ClearSelection();
            }
            if (CheTumunuSec.Checked == true)
            {
                gridView1.SelectAll();
                gridView2.SelectAll();
                gridView3.SelectAll();
                gridView4.SelectAll();
                gridView5.SelectAll();
            }
        }

        private void TxtFormNoYeni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CmbŞirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBolge.Text = "";
            CmbBolge.Properties.Items.Clear();

            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        CmbBolge.Properties.Items.Add(dr[0]);
                    }
                    bgl.kargazBaglanti().Close();
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
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
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CmbBolge_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlCommand bolgeOku = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI=@bolge", bgl.kargazBaglanti());
                    bolgeOku.Parameters.AddWithValue("@bolge", CmbBolge.Text);
                    SqlDataReader drBolge = bolgeOku.ExecuteReader();
                    while (drBolge.Read())
                    {
                        labelControl15.Text = drBolge[0].ToString();
                    }
                    bgl.kargazBaglanti().Close();
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlCommand bolgeOku = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI=@bolge", bgl.serhatgazBaglanti());
                    bolgeOku.Parameters.AddWithValue("@bolge", CmbBolge.Text);
                    SqlDataReader drBolge = bolgeOku.ExecuteReader();
                    while (drBolge.Read())
                    {
                        labelControl15.Text = drBolge[0].ToString();
                    }
                    bgl.serhatgazBaglanti().Close();
                }
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string kaynakDosyaYolu = "";
        string kayitYolu = "";

        private void BtnDosyaYukle_Click(object sender, EventArgs e)
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");
            kayitYolu = satir[5] + CmbBolge.Text + "\\";

            var secHat = gridView1.GetSelectedRows();
            List<int> secHatMslink = new List<int>();
            foreach (int handle in secHat)
            {
                secHatMslink.Add(Convert.ToInt32(gridView1.GetRowCellValue(handle, "MSLINK")));
            }

            string yatirimYil;
            string bolge;

            if (secHatMslink.Count == 0)
            {
                MessageBox.Show("Lütfen bir seçim yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (int hatMslink in secHatMslink)
                {
                    if (Directory.Exists(kayitYolu))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(kayitYolu);
                    }

                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    if (dr != null)
                    {
                        yatirimYil = dr["YATIRIMYILI"].ToString();
                        bolge = dr["ILCE_ADI"].ToString();
                        if (bolge == "SELİM")
                        {
                            bolge = "SELIM";
                        }
                        else if (bolge == "GÖLE")
                        {
                            bolge = "GOLE";
                        }
                        else if (bolge == "SARIKAMIŞ")
                        {
                            bolge = "SARIKAMIS";
                        }
                        else if (bolge == "IĞDIR MERKEZ")
                        {
                            bolge = "IGDIR MERKEZ";
                        }
                        string dosyaAdi = bolge + "_ST_" + yatirimYil + "_" + TxtFormNoYeni.Text + ".pdf";
                        string dosyaYolu = kayitYolu + dosyaAdi;

                        if (CmbŞirket.Text == "KARGAZ")
                        {
                            SqlCommand komut = new SqlCommand("UPDATE HATLAR SET DOSYA = @p1 WHERE MSLINK = " + hatMslink, bgl.kargazBaglanti());
                            komut.Parameters.AddWithValue("@p1", dosyaAdi);
                            komut.ExecuteNonQuery();
                            bgl.kargazBaglanti().Close();
                        }
                        else if (CmbŞirket.Text == "SERHATGAZ")
                        {
                            SqlCommand komut = new SqlCommand("UPDATE HATLAR SET DOSYA = @p1 WHERE MSLINK = " + hatMslink, bgl.serhatgazBaglanti());
                            komut.Parameters.AddWithValue("@p1", dosyaAdi);
                            komut.ExecuteNonQuery();
                            bgl.serhatgazBaglanti().Close();
                        }

                        if (File.Exists(dosyaYolu))
                        {

                        }
                        else
                        {
                            File.Copy(kaynakDosyaYolu, dosyaYolu);
                        }
                    }
                }
                MessageBox.Show("Kayıt İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void BtnDosyaSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Pdf Dosyası | *.pdf";
            dosya.FilterIndex = 2;
            dosya.RestoreDirectory = true;
            dosya.ShowDialog();

            string secilenDosya = dosya.SafeFileName;
            kaynakDosyaYolu = dosya.FileName;
            TxtDosyaAdi.Text = secilenDosya;
        }
    }
}
