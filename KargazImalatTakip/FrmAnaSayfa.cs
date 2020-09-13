using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        FrmPeHatlar fr1;

        private void BtnPeHatlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new FrmPeHatlar();
                fr1.MdiParent = this;
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
    }
}
