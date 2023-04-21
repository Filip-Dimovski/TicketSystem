using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public  class ConcertClass: EventClass
    {
        
        public static Dictionary<Nastan,List<NastanOdrzhuvanje>> AllConcerts()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Koncert WHERE Nastan.Id = Koncert.NastanId";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while(citac.Read())
                {
                    LinkedList<KoncertPejac> kp = concertSingers(Convert.ToInt32(citac["id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id= Convert.ToInt32(citac["id"].ToString()),
                        Slika=citac["Slika"].ToString(),
                        RegularnaCena=Convert.ToDouble(citac["RegularnaCena"].ToString()),
                        Ime=citac["Ime"].ToString(),
                        Opis=citac["Opis"].ToString(),
                        
                          Koncert = new Koncert
                        {
                            NastanId = Convert.ToInt32(citac["Id"].ToString()),
                            KoncertPejac=kp,
                        },
                        
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
        private static LinkedList<KoncertPejac> concertSingers(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM KoncertPejac WHERE KoncertId='" + id + "'";
            try
            {
                konekcija.Open();
                LinkedList<KoncertPejac> pejachi = new LinkedList<KoncertPejac>();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    KoncertPejac kp = new KoncertPejac
                    {
                        KoncertId = Convert.ToInt32(citac["KoncertId"].ToString()),
                        Pejach = citac["Pejach"].ToString()
                    };
                    pejachi.AddLast(kp);
                    
                }
                return pejachi;

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
