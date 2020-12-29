using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KargazImalatTakip
{
    public partial class FrmFittingsHat : Form
    {
        public FrmFittingsHat()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
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
    }
}
