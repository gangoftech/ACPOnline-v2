using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.DataAccess
{
    public class MainDataAccess : BaseDataAccess
    {
        public Info GetAcpInfo(int acpID)
        {
            SqlCommand cmd = new SqlCommand("");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ACP_ID", acpID);
            using (SqlDataReader reader = AcpDbContext.ExecuteReader(cmd))
            {
                var acp = new Info();
                while (reader.Read())
                {
                    acp.ID = reader.GetInt32(0);

                }
                return acp;
            }
        }
    }
}
