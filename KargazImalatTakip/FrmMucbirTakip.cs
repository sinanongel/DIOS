using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmMucbirTakip : Form
    {
        public FrmMucbirTakip()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnMucbirListele_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbFirma.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT H.MSLINK, I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, Y.MSLINK AS YOL_MSLINK, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YATIRIMYILI, FORMNO,  H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU FROM dbo.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE H.MALZEME_CINSI = 'Polietilen' ORDER BY H.MSLINK", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    //gridView1.OptionsView.ShowViewCaption = true;
                    //gridView1.ViewCaption = CmbFirma.Text + " MÜCBİR TAKİP";

                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["YOL_MSLINK"].Caption = "YOL MSLINK";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                    gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                    gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[0].SummaryItem.DisplayFormat = "TOPLAM ADET={0:0}";
                    gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[9].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[10].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";

                    GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                    boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                    boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                    boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORU_UZUNLUGU"];
                    gridView1.GroupSummary.Add(boruUzunlugu);

                    GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
                    yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
                    yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                    yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
                    gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

                    GridGroupSummaryItem asbuiltMetraj = new GridGroupSummaryItem();
                    asbuiltMetraj.FieldName = "ASBUILT_METRAJ";
                    asbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                    asbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    asbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["ASBUILT_METRAJ"];
                    gridView1.GroupSummary.Add(asbuiltMetraj);

                    GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                    kaziBoyu.FieldName = "KAZI_BOYU";
                    kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                    kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZI_BOYU"];
                    gridView1.GroupSummary.Add(kaziBoyu);
                }
                else if (CmbFirma.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT H.MSLINK, I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, Y.MSLINK AS YOL_MSLINK, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                            "YATIRIMYILI, FORMNO,  H.SEKTOR, NET_BORU_CAPI, BORU_UZUNLUGU, YATAY_ASBUILT_METRAJ, ASBUILT_METRAJ, KAZI_BOYU FROM dbo.HATLAR H " +
                            "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                            "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                            "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                            "WHERE H.MALZEME_CINSI = 'Polietilen' ORDER BY H.MSLINK DESC", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    gridView1.Columns["SEKTOR"].Caption = "SEKTÖR";
                    gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                    gridView1.Columns["YATIRIMYILI"].Caption = "YATIRIM YILI";
                    gridView1.Columns["YOL_MSLINK"].Caption = "YOL MSLINK";
                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["NET_BORU_CAPI"].Caption = "BORU ÇAPI";
                    gridView1.Columns["BORU_UZUNLUGU"].Caption = "FORM METRAJI";
                    gridView1.Columns["YATAY_ASBUILT_METRAJ"].Caption = "YATAY ASBUILT METRAJ";
                    gridView1.Columns["ASBUILT_METRAJ"].Caption = "ASBUILT METRAJ";
                    gridView1.Columns["KAZI_BOYU"].Caption = "KAZI BOYU";

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.Columns[0].SummaryItem.DisplayFormat = "TOPLAM ADET={0:0}";
                    gridView1.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[9].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";
                    gridView1.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[10].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";
                    gridView1.Columns[11].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[11].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";
                    gridView1.Columns[12].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[12].SummaryItem.DisplayFormat = "TOPLAM={0:0.##}";

                    GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                    boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                    boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                    boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORU_UZUNLUGU"];
                    gridView1.GroupSummary.Add(boruUzunlugu);

                    GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
                    yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
                    yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                    yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
                    gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

                    GridGroupSummaryItem asbuiltMetraj = new GridGroupSummaryItem();
                    asbuiltMetraj.FieldName = "ASBUILT_METRAJ";
                    asbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                    asbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    asbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["ASBUILT_METRAJ"];
                    gridView1.GroupSummary.Add(asbuiltMetraj);

                    GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                    kaziBoyu.FieldName = "KAZI_BOYU";
                    kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                    kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZI_BOYU"];
                    gridView1.GroupSummary.Add(kaziBoyu);
                }
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            string yol = "Mücbir Rapor.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Mücbir Raporu.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
}
