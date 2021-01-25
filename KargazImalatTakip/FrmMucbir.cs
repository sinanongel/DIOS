using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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
    public partial class FrmMucbir : Form
    {
        public FrmMucbir()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnMucbirListele_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();

            try
            {
                if (CmbFirma.Text == "KARGAZ")
                {
                    SqlDataAdapter daMucbir = new SqlDataAdapter("SELECT ILCE_ADI, MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + YOL AS YOL_ADI, YOL_BOYU, " +
                        "CASE WHEN[201003] IS NOT NULL THEN[201003] ELSE 0 END[201003], " +
                        "CASE WHEN[201004] IS NOT NULL THEN[201004] ELSE 0 END[201004], " +
                        "CASE WHEN[201005] IS NOT NULL THEN[201005] ELSE 0 END[201005], " +
                        "CASE WHEN[201007] IS NOT NULL THEN[201007] ELSE 0 END[201007], " +
                        "CASE WHEN[201022] IS NOT NULL THEN[201022] ELSE 0 END[201022], " +
                        "CASE WHEN[201023] IS NOT NULL THEN[201023] ELSE 0 END[201023], " +
                        "CASE WHEN[201024] IS NOT NULL THEN[201024] ELSE 0 END[201024], " +
                        "CASE WHEN[201025] IS NOT NULL THEN[201025] ELSE 0 END[201025] " +
                        "FROM(SELECT I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, YOL_MSLINK, YOL_KODU, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, Y.YOL_BOYU AS YOL_BOYU, VARLIK_KODU, " +
                        "ISNULL(SUM(YATAY_ASBUILT_METRAJ), 0) AS TOPMETRAJ FROM HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "GROUP BY I.ILCE_ADI, M.MAHALLE_ADI, YOL_MSLINK, YOL_KODU, Y.YOL_ADI, Y.YOL_TIPI, Y.YOL_BOYU, H.VARLIK_KODU) AS TABLOM " +
                        "PIVOT(SUM(TOPMETRAJ) FOR VARLIK_KODU IN([201003], [201004], [201005], [201007], [201022], [201023], [201024], [201025])) AS PIVOTTABLO " +
                        "ORDER BY YOL_MSLINK", bgl.kargazBaglanti());
                    DataTable dtMucbir = new DataTable();
                    daMucbir.Fill(dtMucbir);
                    gridControl1.DataSource = dtMucbir;

                    //gridView1.Columns["201003"].Width = 37;
                    //gridView1.Columns["201004"].Width = 37;
                    //gridView1.Columns["201005"].Width = 37;
                    //gridView1.Columns["201007"].Width = 37;

                }
                else if (CmbFirma.Text == "SERHATGAZ")
                {
                    SqlDataAdapter daMucbir = new SqlDataAdapter("SELECT ILCE_ADI, MAHALLE, CAST(YOL_KODU AS NVARCHAR) + ' - ' + YOL AS YOL_ADI, YOL_BOYU, " +
                        "CASE WHEN[201003] IS NOT NULL THEN[201003] ELSE 0 END[201003], " +
                        "CASE WHEN[201004] IS NOT NULL THEN[201004] ELSE 0 END[201004], " +
                        "CASE WHEN[201005] IS NOT NULL THEN[201005] ELSE 0 END[201005], " +
                        "CASE WHEN[201007] IS NOT NULL THEN[201007] ELSE 0 END[201007], " +
                        "CASE WHEN[201022] IS NOT NULL THEN[201022] ELSE 0 END[201022], " +
                        "CASE WHEN[201023] IS NOT NULL THEN[201023] ELSE 0 END[201023], " +
                        "CASE WHEN[201024] IS NOT NULL THEN[201024] ELSE 0 END[201024], " +
                        "CASE WHEN[201025] IS NOT NULL THEN[201025] ELSE 0 END[201025] " +
                        "FROM(SELECT I.ILCE_ADI AS ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, YOL_MSLINK, YOL_KODU, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, Y.YOL_BOYU AS YOL_BOYU, VARLIK_KODU, " +
                        "ISNULL(SUM(YATAY_ASBUILT_METRAJ), 0) AS TOPMETRAJ FROM HATLAR H " +
                        "LEFT JOIN DBO.YOL Y ON H.YOL_MSLINK = Y.MSLINK " +
                        "LEFT JOIN DBO.MAHALLE M ON H.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON H.ILCE_KODU = I.ILCE_KODU " +
                        "GROUP BY I.ILCE_ADI, M.MAHALLE_ADI, YOL_MSLINK, YOL_KODU, Y.YOL_ADI, Y.YOL_TIPI, Y.YOL_BOYU, H.VARLIK_KODU) AS TABLOM " +
                        "PIVOT(SUM(TOPMETRAJ) FOR VARLIK_KODU IN([201003], [201004], [201005], [201007], [201022], [201023], [201024], [201025])) AS PIVOTTABLO " +
                        "ORDER BY YOL_MSLINK", bgl.serhatgazBaglanti());
                    DataTable dtMucbir = new DataTable();
                    daMucbir.Fill(dtMucbir);
                    gridControl1.DataSource = dtMucbir;                    
                }

                gridView1.Columns["ILCE_ADI"].Caption = "İL/İLÇE ADI";
                gridView1.Columns["YOL_ADI"].Caption = "YOL";
                gridView1.Columns["YOL_BOYU"].Caption = "YOL BOYU";
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["YOL_BOYU"].DisplayFormat.FormatString = "{0:n2}";

                gridView1.Columns["201003"].Caption = "PE 40";
                gridView1.Columns["201003"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201003"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201003"].AppearanceCell.BackColor = Color.PeachPuff;

                gridView1.Columns["201004"].Caption = "PE 63";
                gridView1.Columns["201004"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201004"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201004"].AppearanceCell.BackColor = Color.PaleGoldenrod;

                gridView1.Columns["201005"].Caption = "PE 90";
                gridView1.Columns["201005"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201005"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201005"].AppearanceCell.BackColor = Color.PaleGreen;

                gridView1.Columns["201007"].Caption = "PE 125";
                gridView1.Columns["201007"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201007"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201007"].AppearanceCell.BackColor = Color.PaleTurquoise;

                gridView1.Columns["201022"].Caption = "TB-40";
                gridView1.Columns["201022"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201022"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201022"].AppearanceCell.BackColor = Color.PeachPuff;

                gridView1.Columns["201023"].Caption = "TB-63";
                gridView1.Columns["201023"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201023"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201023"].AppearanceCell.BackColor = Color.PaleGoldenrod;

                gridView1.Columns["201024"].Caption = "TB-90";
                gridView1.Columns["201024"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201024"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201024"].AppearanceCell.BackColor = Color.PaleGreen;

                gridView1.Columns["201025"].Caption = "TB-125";
                gridView1.Columns["201025"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["201025"].DisplayFormat.FormatString = "{0:n2}";
                gridView1.Columns["201025"].AppearanceCell.BackColor = Color.PaleTurquoise;

                GridColumn farkPe40 = new GridColumn();
                farkPe40.FieldName = "FARK40";
                farkPe40.Caption = "PE40 FARK";
                farkPe40.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                farkPe40.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                farkPe40.AppearanceCell.Options.UseBackColor = true;
                farkPe40.AppearanceCell.BackColor = Color.PeachPuff;
                farkPe40.DisplayFormat.FormatString = "#0.00;(#0.00)";
                farkPe40.UnboundExpression = "[201003] - [201022]";
                gridView1.Columns.Add(farkPe40);
                farkPe40.VisibleIndex = 13;

                GridColumn farkPe63 = new GridColumn();
                farkPe63.FieldName = "FARK63";
                farkPe63.Caption = "PE63 FARK";
                farkPe63.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                farkPe63.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                farkPe63.AppearanceCell.Options.UseBackColor = true;
                farkPe63.AppearanceCell.BackColor = Color.PaleGoldenrod;
                farkPe63.DisplayFormat.FormatString = "#0.00;(#0.00)";
                farkPe63.UnboundExpression = "[201004] - [201023]";
                gridView1.Columns.Add(farkPe63);
                farkPe63.VisibleIndex = 14;

                GridColumn farkPe90 = new GridColumn();
                farkPe90.FieldName = "FARK90";
                farkPe90.Caption = "PE90 FARK";
                farkPe90.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                farkPe90.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                farkPe90.AppearanceCell.Options.UseBackColor = true;
                farkPe90.AppearanceCell.BackColor = Color.PaleGreen;
                farkPe90.DisplayFormat.FormatString = "#0.00;(#0.00)";
                farkPe90.UnboundExpression = "[201005] - [201024]";
                gridView1.Columns.Add(farkPe90);
                farkPe90.VisibleIndex = 15;

                GridColumn farkPe125 = new GridColumn();
                farkPe125.FieldName = "FARK125";
                farkPe125.Caption = "PE125 FARK";
                farkPe125.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                farkPe125.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                farkPe125.AppearanceCell.Options.UseBackColor = true;
                farkPe125.AppearanceCell.BackColor = Color.PaleTurquoise;
                farkPe125.DisplayFormat.FormatString = "#0.00;(#0.00)";
                farkPe125.UnboundExpression = "[201007] - [201025]";
                gridView1.Columns.Add(farkPe125);
                farkPe125.VisibleIndex = 16;

                GridGroupSummaryItem pe40 = new GridGroupSummaryItem();
                pe40.FieldName = "201003";
                pe40.DisplayFormat = "TOPLAM={0:0.##}";
                pe40.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                pe40.ShowInGroupColumnFooter = gridView1.Columns["201003"];
                gridView1.GroupSummary.Add(pe40);

                GridGroupSummaryItem pe63 = new GridGroupSummaryItem();
                pe63.FieldName = "201004";
                pe63.DisplayFormat = "TOPLAM={0:0.##}";
                pe63.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                pe63.ShowInGroupColumnFooter = gridView1.Columns["201004"];
                gridView1.GroupSummary.Add(pe63);

                GridGroupSummaryItem pe90 = new GridGroupSummaryItem();
                pe90.FieldName = "201005";
                pe90.DisplayFormat = "TOPLAM={0:0.##}";
                pe90.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                pe90.ShowInGroupColumnFooter = gridView1.Columns["201005"];
                gridView1.GroupSummary.Add(pe90);

                GridGroupSummaryItem pe125 = new GridGroupSummaryItem();
                pe125.FieldName = "201007";
                pe125.DisplayFormat = "TOPLAM={0:0.##}";
                pe125.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                pe125.ShowInGroupColumnFooter = gridView1.Columns["201007"];
                gridView1.GroupSummary.Add(pe125);

                GridGroupSummaryItem tb40 = new GridGroupSummaryItem();
                tb40.FieldName = "201022";
                tb40.DisplayFormat = "TOPLAM={0:0.##}";
                tb40.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                tb40.ShowInGroupColumnFooter = gridView1.Columns["201022"];
                gridView1.GroupSummary.Add(tb40);

                GridGroupSummaryItem tb63 = new GridGroupSummaryItem();
                tb63.FieldName = "201023";
                tb63.DisplayFormat = "TOPLAM={0:0.##}";
                tb63.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                tb63.ShowInGroupColumnFooter = gridView1.Columns["201023"];
                gridView1.GroupSummary.Add(tb63);

                GridGroupSummaryItem tb90 = new GridGroupSummaryItem();
                tb90.FieldName = "201024";
                tb90.DisplayFormat = "TOPLAM={0:0.##}";
                tb90.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                tb90.ShowInGroupColumnFooter = gridView1.Columns["201024"];
                gridView1.GroupSummary.Add(tb90);

                GridGroupSummaryItem tb125 = new GridGroupSummaryItem();
                tb125.FieldName = "201025";
                tb125.DisplayFormat = "TOPLAM={0:0.##}";
                tb125.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                tb125.ShowInGroupColumnFooter = gridView1.Columns["201025"];
                gridView1.GroupSummary.Add(tb125);

                GridGroupSummaryItem fark40 = new GridGroupSummaryItem();
                fark40.FieldName = "FARK40";
                fark40.DisplayFormat = "FARK={0:0.##;(00.##)}";
                fark40.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                fark40.ShowInGroupColumnFooter = gridView1.Columns["FARK40"];
                gridView1.GroupSummary.Add(fark40);

                GridGroupSummaryItem fark63 = new GridGroupSummaryItem();
                fark63.FieldName = "FARK63";
                fark63.DisplayFormat = "FARK={0:0.##;(00.##)}";
                fark63.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                fark63.ShowInGroupColumnFooter = gridView1.Columns["FARK63"];
                gridView1.GroupSummary.Add(fark63);

                GridGroupSummaryItem fark90 = new GridGroupSummaryItem();
                fark90.FieldName = "FARK90";
                fark90.DisplayFormat = "FARK={0:0.##;(00.##)}";
                fark90.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                fark90.ShowInGroupColumnFooter = gridView1.Columns["FARK90"];
                gridView1.GroupSummary.Add(fark90);

                GridGroupSummaryItem fark125 = new GridGroupSummaryItem();
                fark125.FieldName = "FARK125";
                fark125.DisplayFormat = "FARK={0:0.##;(00.##)}";
                fark125.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                fark125.ShowInGroupColumnFooter = gridView1.Columns["FARK125"];
                gridView1.GroupSummary.Add(fark125);
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            string yol = "Mücbir.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            string yol = "Mücbir.pdf";
            gridControl1.ExportToPdf(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
}
