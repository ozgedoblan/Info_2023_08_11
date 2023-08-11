using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kraker.DAL
{
    public class DB
    {
        public static SqlConnection GetConnection()
        {
            var conStr = ConfigurationManager.ConnectionStrings["hrConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            return con;
        }
        public static SqlCommand GetCommand(string cmdText)
        {
            var cmd = new SqlCommand(cmdText,GetConnection());
            return cmd;
        }
        public static object ExecuteScalar(string cmdText)
        {
            object result = null;
            var cmd= GetCommand(cmdText);
            try
            {
                cmd.Connection.Open();
                result = cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }
        public static DataSet GetDataSet(string cmdText)
        {
            DataSet ds = new DataSet();
            var cmd = GetCommand(cmdText);
            var adap = new SqlDataAdapter(cmd);
            adap.Fill(ds);
            return ds;
        }
        public static DataTable GetDataTable(string cmdText)
        {
            return GetDataSet(cmdText).Tables[0];
        }
    }
}
