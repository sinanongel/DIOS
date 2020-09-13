﻿using System;
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
    public partial class FrmPeHatlar : Form
    {
        public FrmPeHatlar()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                //try
                //{

                //if (CmbBolge.Text == "Bölge Seçiniz")
                //{
                SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY dbo.ilce.ILCE_ADI) AS SIRANO, dbo.HATLAR.MSLINK, dbo.HATLAR.SEKTOR, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, yol_adi AS YOL, dbo.yol.yol_tipi AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, FORMNO, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' order by ilce_adi, mahalle_adi, yol_adi, YATIRIMYILI, FORMNO", bgl.kargazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                //}
                //else
                //{
                //SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY dbo.ilce.ILCE_ADI) AS SIRANO, dbo.HATLAR.MSLINK, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, yol_adi AS YOL, dbo.yol.yol_tipi AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, FORMNO, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' and dbo.ilce.ilce_adi like '%" + CmbBolge.Text + "%' and dbo.mahalle.mahalle_adi like '%" + CmbMahalle.Text + "%'and dbo.yol.yol_adi like '%" + CmbSokak.Text + "%'and YATIRIMYILI like '%" + CmbYil.Text + "%' and NET_BORU_CAPI like '%" + CmbCap.Text + "%' order by ilce_adi, mahalle_adi, yol_adi, YATIRIMYILI, FORMNO", bgl.kargazBaglanti());
                //                DataTable dt = new DataTable();
                //                da.Fill(dt);
                //                gridControl1.DataSource = dt;
                //}

                gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                gridView1.Columns["FORMNO"].Caption = "FORM NO";
                gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[13].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY dbo.ilce.ILCE_ADI) AS SIRANO, dbo.HATLAR.MSLINK, dbo.HATLAR.SEKTOR, dbo.ilce.ilce_adi AS ILCE_ADI, mahalle_adi AS MAHALLE, yol_adi AS YOL, dbo.yol.yol_tipi AS YOL_TIPI, YATIRIMYILI, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, FORMNO, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU from dbo.HATLAR, dbo.yol, dbo.mahalle, dbo.ilce where dbo.HATLAR.YOL_MSLINK = dbo.yol.mslink and dbo.HATLAR.MAHALLE_KODU = dbo.mahalle.mahalle_kodu and dbo.HATLAR.ILCE_KODU = dbo.ilce.ilce_kodu and MALZEME_CINSI='Polietilen' order by ilce_adi, mahalle_adi, yol_adi, YATIRIMYILI, FORMNO", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    gridView1.Columns["SIRANO"].Caption = "SIRA NO";
                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YOL_TIPI"].Caption = "YOL TİPİ";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                    gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                    gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog kayit = new SaveFileDialog();
            if (kayit.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXlsx(kayit.FileName + ".xlsx");
            }
        }

        private void CmbŞirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CmbŞirket.Text == "KARGAZ")
            //{
            //    LblBolge.Visible = true;
            //    CmbBolge.Visible = true;
            //    bolgeListele();
            //    mahalleListele();
            //    sokakListele();
            //    yilListele();
            //}
            //else if (CmbŞirket.Text == "SERHATGAZ")
            //{
            //    LblBolge.Visible = false;
            //    CmbBolge.Visible = false;
            //}
        }

        //void bolgeListele()
        //{
        //    SqlCommand komutbolge = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
        //    SqlDataReader drBolge = komutbolge.ExecuteReader();
        //    while (drBolge.Read())
        //    {
        //        CmbBolge.Properties.Items.Add(drBolge[0]);
        //    }
        //    bgl.kargazBaglanti().Close();
        //}

        //void mahalleListele()
        //{
        //    SqlCommand komutMahalle = new SqlCommand("SELECT MAHALLE_ADI FROM DBO.MAHALLE ORDER BY MAHALLE_ADI", bgl.kargazBaglanti());
        //    SqlDataReader drMahalle = komutMahalle.ExecuteReader();
        //    while (drMahalle.Read())
        //    {
        //        CmbMahalle.Properties.Items.Add(drMahalle[0]);
        //    }
        //    bgl.kargazBaglanti().Close();
        //}

        //void sokakListele()
        //{
        //    SqlCommand komutSokak = new SqlCommand("SELECT YOL_ADI FROM DBO.YOL ORDER BY YOL_ADI", bgl.kargazBaglanti());
        //    SqlDataReader drSokak = komutSokak.ExecuteReader();
        //    while (drSokak.Read())
        //    {
        //        CmbSokak.Properties.Items.Add(drSokak[0]);
        //    }
        //    bgl.kargazBaglanti().Close();
        //}

        //void yilListele()
        //{
        //    SqlCommand komutYil = new SqlCommand("SELECT YATIRIMYILI FROM DBO.D_YATIRIM ORDER BY YATIRIMYILI", bgl.kargazBaglanti());
        //    SqlDataReader drYil = komutYil.ExecuteReader();
        //    while (drYil.Read())
        //    {
        //        CmbYil.Properties.Items.Add(drYil[0]);
        //    }
        //    bgl.kargazBaglanti().Close();
        //}
    }
}
