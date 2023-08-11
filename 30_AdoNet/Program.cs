using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conStr = ConfigurationManager.ConnectionStrings["hrConnection"].ConnectionString;
            Console.WriteLine(conStr);
            SqlConnection con= new SqlConnection(conStr);

            con.Open();
            Console.WriteLine("db Open");

            con.Close();
            Console.WriteLine("db close");
        }
    }
}
