using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kraker.DAL;

class Program
{
    static void Main(string[] args)
    {
        var con = DB.GetConnection();
        var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "usp_Status";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            Console.WriteLine("Çalışan ="+ dt.Rows[0]["CalisanSayisi"]);
            Console.WriteLine("Departman =" + dt.Rows[0]["DepartmanSayisi"]);
            Console.WriteLine("Takım=" + dt.Rows[0]["TakimSayisi"]);
        }
    }

    private static void DataTableTest()
    {
        string sqlstr = @"select*from Calisan;
                          select*from Departman;
                          select*from Takim;";
        var dt = DB.GetDataTable("select*from Departman");

        Console.WriteLine(dt.Rows.Count);
        foreach (DataRow dataRow in dt.Rows)
        {
            Console.WriteLine(dataRow["Adi"]);
        }
    }

    private static void DataSetOrnek(string sqlstr)
    {
        DataSet ds = new DataSet();

        var cmd = DB.GetCommand(sqlstr);
        var adap = new SqlDataAdapter(cmd);
        adap.Fill(ds);
        int tableNdx = 1;

        foreach (DataTable dt in ds.Tables)
        {
            Console.WriteLine("----table-" + tableNdx);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Id"]}- {dr["Adi"]}");
            }
            Console.WriteLine("-----------");
        }
        Console.WriteLine("***************************");
        Console.WriteLine(ds.Tables[0].Rows.Count); //ilk tablodaki kayıt sayısını gösterir.
        Console.WriteLine(ds.Tables[1].Rows.Count);
    }

    private static void test()
    {
        var con = DB.GetConnection();
        con.Open();
        con.Close();

        var res = DB.ExecuteScalar("select count(*) from Calisan");
        Console.WriteLine(res);
    }
}

