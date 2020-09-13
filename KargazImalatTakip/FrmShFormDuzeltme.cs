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
    public partial class FrmShFormDuzeltme : Form
    {
        public FrmShFormDuzeltme()
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

            gridView1.Columns.Clear();
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();

            CheTumunuSec.Checked = false;
        }

        void listele()
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.SERVIS_HATLARI.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, HAT_MSLINK, CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, EKIPNO from dbo.SERVIS_HATLARI, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_HATLARI.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_HATLARI.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_HATLARI.ILCE_KODU = dbo.ilce.ilce_kodu and formno =" + TxtFormNo.Text, bgl.kargazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                    gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    SqlDataAdapter daServisElemanı = new SqlDataAdapter("SELECT dbo.SERVIS_ELEMANLARI.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, BOLGE, SEKTOR, HAT_MSLINK, TIPI, CAP FROM DBO.SERVIS_ELEMANLARI, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_ELEMANLARI.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_ELEMANLARI.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_ELEMANLARI.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = " + TxtFormNo.Text, bgl.kargazBaglanti());
                    DataTable dtServisElemanı = new DataTable();
                    daServisElemanı.Fill(dtServisElemanı);
                    GrCoSaddle.DataSource = dtServisElemanı;

                    gridView2.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView2.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView2.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView2.Columns["FORMNO"].Caption = "FORM NO";
                    gridView2.Columns["BOLGE"].Caption = "BÖLGE";
                    gridView2.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                    gridView2.Columns["TIPI"].Caption = "TİPİ";
                    gridView2.Columns["CAP"].Caption = "ÇAP";

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT dbo.BAGLANTI_ELEMANLARI_PE.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_PE, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BAGLANTI_ELEMANLARI_PE.YOL_MSLINK = dbo.yol.mslink and dbo.BAGLANTI_ELEMANLARI_PE.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BAGLANTI_ELEMANLARI_PE.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = 'S" + TxtFormNo.Text + "'", bgl.kargazBaglanti());
                    DataTable dtMalzeme = new DataTable();
                    daMalzeme.Fill(dtMalzeme);
                    GrCoMalzeme.DataSource = dtMalzeme;

                    gridView4.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView4.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView4.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView4.Columns["FORMNO"].Caption = "FORM NO";
                    gridView4.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView4.Columns["TIPI"].Caption = "TİPİ";
                    gridView4.Columns["CAP"].Caption = "ÇAP";
                    gridView4.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    SqlDataAdapter daServisKutusu = new SqlDataAdapter("SELECT dbo.SERVIS_KUTUSU.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL ,KUTU_TIPI, CINSI, SKUTUVANASI FROM dbo.SERVIS_KUTUSU, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_KUTUSU.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_KUTUSU.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_KUTUSU.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = " + TxtFormNo.Text, bgl.kargazBaglanti());
                    DataTable dtServisKutusu = new DataTable();
                    daServisKutusu.Fill(dtServisKutusu);
                    GrCoServisKutusu.DataSource = dtServisKutusu;

                    gridView3.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView3.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView3.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView3.Columns["FORMNO"].Caption = "FORM NO";
                    gridView3.Columns["KUTU_TIPI"].Caption = "KUTU TİPİ";
                    gridView3.Columns["CINSI"].Caption = "CİNSİ";
                    gridView3.Columns["SKUTUVANASI"].Caption = "KUTU VANASI";
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                //try
                //{
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.SERVIS_HATLARI.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, EKIPNO from dbo.SERVIS_HATLARI, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_HATLARI.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_HATLARI.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_HATLARI.ILCE_KODU = dbo.ilce.ilce_kodu and formno =" + TxtFormNo.Text, bgl.serhatgazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    SqlDataAdapter daServisElemanı = new SqlDataAdapter("SELECT dbo.SERVIS_ELEMANLARI.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, BOLGE, SEKTOR, TIPI, CAP FROM DBO.SERVIS_ELEMANLARI, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_ELEMANLARI.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_ELEMANLARI.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_ELEMANLARI.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = '" + TxtFormNo.Text + "'", bgl.serhatgazBaglanti());
                    DataTable dtServisElemanı = new DataTable();
                    daServisElemanı.Fill(dtServisElemanı);
                    GrCoSaddle.DataSource = dtServisElemanı;

                    gridView2.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView2.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView2.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView2.Columns["FORMNO"].Caption = "FORM NO";
                    gridView2.Columns["BOLGE"].Caption = "BÖLGE";
                    gridView2.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView2.Columns["TIPI"].Caption = "TİPİ";
                    gridView2.Columns["CAP"].Caption = "ÇAP";

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT dbo.BAGLANTI_ELEMANLARI_PE.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_PE, dbo.yol, dbo.mahalle, dbo.ilce where dbo.BAGLANTI_ELEMANLARI_PE.YOL_MSLINK = dbo.yol.mslink and dbo.BAGLANTI_ELEMANLARI_PE.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.BAGLANTI_ELEMANLARI_PE.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = 'S" + TxtFormNo.Text + "'", bgl.serhatgazBaglanti());
                    DataTable dtMalzeme = new DataTable();
                    daMalzeme.Fill(dtMalzeme);
                    GrCoMalzeme.DataSource = dtMalzeme;

                    gridView4.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView4.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView4.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView4.Columns["FORMNO"].Caption = "FORM NO";
                    gridView4.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView4.Columns["TIPI"].Caption = "TİPİ";
                    gridView4.Columns["CAP"].Caption = "ÇAP";
                    gridView4.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    SqlDataAdapter daServisKutusu = new SqlDataAdapter("SELECT dbo.SERVIS_KUTUSU.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) as IMALAT_TARIHI, dbo.ilce.ILCE_ADI, MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL ,KUTU_TIPI, CINSI, SKUTUVANASI FROM dbo.SERVIS_KUTUSU, dbo.yol, dbo.mahalle, dbo.ilce where dbo.SERVIS_KUTUSU.YOL_MSLINK = dbo.yol.mslink and dbo.SERVIS_KUTUSU.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.SERVIS_KUTUSU.ILCE_KODU = dbo.ilce.ilce_kodu and FORMNO = " + TxtFormNo.Text, bgl.serhatgazBaglanti());
                    DataTable dtServisKutusu = new DataTable();
                    daServisKutusu.Fill(dtServisKutusu);
                    GrCoServisKutusu.DataSource = dtServisKutusu;

                    gridView3.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView3.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView3.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView3.Columns["FORMNO"].Caption = "FORM NO";
                    gridView3.Columns["KUTU_TIPI"].Caption = "KUTU TİPİ";
                    gridView3.Columns["CINSI"].Caption = "CİNSİ";
                    gridView3.Columns["SKUTUVANASI"].Caption = "KUTU VANASI";
                //}
                //catch (System.Data.SqlClient.SqlException)
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
                if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        if (gridView1.RowCount != 0)
                        {
                            SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM DBO.SERVIS_HATLARI WHERE FORMNO=@P1", bgl.kargazBaglanti());
                            komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                            SqlDataReader drHat = komutHat.ExecuteReader();
                            while (drHat.Read())
                            {
                                TxtFormNoYeni.Text = drHat[0].ToString();
                                TxtYatirimYili.Text = drHat[1].ToString();
                                TxtImalatTarihi.Text = drHat[2].ToString();
                                TxtSektor.Text = drHat[3].ToString();
                            }
                            bgl.kargazBaglanti().Close();

                            SqlCommand komutSaddleBolge = new SqlCommand("SELECT BOLGE FROM DBO.SERVIS_ELEMANLARI WHERE FORMNO=@P2", bgl.kargazBaglanti());
                            komutSaddleBolge.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drSaddleBolge = komutSaddleBolge.ExecuteReader();
                            while (drSaddleBolge.Read())
                            {
                                TxtBolge.Text = drSaddleBolge[0].ToString();
                            }
                            bgl.kargazBaglanti().Close();
                        }
                        else
                        {
                            SqlCommand komutSaddle = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM dbo.SERVIS_ELEMANLARI WHERE FORMNO=@P2", bgl.kargazBaglanti());
                            komutSaddle.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drSaddle = komutSaddle.ExecuteReader();
                            while (drSaddle.Read())

                            {
                                TxtFormNoYeni.Text = drSaddle[0].ToString();
                                TxtYatirimYili.Text = drSaddle[1].ToString();
                                TxtImalatTarihi.Text = drSaddle[2].ToString();
                                TxtSektor.Text = drSaddle[3].ToString();
                            }
                            bgl.kargazBaglanti().Close();

                            SqlCommand komutSaddleBolge = new SqlCommand("SELECT BOLGE FROM DBO.SERVIS_ELEMANLARI WHERE FORMNO=@P2", bgl.kargazBaglanti());
                            komutSaddleBolge.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drSaddleBolge = komutSaddleBolge.ExecuteReader();
                            while (drSaddleBolge.Read())
                            {
                                TxtBolge.Text = drSaddleBolge[0].ToString();
                            }
                            bgl.kargazBaglanti().Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                if (gridView1.RowCount == 0 && gridView2.RowCount == 0 && gridView3.RowCount == 0 && gridView4.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        if (gridView1.RowCount != 0)
                        {
                            SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM DBO.SERVIS_HATLARI WHERE FORMNO=@P1", bgl.serhatgazBaglanti());
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

                            SqlCommand komutSaddleBolge = new SqlCommand("SELECT BOLGE FROM DBO.SERVIS_ELEMANLARI WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutSaddleBolge.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drSaddleBolge = komutSaddleBolge.ExecuteReader();
                            while (drSaddleBolge.Read())
                            {
                                TxtBolge.Text = drSaddleBolge[0].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();
                        }
                        else
                        {
                            SqlCommand komutSaddle = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR FROM dbo.SERVIS_ELEMANLARI WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutSaddle.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drSaddle = komutSaddle.ExecuteReader();
                            while (drSaddle.Read())

                            {
                                TxtFormNoYeni.Text = drSaddle[0].ToString();
                                TxtYatirimYili.Text = drSaddle[1].ToString();
                                TxtImalatTarihi.Text = drSaddle[2].ToString();
                                TxtSektor.Text = drSaddle[3].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();

                            SqlCommand komutSaddleBolge = new SqlCommand("SELECT BOLGE FROM DBO.SERVIS_ELEMANLARI WHERE FORMNO=@P2", bgl.serhatgazBaglanti());
                            komutSaddleBolge.Parameters.AddWithValue("@P2", TxtFormNo.Text);
                            SqlDataReader drSaddleBolge = komutSaddleBolge.ExecuteReader();
                            while (drSaddleBolge.Read())
                            {
                                TxtBolge.Text = drSaddleBolge[0].ToString();
                            }
                            bgl.serhatgazBaglanti().Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        //MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                //try
                //{
                var secHat = gridView1.GetSelectedRows();
                List<int> secHatMslink = new List<int>(); foreach (int handle in secHat)
                {
                    secHatMslink.Add(Convert.ToInt32(gridView1.GetRowCellValue(handle, "MSLINK")));
                }

                var secSaddle = gridView2.GetSelectedRows();
                List<int> secSaddleMslink = new List<int>();
                foreach (int handle in secSaddle)
                {
                    secSaddleMslink.Add(Convert.ToInt32(gridView2.GetRowCellValue(handle, "MSLINK")));
                }

                var secServisKutusu = gridView3.GetSelectedRows();
                List<int> secServisKutusuMslink = new List<int>();
                foreach (int handle in secServisKutusu)
                {
                    secServisKutusuMslink.Add(Convert.ToInt32(gridView3.GetRowCellValue(handle, "MSLINK")));
                }

                var secMalzeme = gridView4.GetSelectedRows();
                List<int> secMalzemeMslink = new List<int>();
                foreach (int handle in secMalzeme)
                {
                    secMalzemeMslink.Add(Convert.ToInt32(gridView4.GetRowCellValue(handle, "MSLINK")));
                }

                if (secHatMslink.Count == 0 && secMalzemeMslink.Count == 0 && secSaddleMslink.Count == 0 && secServisKutusuMslink.Count == 0)
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
                            SqlCommand komutHat = new SqlCommand("UPDATE dbo.SERVIS_HATLARI SET FORMNO=@p1, YATIRIMYILI=@p2, IMALATTARIHI=@p3, SEKTOR=@p4 where MSLINK=" + hatMslink, bgl.kargazBaglanti());
                            komutHat.Parameters.AddWithValue("@p1", TxtFormNoYeni.Text);
                            komutHat.Parameters.AddWithValue("@p2", TxtYatirimYili.Text);
                            komutHat.Parameters.AddWithValue("@p3", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutHat.Parameters.AddWithValue("@p4", TxtSektor.Text);
                            komutHat.ExecuteNonQuery();
                            bgl.kargazBaglanti().Close();
                        }

                        foreach (int saddleMslink in secSaddleMslink)
                        {
                            SqlCommand komutSaddle = new SqlCommand("UPDATE dbo.SERVIS_ELEMANLARI SET FORMNO=@p5, YATIRIMYILI=@p6, IMALAT_TARIHI=@p7, SEKTOR=@p8, BOLGE=@p9 where MSLINK=" + saddleMslink, bgl.kargazBaglanti());
                            komutSaddle.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                            komutSaddle.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                            komutSaddle.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutSaddle.Parameters.AddWithValue("@p8", TxtSektor.Text);
                            komutSaddle.Parameters.AddWithValue("@p9", TxtBolge.Text);
                            komutSaddle.ExecuteNonQuery();
                            bgl.kargazBaglanti().Close();
                        }

                        foreach (int malzemeMslink in secMalzemeMslink)
                        {
                            SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_PE SET FORMNO=@p10, YATIRIMYILI=@p11, IMALATTARIHI=@p12, SEKTOR=@p13 where MSLINK=" + malzemeMslink, bgl.kargazBaglanti());
                            komutMalzeme.Parameters.AddWithValue("@p10", "S" + TxtFormNoYeni.Text);
                            komutMalzeme.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                            komutMalzeme.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutMalzeme.Parameters.AddWithValue("@p13", TxtSektor.Text);
                            komutMalzeme.ExecuteNonQuery();
                            bgl.kargazBaglanti().Close();
                        }

                        foreach (int servisKutusuMslink in secServisKutusuMslink)
                        {
                            SqlCommand komutServisKutusu = new SqlCommand("UPDATE dbo.SERVIS_KUTUSU SET FORMNO=@p14, YATIRIMYILI=@p15, IMALATTARIHI=@p16 where MSLINK=" + servisKutusuMslink, bgl.kargazBaglanti());
                            komutServisKutusu.Parameters.AddWithValue("@p14", TxtFormNoYeni.Text);
                            komutServisKutusu.Parameters.AddWithValue("@p15", TxtYatirimYili.Text);
                            komutServisKutusu.Parameters.AddWithValue("@p16", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutServisKutusu.ExecuteNonQuery();
                            bgl.kargazBaglanti().Close();
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
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
               
                //try
                //{
                var secHat = gridView1.GetSelectedRows();
                List<int> secHatMslink = new List<int>(); foreach (int handle in secHat)
                {
                    secHatMslink.Add(Convert.ToInt32(gridView1.GetRowCellValue(handle, "MSLINK")));
                }

                var secSaddle = gridView2.GetSelectedRows();
                List<int> secSaddleMslink = new List<int>();
                foreach (int handle in secSaddle)
                {
                    secSaddleMslink.Add(Convert.ToInt32(gridView2.GetRowCellValue(handle, "MSLINK")));
                }

                var secServisKutusu = gridView3.GetSelectedRows();
                List<int> secServisKutusuMslink = new List<int>();
                foreach (int handle in secServisKutusu)
                {
                    secServisKutusuMslink.Add(Convert.ToInt32(gridView3.GetRowCellValue(handle, "MSLINK")));
                }

                var secMalzeme = gridView4.GetSelectedRows();
                List<int> secMalzemeMslink = new List<int>();
                foreach (int handle in secMalzeme)
                {
                    secMalzemeMslink.Add(Convert.ToInt32(gridView4.GetRowCellValue(handle, "MSLINK")));
                }

                if (secHatMslink.Count == 0 && secMalzemeMslink.Count == 0 && secSaddleMslink.Count == 0 && secServisKutusuMslink.Count == 0)
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
                            SqlCommand komutHat = new SqlCommand("UPDATE dbo.SERVIS_HATLARI SET FORMNO=@p1, YATIRIMYILI=@p2, IMALATTARIHI=@p3, SEKTOR=@p4, ESKIFORMNO=@p5 where MSLINK=" + hatMslink, bgl.serhatgazBaglanti());
                            komutHat.Parameters.AddWithValue("@p1", TxtFormNoYeni.Text);
                            komutHat.Parameters.AddWithValue("@p2", TxtYatirimYili.Text);
                            komutHat.Parameters.AddWithValue("@p3", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutHat.Parameters.AddWithValue("@p4", TxtSektor.Text);
                            komutHat.Parameters.AddWithValue("@p5", TxtFormNo.Text);
                            komutHat.ExecuteNonQuery();
                            bgl.serhatgazBaglanti().Close();
                        }

                        foreach (int saddleMslink in secSaddleMslink)
                        {
                            SqlCommand komutSaddle = new SqlCommand("UPDATE dbo.SERVIS_ELEMANLARI SET FORMNO=@p5, YATIRIMYILI=@p6, IMALAT_TARIHI=@p7, SEKTOR=@p8, BOLGE=@p9, ESKIFORMNO=@p10 where MSLINK=" + saddleMslink, bgl.serhatgazBaglanti());
                            komutSaddle.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                            komutSaddle.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                            komutSaddle.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutSaddle.Parameters.AddWithValue("@p8", TxtSektor.Text);
                            komutSaddle.Parameters.AddWithValue("@p9", TxtBolge.Text);
                            komutSaddle.Parameters.AddWithValue("@p10", TxtFormNo.Text);
                            
                            komutSaddle.ExecuteNonQuery();
                            bgl.serhatgazBaglanti().Close();
                        }

                        foreach (int malzemeMslink in secMalzemeMslink)
                        {
                            SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_PE SET FORMNO=@p10, YATIRIMYILI=@p11, IMALATTARIHI=@p12, SEKTOR=@p13, ESKIFORMNO=@p14 where MSLINK=" + malzemeMslink, bgl.serhatgazBaglanti());
                            komutMalzeme.Parameters.AddWithValue("@p10", "S" + TxtFormNoYeni.Text);
                            komutMalzeme.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                            komutMalzeme.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutMalzeme.Parameters.AddWithValue("@p13", TxtSektor.Text);
                            komutMalzeme.Parameters.AddWithValue("@p14", "S" + TxtFormNo.Text);
                            komutMalzeme.ExecuteNonQuery();
                            bgl.serhatgazBaglanti().Close();
                        }

                        foreach (int servisKutusuMslink in secServisKutusuMslink)
                        {
                            SqlCommand komutServisKutusu = new SqlCommand("UPDATE dbo.SERVIS_KUTUSU SET FORMNO=@p14, YATIRIMYILI=@p15, IMALATTARIHI=@p16, ESKIFORMNO=@p17 where MSLINK=" + servisKutusuMslink, bgl.serhatgazBaglanti());
                            komutServisKutusu.Parameters.AddWithValue("@p14", TxtFormNoYeni.Text);
                            komutServisKutusu.Parameters.AddWithValue("@p15", TxtYatirimYili.Text);
                            komutServisKutusu.Parameters.AddWithValue("@p16", Convert.ToDateTime(TxtImalatTarihi.Text));
                            komutServisKutusu.Parameters.AddWithValue("@p17", TxtFormNo.Text);
                            komutServisKutusu.ExecuteNonQuery();
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
                gridView4.ClearSelection();
            }
            if (CheTumunuSec.Checked == true)
            {
                gridView1.SelectAll();
                gridView2.SelectAll();
                gridView3.SelectAll();
                gridView4.SelectAll();
            }
        }

        private void FrmShFormDuzeltme_Load(object sender, EventArgs e)
        {

        }

        private void TxtFormNoYeni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
