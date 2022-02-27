using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        public int kullaniciId;
        public string firma;
        string yetkiGrup;

        FrmPeHatlar fr1;

        private void BtnPeHatlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new FrmPeHatlar();
                fr1.MdiParent = this;
                fr1.yetkiGrup = yetkiGrup;
                fr1.Show();
            }
        }

        FrmCelikHatlar fr2;

        private void BtnCelikHatlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmCelikHatlar();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        FrmServisHatlar fr3;

        private void BtnServisHatlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FrmServisHatlar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        FrmFormDuzelt fr4;

        private void BtnPeFormDuzeltme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FrmFormDuzelt();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        FrmPeKayitDuzeltme fr5;

        private void BtnPeKayitDuzeltme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmPeKayitDuzeltme();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        FrmShFormDuzeltme fr6;

        private void BtnShFormDuzeltme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmShFormDuzeltme();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        FrmShKayitDuzelt fr7;

        private void BtnShKayitDuzeltme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmShKayitDuzelt();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        FrmPeVana fr8;

        private void BtnPeVanalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FrmPeVana();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        FrmCelikVana fr9;

        private void BtnCelikVanalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new FrmCelikVana();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }

        FrmBolgeRegulatoru fr10;

        private void BtnBolgeRegulator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new FrmBolgeRegulatoru();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        FrmTumImalat fr11;

        private void BtnTumImalatlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new FrmTumImalat();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        FrmStFormDuzeltme fr12;

        private void BtnStFormDuzeltme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new FrmStFormDuzeltme();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        FrmYolKaziRaporu fr13;

        private void BtnPeYolKazıRaporu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new FrmYolKaziRaporu();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }

        FrmIcmal fr14;

        private void BtnIcmalRaporu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new FrmIcmal();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        FrmFittingsHat fr15;

        private void BtnFittingsHat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new FrmFittingsHat();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        FrmAboOlanKutusuOlmayanBina fr16;

        private void BtnAboneligiOlanKutusuOlmayanBinalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new FrmAboOlanKutusuOlmayanBina();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }

        FrmMucbirTakip fr17;

        private void BtnMucbirTakip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new FrmMucbirTakip();
                fr17.MdiParent = this;
                fr17.Show();
            }
        }

        FrmMucbir fr18;

        private void BtnMucbir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new FrmMucbir();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        FrmSokakBazındaBinaDaireSayısı fr19;

        private void BtnSokBazBinaDaireSay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new FrmSokakBazındaBinaDaireSayısı();
                fr19.MdiParent = this;
                fr19.Show();
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            LblCopyright.Text = "Copyright © " + DateTime.Today.ToString("yyyy") + " Sinan Öngel";
            LblTarih.Text = DateTime.Today.ToString("d");

            if (firma == "KARGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT AD, SOYAD, YETKIGRUP FROM KULLANICI WHERE KULLANICIID = " + kullaniciId, bgl.kargazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    LblKullaniciAdi.Text = dr[0].ToString() + " " + dr[1].ToString();
                    yetkiGrup = dr[2].ToString();
                }
                bgl.kargazBaglanti().Close();
            }
            else if (firma == "SERHATGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT AD, SOYAD, YETKIGRUP FROM KULLANICI WHERE KULLANICIID = " + kullaniciId, bgl.serhatgazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    LblKullaniciAdi.Text = dr[0].ToString() + " " + dr[1].ToString();
                    yetkiGrup = dr[2].ToString();
                }
                bgl.serhatgazBaglanti().Close();
            }

            if(yetkiGrup=="SS" || yetkiGrup == "KS")
            {
                ribbonPage2.Visible = false;
            }
        }

        FrmSifreDegistir fr20;

        private void BtnSifreDegistirme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr19.IsDisposed)
            {
                fr20 = new FrmSifreDegistir();
                fr20.kullaniciId = kullaniciId;
                fr20.firma = firma;
                fr20.Show();
            }
        }

        FrmBinaKutuKontrol fr21;
        private void BtnBinaKutuKontrol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21 == null || fr21.IsDisposed)
            {
                fr21 = new FrmBinaKutuKontrol();
                fr21.MdiParent = this;
                fr21.Show();
            }
        }

        private void FrmAnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        FrmPeShAdresKontrol fr22;
        private void BtnPeShAdresKontrol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr22 == null || fr22.IsDisposed)
            {
                fr22 = new FrmPeShAdresKontrol();
                fr22.MdiParent = this;
                fr22.Show();
            }
        }

        FrmIlisikOlmayanKutular fr23;
        private void BtnIlisikOlmayanKutular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23 == null || fr23.IsDisposed)
            {
                fr23 = new FrmIlisikOlmayanKutular();
                fr23.MdiParent = this;
                fr23.Show();
            }
        }

        FrmYolRaporu fr24;
        private void BtnYolRaporu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24 == null || fr24.IsDisposed)
            {
                fr24 = new FrmYolRaporu();
                fr24.MdiParent = this;
                fr24.Show();
            }
        }
    }
}
