using System.Data.SqlClient;
using System.IO;

namespace KargazImalatTakip
{
    class SqlBaglanti
    {
        string baglantiAdresi;
        public SqlConnection kargazBaglanti()
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");
            baglantiAdresi = satir[3]; //KargazHarita sunucu bağlatısı
            //baglantiAdresi = satir[5]; //KargazHarita localhost bağlatısı

            SqlConnection baglan = new SqlConnection(baglantiAdresi);

            baglan.Open();
            return baglan;
        }

        public SqlConnection serhatgazBaglanti()
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");
            baglantiAdresi = satir[4]; //SerhatHarita sunucu bağlatısı
            //baglantiAdresi = satir[6]; //SerhatHarita localhost bağlatısı

            SqlConnection baglan = new SqlConnection(baglantiAdresi);

            baglan.Open();
            return baglan;
        }
    }
}
