using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;

namespace KargazImalatTakip
{
    public partial class FrmYolKaziRaporu : Form
    {
        public FrmYolKaziRaporu()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void CmbGenelŞirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbGenelBolge.Text = "";
            CmbGenelBolge.Properties.Items.Clear();

            if (CmbGenelŞirket.Text == "KARGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbGenelBolge.Properties.Items.Add(dr[0]);
                }
                bgl.kargazBaglanti().Close();
            }
            else if (CmbGenelŞirket.Text == "SERHATGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.serhatgazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbGenelBolge.Properties.Items.Add(dr[0]);
                }
                bgl.serhatgazBaglanti().Close();
            }
        }
        private void BtnGenelListele_Click(object sender, EventArgs e)
        {
            if (CmbGenelŞirket.Text == "KARGAZ")
            {
                gridView1.Columns.Clear();

                SqlCommand bolgeId = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI = '" + CmbGenelBolge.Text + "'", bgl.kargazBaglanti());
                SqlDataReader drBolge = bolgeId.ExecuteReader();
                while (drBolge.Read())
                {
                    labelControl1.Text = drBolge[0].ToString();
                }

                SqlDataAdapter daHat = new SqlDataAdapter("SELECT M.MAHALLE_ADI, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, ROUND(Y.YOL_BOYU, 2) AS YOL_BOYU, SUM(H.BORU_UZUNLUGU) AS BORU_BOYU, SUM(H.KAZI_BOYU) AS KAZI_BOYU FROM HATLAR H INNER JOIN MAHALLE M ON M.MAHALLE_KODU = H.MAHALLE_KODU INNER JOIN YOL Y ON Y.MSLINK = H.YOL_MSLINK WHERE H.ILCE_KODU = '" + labelControl1.Text + "' GROUP BY M.MAHALLE_ADI, Y.YOL_ADI, Y.YOL_TIPI, YOL_BOYU ORDER BY Y.YOL_ADI", bgl.kargazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl1.DataSource = dtHat;

                gridView1.Columns["MAHALLE_ADI"].Caption = "MAHALLE ADI";
                gridView1.Columns["YOL"].Caption = "YOL";
                gridView1.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView1.Columns["BORU_BOYU"].Caption = "BORU BOYU";
                gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";
                gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = "FARK(YOL-KAZI)",
                    FieldName = "FARK",
                    UnboundType = DevExpress.Data.UnboundColumnType.Decimal,
                    UnboundExpression = "YOL_BOYU - KAZI_BOYU",
                    Visible = true
                });
                gridView1.Columns["FARK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["FARK"].DisplayFormat.FormatString = "#0.00;(#0.00)";

                gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[5].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum; 
            }
            else if (CmbGenelŞirket.Text == "SERHATGAZ")
            {
                gridView1.Columns.Clear();

                SqlCommand bolgeId = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI = '" + CmbGenelBolge.Text + "'", bgl.serhatgazBaglanti());
                SqlDataReader drBolge = bolgeId.ExecuteReader();
                while (drBolge.Read())
                {
                    labelControl1.Text = drBolge[0].ToString();
                }

                SqlDataAdapter daHat = new SqlDataAdapter("SELECT M.MAHALLE_ADI, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, ROUND(Y.YOL_BOYU, 2) AS YOL_BOYU, SUM(H.BORU_UZUNLUGU) AS BORU_BOYU, SUM(H.KAZI_BOYU) AS KAZI_BOYU FROM HATLAR H INNER JOIN MAHALLE M ON M.MAHALLE_KODU = H.MAHALLE_KODU INNER JOIN YOL Y ON Y.MSLINK = H.YOL_MSLINK WHERE H.ILCE_KODU = '" + labelControl1.Text + "' GROUP BY M.MAHALLE_ADI, Y.YOL_ADI, Y.YOL_TIPI, YOL_BOYU ORDER BY Y.YOL_ADI", bgl.serhatgazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl1.DataSource = dtHat;

                gridView1.Columns["MAHALLE_ADI"].Caption = "MAHALLE ADI";
                gridView1.Columns["YOL"].Caption = "YOL";
                gridView1.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView1.Columns["BORU_BOYU"].Caption = "BORU BOYU";
                gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";
                gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = "FARK(YOL-KAZI)",
                    FieldName = "FARK",
                    UnboundType = DevExpress.Data.UnboundColumnType.Decimal,
                    UnboundExpression = "YOL_BOYU - KAZI_BOYU",
                    Visible = true
                });
                gridView1.Columns["FARK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["FARK"].DisplayFormat.FormatString = "#0.00;(#0.00)";

                gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[5].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            }
            LblBaslik.Text = CmbGenelŞirket.Text + " - " + CmbGenelBolge.Text;
        }

        private void CmbDetaySirket_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDetayBolge.Text = "";
            CmbDetayBolge.Properties.Items.Clear();

            if (CmbDetaySirket.Text == "KARGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.kargazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbDetayBolge.Properties.Items.Add(dr[0]);
                }
                bgl.kargazBaglanti().Close();
            }
            else if (CmbDetaySirket.Text == "SERHATGAZ")
            {
                SqlCommand komut = new SqlCommand("SELECT ILCE_ADI FROM DBO.ILCE", bgl.serhatgazBaglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CmbDetayBolge.Properties.Items.Add(dr[0]);
                }
                bgl.serhatgazBaglanti().Close();
            }
        }

        private void BtnDetayListele_Click(object sender, EventArgs e)
        {
            DateTime tarih1 = DateTime.Parse(DtBaslangicTarihi.Text);
            DateTime tarih2 = DateTime.Parse(DtBitisTarihi.Text);

            if (CmbDetaySirket.Text == "KARGAZ")
            {
                SqlCommand bolgeId = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI = '" + CmbDetayBolge.Text + "'", bgl.kargazBaglanti());
                SqlDataReader drBolge = bolgeId.ExecuteReader();
                while (drBolge.Read())
                {
                    labelControl1.Text = drBolge[0].ToString();
                }

                SqlDataAdapter daHat = new SqlDataAdapter("SELECT M.MAHALLE_ADI, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, ROUND(Y.YOL_BOYU, 2) AS YOL_BOYU, H.IMALAT_TARIHI, H.FORMNO, H.SEKTOR, H.NET_BORU_CAPI,  H.BORU_UZUNLUGU, H.KAZI_BOYU FROM HATLAR H INNER JOIN MAHALLE M ON M.MAHALLE_KODU = H.MAHALLE_KODU INNER JOIN YOL Y ON Y.MSLINK = H.YOL_MSLINK WHERE H.ILCE_KODU = '" + labelControl1.Text + "' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' ORDER BY Y.YOL_ADI", bgl.kargazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl2.DataSource = dtHat;

                gridView2.Columns["MAHALLE_ADI"].Caption = "MAHALLE ADI";
                gridView2.Columns["YOL"].Caption = "YOL";
                gridView2.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView2.Columns["FORMNO"].Caption = "FORM NO";
                gridView2.Columns["SEKTOR"].Caption = "SEKTOR";
                gridView2.Columns["NET_BORU_CAPI"].Caption = "ÇAP";
                gridView2.Columns["BORU_UZUNLUGU"].Caption = "BORU BOYU";
                gridView2.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns[2].SummaryItem.DisplayFormat = "TOPLAM YOL BOYU={0:0.##}";
                gridView2.Columns[7].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns[7].SummaryItem.DisplayFormat = "GENEL TOPLAM={0:0.##}";
                gridView2.Columns[8].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns[8].SummaryItem.DisplayFormat = "GENEL TOPLAM={0:0.##}";

                GridGroupSummaryItem yolBoyu = new GridGroupSummaryItem();
                yolBoyu.FieldName = "YOL_BOYU";
                yolBoyu.DisplayFormat = "YOL BOYU={0:0.##}";
                yolBoyu.SummaryType = DevExpress.Data.SummaryItemType.Average;
                yolBoyu.ShowInGroupColumnFooter = gridView2.Columns["YOL_BOYU"];
                gridView2.GroupSummary.Add(yolBoyu);

                GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                boruUzunlugu.ShowInGroupColumnFooter = gridView2.Columns["BORU_UZUNLUGU"];
                gridView2.GroupSummary.Add(boruUzunlugu);

                GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                kaziBoyu.FieldName = "KAZI_BOYU";
                kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                kaziBoyu.ShowInGroupColumnFooter = gridView2.Columns["KAZI_BOYU"];
                gridView2.GroupSummary.Add(kaziBoyu);
            }
            else if (CmbDetaySirket.Text == "SERHATGAZ")
            {
                SqlCommand bolgeId = new SqlCommand("SELECT ILCE_KODU FROM DBO.ILCE WHERE ILCE_ADI = '" + CmbDetayBolge.Text + "'", bgl.serhatgazBaglanti());
                SqlDataReader drBolge = bolgeId.ExecuteReader();
                while (drBolge.Read())
                {
                    labelControl1.Text = drBolge[0].ToString();
                }

                SqlDataAdapter daHat = new SqlDataAdapter("SELECT M.MAHALLE_ADI, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, ROUND(Y.YOL_BOYU, 2) AS YOL_BOYU, H.IMALAT_TARIHI, H.FORMNO, H.SEKTOR, H.NET_BORU_CAPI,  H.BORU_UZUNLUGU, H.KAZI_BOYU FROM HATLAR H INNER JOIN MAHALLE M ON M.MAHALLE_KODU = H.MAHALLE_KODU INNER JOIN YOL Y ON Y.MSLINK = H.YOL_MSLINK WHERE H.ILCE_KODU = '" + labelControl1.Text + "' AND IMALAT_TARIHI BETWEEN '" + tarih1 + "' AND '" + tarih2 + "' ORDER BY Y.YOL_ADI", bgl.serhatgazBaglanti());
                DataTable dtHat = new DataTable();
                daHat.Fill(dtHat);
                gridControl2.DataSource = dtHat;

                gridView2.Columns["MAHALLE_ADI"].Caption = "MAHALLE ADI";
                gridView2.Columns["YOL"].Caption = "YOL";
                gridView2.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView2.Columns["FORMNO"].Caption = "FORM NO";
                gridView2.Columns["SEKTOR"].Caption = "SEKTOR";
                gridView2.Columns["NET_BORU_CAPI"].Caption = "ÇAP";
                gridView2.Columns["BORU_UZUNLUGU"].Caption = "BORU BOYU";
                gridView2.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                gridView2.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns[2].SummaryItem.DisplayFormat = "TOPLAM YOL BOYU={0:0.##}";
                gridView2.Columns[7].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns[7].SummaryItem.DisplayFormat = "GENEL TOPLAM={0:0.##}";
                gridView2.Columns[8].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns[8].SummaryItem.DisplayFormat = "GENEL TOPLAM={0:0.##}";

                GridGroupSummaryItem yolBoyu = new GridGroupSummaryItem();
                yolBoyu.FieldName = "YOL_BOYU";
                yolBoyu.DisplayFormat = "YOL BOYU={0:0.##}";
                yolBoyu.SummaryType = DevExpress.Data.SummaryItemType.Average;
                yolBoyu.ShowInGroupColumnFooter = gridView2.Columns["YOL_BOYU"];
                gridView2.GroupSummary.Add(yolBoyu);

                GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                boruUzunlugu.ShowInGroupColumnFooter = gridView2.Columns["BORU_UZUNLUGU"];
                gridView2.GroupSummary.Add(boruUzunlugu);

                GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                kaziBoyu.FieldName = "KAZI_BOYU";
                kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                kaziBoyu.ShowInGroupColumnFooter = gridView2.Columns["KAZI_BOYU"];
                gridView2.GroupSummary.Add(kaziBoyu);
            }
            LblDetayBaslik.Text = CmbDetaySirket.Text + " - " + CmbDetayBolge.Text;
            LblTarihAraligi.Text = DtBaslangicTarihi.Text + " - " + DtBitisTarihi.Text;
        }

        private void BtnGenelExcel_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Çelik Boy Kazı Raporu.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnDetayExcel_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Çelik Boy Kazı Detay Raporu.xlsx";
            gridControl2.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnGenelPdf_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Çelik Boy Kazı Raporu.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnDetayPdf_Click(object sender, EventArgs e)
        {
            string yol = "Polietilen Çelik Boy Kazı Raporu.pdf";
            gridControl2.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {
            DtBitisTarihi.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}
