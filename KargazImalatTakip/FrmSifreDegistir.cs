using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmSifreDegistir : Form
    {
        public FrmSifreDegistir()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        public int kullaniciId;
        public string firma;
        public string sfr;

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string hash = "f0xle@rn";
            string md5Sifre;

            byte[] sifre = Convert.FromBase64String(sfr);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] anahtar = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = anahtar, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform donüsüm = tripDes.CreateDecryptor();
                    byte[] results = donüsüm.TransformFinalBlock(sifre, 0, sifre.Length);
                    md5Sifre = UTF8Encoding.UTF8.GetString(results);
                }
            }
            if (sfr != null && md5Sifre == TxtSifre.Text)
            {
                if (TxtYeniSifre.Text.Length == 6 && TxtYeniSifreTekrar.Text.Length == 6)
                {
                    if (TxtYeniSifre.Text == TxtYeniSifreTekrar.Text)
                    {
                        string yHash = "f0xle@rn";
                        string yMd5Sifre;

                        byte[] ySifre = UTF8Encoding.UTF8.GetBytes(TxtYeniSifreTekrar.Text);
                        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                        {
                            byte[] anahtar = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(yHash));
                            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = anahtar, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                            {
                                ICryptoTransform donüsüm = tripDes.CreateEncryptor();
                                byte[] results = donüsüm.TransformFinalBlock(ySifre, 0, ySifre.Length);
                                yMd5Sifre = Convert.ToBase64String(results, 0, results.Length);
                            }
                        }

                        if (firma == "KARGAZ")
                        {
                            SqlCommand kmtSfr = new SqlCommand("UPDATE KULLANICI SET SIFRE = @p1 WHERE KULLANICIID = " + kullaniciId, bgl.kargazBaglanti());
                            kmtSfr.Parameters.AddWithValue("@p1", yMd5Sifre);
                            kmtSfr.ExecuteNonQuery();
                            bgl.kargazBaglanti().Close();
                        }
                        else if (firma == "SERHATGAZ")
                        {
                            SqlCommand kmtSfr = new SqlCommand("UPDATE KULLANICI SET SIFRE = @p1 WHERE KULLANICIID = " + kullaniciId, bgl.serhatgazBaglanti());
                            kmtSfr.Parameters.AddWithValue("@p1", yMd5Sifre);
                            kmtSfr.ExecuteNonQuery();
                            bgl.serhatgazBaglanti().Close();
                        }

                        MessageBox.Show("Şİfre değişikliği başarıyla tamamlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Yeni şifre tekrarınız aynı değil, lütfen tekrar deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Şifre 6 karakter olmalı!");
                }
            }
            else
            {
                MessageBox.Show("Şifreniz yanlış, lütfen kontrol edip tekrar deneyiniz.");
            }
            this.Close();
        }

        private void FrmSifreDegistir_Load(object sender, EventArgs e)
        {
            if (firma == "KARGAZ")
            {
                SqlCommand kmtSifre = new SqlCommand("SELECT KULLANICIAD, SIFRE FROM KULLANICI WHERE KULLANICIID = " + kullaniciId, bgl.kargazBaglanti());
                SqlDataReader drSifre = kmtSifre.ExecuteReader();
                while (drSifre.Read())
                {
                    LblKullaniciAdi.Text = drSifre[0].ToString();
                    sfr = drSifre[1].ToString();
                }
                bgl.kargazBaglanti().Close();
            }
            else if (firma == "SERHATGAZ")
            {
                SqlCommand kmtSifre = new SqlCommand("SELECT KULLANICIAD, SIFRE FROM KULLANICI WHERE KULLANICIID = " + kullaniciId, bgl.serhatgazBaglanti());
                SqlDataReader drSifre = kmtSifre.ExecuteReader();
                while (drSifre.Read())
                {
                    LblKullaniciAdi.Text = drSifre[0].ToString();
                    sfr = drSifre[1].ToString();
                }
                bgl.serhatgazBaglanti().Close();
            }
        }
    }
}
