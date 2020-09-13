using System;
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
    public partial class FrmTumImalat : Form
    {
        public FrmTumImalat()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            if (CmbŞirket.Text == "KARGAZ")
            {
                try
                {
                    SqlDataAdapter daForm = new SqlDataAdapter("SELECT * FROM (SELECT FORMNO, VARLIK_KODU, SUM(BORU_UZUNLUGU) AS MALZTOP FROM [KargazHarita].[dbo].[HATLAR] GROUP BY FORMNO, VARLIK_KODU UNION SELECT FORMNO, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[KargazHarita].[dbo].[BAGLANTI_ELEMANLARI_PE] GROUP BY FORMNO, VARLIK_KODU UNION SELECT FORMNO, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[KargazHarita].[dbo].[VANA] GROUP BY FORMNO, VARLIK_KODU) AS TABLOM PIVOT (SUM(MALZTOP) FOR VARLIK_KODU IN([201003], [201004], [201005], [201007], [202003], [202004], [202005], [202007], [207008], [207011], [207007], [207012], [203023], [203014], [203024], [203015], [208008], [208001], [208007], [208002], [206014], [206015], [206017], [206023], [203021])) AS PIVOTTABLO", bgl.kargazBaglanti());
                    DataTable dtForm = new DataTable();
                    daForm.Fill(dtForm);
                    GrCoForm.DataSource = dtForm;

                    gridView1.Columns["FORMNO"].Visible = false;

                    gridView1.Columns["201003"].Caption = "PE 40";
                    gridView1.Columns["201004"].Caption = "PE 63";
                    gridView1.Columns["201005"].Caption = "PE 90";
                    gridView1.Columns["201007"].Caption = "PE 125";
                    gridView1.Columns["202003"].Caption = "Ø40 MANŞON";
                    gridView1.Columns["202004"].Caption = "Ø63 MANŞON";
                    gridView1.Columns["202005"].Caption = "Ø90 MANŞON";
                    gridView1.Columns["202007"].Caption = "Ø125 MANŞON";
                    gridView1.Columns["207008"].Caption = "Ø40 KEP";
                    gridView1.Columns["207011"].Caption = "Ø63 KEP";
                    gridView1.Columns["207007"].Caption = "Ø90 KEP";
                    gridView1.Columns["207012"].Caption = "Ø125 KEP";
                    gridView1.Columns["203023"].Caption = "Ø40 TEE";
                    gridView1.Columns["203014"].Caption = "Ø63 TEE";
                    gridView1.Columns["203024"].Caption = "Ø90 TEE";
                    gridView1.Columns["203015"].Caption = "Ø125 TEE";
                    gridView1.Columns["208008"].Caption = "Ø40 VANA";
                    gridView1.Columns["208001"].Caption = "Ø63 VANA";
                    gridView1.Columns["208007"].Caption = "Ø90 VANA";
                    gridView1.Columns["208002"].Caption = "Ø125 VANA";
                    gridView1.Columns["206014"].Caption = "Ø63X40 REDÜKSİYON";
                    gridView1.Columns["206015"].Caption = "Ø90X63 REDÜKSİYON";
                    gridView1.Columns["206017"].Caption = "Ø125X63 REDÜKSİYON";
                    gridView1.Columns["206023"].Caption = "Ø125X90 REDÜKSİYON";
                    gridView1.Columns["203021"].Caption = "Ø63X63X40 REDÜKSİYON";

                    gridView1.Columns["201003"].Width = 37;
                    gridView1.Columns["201004"].Width = 37;
                    gridView1.Columns["201005"].Width = 37;
                    gridView1.Columns["201007"].Width = 37;
                    gridView1.Columns["202003"].Width = 70;
                    gridView1.Columns["202004"].Width = 70;
                    gridView1.Columns["202005"].Width = 70;
                    gridView1.Columns["202007"].Width = 70;
                    gridView1.Columns["207008"].Width = 50;
                    gridView1.Columns["207011"].Width = 50;
                    gridView1.Columns["207007"].Width = 50;
                    gridView1.Columns["207012"].Width = 50;
                    gridView1.Columns["203023"].Width = 50;
                    gridView1.Columns["203014"].Width = 50;
                    gridView1.Columns["203024"].Width = 50;
                    gridView1.Columns["203015"].Width = 50;
                    gridView1.Columns["208008"].Width = 55;
                    gridView1.Columns["208001"].Width = 55;
                    gridView1.Columns["208007"].Width = 55;
                    gridView1.Columns["208002"].Width = 55;
                    gridView1.Columns["206014"].Width = 100;
                    gridView1.Columns["206015"].Width = 100;
                    gridView1.Columns["206017"].Width = 100;
                    gridView1.Columns["206023"].Width = 100;
                    gridView1.Columns["203021"].Width = 100;
                }
                catch
                {
                    MessageBox.Show("Veri tabanına bağlanılamıyor, lütfen internet bağlantınızı kontrol ediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (CmbŞirket.Text == "SERHATGAZ")
            {
                try
                {
                    SqlDataAdapter daForm = new SqlDataAdapter("SELECT * FROM (SELECT FORMNO, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, VARLIK_KODU, SUM(BORU_UZUNLUGU) AS MALZTOP FROM [SerhatgazHarita].[dbo].[HATLAR] WHERE MALZEME_CINSI='Polietilen' GROUP BY FORMNO, IMALAT_TARIHI, VARLIK_KODU UNION SELECT FORMNO, convert(varchar, IMALATTARIHI, 104) AS IMALAT_TARIHI, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[SerhatgazHarita].[dbo].[BAGLANTI_ELEMANLARI_PE] WHERE FORMNO NOT LIKE 'S%' GROUP BY FORMNO, IMALATTARIHI, VARLIK_KODU UNION SELECT FORMNO, convert(varchar, IMALAT_TARIHI, 104) AS IMALAT_TARIHI, VARLIK_KODU, COUNT(VARLIK_KODU) AS MALZTOP FROM[SerhatgazHarita].[dbo].[VANA] WHERE FORMNO NOT LIKE 'C%' GROUP BY FORMNO, IMALAT_TARIHI, VARLIK_KODU) AS TABLOM PIVOT (SUM(MALZTOP) FOR VARLIK_KODU IN([201003], [201004], [201005], [201007], [202003], [202004], [202005], [202007], [299006], [299004], [299005], [207008], [207011], [207007], [207012], [203023], [203014], [203024], [203015], [208008], [208001], [208007], [208002], [206014], [206015], [206017], [206023], [203021])) AS PIVOTTABLO", bgl.serhatgazBaglanti());
                    DataTable dtForm = new DataTable();
                    daForm.Fill(dtForm);
                    GrCoForm.DataSource = dtForm;

                    gridView1.Columns["FORMNO"].Caption = "FORM NO";
                    gridView1.Columns["IMALAT_TARIHI"].Caption = "İMALAT TARİHİ";
                    gridView1.Columns["201003"].Caption = "PE 40";
                    gridView1.Columns["201004"].Caption = "PE 63";
                    gridView1.Columns["201005"].Caption = "PE 90";
                    gridView1.Columns["201007"].Caption = "PE 125";
                    gridView1.Columns["202003"].Caption = "Ø40 MANŞON";
                    gridView1.Columns["202004"].Caption = "Ø63 MANŞON";
                    gridView1.Columns["202005"].Caption = "Ø90 MANŞON";
                    gridView1.Columns["202007"].Caption = "Ø125 MANŞON";
                    gridView1.Columns["299006"].Caption = "Ø40 TAMİR MANŞON";
                    gridView1.Columns["299004"].Caption = "Ø63 TAMİR MANŞON";
                    gridView1.Columns["299005"].Caption = "Ø125 TAMİR MANŞON";
                    gridView1.Columns["207008"].Caption = "Ø40 KEP";
                    gridView1.Columns["207011"].Caption = "Ø63 KEP";
                    gridView1.Columns["207007"].Caption = "Ø90 KEP";
                    gridView1.Columns["207012"].Caption = "Ø125 KEP";
                    gridView1.Columns["203023"].Caption = "Ø40 TEE";
                    gridView1.Columns["203014"].Caption = "Ø63 TEE";
                    gridView1.Columns["203024"].Caption = "Ø90 TEE";
                    gridView1.Columns["203015"].Caption = "Ø125 TEE";
                    gridView1.Columns["208008"].Caption = "Ø40 VANA";
                    gridView1.Columns["208001"].Caption = "Ø63 VANA";
                    gridView1.Columns["208007"].Caption = "Ø90 VANA";
                    gridView1.Columns["208002"].Caption = "Ø125 VANA";
                    gridView1.Columns["206014"].Caption = "Ø63X40 REDÜKSİYON";
                    gridView1.Columns["206015"].Caption = "Ø90X63 REDÜKSİYON";
                    gridView1.Columns["206017"].Caption = "Ø125X63 REDÜKSİYON";
                    gridView1.Columns["206023"].Caption = "Ø125X90 REDÜKSİYON";
                    gridView1.Columns["203021"].Caption = "Ø63X63X40 REDÜKSİYON";

                    gridView1.Columns["FORMNO"].Width = 37;
                    gridView1.Columns["201003"].Width = 37;
                    gridView1.Columns["201004"].Width = 37;
                    gridView1.Columns["201005"].Width = 37;
                    gridView1.Columns["201007"].Width = 37;
                    gridView1.Columns["202003"].Width = 70;
                    gridView1.Columns["202004"].Width = 70;
                    gridView1.Columns["202005"].Width = 70;
                    gridView1.Columns["202007"].Width = 70;
                    gridView1.Columns["207008"].Width = 50;
                    gridView1.Columns["207011"].Width = 50;
                    gridView1.Columns["207007"].Width = 50;
                    gridView1.Columns["207012"].Width = 50;
                    gridView1.Columns["203023"].Width = 50;
                    gridView1.Columns["203014"].Width = 50;
                    gridView1.Columns["203024"].Width = 50;
                    gridView1.Columns["203015"].Width = 50;
                    gridView1.Columns["208008"].Width = 55;
                    gridView1.Columns["208001"].Width = 55;
                    gridView1.Columns["208007"].Width = 55;
                    gridView1.Columns["208002"].Width = 55;
                    gridView1.Columns["206014"].Width = 100;
                    gridView1.Columns["206015"].Width = 100;
                    gridView1.Columns["206017"].Width = 100;
                    gridView1.Columns["206023"].Width = 100;
                    gridView1.Columns["203021"].Width = 100;
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

        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            //if (e.Column.FieldName == "IMALAT_TARIHI")
            //{
            //    e.Handled = true;
            //    int month1 = Convert.ToDateTime(e.Value1).Month;
            //    int month2 = Convert.ToDateTime(e.Value2).Month;
            //    if (month1 > month2)
            //        e.Result = 1;
            //    else
            //        if (month1 < month2)
            //        e.Result = -1;
            //    else e.Result = System.Collections.Comparer.Default.Compare(Convert.ToDateTime(e.Value1).Day, Convert.ToDateTime(e.Value2).Day);
            //}
        }
    }
}
