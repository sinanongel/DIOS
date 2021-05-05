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
using System.IO;
using DevExpress.XtraEditors.Repository;
using System.Diagnostics;

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
            TxtDosyaAdi.Text = "";

            gridView1.Columns.Clear();
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();

            CheTumunuSec.Checked = false;
        }

        void listele()
        {
            //Veri tabanına bağlanamama durumunda ikaz vermesi için try-catch bloğuna aldım.
            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                        "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                        "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO, DOSYA FROM dbo.HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE H.MALZEME_CINSI = 'Polietilen' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
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
                    gridView1.Columns["DOSYA"].Caption = "DOSYA";

                    RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                    gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                    dosyaYolu.OpenLink += DosyaYolu_OpenLink;

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT B.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, B.IMALATTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_PE B " +
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

                    SqlDataAdapter daVana = new SqlDataAdapter("SELECT V.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, V.IMALAT_TARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, VANA_NO, BOLGE, SEKTOR, VANA_TIPI, CAP FROM dbo.VANA V " +
                        "LEFT JOIN DBO.YOL Y ON V.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON V.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON V.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE FORMNO =  '" + TxtFormNo.Text + "'" + " AND I.ILCE_ADI ='" + CmbBolge.Text + "' " +
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

                    if (gridView1.RowCount != 0)
                    {
                        SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR" +
                            " FROM DBO.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE MALZEME_CINSI='Polietilen' AND FORMNO=@P1 AND I.ILCE_ADI=@P2", bgl.kargazBaglanti());
                        komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                        komutHat.Parameters.AddWithValue("@P2", CmbBolge.Text);
                        SqlDataReader drHat = komutHat.ExecuteReader();
                        while (drHat.Read())
                        {
                            TxtFormNoYeni.Text = drHat[0].ToString();
                            TxtYatirimYili.Text = drHat[1].ToString();
                            TxtImalatTarihi.Text = drHat[2].ToString();
                            TxtSektor.Text = drHat[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE, VANA_NO FROM DBO.VANA WHERE FORMNO=@P3", bgl.kargazBaglanti());
                        komutVana.Parameters.AddWithValue("@P3", TxtFormNo.Text);
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
                            "FROM dbo.BAGLANTI_ELEMANLARI_PE B " +
                            "LEFT JOIN DBO.YOL Y ON B.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE FORMNO=@P4 AND I.ILCE_ADI=@P5", bgl.kargazBaglanti());
                        komutMalzeme.Parameters.AddWithValue("@P4", TxtFormNo.Text);
                        komutMalzeme.Parameters.AddWithValue("@P5", CmbBolge.Text);
                        SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                        while (drMalzeme.Read())

                        {
                            TxtFormNoYeni.Text = drMalzeme[0].ToString();
                            TxtYatirimYili.Text = drMalzeme[1].ToString();
                            TxtImalatTarihi.Text = drMalzeme[2].ToString();
                            TxtSektor.Text = drMalzeme[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

                        SqlCommand komutVana = new SqlCommand("SELECT BOLGE FROM DBO.VANA WHERE FORMNO=@P6", bgl.kargazBaglanti());
                        komutVana.Parameters.AddWithValue("@P6", TxtFormNo.Text);
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
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter daHat = new SqlDataAdapter("SELECT H.MSLINK, FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, " +
                        "I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, " +
                        "YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU, EKIPNO, DOSYA FROM dbo.HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE H.MALZEME_CINSI = 'Polietilen' AND FORMNO =" + TxtFormNo.Text + " AND I.ILCE_ADI ='" + CmbBolge.Text + "'" +
                        "ORDER BY H.MSLINK", bgl.serhatgazBaglanti());
                    DataTable dtHat = new DataTable();
                    daHat.Fill(dtHat);
                    GrCoHat.DataSource = dtHat;

                    RepositoryItemHyperLinkEdit dosyaYolu = new RepositoryItemHyperLinkEdit();
                    gridView1.Columns["DOSYA"].ColumnEdit = dosyaYolu;
                    dosyaYolu.OpenLink += DosyaYolu_OpenLink;

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

                    SqlDataAdapter daMalzeme = new SqlDataAdapter("SELECT B.MSLINK, FORMNO, YATIRIMYILI, convert(varchar, B.IMALATTARIHI, 104) as IMALAT_TARIHI, " +
                        "I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, (Y.YOL_ADI + ' ' + Y.YOL_TIPI) AS YOL, SEKTOR, TIPI, CAP, EKIPNO FROM dbo.BAGLANTI_ELEMANLARI_PE B " +
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

                    if (gridView1.RowCount != 0)
                    {
                        SqlCommand komutHat = new SqlCommand("SELECT FORMNO, YATIRIMYILI, CONVERT(VARCHAR, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, SEKTOR " +
                            "FROM DBO.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE MALZEME_CINSI='Polietilen' AND FORMNO=@P1 AND I.ILCE_ADI=@P2", bgl.serhatgazBaglanti());
                        komutHat.Parameters.AddWithValue("@P1", TxtFormNo.Text);
                        komutHat.Parameters.AddWithValue("@P2", CmbBolge.Text);
                        SqlDataReader drHat = komutHat.ExecuteReader();
                        while (drHat.Read())
                        {
                            TxtFormNoYeni.Text = drHat[0].ToString();
                            TxtYatirimYili.Text = drHat[1].ToString();
                            TxtImalatTarihi.Text = drHat[2].ToString();
                            TxtSektor.Text = drHat[3].ToString();
                            //CmbMahalle.Text = drHat[4].ToString();
                            //CmbSokak.Text = drHat[5].ToString();
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
                        SqlCommand komutMalzeme = new SqlCommand("SELECT FORMNO, YATIRIMYILI, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, SEKTOR" +
                            "FROM dbo.BAGLANTI_ELEMANLARI_PE B " +
                            "LEFT JOIN DBO.YOL Y ON B.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE FORMNO=@P4 AND I.ILCE_ADI=@P5", bgl.serhatgazBaglanti());
                        komutMalzeme.Parameters.AddWithValue("@P4", TxtFormNo.Text);
                        komutMalzeme.Parameters.AddWithValue("@P5", CmbBolge.Text);
                        SqlDataReader drMalzeme = komutMalzeme.ExecuteReader();
                        while (drMalzeme.Read())

                        {
                            TxtFormNoYeni.Text = drMalzeme[0].ToString();
                            TxtYatirimYili.Text = drMalzeme[1].ToString();
                            TxtImalatTarihi.Text = drMalzeme[2].ToString();
                            TxtSektor.Text = drMalzeme[3].ToString();
                        }
                        bgl.kargazBaglanti().Close();

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
                        MessageBox.Show("Girilen Form Numarası ile ilgili herhangi bir kayıt bulunamadı.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                dosyaYolu = satir[0] + bolge + "\\";
                yol = dosyaYolu + dosya;
                //yol = dr["DOSYA_YOLU"].ToString();
                Process.Start(yol);
            }

            //FileInfo dosyaBilgi = new FileInfo();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbŞirket.Text == "KARGAZ")
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
                            
                            MessageBox.Show("Tüm Bilgiler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            listele();
                        }
                    }
                
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
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
                                SqlCommand komutHat = new SqlCommand("UPDATE dbo.HATLAR SET FORMNO=@p1, YATIRIMYILI=@p2, IMALAT_TARIHI=@p3, SEKTOR=@p4 where MSLINK=" + hatMslink, bgl.serhatgazBaglanti());
                                komutHat.Parameters.AddWithValue("@p1", TxtFormNoYeni.Text);
                                komutHat.Parameters.AddWithValue("@p2", TxtYatirimYili.Text);
                                komutHat.Parameters.AddWithValue("@p3", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutHat.Parameters.AddWithValue("@p4", TxtSektor.Text);
                                //komutHat.Parameters.AddWithValue("@p5", TxtFormNo.Text);
                                komutHat.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            foreach (int malzemeMslink in secMalzemeMslink)
                            {
                                SqlCommand komutMalzeme = new SqlCommand("UPDATE dbo.BAGLANTI_ELEMANLARI_PE SET FORMNO=@p5, YATIRIMYILI=@p6, IMALATTARIHI=@p7, SEKTOR=@p9 where MSLINK=" + malzemeMslink, bgl.serhatgazBaglanti());
                                komutMalzeme.Parameters.AddWithValue("@p5", TxtFormNoYeni.Text);
                                komutMalzeme.Parameters.AddWithValue("@p6", TxtYatirimYili.Text);
                                komutMalzeme.Parameters.AddWithValue("@p7", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutMalzeme.Parameters.AddWithValue("@p9", TxtSektor.Text);
                                //komutMalzeme.Parameters.AddWithValue("@p10", TxtFormNo.Text);
                                komutMalzeme.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }
                            foreach (int vanaMslink in secVanaMslink)
                            {
                                SqlCommand komutVana = new SqlCommand("UPDATE dbo.VANA SET FORMNO=@p10, YATIRIMYILI=@p11, IMALAT_TARIHI=@p12,  VANA_NO=@p13, BOLGE=@p14, SEKTOR=@p15, where MSLINK=" + vanaMslink, bgl.serhatgazBaglanti());
                                komutVana.Parameters.AddWithValue("@p10", TxtFormNoYeni.Text);
                                komutVana.Parameters.AddWithValue("@p11", TxtYatirimYili.Text);
                                komutVana.Parameters.AddWithValue("@p12", Convert.ToDateTime(TxtImalatTarihi.Text));
                                komutVana.Parameters.AddWithValue("@p13", TxtVanaNo.Text);
                                komutVana.Parameters.AddWithValue("@p14", TxtBolge.Text);
                                komutVana.Parameters.AddWithValue("@p15", TxtSektor.Text);
                                //komutVana.Parameters.AddWithValue("@p16", TxtFormNo.Text);
                                komutVana.ExecuteNonQuery();
                                bgl.serhatgazBaglanti().Close();
                            }

                            MessageBox.Show("Tüm Bilgiler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);                        
                            listele();
                        }                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        string kaynakDosyaYolu = "";
        string kayitYolu = "";

        private void BtnDosyaYukle_Click(object sender, EventArgs e)
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");
            kayitYolu = satir[0] + CmbBolge.Text + "\\";

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
                        string dosyaAdi = bolge + "_PE_" + yatirimYil + "_" + TxtFormNoYeni.Text + ".pdf";
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
