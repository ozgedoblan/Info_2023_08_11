using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var conStr = "Data Source=NIVI;Initial Catalog=KrakerHR2;Integrated Security=True;";
        DataTable dt = new DataTable();

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand("Select Id,TamAdi from vw_Calisan", con);

        SqlDataAdapter adap = new SqlDataAdapter(cmd);

        adap.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["Id"] + "-" + dr["TamAdi"]);
        }
    }
}
