using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class NearMeClass: ControlClass
    {
        public static string FindLocation(string userId)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Korisnik WHERE Id='" + userId + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    return citac["Drzhava"].ToString();
                }
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

        public static Dictionary<NastanOdrzhuvanje,Nastan> FindEvents(string country)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM NastanOdrzhuvanje WHERE Lokacija LIKE'%" + country + "%'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                Dictionary<NastanOdrzhuvanje,Nastan> events = new Dictionary<NastanOdrzhuvanje, Nastan>();
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
                    events.Add(no,eventInfo((citac["NastanId"].ToString())));
                }
                return events;
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
