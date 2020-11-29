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
    public partial class FrmShKayitDuzelt : Form
    {
        public FrmShKayitDuzelt()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();

        void temizle()
        {
            TxtMslink.Text = "";
            TxtYatirimYili.Text = "";
            TxtImalatTarihi.Text = "";
            TxtBoruBoyu.Text = "";
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
                try
                {
                    SqlDataAdapter daHat = new SqlDataAdapter("SELECT SH.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, SH.IMALATTARIHI, 104) AS IMALAT_TARIHI, " +
                        "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' + YOL_TIPI AS YOL, SEKTOR, HAT_MSLINK, FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, " +
                        "CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, EKIPNO FROM dbo.SERVIS_HATLARI SH " +
                        "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO = " + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.kargazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["FROM_ID"].Caption = "FROM ID";
                    gridView1.Columns["FROM_MSLINK"].Caption = "FROM MSLINK";
                    gridView1.Columns["TO_ID"].Caption = "TO ID";
                    gridView1.Columns["TO_MSLINK"].Caption = "TO MSLINK";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                    gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    gridView1.Columns[14].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (gridView1.RowCount == 0)
                {
                    MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlDataAdapter daHat = new SqlDataAdapter("SELECT SH.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, SH.IMALATTARIHI, 104) AS IMALAT_TARIHI, " +
                        "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, YOL_ADI + ' ' + YOL_TIPI AS YOL, SEKTOR, HAT_MSLINK, FROM_ID, FROM_MSLINK, TO_ID, TO_MSLINK, " +
                        "CAP, KAZIBOYU, BORUBOYU, YATAY_ASBUILT_METRAJ, SHATTIMETRAJ, EKIPNO FROM dbo.SERVIS_HATLARI SH " +
                        "LEFT JOIN DBO.YOL Y ON SH.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON SH.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON SH.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO = " + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'", bgl.serhatgazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["FROM_ID"].Caption = "FROM ID";
                    gridView1.Columns["FROM_MSLINK"].Caption = "FROM MSLINK";
                    gridView1.Columns["TO_ID"].Caption = "TO ID";
                    gridView1.Columns["TO_MSLINK"].Caption = "TO MSLINK";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["CAP"].Caption = "BORU ÇAPI";
                    gridView1.Columns["HAT_MSLINK"].Caption = "HAT MSLINK";
                    gridView1.Columns["KAZIBOYU"].Caption = "FORM KAZI BOYU";
                    gridView1.Columns["BORUBOYU"].Caption = "FORM BORU BOYU";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["SHATTIMETRAJ"].Caption = "EĞİK ASBUILT METRAJ";
                    gridView1.Columns["EKIPNO"].Caption = "MÜTEAHHİT";

                    gridView1.Columns[14].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                        SqlCommand komutSil = new SqlCommand("Delete from dbo.SERVIS_HATLARI where MSLINK=@p1", bgl.kargazBaglanti());
                        komutSil.Parameters.AddWithValue("@p1", TxtMslink.Text);
                        komutSil.ExecuteNonQuery();
                        bgl.kargazBaglanti().Close();
                        MessageBox.Show("Kayıt Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
                    DialogResult Soru;

                    Soru = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Soru == DialogResult.Yes)
                    {
                        SqlCommand komutSil = new SqlCommand("Delete from dbo.SERVIS_HATLARI where MSLINK=@p1", bgl.serhatgazBaglanti());
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtMslink.Text = dr["MSLINK"].ToString();
                TxtYatirimYili.Text = dr["YATIRIMYILI"].ToString();
                TxtImalatTarihi.Text = dr["IMALAT_TARIHI"].ToString();
                TxtBoruBoyu.Text = dr["BORUBOYU"].ToString();
                TxtKaziBoyu.Text = dr["KAZIBOYU"].ToString();
                CmbCap.Text = dr["CAP"].ToString();
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlCommand komutHat = new SqlCommand("UPDATE dbo.SERVIS_HATLARI SET BORUBOYU=@p1, KAZIBOYU=@p2, CAP=@p3, VARLIK_KODU=@p4 where MSLINK=@p5", bgl.kargazBaglanti());
                    komutHat.Parameters.AddWithValue("@p1", TxtBoruBoyu.Text.ToString().Replace(",", "."));
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
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlCommand komutHat = new SqlCommand("UPDATE dbo.SERVIS_HATLARI SET BORUBOYU=@p1, KAZIBOYU=@p2, CAP=@p3, VARLIK_KODU=@p4 where MSLINK=@p5", bgl.serhatgazBaglanti());
                    komutHat.Parameters.AddWithValue("@p1", TxtBoruBoyu.Text.ToString().Replace(",", "."));
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
                catch
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
