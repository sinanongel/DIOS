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
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.HATLAR.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Celik' and FORMNO =" + TxtFormNo.Text, bgl.kargazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

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

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT dbo.BAGLANTI_ELEMANLARI_CELIK.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_CELIK, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BAGLANTI_ELEMANLARI_CELIK.YOL_MSLINK = dbo.yol.mslink and dbo.BAGLANTI_ELEMANLARI_CELIK.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BAGLANTI_ELEMANLARI_CELIK.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = '" + TxtFormNo.Text + "'", bgl.kargazBaglanti());
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

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT dbo.VANA.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA, dbo.yol, dbo.mahalle, dbo.ilce where dbo.VANA.YOL_MSLINK = dbo.yol.mslink and dbo.VANA.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.VANA.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = 'C" + TxtFormNo.Text + "'", bgl.kargazBaglanti());
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
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.HATLAR.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Celik' and FORMNO =" + TxtFormNo.Text, bgl.serhatgazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

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

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT dbo.BAGLANTI_ELEMANLARI_CELIK.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_CELIK, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BAGLANTI_ELEMANLARI_CELIK.YOL_MSLINK = dbo.yol.mslink and dbo.BAGLANTI_ELEMANLARI_CELIK.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BAGLANTI_ELEMANLARI_CELIK.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = '" + TxtFormNo.Text + "'", bgl.serhatgazBaglanti());
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

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT dbo.VANA.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA, dbo.yol, dbo.mahalle, dbo.ilce where dbo.VANA.YOL_MSLINK = dbo.yol.mslink and dbo.VANA.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.VANA.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = 'C" + TxtFormNo.Text + "'", bgl.serhatgazBaglanti());
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

                    SqlDataAdapter daKaynak = new SqlDataAdapter("SELECT dbo.KAYNAK.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, KAYNAKTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, KAYNAKNO, CAP FROM dbo.KAYNAK, dbo.yol, dbo.mahalle, dbo.ilce where dbo.KAYNAK.YOL_MSLINK = dbo.yol.mslink and dbo.KAYNAK.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.KAYNAK.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO =" + TxtFormNo.Text, bgl.serhatgazBaglanti());
                    DataTable dtKaynak = new DataTable();
                    daKaynak.Fill(dtKaynak);
                    GrCoKaynak.DataSource = dtKaynak;

                    gridView4.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView4.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView4.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView4.Columns["FORMNO"].Caption = "FORM NO";
                    gridView4.Columns["KAYNAKNO"].Caption = "KAYNAK NO";
                    gridView4.Columns["CAP"].Caption = "ÇAP";

                    SqlDataAdapter daBr = new SqlDataAdapter("SELECT dbo.BOLGE_REGULATORU.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, REGULATORADI, REGULATORTIPI FROM dbo.BOLGE_REGULATORU, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BOLGE_REGULATORU.YOL_MSLINK = dbo.yol.mslink and dbo.BOLGE_REGULATORU.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BOLGE_REGULATORU.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO =" + TxtFormNo.Text, bgl.serhatgazBaglanti());
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
                //    try
                //    {
                //if (gridView1.RowCount != 0)
                //{
                //    SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR, BORU_UZUNLUGU, KAZI_BOYU FROM DBO.HATLAR WHERE MALZEME_CINSI='Polietilen' AND FORMNO=@P1", bgl.kargazBaglanti());
                //    komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                //    SqlDataReader drHat = komutHat.ExecuteReader();
                //    while (drHat.Read())
                //    {
                //        TxtFormNoYeni.Text = drHat[0].ToString();
                //        TxtYatirimYili.Text = drHat[1].ToString();
                //        TxtImalatTarihi.Text = drHat[2].ToString();
                //        TxtSektor.Text = drHat[3].ToString();
                //    }
                //    bgl.kargazBaglanti().Close();

                //    SqlCommand komutVana = new SqlCommand("SELECT BOLGE FROM DBO.VANA WHERE FORMNO=@P2", bgl.kargazBaglanti());
                //    komutVana.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                //    SqlDataReader drVana = komutVana.ExecuteReader();
                //    while (drVana.Read())
                //    {
                //        TxtBolge.Text = drVana[0].ToString();
                //        TxtVanaNo.Text = drVana[1].ToString();
                //    }
                //    bgl.kargazBaglanti().Close();
                //}
                //else
                //{
                //    SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM dbo.BAGLANTI_ELEMANLARI_PE WHERE FORMNO=@P2", bgl.kargazBaglanti());
                //    komutMalzeme.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                //    SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                //    while (drMalzeme.Read())

                //    {
                //        TxtFormNoYeni.Text = drMalzeme[0].ToString();
                //        TxtYatirimYili.Text = drMalzeme[1].ToString();
                //        TxtImalatTarihi.Text = drMalzeme[2].ToString();
                //        TxtSektor.Text = drMalzeme[3].ToString();
                //    }
                //    bgl.kargazBaglanti().Close();

                //    SqlCommand komutVana = new SqlCommand("SELECT BOLGE FROM DBO.VANA WHERE FORMNO=@P2", bgl.kargazBaglanti());
                //    komutVana.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                //    SqlDataReader drVana = komutVana.ExecuteReader();
                //    while (drVana.Read())
                //    {
                //        TxtBolge.Text = drVana[0].ToString();
                //        TxtVanaNo.Text = drVana[1].ToString();
                //    }
                //    bgl.kargazBaglanti().Close();
                //}
                //if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0)
                //{
                //    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //    }
                //    catch
                //    {
                //        MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    try
                    {
                        if (gridView1.RowCount != 0)
                        {
                            SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR, BORU_UZUNLUGU, KAZI_BOYU FROM DBO.HATLAR WHERE MALZEME_CINSI='Celik' AND FORMNO=@P1", bgl.serhatgazBaglanti());
                            komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                            SqlDataReader drHat = komutHat.ExecuteReader();
                            while (drHat.Read())
                            {
                                TxtFormNoYeni.Text = drHat[0].ToString();
                                TxtYatirimYili.Text = drHat[1].ToString();
                                TxtImalatTarihi.Text = drHat[2].ToString();
                                TxtSektor.Text = drHat[3].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();

                            SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutVana.Parameters.AddWithValue("@P2", "C" + TxtFormNo.Text);
                            SqlDataReader drVana = komutVana.ExecuteReader();
                            while (drVana.Read())
                            {
                                TxtBolge.Text = drVana[0].ToString();
                                TxtVanaNo.Text = drVana[1].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();
                        }
                        else
                        {
                            SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM dbo.BAGLANTI_ELEMANLARI_CELIK WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutMalzeme.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                            while (drMalzeme.Read())
                            {
                                TxtFormNoYeni.Text = drMalzeme[0].ToString();
                                TxtYatirimYili.Text = drMalzeme[1].ToString();
                                TxtImalatTarihi.Text = drMalzeme[2].ToString();
                                TxtSektor.Text = drMalzeme[3].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();

                            SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutVana.Parameters.AddWithValue("@P2", "C" + TxtFormNo.Text);
                            SqlDataReader drVana = komutVana.ExecuteReader();
                            while (drVana.Read())
                            {
                                TxtBolge.Text = drVana[0].ToString();
                                TxtVanaNo.Text = drVana[1].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();
                        }
                        if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0)
                        {
                            SqlCommand komutBr = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI FROM dbo.BOLGE_REGULATORU WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutBr.Parameters.AddWithValue("@P2", TxtFormNo.Text);
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                //try
                //{
                //    var secHat = gridView1.GetSelectedRows();
                //    List<int> secHatMslink = new List<int>();
                //    foreach (int handle in secHat)
                //    {
                //        secHatMslink.Add(Convert.ToInt32(gridView1.GetRowCellValue(handle, "MSLINK")));
                //    }

                //    var secMalzeme = gridView2.GetSelectedRows();
                //    List<int> secMalzemeMslink = new List<int>();
                //    foreach (int handle in secMalzeme)
                //    {
                //        secMalzemeMslink.Add(Convert.ToInt32(gridView2.GetRowCellValue(handle, "MSLINK")));
                //    }

                //    var secVana = gridView3.GetSelectedRows();
                //    List<int> secVanaMslink = new List<int>();
                //    foreach (int handle in secVana)
                //    {
                //        secVanaMslink.Add(Convert.ToInt32(gridView3.GetRowCellValue(handle, "MSLINK")));
                //    }

                //    if (secHatMslink.Count == 0 && secMalzemeMslink.Count == 0 && secVanaMslink.Count == 0)
                //    {
                //        MessageBox.Show("Lütfen bir seçim yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    else
                //    {
                //        DialogResult soru;
                //        soru = MessageBox.Show("Bu bilgileri güncellemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //        if (soru == DialogResult.Yes)
                //        {
                //            foreach (int hatMslink in secHatMslink)
                //            {
                //                SqlCommand komutHat = new SqlCommand("UPDATE dbo.HATLAR SET FORMNO=@p1, YATIRIMYILI=@p2, IMALAT_TARIHI=@p3, SEKTOR=@p4 where MSLINK=" + hatMslink, bgl.kargazBaglanti());
                //                komutHat.Parameters.AddWithValue("@p1", TxtFormNoYeni.Text);
                //                komutHat.Parameters.AddWithValue("@p2", TxtYatirimYili.Text);
                //                komutHat.Parameters.AddWithValue("@p3", Convert.ToDateTime(TxtImalatTarihi.Text));
                //                komutHat.Parameters.AddWithValue("@p4", TxtSektor.Text);
                //                komutHat.ExecuteNonQuery();
                //                bgl.kargazBaglanti().Close();
                //            }
                //            foreach (int malzemeMslink in secMalzemeMslink)
                //            {
                //                SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_PE SET FORMNO=@p5, YATIRIMYILI=@p6, IMALATTARIHI=@p7, SEKTOR=@p9 where MSLINK=" + malzemeMslink, bgl.kargazBaglanti());
                //                komutMalzeme.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                //                komutMalzeme.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                //                komutMalzeme.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                //                komutMalzeme.Parameters.AddWithValue("@p9", TxtSektor.Text);
                //                komutMalzeme.ExecuteNonQuery();
                //                bgl.kargazBaglanti().Close();
                //            }
                //            foreach (int vanaMslink in secVanaMslink)
                //            {
                //                SqlCommand komutVana = new SqlCommand("UPDATE dbo.VANA SET FORMNO=@p10, YATIRIMYILI=@p11, IMALAT_TARIHI=@p12, VANA_NO=@p13, BOLGE=@p14, SEKTOR=@p15 where MSLINK=" + vanaMslink, bgl.kargazBaglanti());
                //                komutVana.Parameters.AddWithValue("@p10", TxtFormNoYeni.Text);
                //                komutVana.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                //                komutVana.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                //                komutVana.Parameters.AddWithValue("@p13", TxtVanaNo.Text);
                //                komutVana.Parameters.AddWithValue("@p14", TxtBolge.Text);
                //                komutVana.Parameters.AddWithValue("@p15", TxtSektor.Text);
                //                komutVana.ExecuteNonQuery();
                //                bgl.kargazBaglanti().Close();
                //            }
                //            listele();
                //            MessageBox.Show("Tüm Bilgiler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        }
                //    }
                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                //try
                //{
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
                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
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
    }
}
