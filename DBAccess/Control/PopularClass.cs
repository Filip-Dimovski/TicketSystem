using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class PopularClass:ControlClass
    {
        public static List<Nastan> AllConcerts()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Koncert WHERE Nastan.Id = Koncert.NastanId";
            try
            {
                List<Nastan> concerts = new List<Nastan>();
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

                        Koncert = new Koncert
                        {
                            NastanId = Convert.ToInt32(citac["Id"].ToString()),
                        },

                    };
                    concerts.Add(n);
                }
                return concerts;
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

        public static List<Nastan> AllMovies()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Kino WHERE Nastan.Id = Kino.NastanId";
            try
            {
                List<Nastan> movies = new List<Nastan>();
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
                    movies.Add(n);
                }
                return movies;
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


        public static List<Nastan> AllSports()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Sport WHERE Nastan.Id = Sport.NastanId";
            try
            {
                List<Nastan> sports = new List<Nastan>();
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
                    sports.Add(n);
                }
                return sports;
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
    public static List<Nastan> AllTheaters()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Teatar WHERE Nastan.Id = Teatar.NastanId";
            try
            {
                List<Nastan> theaters = new List<Nastan>();
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
                    theaters.Add(n);
                }
                return theaters;
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
