using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public  class ControlClass
    {
        protected static string connectionString = "Data Source=FILIP-PC\\SQLEXPRESS;initial Catalog=Ticket;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected static Nastan eventInfo(string id)
        {

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = connectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "SELECT * FROM Nastan WHERE Id='" + id + "'";
            try
            {
                konekcija.Open();
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Nastan n = new Nastan
                    {
                        Id = Convert.ToInt32(id),
                        Ime = citac["Ime"].ToString(),
                        Opis = citac["Opis"].ToString(),
                        RegularnaCena = Convert.ToDouble(citac["RegularnaCena"].ToString()),
                        Slika = citac["Slika"].ToString()
                    };
                    return n;
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
