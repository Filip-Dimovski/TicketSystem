using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class ZooClass:EventClass
    {
        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllZooEvents()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Zooloshka WHERE Nastan.Id = Zooloshka.NastanId";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        RegularnaCena = Convert.ToDouble(citac["RegularnaCena"].ToString()),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),
                    };
                    events.Add(n, allEvents(n.Id));
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
