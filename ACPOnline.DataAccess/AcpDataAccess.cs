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
    public class AcpDataAccess : BaseDataAccess
    {
        public Acp GetAcpInfo(int acpID)
        {
            SqlCommand cmd = new SqlCommand("spd_Get_Acp_Info");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ACP_ID", acpID);
            using (SqlDataReader reader = AcpDbContext.ExecuteReader(cmd))
            {
                var acp = new Acp();
                while (reader.Read())
                {
                    acp = FillAcpInfo(reader);
                }
                return acp;
            }
        }

        public List<Acp> GetAllAcpInfo()
        {
            SqlCommand cmd = new SqlCommand("spd_Get_All_Acp_Info");
            cmd.CommandType = CommandType.StoredProcedure;
            
            return AcpDbContext.ExecuteReaderAndFillList(cmd,
            reader =>
            {
                return FillAcpInfo(reader);
                
            });
            
        }

        public int UpdateAcpInfo(Acp acp)
        {
            SqlCommand cmd = new SqlCommand("spd_Get_Acp_Info_Update");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ACP_ID", acp.ID);
            cmd.Parameters.AddWithValue("@ACP_Type_ID", acp.TypeID);
            cmd.Parameters.AddWithValue("@ACP_Category_Id", acp.CategoryId);
            cmd.Parameters.AddWithValue("@ACP_Name", acp.Name);
            cmd.Parameters.AddWithValue("@Proposed_By", acp.ProposedBy);
            cmd.Parameters.AddWithValue("@ACP_Lead", acp.Lead);
            cmd.Parameters.AddWithValue("@Description", acp.Description);
            cmd.Parameters.AddWithValue("@Lead_Assn_Date", acp.LeadAssnDate);
            cmd.Parameters.AddWithValue("@Impl_Start_Date", acp.ImplStartDate);
            cmd.Parameters.AddWithValue("@Impl_End_Date", acp.ImplEndDate);
            cmd.Parameters.AddWithValue("@Pl_Impl_Start_Date", acp.PlImplStartDate);
            cmd.Parameters.AddWithValue("@Pl_Impl_End_Date", acp.PlImplEndDate);
            cmd.Parameters.AddWithValue("@Launch_Date", acp.LaunchDate);
            cmd.Parameters.AddWithValue("@Pl_Launch_Date", acp.PlLaunchDate);
            cmd.Parameters.AddWithValue("@ACP_Status_Id", acp.StatusId);
            cmd.Parameters.AddWithValue("@Created_By", acp.CreatedBy);
            cmd.Parameters.AddWithValue("@Updated_By", acp.UpdatedBy);
            return AcpDbContext.ExecuteNonQuery(cmd);
        }

        private Acp FillAcpInfo(SqlDataReader reader)
        {

                var acp = new Acp();

                acp.ID = reader.GetNullableInt32(0);
                acp.TypeID = reader.GetInt32(1);
                acp.Type = (!reader.IsDBNull(2)? reader.GetString(2):"");
                acp.CategoryId = reader.GetInt32(3);
                acp.CategoryName = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                acp.Name = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                acp.ProposedBy = reader.GetInt32(6);
                acp.ProposedByName = (!reader.IsDBNull(7) ? reader.GetString(7) : "");
                acp.Lead = reader.GetInt32(8);
                acp.LeadName = reader.GetString(9);
                acp.Description = reader.GetString(10);
                acp.LeadAssnDate = reader.GetNullableDateTime(11);
                acp.ImplStartDate = reader.GetNullableDateTime(12);
                acp.ImplEndDate = reader.GetNullableDateTime(13);
                acp.PlImplStartDate = reader.GetNullableDateTime(14);
                acp.PlImplEndDate = reader.GetNullableDateTime(15);
                acp.LaunchDate = reader.GetNullableDateTime(16);
                acp.PlLaunchDate = reader.GetNullableDateTime(17);
                acp.StatusId = reader.GetInt32(18);
                acp.StatusName = reader.GetString(19);
                acp.CreatedDate = reader.GetNullableDateTime(20);
                acp.CreatedBy = reader.GetInt32(21);
                acp.CreatedByName = reader.GetString(22);
                acp.UpdatedDate = reader.GetNullableDateTime(23);
                acp.UpdatedBy = reader.GetInt32(24);
                acp.UpdatedByName = reader.GetString(25);

            return acp;
        }
    }
}
