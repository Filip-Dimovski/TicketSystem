using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;

namespace DBAccess
{
    public class UserClass : ControlClass
    {
         public static int RegisterUser(string brKreditnaKartichka, string ime, string prezime, string email, string lozinka, string datumRagjanje, string drzhava, string pol, out string message)
        {
            if (creditCardExcisting(brKreditnaKartichka, out message)) return -1;
            if (emailExcisting(email, out message)) return -1;
            int id = createCreditCard(brKreditnaKartichka,out message);
            if (id == -1) return -1;
            return (createUser(ime, prezime, email, lozinka, datumRagjanje, drzhava, pol, id, out message));
           
        }
        
        public static string LoginUser(string email, string password)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Korisnik WHERE Email='"+email+"'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while(citac.Read())
                {
                    string decryptedPassword = StringCipher.Decrypt(citac["Lozinka"].ToString(), "123");
                    if(password==decryptedPassword)
                    {
                        return citac["id"].ToString();

                    }
                }
            }
            catch(Exception)
            {

            }
            finally
            {
                konekcija.Close();
            }
            return "-1";
        }

        public static string FindUserName(int id)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT Ime FROM Korisnik WHERE Id='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    return citac["Ime"].ToString();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                konekcija.Close();
            }
            return "Greshka";
        }
    
        private static bool creditCardExcisting(string brKreditnaKartichka, out string  message)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT COUNT(*) FROM KreditnaKartichka WHERE Broj='"+brKreditnaKartichka+"'";
            try
            {
                konekcija.Open();
                int sameCreditCard=(int)komanda.ExecuteScalar();
                if (sameCreditCard == 0) {
                    message = "";
                    return false;
                }
                else {
                    message = "Кредитната картичка веќе постои";
                    return true;
                }
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            finally
            {
                konekcija.Close();
            }
            return true;
        }
        private  static bool emailExcisting(string email,out string message)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT COUNT(*) FROM Korisnik WHERE Email='" + email + "'";
            try
            {
                konekcija.Open();
                int sameEmail = (int)komanda.ExecuteScalar();
                if (sameEmail == 0)
                {
                    message = "";
                    return false;
                }
                else
                {
                    message = "Емаилот веќе постои! Пробајте да се најавите.";
                    return true;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            finally
            {
                konekcija.Close();
            }
            return true;
        }
        private static  int  createCreditCard(string brojKreditna,out string message)
        {
            SqlConnection konekcija = new SqlConnection();
            //konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["TicketModelConnection"].ConnectionString;
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO KreditnaKartichka(Broj) OUTPUT Inserted.ID VALUES (" + brojKreditna+")";
            try
            {
                konekcija.Open();
                message = "";
               return (int)komanda.ExecuteScalar();
   
            }
            catch(Exception err)
            {
                message = err.Message;
                
            }
            finally
            {
                konekcija.Close();
            }
            return -1;

        }



        private static int createUser(string ime, string prezime, string email, string lozinka, string datumRagjanje, string drzhava, string pol, int kartichkaId,out string message)
        {
            SqlConnection konekcija = new SqlConnection();
          
            konekcija.ConnectionString =connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string p = "";
            if (pol == "Машки") p = "M";
            else p = "Z";
            string encryptedPassword = StringCipher.Encrypt(lozinka, "123");
          //  string decryptedPassword = StringCipher.Decrypt(encryptedPassword, "123");
          //  string s = "INSERT INTO Korisnik (Ime,Prezime,Email,Lozinka,DatumRagjanje,Drzhava,Pol,IdKreditnaKartichka)  VALUES (" + ime + "," + prezime + "," + email + "," + lozinka + "," + datumRagjanje + "," + p + "," + kartichkaId + ")";
            komanda.CommandText = "INSERT INTO Korisnik (Ime,Prezime,Email,Lozinka,DatumRagjanje,Drzhava,Pol,IdKreditnaKartichka) OUTPUT Inserted.ID  VALUES (@i,@p,@e,@l,@d,@dr,@po,@idkk)";
            komanda.Parameters.AddWithValue("@i", ime);
            komanda.Parameters.AddWithValue("@p", prezime);
            komanda.Parameters.AddWithValue("@e", email);
            komanda.Parameters.AddWithValue("@l", encryptedPassword);
            komanda.Parameters.AddWithValue("@d", datumRagjanje);
            komanda.Parameters.AddWithValue("@dr", drzhava);
            komanda.Parameters.AddWithValue("@po", p);
            komanda.Parameters.AddWithValue("@idkk", kartichkaId);
            try
            {
                konekcija.Open();
                message = "";
                return (int) komanda.ExecuteScalar();
                

            }
            catch (Exception e)
            {
                message = e.Message;
            }
            finally
            {
                konekcija.Close();
            }
            return -1;
        }

        
    }
}
