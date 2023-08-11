using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var conStr = "Data Source=NIVI;Initial Catalog=KrakerHR2;Integrated Security=True;";
        SqlConnection con = new SqlConnection(conStr);

        SqlCommand cmd = new SqlCommand("Select * from vw_Calisan", con);
        //    cmd.CommandText = "Select* from Calisan";
        //    cmd.connection = con;
        try
        {
            con.Open();
            Console.WriteLine("Bağlantı Açıldı");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["Id"]},{dr["TamAdi"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata Oldu");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            Console.WriteLine("Bağlantı Kapandı");
        }    
    }
}
