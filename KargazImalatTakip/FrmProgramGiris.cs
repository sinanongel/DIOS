using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PersonelDegerlendirme.Tanımlama
{
    public partial class FrmProgramGiris : Form
    {
        public FrmProgramGiris()
        {
            InitializeComponent();
        }

//        DbPersonelEntities db = new DbPersonelEntities();

//        private void BtnGiris_Click(object sender, EventArgs e)
//        {
//            string hash = "f0xle@rn";
//            string md5Sifre;

//            var kKulAdi = db.KULLANICI.Where(k => k.KULLANICIADI == TxtKullaniciAdi.Text)
//                .Select(t => t.KULLANICIADI)
//                .FirstOrDefault();

//            var kSifre = db.KULLANICI.Where(k => k.KULLANICIADI == TxtKullaniciAdi.Text)
//                .Select(t => t.SIFRE)
//                .FirstOrDefault();

//            var kAdi = db.KULLANICI.Where(k => k.KULLANICIADI == TxtKullaniciAdi.Text)
//                .Select(t => t.ADI)
//                .FirstOrDefault();

//            var kSoyadi = db.KULLANICI.Where(k => k.KULLANICIADI == TxtKullaniciAdi.Text)
//                .Select(t => t.SOYADI)
//                .FirstOrDefault();

//            var kYetkiGrup = db.KULLANICI.Where(k => k.KULLANICIADI == TxtKullaniciAdi.Text)
//                .Select(t => t.YETKIGURUBU)
//                .FirstOrDefault();

//            var kFirmaId = db.KULLANICI.Where(k => k.KULLANICIADI == TxtKullaniciAdi.Text)
//                .Select(t => t.FIRMAID)
//                .FirstOrDefault();

//            byte[] sifre = Convert.FromBase64String(kSifre);
//            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
//            {
//                byte[] anahtar = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
//                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = anahtar, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
//                {
//                    ICryptoTransform donüsüm = tripDes.CreateDecryptor();
//                    byte[] results = donüsüm.TransformFinalBlock(sifre, 0, sifre.Length);
//                    md5Sifre = UTF8Encoding.UTF8.GetString(results);
//                }
//            }
//            if (kSifre != null && md5Sifre==TxtSifre.Text)
//            {
//                FrmProgramGiris pg = new FrmProgramGiris();
//                pg.Close();
//                FrmAnaSayfa br = new FrmAnaSayfa();
//                br.kullaniciAdi = kKulAdi;
//                br.adi = kAdi;
//                br.soyadi = kSoyadi;
//                br.yetkigrup = kYetkiGrup;
//                br.firmaId = Convert.ToInt32(kFirmaId);
//                br.Show();
//                this.Hide();
//            }
//            else
//            {
//                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre");
//            }
//        }

//        private void TxtKullaniciAdi_Click(object sender, EventArgs e)
//        {
//            TxtKullaniciAdi.ResetText();
//        }

//        private void TxtSifre_Click(object sender, EventArgs e)
//        {
//            TxtSifre.ResetText();
//        }
    }
}
