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
    public partial class FrmAboOlanKutusuOlmayanBina : Form
    {
        public FrmAboOlanKutusuOlmayanBina()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbŞirket.Text == "KARGAZ")
                {
                    SqlDataAdapter bina = new SqlDataAdapter("SELECT B.MSLINK, BINA_KODU,I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                        "BINA_ADI, DIS_KAPI_NO, KAT_ADEDI, DAIRE_SAYISI, ISYERI_SAYISI, SEKTOR, KULLANIM_TIPI FROM DBO.BINA B " +
                        "LEFT JOIN DBO.YOL Y ON b.yol_kodu = Y.yol_kodu " +
                        "LEFT JOIN DBO.MAHALLE M ON b.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON b.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE BINA_KODU IN (SELECT BinaKod FROM AybsPlusKargaz.dbo.tesisat) " +
                        "AND B.MSLINK NOT IN (SELECT BINA_MSLINK FROM DBO.BINA_SERVISKUTUSU) ORDER BY B.MSLINK", bgl.kargazBaglanti());
                    DataTable dtBina = new DataTable();
                    bina.Fill(dtBina);
                    gridControl1.DataSource = dtBina;

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                }
                else if (CmbŞirket.Text == "SERHATGAZ")
                {
                    SqlDataAdapter bina = new SqlDataAdapter("SELECT B.MSLINK, BINA_KODU,I.ILCE_ADI, M.MAHALLE_ADI AS MAHALLE, Y.YOL_ADI + ' ' + Y.YOL_TIPI AS YOL, " +
                        "BINA_ADI, DIS_KAPI_NO, KAT_ADEDI, DAIRE_SAYISI, ISYERI_SAYISI, SEKTOR, KULLANIM_TIPI FROM DBO.BINA B " +
                        "LEFT JOIN DBO.YOL Y ON b.yol_kodu = Y.yol_kodu " +
                        "LEFT JOIN DBO.MAHALLE M ON b.MAHALLE_KODU = M.MAHALLE_KODU " +
                        "LEFT JOIN DBO.ILCE I ON b.ILCE_KODU = I.ILCE_KODU " +
                        "WHERE BINA_KODU IN (SELECT BinaKod FROM AybsPlusSerhatgaz.dbo.tesisat) " +
                        "AND B.MSLINK NOT IN (SELECT BINA_MSLINK FROM DBO.BINA_SERVISKUTUSU) ORDER BY B.MSLINK", bgl.serhatgazBaglanti());
                    DataTable dtBina = new DataTable();
                    bina.Fill(dtBina);
                    gridControl1.DataSource = dtBina;

                    gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

                }
            }
            catch
            {
                MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcelAktar_Click(object sender, EventArgs e)
        {
            string yol = "Abone Olan Kutu Olmayan Bina Listesi.xlsx";
            gridControl1.ExportToXlsx(yol);
            //Dosyayı direk varsayılan uygulamayla açmak için...
            Process.Start(yol);
        }
    }
}
