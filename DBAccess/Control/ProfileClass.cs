using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public  class ProfileClass:ControlClass
    {
          public static Korisnik UserInformation(int id)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Korisnik WHERE Id='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    string pol = "";
                    if (citac["Pol"].ToString() == "M")
                        pol = "Машки";
                    else pol = "Женски";
                    Korisnik k = new Korisnik
                    {
                        Id = Convert.ToInt32(citac["Id"]),
                        Ime = citac["Ime"].ToString(),
                        Prezime = citac["Prezime"].ToString(),
                        Email = citac["Email"].ToString(),
                        Lozinka = StringCipher.Decrypt(citac["Lozinka"].ToString(), "123"),
                        DatumRagjanje = Convert.ToDateTime(citac["DatumRagjanje"].ToString()),
                        Drzhava = citac["Drzhava"].ToString(),
                        IdKreditnaKartichka = Convert.ToInt32(citac["IdKreditnaKartichka"].ToString()),
                        Pol = pol

                    };
                    return k;
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
        public static Dictionary<Poseta, Nastan> UserEvents(int userId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Poseta WHERE KorisnikId='" + userId + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                Dictionary<Poseta, Nastan> allUserEvents = new Dictionary<Poseta, Nastan>();
                while (citac.Read())
                {
                    Poseta p = new Poseta
                    {
                        DatumRezervacija = Convert.ToDateTime(citac["DatumRezervacija"].ToString()),
                        KorisnikId = Convert.ToInt32(citac["KorisnikId"].ToString()),
                        Lokacija=citac["Lokacija"].ToString(),
                        VremeOdrzhuvanje= Convert.ToDateTime(citac["VremeOdrzhuvanje"].ToString()),
                        NastanId= Convert.ToInt32(citac["NastanId"].ToString())

                    };
                    allUserEvents.Add(p, eventInfo(citac["NastanId"].ToString()));
                }
                return allUserEvents;
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
