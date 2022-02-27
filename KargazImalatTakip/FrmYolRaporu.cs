using DevExpress.Utils;
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
    public partial class FrmYolRaporu : Form
    {
        public FrmYolRaporu()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        public string yetkiGrup;

        private void BtnListele_Click(object sender, EventArgs e)
        {

            {
                gridView1.Columns.Clear();

                //try
                //{
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Y.MSLINK, I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, " +
                        "Cast(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, YOL_BOYU FROM DBO.YOL Y " +
                        "LEFT JOIN DBO.ILCE I ON Y.ILCE_KODU = I.ILCE_KODU " +
                        "LEFT JOIN DBO.YOL_MAHALLE YM ON Y.MSLINK = YM.YOL_MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON YM.MAHALLE_MSLINK = M.MSLINK " +
                        "ORDER BY I.ILCE_ADI, M.MAHALLE_ADI, Y.YOL_ADI", bgl.kargazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Y.MSLINK, I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, " +
                        "Cast(YOL_KODU AS NVARCHAR) + ' - ' + Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, YOL_BOYU FROM DBO.YOL Y " +
                        "LEFT JOIN DBO.ILCE I ON Y.ILCE_KODU = I.ILCE_KODU " +
                        "LEFT JOIN DBO.YOL_MAHALLE YM ON Y.MSLINK = YM.YOL_MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON YM.MAHALLE_MSLINK = M.MSLINK " +
                        "ORDER BY I.ILCE_ADI, M.MAHALLE_ADI, Y.YOL_ADI", bgl.serhatgazBaglanti());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatString = "{0:n2}";

                gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.Columns[0].SummaryItem.DisplayFormat = "{0:0.##} ADET";
                //gridView1.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[6].SummaryItem.DisplayFormat = "{0:0.##}";
                //gridView1.Columns[15].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[15].SummaryItem.DisplayFormat = "{0:0.##}";
                //gridView1.Columns[16].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[16].SummaryItem.DisplayFormat = "{0:0.##}";
                //gridView1.Columns[17].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[17].SummaryItem.DisplayFormat = "{0:0.##}";
                //gridView1.Columns[18].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //gridView1.Columns[18].SummaryItem.DisplayFormat = "{0:0.##}";

                //GridGroupSummaryItem boruUzunlugu = new GridGroupSummaryItem();
                //boruUzunlugu.FieldName = "BORU_UZUNLUGU";
                //boruUzunlugu.DisplayFormat = "TOPLAM={0:0.##}";
                //boruUzunlugu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //boruUzunlugu.ShowInGroupColumnFooter = gridView1.Columns["BORU_UZUNLUGU"];
                //gridView1.GroupSummary.Add(boruUzunlugu);

                //GridGroupSummaryItem yatayAsbuiltMetraj = new GridGroupSummaryItem();
                //yatayAsbuiltMetraj.FieldName = "YATAY_ASBUILT_METRAJ";
                //yatayAsbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                //yatayAsbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //yatayAsbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["YATAY_ASBUILT_METRAJ"];
                //gridView1.GroupSummary.Add(yatayAsbuiltMetraj);

                //GridGroupSummaryItem asbuiltMetraj = new GridGroupSummaryItem();
                //asbuiltMetraj.FieldName = "ASBUILT_METRAJ";
                //asbuiltMetraj.DisplayFormat = "TOPLAM={0:0.##}";
                //asbuiltMetraj.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //asbuiltMetraj.ShowInGroupColumnFooter = gridView1.Columns["ASBUILT_METRAJ"];
                //gridView1.GroupSummary.Add(asbuiltMetraj);

                //GridGroupSummaryItem kaziBoyu = new GridGroupSummaryItem();
                //kaziBoyu.FieldName = "KAZI_BOYU";
                //kaziBoyu.DisplayFormat = "TOPLAM={0:0.##}";
                //kaziBoyu.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //kaziBoyu.ShowInGroupColumnFooter = gridView1.Columns["KAZI_BOYU"];
                //gridView1.GroupSummary.Add(kaziBoyu);


                //}
                //catch
                //{
                //    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            string yol = "Yol Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için.
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Yol Listesi.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için.
            Process.Start(yol);
        }
    }
}
