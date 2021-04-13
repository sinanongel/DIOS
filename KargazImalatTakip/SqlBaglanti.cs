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
            baglantiAdresi = satir[0]; //KargazHarita sunucu bağlatısı
            //baglantiAdresi = satir[2]; //KargazHarita localhost bağlatısı

            SqlConnection baglan = new SqlConnection(baglantiAdresi);

            //SqlConnection baglan = new SqlConnection(@"Data Source=192.168.0.251;Initial Catalog=KargazHarita;Persist Security Info=True;User ID=sa;Password=Aybs@07!Login");
            //SqlConnection baglan = new SqlConnection(@"Data Source=SONGEL;Initial Catalog=KargazHarita;Integrated Security=True; ");

            baglan.Open();
            return baglan;
        }

        public SqlConnection serhatgazBaglanti()
        {
            string[] satir = File.ReadAllLines("C:\\SqlBaglanti.txt");
            baglantiAdresi = satir[1]; //SerhatHarita sunucu bağlatısı
            //baglantiAdresi = satir[3]; //SerhatHarita localhost bağlatısı

            SqlConnection baglan = new SqlConnection(baglantiAdresi);

            //SqlConnection baglan = new SqlConnection(@"Data Source=192.168.0.251;Initial Catalog=SerhatgazHarita;Persist Security Info=True;User ID=sa;Password=Aybs@07!Login");
            //SqlConnection baglan = new SqlConnection(@"Data Source=SONGEL;Initial Catalog=SerhatgazHarita;Integrated Security=True; User ID=SONGEL\harita5");

            baglan.Open();
            return baglan;
        }
        public 
    }
}
