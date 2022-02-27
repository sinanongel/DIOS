using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        public int kullaniciId;
        public string sfr;
        public string firma;

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string hash = "f0xle@rn";
            string md5Sifre;

            if (CmbŞirket.Text == "KARGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT KULLANICIID, SIFRE, FIRMA FROM KULLANICI WHERE KULLANICIAD = '" + TxtKullaniciAdi.Text + "'", bgl.kargazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    kullaniciId = Convert.ToInt32(dr[0].ToString());
                    sfr = dr[1].ToString();
                    firma = dr[2].ToString();
                }
                bgl.kargazBaglanti().Close();
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT KULLANICIID, SIFRE, FIRMA FROM KULLANICI WHERE KULLANICIAD = '" + TxtKullaniciAdi.Text + "'", bgl.serhatgazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    kullaniciId = Convert.ToInt32(dr[0].ToString());
                    sfr = dr[1].ToString();
                    firma = dr[2].ToString();
                }
                bgl.serhatgazBaglanti().Close();
            }

            byte[] sifre = Convert.FromBase64String(sfr);
            
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] anahtar = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripDes=new TripleDESCryptoServiceProvider() { Key = anahtar, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform donusum = tripDes.CreateDecryptor();
                    byte[] results = donusum.TransformFinalBlock(sifre, 0, sifre.Length);
                    md5Sifre = UTF8Encoding.UTF8.GetString(results);
                }
            }

            if (sfr != null && md5Sifre == TxtSifre.Text)
            {
                FrmGiris g = new FrmGiris();
                g.Close();

                FrmAnaSayfa aSayfa = new FrmAnaSayfa();
                aSayfa.kullaniciId = kullaniciId;
                aSayfa.firma = firma;
                aSayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre");
            }
        }

        private void TxtKullaniciAdi_Click(object sender, EventArgs e)
        {
            TxtKullaniciAdi.ResetText();
        }

        private void TxtSifre_Click(object sender, EventArgs e)
        {
            TxtSifre.ResetText();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            labelControl3.Text = "Copyright © "+ DateTime.Today.ToString("yyyy") +" Sinan Öngel";
        }
    }
}
