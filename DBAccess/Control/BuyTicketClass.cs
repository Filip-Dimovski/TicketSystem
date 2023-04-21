using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
   public class BuyTicketClass:ControlClass
    {
        public static NastanOdrzhuvanje EventTimmingInfo(string id,string vreme,string lokacija)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM NastanOdrzhuvanje WHERE NastanId='" + id + "' AND Lokacija='" + lokacija + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                
                while (citac.Read())
                {
                   NastanOdrzhuvanje  no = new NastanOdrzhuvanje
                    {
                        Lokacija = citac["Lokacija"].ToString(),
                        SlobodniMesta = Convert.ToInt32(citac["SlobodniMesta"].ToString()),
                        NastanId = Convert.ToInt32(citac["NastanId"].ToString()),
                        VremeOdrzhuvanje = Convert.ToDateTime(citac["VremeOdrzhuvanje"].ToString()),
                        Nastan = eventInfo(citac["NastanId"].ToString()),
                        Cena=Convert.ToDouble(citac["Cena"].ToString())
                       
                    };
                    if(citac["VremeOdrzhuvanje"].ToString() == vreme)
                    return no;
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

        public static bool BuyTicket(string eventId,string kreditnaKartichka,string userId,string lokacija,DateTime vremeOdrzhuvanje,double pari,out string message)
        {
            string idCreditCard = UserCreditCard(userId);
            KreditnaKartichka kreditna = CreditCardNumber(idCreditCard);
            if(kreditna==null || kreditna.Broj!=kreditnaKartichka)
            {
                message = "Грешка! Грешен број на кредитната картичка!";
                return false;
            }
            if(pari>kreditna.Pari)
            {
                message = "Немате доволно пари. Потребни Ви се уште "+(pari-kreditna.Pari)+" долари.";
                return false;
            }
            reduceMoney(kreditna.Id,(float)(kreditna.Pari-pari));
            makeEventForUser(userId, eventId,vremeOdrzhuvanje,lokacija);
            reduceFreeSeats(eventId,vremeOdrzhuvanje,lokacija);
            message = "";
            return true;
        }
        private static void makeEventForUser(string userId,string eventId,DateTime vremeNastan,string lokacija)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Poseta (KorisnikId,NastanId,DatumRezervacija,VremeOdrzhuvanje,Lokacija) VALUES (@k,@n,@d,@v,@l)";
            komanda.Parameters.AddWithValue("@k", Convert.ToInt32(userId));
            komanda.Parameters.AddWithValue("@n", Convert.ToInt32(eventId));
            komanda.Parameters.AddWithValue("@d",DateTime.Now);
            komanda.Parameters.AddWithValue("@v", vremeNastan);
            komanda.Parameters.AddWithValue("@l", lokacija);
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                konekcija.Close();
            }
        }
        private static void reduceFreeSeats(string eventId,DateTime vreme,string lokacija)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "UPDATE NastanOdrzhuvanje SET SlobodniMesta=SlobodniMesta - 1 WHERE NastanId='" + eventId + "' AND VremeOdrzhuvanje=@v AND Lokacija='"+lokacija+"'";
            komanda.Parameters.AddWithValue("@v", vreme); 
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                konekcija.Close();
            }
        }
        private static void reduceMoney(int id,float newMoney)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "UPDATE KreditnaKartichka SET Pari='"+newMoney.ToString().Replace(",",".")+"' WHERE Id='" + id + "'";
            try
            {
                konekcija.Open();
               komanda.ExecuteNonQuery();
                
            }
            catch (Exception)
            {

            }
            finally
            {
                konekcija.Close();
            }
            
        }
        public static string UserCreditCard(string id)
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
                    return citac["IdKreditnaKartichka"].ToString();
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
        private static KreditnaKartichka CreditCardNumber(string id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM KreditnaKartichka WHERE Id='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    KreditnaKartichka kk = new KreditnaKartichka
                    {
                        Id=Convert.ToInt32(id),
                        Broj=citac["Broj"].ToString(),
                        Pari=Convert.ToDouble(citac["Pari"].ToString())
                    };
                    return kk;
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
