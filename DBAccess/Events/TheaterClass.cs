using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class TheaterClass: EventClass
    {

        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllTheaterPerfomances()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Teatar WHERE Nastan.Id = Teatar.NastanId";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    LinkedList<TeatarIzveduvach> artists = TheaterArtistsInfo(Convert.ToInt32(citac["id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        RegularnaCena = Convert.ToDouble(citac["RegularnaCena"].ToString()),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),
                        Teatar = new Teatar
                        {
                            NastanId= Convert.ToInt32(citac["id"].ToString()),
                            TIp=TheaterTypeInfo(Convert.ToInt32(citac["Id"].ToString())),
                            TeatarIzveduvach=artists
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
        private static LinkedList<TeatarIzveduvach> TheaterArtistsInfo(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM TeatarIzveduvach WHERE TeatarId ='" + id + "'";
            try
            {
                LinkedList<TeatarIzveduvach> artists = new LinkedList<TeatarIzveduvach>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    TeatarIzveduvach ti = new TeatarIzveduvach
                    {
                        Izveduvach=citac["Izveduvach"].ToString(),
                        TeatarId=Convert.ToInt32(citac["TeatarId"].ToString())

                    };
                    artists.AddLast(ti);

                }
                return artists;
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
        private static string TheaterTypeInfo(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Teatar WHERE NastanId ='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    return citac["TIp"].ToString();
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
