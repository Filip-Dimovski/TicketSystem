using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class CinemaClass: EventClass
    {
        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllCinemaEvents()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Kino WHERE Nastan.Id = Kino.NastanId";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    LinkedList<KinoAkter> actors = ActorsInfo(Convert.ToInt32(citac["id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        RegularnaCena = Convert.ToDouble(citac["RegularnaCena"].ToString()),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),
                        Kino=new Kino
                        {
                            NastanId= Convert.ToInt32(citac["id"].ToString()),
                            KinoAkter=actors,
                            Tip=CinemaType(Convert.ToInt32(citac["id"].ToString()))
                        }

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
        private static LinkedList<KinoAkter> ActorsInfo(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM KinoAkter WHERE KinoId ='" + id + "'";
            try
            {
                LinkedList<KinoAkter> actors = new LinkedList<KinoAkter>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    KinoAkter ka = new KinoAkter
                    {
                        KinoId=id,
                        Akter=citac["Akter"].ToString(),
                    };
                    actors.AddLast(ka);

                }
                return actors;
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
        private static string CinemaType(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Kino WHERE NastanId ='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    return citac["Tip"].ToString();
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
    }
}
