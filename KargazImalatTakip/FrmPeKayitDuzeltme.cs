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
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                    "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                    "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO FROM dbo.HATLAR H " +
                    "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                    "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE H.MALZEME_CINSI = 'Polietilen' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                    "ORDER BY H.MSLINK", bgl.kargazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                GrCoHat.DataSource = dtHat;

                if (gridView1.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                    "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                    "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO FROM dbo.HATLAR H " +
                    "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                    "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                    "WHERE H.MALZEME_CINSI = 'Polietilen' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                    "ORDER BY H.MSLINK", bgl.serhatgazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                GrCoHat.DataSource = dtHat;

                //gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                //gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                //gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                //gridView1.Columns["FORMNO"].Caption = "FORM NO";
                //gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                //gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                //gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                //gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                //gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";
                //gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                //gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                //gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                if (gridView1.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

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

            gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
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
    }
}
