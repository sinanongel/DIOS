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
    public partial class FrmPeKayitDuzeltme : Form
    {
        public FrmPeKayitDuzeltme()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtMslink.Text = "";
            TxtYatirimYili.Text = "";
            TxtImalatTarihi.Text = "";
            TxtFormMetraj.Text = "";
            TxtKaziBoyu.Text = "";
            TxtSektor.Text = "";
            CmbCap.Text = "";
            LblStokKodu.Text = "---------";
            LblStokAd.Text = "------------------------";
        }

        void listeTemizle()
        {
            gridView1.Columns.Clear();
        }

        void listele()
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.HATLAR.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' and FORMNO =" + TxtFormNo.Text, bgl.kargazBaglanti());
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

                    SqlDataAdapter daForm = new SqlDataAdapter("SELECT * FROM (SELECT FORMNO, VARLIK_KODU, SUM(BORU_UZUNLUGU) AS MALZTOP FROM [KargazHarita].[dbo].[HATLAR] WHERE FORMNO='" + TxtFormNo.Text + "' GROUP BY FORMNO, VARLIK_KODU UNION SELECT FORMNO, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[KargazHarita].[dbo].[BAGLANTI_ELEMANLARI_PE] WHERE FORMNO = '" + TxtFormNo.Text + "' GROUP BY FORMNO, VARLIK_KODU UNION SELECT FORMNO, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[KargazHarita].[dbo].[VANA] WHERE FORMNO = '" + TxtFormNo.Text + "' GROUP BY FORMNO, VARLIK_KODU) AS TABLOM PIVOT (SUM(MALZTOP) FOR VARLIK_KODU IN([201003], [201004], [201005], [201007], [202003], [202004], [202005], [202007], [207008], [207011], [207007], [207012], [203023], [203014], [203024], [203015], [208008], [208001], [208007], [208002], [206014], [206015], [206017], [206023], [203021])) AS PIVOTTABLO", bgl.kargazBaglanti());
                    DataTable dtForm = new DataTable();
                    daForm.Fill(dtForm);
                    GrCoForm.DataSource = dtForm;

                    gridView2.Columns["FORMNO"].Visible = false;

                    gridView2.Columns["201003"].Caption = "PE 40";
                    gridView2.Columns["201004"].Caption = "PE 63";
                    gridView2.Columns["201005"].Caption = "PE 90";
                    gridView2.Columns["201007"].Caption = "PE 125";
                    gridView2.Columns["202003"].Caption = "Ø40 MANŞON";
                    gridView2.Columns["202004"].Caption = "Ø63 MANŞON";
                    gridView2.Columns["202005"].Caption = "Ø90 MANŞON";
                    gridView2.Columns["202007"].Caption = "Ø125 MANŞON";
                    gridView2.Columns["207008"].Caption = "Ø40 KEP";
                    gridView2.Columns["207011"].Caption = "Ø63 KEP";
                    gridView2.Columns["207007"].Caption = "Ø90 KEP";
                    gridView2.Columns["207012"].Caption = "Ø125 KEP";
                    gridView2.Columns["203023"].Caption = "Ø40 TEE";
                    gridView2.Columns["203014"].Caption = "Ø63 TEE";
                    gridView2.Columns["203024"].Caption = "Ø90 TEE";
                    gridView2.Columns["203015"].Caption = "Ø125 TEE";
                    gridView2.Columns["208008"].Caption = "Ø40 VANA";
                    gridView2.Columns["208001"].Caption = "Ø63 VANA";
                    gridView2.Columns["208007"].Caption = "Ø90 VANA";
                    gridView2.Columns["208002"].Caption = "Ø125 VANA";
                    gridView2.Columns["206014"].Caption = "Ø63X40 REDÜKSİYON";
                    gridView2.Columns["206015"].Caption = "Ø90X63 REDÜKSİYON";
                    gridView2.Columns["206017"].Caption = "Ø125X63 REDÜKSİYON";
                    gridView2.Columns["206023"].Caption = "Ø125X90 REDÜKSİYON";
                    gridView2.Columns["203021"].Caption = "Ø63X63X40 REDÜKSİYON";

                    gridView2.Columns["201003"].Width = 37;
                    gridView2.Columns["201004"].Width = 37;
                    gridView2.Columns["201005"].Width = 37;
                    gridView2.Columns["201007"].Width = 37;
                    gridView2.Columns["202003"].Width = 70;
                    gridView2.Columns["202004"].Width = 70;
                    gridView2.Columns["202005"].Width = 70;
                    gridView2.Columns["202007"].Width = 70;
                    gridView2.Columns["207008"].Width = 50;
                    gridView2.Columns["207011"].Width = 50;
                    gridView2.Columns["207007"].Width = 50;
                    gridView2.Columns["207012"].Width = 50;
                    gridView2.Columns["203023"].Width = 50;
                    gridView2.Columns["203014"].Width = 50;
                    gridView2.Columns["203024"].Width = 50;
                    gridView2.Columns["203015"].Width = 50;
                    gridView2.Columns["208008"].Width = 55;
                    gridView2.Columns["208001"].Width = 55;
                    gridView2.Columns["208007"].Width = 55;
                    gridView2.Columns["208002"].Width = 55;
                    gridView2.Columns["206014"].Width = 100;
                    gridView2.Columns["206015"].Width = 100;
                    gridView2.Columns["206017"].Width = 100;
                    gridView2.Columns["206023"].Width = 100;
                    gridView2.Columns["203021"].Width = 100;
                //}
                //catch (System.Data.SqlClient.SqlException)
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                if (gridView1.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                //try
                //{
                    SqlDataAdapter daHat = new SqlDataAdapter("select dbo.HATLAR.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, YOL_ADI + ' ' +yol_tipi AS YOL, SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' and FORMNO =" + TxtFormNo.Text, bgl.serhatgazBaglanti());
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

                    SqlDataAdapter daForm = new SqlDataAdapter("SELECT * FROM (SELECT FORMNO, VARLIK_KODU, SUM(BORU_UZUNLUGU) AS MALZTOP FROM [SerhatgazHarita].[dbo].[HATLAR] WHERE FORMNO='" + TxtFormNo.Text + "' GROUP BY FORMNO, VARLIK_KODU UNION SELECT FORMNO, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[SerhatgazHarita].[dbo].[BAGLANTI_ELEMANLARI_PE] WHERE FORMNO = '" + TxtFormNo.Text + "' GROUP BY FORMNO, VARLIK_KODU UNION SELECT FORMNO, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[SerhatgazHarita].[dbo].[VANA] WHERE FORMNO = '" + TxtFormNo.Text + "' GROUP BY FORMNO, VARLIK_KODU) AS TABLOM PIVOT (SUM(MALZTOP) FOR VARLIK_KODU IN([201003], [201004], [201005], [201007], [202003], [202004], [202005], [202007], [207008], [207011], [207007], [207012], [203023], [203014], [203024], [203015], [208008], [208001], [208007], [208002], [206014], [206015], [206017], [206023], [203021])) AS PIVOTTABLO", bgl.serhatgazBaglanti());
                    DataTable dtForm = new DataTable();
                    daForm.Fill(dtForm);
                    GrCoForm.DataSource = dtForm;

                    gridView2.Columns["FORMNO"].Visible = false;

                    gridView2.Columns["201003"].Caption = "PE 40";
                    gridView2.Columns["201004"].Caption = "PE 63";
                    gridView2.Columns["201005"].Caption = "PE 90";
                    gridView2.Columns["201007"].Caption = "PE 125";
                    gridView2.Columns["202003"].Caption = "Ø40 MANŞON";
                    gridView2.Columns["202004"].Caption = "Ø63 MANŞON";
                    gridView2.Columns["202005"].Caption = "Ø90 MANŞON";
                    gridView2.Columns["202007"].Caption = "Ø125 MANŞON";
                    gridView2.Columns["207008"].Caption = "Ø40 KEP";
                    gridView2.Columns["207011"].Caption = "Ø63 KEP";
                    gridView2.Columns["207007"].Caption = "Ø90 KEP";
                    gridView2.Columns["207012"].Caption = "Ø125 KEP";
                    gridView2.Columns["203023"].Caption = "Ø40 TEE";
                    gridView2.Columns["203014"].Caption = "Ø63 TEE";
                    gridView2.Columns["203024"].Caption = "Ø90 TEE";
                    gridView2.Columns["203015"].Caption = "Ø125 TEE";
                    gridView2.Columns["208008"].Caption = "Ø40 VANA";
                    gridView2.Columns["208001"].Caption = "Ø63 VANA";
                    gridView2.Columns["208007"].Caption = "Ø90 VANA";
                    gridView2.Columns["208002"].Caption = "Ø125 VANA";
                    gridView2.Columns["206014"].Caption = "Ø63X40 REDÜKSİYON";
                    gridView2.Columns["206015"].Caption = "Ø90X63 REDÜKSİYON";
                    gridView2.Columns["206017"].Caption = "Ø125X63 REDÜKSİYON";
                    gridView2.Columns["206023"].Caption = "Ø125X90 REDÜKSİYON";
                    gridView2.Columns["203021"].Caption = "Ø63X63X40 REDÜKSİYON";

                    gridView2.Columns["201003"].Width = 37;
                    gridView2.Columns["201004"].Width = 37;
                    gridView2.Columns["201005"].Width = 37;
                    gridView2.Columns["201007"].Width = 37;
                    gridView2.Columns["202003"].Width = 70;
                    gridView2.Columns["202004"].Width = 70;
                    gridView2.Columns["202005"].Width = 70;
                    gridView2.Columns["202007"].Width = 70;
                    gridView2.Columns["207008"].Width = 50;
                    gridView2.Columns["207011"].Width = 50;
                    gridView2.Columns["207007"].Width = 50;
                    gridView2.Columns["207012"].Width = 50;
                    gridView2.Columns["203023"].Width = 50;
                    gridView2.Columns["203014"].Width = 50;
                    gridView2.Columns["203024"].Width = 50;
                    gridView2.Columns["203015"].Width = 50;
                    gridView2.Columns["208008"].Width = 55;
                    gridView2.Columns["208001"].Width = 55;
                    gridView2.Columns["208007"].Width = 55;
                    gridView2.Columns["208002"].Width = 55;
                    gridView2.Columns["206014"].Width = 100;
                    gridView2.Columns["206015"].Width = 100;
                    gridView2.Columns["206017"].Width = 100;
                    gridView2.Columns["206023"].Width = 100;
                    gridView2.Columns["203021"].Width = 100;
            //    }
            //    catch (System.Data.SqlClient.SqlException)
            //{
            //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (gridView1.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {            
            listele();
        }
       
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
            listeTemizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    DialogResult Soru;

                    Soru = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Soru == DialogResult.Yes)
                    {
                        SqlCommand komutSil = new SqlCommand("Delete from dbo.HATLAR where MSLINK=@p1", bgl.kargazBaglanti());
                        komutSil.Parameters.AddWithValue("@p1", TxtMslink.Text);
                        komutSil.ExecuteNonQuery();
                        bgl.kargazBaglanti().Close();
                        MessageBox.Show("Kayıt Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    DialogResult Soru;

                    Soru = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Soru == DialogResult.Yes)
                    {
                        SqlCommand komutSil = new SqlCommand("Delete from dbo.HATLAR where MSLINK=@p1", bgl.serhatgazBaglanti());
                        komutSil.Parameters.AddWithValue("@p1", TxtMslink.Text);
                        komutSil.ExecuteNonQuery();
                        bgl.serhatgazBaglanti().Close();
                        MessageBox.Show("Kayıt Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlCommand komutHat = new SqlCommand("UPDATE dbo.HATLAR SET BORU_UZUNLUGU=@p1, KAZI_BOYU=@p2, NET_BORU_CAPI=@p3, VARLIK_KODU=@p4 where MSLINK=@p5", bgl.kargazBaglanti());
                    komutHat.Parameters.AddWithValue("@p1", TxtFormMetraj.Text.ToString().Replace(",", "."));
                    komutHat.Parameters.AddWithValue("@p2", TxtKaziBoyu.Text.ToString().Replace(",", "."));
                    komutHat.Parameters.AddWithValue("@p3", CmbCap.Text);
                    komutHat.Parameters.AddWithValue("@p4", LblStokKodu.Text);
                    komutHat.Parameters.AddWithValue("@p5", TxtMslink.Text);
                    komutHat.ExecuteNonQuery();
                    bgl.kargazBaglanti().Close();

                    MessageBox.Show("Güncelleme Yapıldı..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    listele();
                    temizle();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlCommand komutHat = new SqlCommand("UPDATE dbo.HATLAR SET BORU_UZUNLUGU=@p1, KAZI_BOYU=@p2, NET_BORU_CAPI=@p3, VARLIK_KODU=@p4 where MSLINK=@p5", bgl.serhatgazBaglanti());
                    komutHat.Parameters.AddWithValue("@p1", TxtFormMetraj.Text.ToString().Replace(",", "."));
                    komutHat.Parameters.AddWithValue("@p2", TxtKaziBoyu.Text.ToString().Replace(",", "."));
                    komutHat.Parameters.AddWithValue("@p3", CmbCap.Text);
                    komutHat.Parameters.AddWithValue("@p4", LblStokKodu.Text);
                    komutHat.Parameters.AddWithValue("@p5", TxtMslink.Text);
                    komutHat.ExecuteNonQuery();
                    bgl.serhatgazBaglanti().Close();

                    MessageBox.Show("Güncelleme Yapıldı..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    listele();
                    temizle();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtMslink.Text = dr["MSLINK"].ToString();
                TxtYatirimYili.Text = dr["YATIRIMYILI"].ToString();
                TxtImalatTarihi.Text = dr["IMALAT_TARIHI"].ToString();
                TxtFormMetraj.Text = dr["BORU_UZUNLUGU"].ToString();
                TxtKaziBoyu.Text = dr["KAZI_BOYU"].ToString();
                CmbCap.Text = dr["NET_BORU_CAPI"].ToString();
                TxtSektor.Text = dr["SEKTOR"].ToString();
            }

            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("SELECT STOKKOD, STOKAD FROM DBO.STOKKART WHERE CAP=@p1", bgl.kargazBaglanti());
                    komut.Parameters.AddWithValue("@p1", CmbCap.Text);
                    SqlDataReader stok = komut.ExecuteReader();
                    if (stok.Read())
                    {
                        LblStokKodu.Text = stok["STOKKOD"].ToString();
                        LblStokAd.Text = stok["STOKAD"].ToString();
                    }
                    bgl.kargazBaglanti().Close();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("SELECT STOKKOD, STOKAD FROM DBO.STOKKART WHERE CAP=@p1", bgl.serhatgazBaglanti());
                    komut.Parameters.AddWithValue("@p1", CmbCap.Text);
                    SqlDataReader stok = komut.ExecuteReader();
                    if (stok.Read())
                    {
                        LblStokKodu.Text = stok["STOKKOD"].ToString();
                        LblStokAd.Text = stok["STOKAD"].ToString();
                    }
                    bgl.serhatgazBaglanti().Close();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("SELECT STOKKOD, STOKAD FROM DBO.STOKKART WHERE CAP=@p1", bgl.kargazBaglanti());
                    komut.Parameters.AddWithValue("@p1", CmbCap.Text);
                    SqlDataReader stok = komut.ExecuteReader();
                    if (stok.Read())
                    {
                        LblStokKodu.Text = stok["STOKKOD"].ToString();
                        LblStokAd.Text = stok["STOKAD"].ToString();
                    }
                    bgl.kargazBaglanti().Close();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("SELECT STOKKOD, STOKAD FROM DBO.STOKKART WHERE CAP=@p1", bgl.serhatgazBaglanti());
                    komut.Parameters.AddWithValue("@p1", CmbCap.Text);
                    SqlDataReader stok = komut.ExecuteReader();
                    if (stok.Read())
                    {
                        LblStokKodu.Text = stok["STOKKOD"].ToString();
                        LblStokAd.Text = stok["STOKAD"].ToString();
                    }
                    bgl.serhatgazBaglanti().Close();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }        
    }
}
