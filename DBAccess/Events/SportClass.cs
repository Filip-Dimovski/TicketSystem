using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class SportClass : EventClass
    {
       
        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllFootbalMatches()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Sport WHERE Nastan.Id = Sport.NastanId AND Sport.Tip='Football'";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Sport s = SportInfo(Convert.ToInt32(citac["Id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),

                        Sport = new Sport
                        {
                            NastanId = Convert.ToInt32(citac["id"].ToString()),
                            Tip = s.Tip,
                            Tim = TeamInfo(s.DomashenTimId ?? default(int)),
                            Tim1 = TeamInfo(s.GostinskiTimId ?? default(int)),
                            DomashenTimId = s.DomashenTimId,
                            GostinskiTimId = s.GostinskiTimId
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

        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllBasketballMatches()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Sport WHERE Nastan.Id = Sport.NastanId AND Sport.Tip='Basketball'";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Sport s = SportInfo(Convert.ToInt32(citac["Id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),

                        Sport = new Sport
                        {
                            NastanId = Convert.ToInt32(citac["id"].ToString()),
                            Tip = s.Tip,
                            Tim = TeamInfo(s.DomashenTimId ?? default(int)),
                            Tim1 = TeamInfo(s.GostinskiTimId ?? default(int)),
                            DomashenTimId = s.DomashenTimId,
                            GostinskiTimId = s.GostinskiTimId
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

        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllBaseballMatches()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Sport WHERE Nastan.Id = Sport.NastanId AND Sport.Tip='Baseball'";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Sport s = SportInfo(Convert.ToInt32(citac["Id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),

                        Sport = new Sport
                        {
                            NastanId = Convert.ToInt32(citac["id"].ToString()),
                            Tip = s.Tip,
                            Tim = TeamInfo(s.DomashenTimId ?? default(int)),
                            Tim1 = TeamInfo(s.GostinskiTimId ?? default(int)),
                            DomashenTimId = s.DomashenTimId,
                            GostinskiTimId = s.GostinskiTimId
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
        public static Dictionary<Nastan, List<NastanOdrzhuvanje>> AllIceHockeyMatches()
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Nastan.* FROM Nastan,Sport WHERE Nastan.Id = Sport.NastanId AND Sport.Tip='Ice Hockey'";
            try
            {
                Dictionary<Nastan, List<NastanOdrzhuvanje>> events = new Dictionary<Nastan, List<NastanOdrzhuvanje>>();
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Sport s = SportInfo(Convert.ToInt32(citac["Id"].ToString()));
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(citac["id"].ToString()),
                        Slika = citac["Slika"].ToString(),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),

                        Sport = new Sport
                        {
                            NastanId = Convert.ToInt32(citac["id"].ToString()),
                            Tip = s.Tip,
                            Tim = TeamInfo(s.DomashenTimId ?? default(int)),
                            Tim1 = TeamInfo(s.GostinskiTimId ?? default(int)),
                            DomashenTimId = s.DomashenTimId,
                            GostinskiTimId = s.GostinskiTimId
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
        private static Tim TeamInfo(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Tim WHERE Id ='" + id + "'";
            try
            {
             
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                   return new Tim
                    {
                       Id=id,
                       Ime=citac["Ime"].ToString()
                       
                    };
                   
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
        private static Sport SportInfo(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Sport WHERE NastanId ='"+id+"'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Sport s = new Sport
                    {
                        DomashenTimId=Convert.ToInt32(citac["DomashenTimId"].ToString()),
                        Tip=citac["Tip"].ToString(),
                        GostinskiTimId=Convert.ToInt32(citac["GostinskiTimId"].ToString()),
                        
                    };
                    return s;
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
