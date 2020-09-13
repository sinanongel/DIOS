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
    public partial class FrmFormDuzelt : Form
    {
        public FrmFormDuzelt()
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
            CmbMahalle.Text = "";
            CmbSokak.Text = "";

            gridView1.Columns.Clear();
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();

            CheTumunuSec.Checked = false;
        }

        void listele()
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                //try
                //{
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.HATLAR.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' and FORMNO =" + TxtFormNo.Text + " AND dbo.ILCE.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.kargazBaglanti());
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

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT dbo.BAGLANTI_ELEMANLARI_PE.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_PE, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BAGLANTI_ELEMANLARI_PE.YOL_MSLINK = dbo.yol.mslink and dbo.BAGLANTI_ELEMANLARI_PE.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BAGLANTI_ELEMANLARI_PE.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = '" + TxtFormNo.Text + "'" + " AND dbo.ILCE.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.kargazBaglanti());
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

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT dbo.VANA.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA, dbo.yol, dbo.mahalle, dbo.ilce where dbo.VANA.YOL_MSLINK = dbo.yol.mslink and dbo.VANA.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.VANA.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO =  '" + TxtFormNo.Text + "'" + " AND dbo.ILCE.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.kargazBaglanti());
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
                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {                    
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.HATLAR.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' and FORMNO =" + TxtFormNo.Text + " AND dbo.ILCE.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.serhatgazBaglanti());
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

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT dbo.BAGLANTI_ELEMANLARI_PE.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_PE, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BAGLANTI_ELEMANLARI_PE.YOL_MSLINK = dbo.yol.mslink and dbo.BAGLANTI_ELEMANLARI_PE.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BAGLANTI_ELEMANLARI_PE.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = '" + TxtFormNo.Text + "'" + " AND dbo.ILCE.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.serhatgazBaglanti());
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

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT dbo.VANA.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA, dbo.yol, dbo.mahalle, dbo.ilce where dbo.VANA.YOL_MSLINK = dbo.yol.mslink and dbo.VANA.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.VANA.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO =  '" + TxtFormNo.Text + "'" + " AND dbo.ILCE.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.serhatgazBaglanti());
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
        }            

        private void BtnBul_Click(object sender, EventArgs e)
        {
            listele();

            if (CmbŞirket.Text == "KARGAZ")
            {
                //try
                //{
                    //string id;
                    if (gridView1.RowCount != 0)
                    {
                        SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR, MAHALLE_ADI, YOL_ADI + ' ' + YOL_TIPI FROM DBO.HATLAR, DBO.MAHALLE, DBO.YOL, dbo.il, dbo.ilce WHERE DBO.MAHALLE.MAHALLE_KODU = DBO.HATLAR.MAHALLE_KODU AND DBO.YOL.MSLINK = DBO.HATLAR.YOL_MSLINK AND DBO.ilce.mslink=DBO.HATLAR.ILCE_KODU AND MALZEME_CINSI='Polietilen' AND FORMNO=@P1 and DBO.HATLAR.ILCE_KODU=@P2", bgl.kargazBaglanti());
                        komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                        komutHat.Parameters.AddWithValue("@P2", labelControl15.Text);
                        SqlDataReader drHat = komutHat.ExecuteReader();
                        while (drHat.Read())
                        {
                            TxtFormNoYeni.Text = drHat[0].ToString();
                            TxtYatirimYili.Text = drHat[1].ToString();
                            TxtImalatTarihi.Text = drHat[2].ToString();
                            TxtSektor.Text = drHat[3].ToString();
                            CmbMahalle.Text = drHat[4].ToString();
                            CmbSokak.Text = drHat[5].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA WHERE FORMNO=@P2", bgl.kargazBaglanti());
                        komutVana.Parameters.AddWithValue("@P2", TxtFormNo.Text);
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
                        SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM dbo.BAGLANTI_ELEMANLARI_PE WHERE FORMNO=@P2", bgl.kargazBaglanti());
                        komutMalzeme.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                        SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                        while (drMalzeme.Read())

                        {
                            TxtFormNoYeni.Text = drMalzeme[0].ToString();
                            TxtYatirimYili.Text = drMalzeme[1].ToString();
                            TxtImalatTarihi.Text = drMalzeme[2].ToString();
                            TxtSektor.Text = drMalzeme[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE FROM DBO.VANA WHERE FORMNO=@P2", bgl.kargazBaglanti());
                        komutVana.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                        SqlDataReader drVana = komutVana.ExecuteReader();
                        while (drVana.Read())
                        {
                            TxtBolge.Text = drVana[0].ToString();
                            TxtVanaNo.Text = drVana[1].ToString();
                        }
                        bgl.kargazBaglanti().Close();
                    }
                    if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0)
                    {
                        MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    if (gridView1.RowCount != 0)
                    {
                        SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR, MAHALLE_ADI, YOL_ADI FROM DBO.HATLAR, DBO.MAHALLE, DBO.YOL, dbo.il, dbo.ilce WHERE DBO.MAHALLE.MAHALLE_KODU = DBO.HATLAR.MAHALLE_KODU AND DBO.YOL.MSLINK = DBO.HATLAR.YOL_MSLINK AND DBO.ilce.ilce_kodu=DBO.HATLAR.ILCE_KODU AND MALZEME_CINSI='Polietilen' AND FORMNO=@P1 and DBO.HATLAR.ILCE_KODU=@P2", bgl.serhatgazBaglanti());
                        komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                        komutHat.Parameters.AddWithValue("@P2", labelControl15.Text);
                        SqlDataReader drHat = komutHat.ExecuteReader();
                        while (drHat.Read())
                        {
                            TxtFormNoYeni.Text = drHat[0].ToString();
                            TxtYatirimYili.Text = drHat[1].ToString();
                            TxtImalatTarihi.Text = drHat[2].ToString();
                            TxtSektor.Text = drHat[3].ToString();
                            CmbMahalle.Text = drHat[4].ToString();
                            CmbSokak.Text = drHat[5].ToString();
                        }
                        bgl.serhatgazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                        komutVana.Parameters.AddWithValue("@P2", TxtFormNo.Text);
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
                        SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM dbo.BAGLANTI_ELEMANLARI_PE WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
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
                        komutVana.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                        SqlDataReader drVana = komutVana.ExecuteReader();
                        while (drVana.Read())
                        {
                            TxtBolge.Text = drVana[0].ToString();
                            TxtVanaNo.Text = drVana[1].ToString();
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
                                SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_PE SET FORMNO=@p5, YATIRIMYILI=@p6, IMALATTARIHI=@p7, SEKTOR=@p9 where MSLINK=" + malzemeMslink, bgl.kargazBaglanti());
                                komutMalzeme.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                                komutMalzeme.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                                komutMalzeme.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutMalzeme.Parameters.AddWithValue("@p9", TxtSektor.Text);
                                komutMalzeme.ExecuteNonQuery();
                                bgl.kargazBaglanti().Close();
                            }
                            foreach (int vanaMslink in secVanaMslink)
                            {
                                SqlCommand komutVana = new SqlCommand("UPDATE dbo.VANA SET FORMNO=@p10, YATIRIMYILI=@p11, IMALAT_TARIHI=@p12, VANA_NO=@p13, BOLGE=@p14, SEKTOR=@p15 where MSLINK=" + vanaMslink, bgl.kargazBaglanti());
                                komutVana.Parameters.AddWithValue("@p10", TxtFormNoYeni.Text);
                                komutVana.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                                komutVana.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutVana.Parameters.AddWithValue("@p13", TxtVanaNo.Text);
                                komutVana.Parameters.AddWithValue("@p14", TxtBolge.Text);
                                komutVana.Parameters.AddWithValue("@p15", TxtSektor.Text);
                                komutVana.ExecuteNonQuery();
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
                                SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_PE SET FORMNO=@p5, YATIRIMYILI=@p6, IMALATTARIHI=@p7, SEKTOR=@p9, ESKIFORMNO=@p10 where MSLINK=" + malzemeMslink, bgl.serhatgazBaglanti());
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
                                komutVana.Parameters.AddWithValue("@p10", TxtFormNoYeni.Text);
                                komutVana.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                                komutVana.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutVana.Parameters.AddWithValue("@p13", TxtVanaNo.Text);
                                komutVana.Parameters.AddWithValue("@p14", TxtBolge.Text);
                                komutVana.Parameters.AddWithValue("@p15", TxtSektor.Text);
                                komutVana.Parameters.AddWithValue("@p16", TxtFormNo.Text);
                                komutVana.ExecuteNonQuery();
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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void CheTumunuSec_CheckedChanged(object sender, EventArgs e)
        {
            if (CheTumunuSec.Checked == false)
            {
                gridView1.ClearSelection();
                gridView2.ClearSelection();
                gridView3.ClearSelection();
            }
            if (CheTumunuSec.Checked == true)
            {
                gridView1.SelectAll();
                gridView2.SelectAll();
                gridView3.SelectAll();
            }
        }

        private void TxtFormNoYeni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FrmFormDuzelt_Load(object sender, EventArgs e)
        {
            bolgeListele();
        }

        void bolgeListele()
        {
            //if (CmbŞirket.Text == "KARGAZ")
            //{
            //    SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
            //    SqlDataReader dr = komut.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        CmbBolge.Properties.Items.Add(dr[0]);
            //    }
            //    bgl.kargazBaglanti().Close();
            //}
            //else if (CmbŞirket.Text == "SERHATGAZ")
            //{
            //    SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.serhatgazBaglanti());
            //    SqlDataReader dr = komut.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        CmbBolge.Properties.Items.Add(dr[0]);
            //    }
            //    bgl.serhatgazBaglanti().Close();
            //}            
        }

        private void CmbŞirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBolge.Text = "";
            CmbBolge.Properties.Items.Clear();

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

        private void CmbBolge_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbMahalle.Text = "";
            CmbMahalle.Properties.Items.Clear();

            if (CmbŞirket.Text == "KARGAZ")
            {
                SqlCommand bolgeOku = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI=@bolge", bgl.kargazBaglanti());
                bolgeOku.Parameters.AddWithValue("@bolge", CmbBolge.Text);
                SqlDataReader drBolge = bolgeOku.ExecuteReader();
                while (drBolge.Read())
                {
                    labelControl15.Text = drBolge[0].ToString();
                }

                SqlCommand komut = new SqlCommand("SELECT MAHALLE_ADI FROM DBO.MAHALLE WHERE ILCE_KODU = @P1", bgl.kargazBaglanti());
                komut.Parameters.AddWithValue("@p1", labelControl15.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbMahalle.Properties.Items.Add(dr[0]);
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

                SqlCommand komut = new SqlCommand("SELECT MAHALLE_ADI FROM DBO.MAHALLE WHERE ILCE_KODU = @P1", bgl.serhatgazBaglanti());
                komut.Parameters.AddWithValue("@p1", labelControl15.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbMahalle.Properties.Items.Add(dr[0]);
                }
                bgl.serhatgazBaglanti().Close();
            }
        }

        private void CmbMahalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSokak.Properties.Items.Clear();

            if (CmbŞirket.Text == "KARGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT yol_adi + ' ' + YOL_TIPI FROM dbo.yol, DBO.mahalle, dbo.yol_mahalle WHERE DBO.yol.mslink=DBO.yol_mahalle.yol_mslink AND DBO.yol_mahalle.mahalle_mslink=DBO.mahalle.mslink AND mahalle_adi =@P1 AND DBO.YOL.ILCE_KODU =@P2", bgl.kargazBaglanti());
                komut.Parameters.AddWithValue("@p1", CmbMahalle.Text);
                komut.Parameters.AddWithValue("@p2", labelControl15.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbSokak.Properties.Items.Add(dr[0]);
                }
                bgl.kargazBaglanti().Close();
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT yol_adi FROM dbo.yol, DBO.mahalle, dbo.yol_mahalle WHERE DBO.yol.mslink=DBO.yol_mahalle.yol_mslink AND DBO.yol_mahalle.mahalle_mslink=DBO.mahalle.mslink AND mahalle_adi =@P1 AND DBO.YOL.ILCE_KODU =@P2", bgl.serhatgazBaglanti());
                komut.Parameters.AddWithValue("@p1", CmbMahalle.Text);
                komut.Parameters.AddWithValue("@p2", labelControl15.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbSokak.Properties.Items.Add(dr[0]);
                }
                bgl.serhatgazBaglanti().Close();
            }
        }
    }
}
