using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmSokakBinaDetay : Form
    {
        public FrmSokakBinaDetay()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        public string firma;
        public string bolge;
        public string mahalle;
        public string sokak;

        private void FrmSokakBinaDetay_Load(object sender, EventArgs e)
        {
            LblFirma.Text = firma;
            LblBolge.Text = bolge;
            LblMahalle.Text = mahalle;
            LblSokak.Text = sokak;

            string yolKodu = sokak.Substring(0, 5);

            if (LblFirma.Text == "KARGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT B.BINA_KODU AS BINAKOD, B.BINA_ADI AS BINAAD, B.DIS_KAPI_NO AS DISKAPINO, " +
                    "B.DAIRE_SAYISI AS DAIRESAYISI, BS.SERVISKUTUSU_MSLINK AS KUTUMSLINK FROM DBO.BINA B " +
                    "LEFT JOIN DBO.YOL Y ON B.YOL_KODU = Y.YOL_KODU " +
                    "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "LEFT JOIN DBO.BINA_SERVISKUTUSU BS ON BS.BINA_MSLINK = B.MSLINK " +
                    "WHERE B.YOL_KODU=" + yolKodu +
                    "GROUP BY B.BINA_KODU, B.BINA_ADI, B.DIS_KAPI_NO, B.DAIRE_SAYISI, BS.SERVISKUTUSU_MSLINK ORDER BY B.BINA_KODU", bgl.kargazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            else if (LblFirma.Text == "SERHATGAZ")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT B.BINA_KODU, B.DIS_KAPI_NO, B.DAIRE_SAYISI, BS.SERVISKUTUSU_MSLINK AS KUTU_MSLINK FROM DBO.BINA B " +
                    "LEFT JOIN DBO.YOL Y ON B.YOL_KODU = Y.YOL_KODU " +
                    "LEFT JOIN DBO.MAHALLE M ON B.MAHALLE_KODU = M.MAHALLE_KODU " +
                    "LEFT JOIN DBO.ILCE I ON B.ILCE_KODU = I.ILCE_KODU " +
                    "LEFT JOIN DBO.BINA_SERVISKUTUSU BS ON BS.BINA_MSLINK = B.MSLINK " +
                    "WHERE B.YOL_KODU=" + yolKodu +
                    "GROUP BY B.BINA_KODU, B.DIS_KAPI_NO, B.DAIRE_SAYISI, BS.SERVISKUTUSU_MSLINK ORDER BY B.BINA_KODU", bgl.serhatgazBaglanti());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }

            gridView1.Columns["BINAKOD"].Caption = "BİNA KODU";
            gridView1.Columns["BINAAD"].Caption = "BİNA ADI";
            gridView1.Columns["DISKAPINO"].Caption = "DIŞ KAPI NO";
            gridView1.Columns["DAIRESAYISI"].Caption = "DAİRE SAYISI";
            gridView1.Columns["KUTUMSLINK"].Caption = "KUTU MSLINK";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "{0} adet bulundu...";

            gridView1.Columns["DISKAPINO"].AppearanceCell.BackColor = Color.PeachPuff;
            gridView1.Columns["DAIRESAYISI"].AppearanceCell.BackColor = Color.PaleGoldenrod;
            gridView1.Columns["KUTUMSLINK"].AppearanceCell.BackColor = Color.PaleGreen;
        }
    }
}
