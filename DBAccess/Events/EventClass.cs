using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
   public  class EventClass
    {
       protected static string connectionString = "Data Source=FILIP-PC\\SQLEXPRESS;initial Catalog=Ticket;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected static List<NastanOdrzhuvanje> allEvents(int id)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM NastanOdrzhuvanje WHERE NastanId='" + id + "'";
            try
            {
                konekcija.Open();
                List<NastanOdrzhuvanje> nastani = new List<NastanOdrzhuvanje>();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    NastanOdrzhuvanje no = new NastanOdrzhuvanje
                    {
                        NastanId = Convert.ToInt32((citac["NastanId"].ToString())),
                        Lokacija = citac["Lokacija"].ToString(),
                        VremeOdrzhuvanje = Convert.ToDateTime(citac["VremeOdrzhuvanje"].ToString()),
                        SlobodniMesta = Convert.ToInt32(citac["SlobodniMesta"].ToString()),
                        Cena = Convert.ToDouble(citac["Cena"].ToString())
                    };
                    nastani.Add(no);

                }
                return nastani;

            }
            catch (Exception)
            {
            }
            finally
            {
                konekcija.Close();
            }
            return null;
        }
    }
}
