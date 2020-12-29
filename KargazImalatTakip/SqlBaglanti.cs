using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace KargazImalatTakip
{
    class SqlBaglanti
    {
        public SqlConnection kargazBaglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=192.168.0.251;Initial Catalog=KargazHarita;Persist Security Info=True;User ID=sa;Password=Aybs@07!Login");
            baglan.Open();
            return baglan;
        }

        public SqlConnection serhatgazBaglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=192.168.0.251;Initial Catalog=SerhatgazHarita;Persist Security Info=True;User ID=sa;Password=Aybs@07!Login");
            //SqlConnection baglan = new SqlConnection(@"Data Source=LENOVO-PC;Initial Catalog=SerhatgazHarita;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
