using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ACPOnline.DataAccess
{
    public class Database
    {

        private string connectionString = "";

        public Database(string connectionStringName)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    return cmd.ExecuteReader();
                }
                catch
                {
                    return null;
                }
                finally {
                    connection.Close();
                }
            }
        }
    }
}
