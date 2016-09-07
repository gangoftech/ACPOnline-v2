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
    public class UserDataAccess : BaseDataAccess
    {
        public List<User> GetAllUserInfo()
        {
            SqlCommand cmd = new SqlCommand("spd_Get_All_User_Info");
            cmd.CommandType = CommandType.StoredProcedure;
            return AcpDbContext.ExecuteReaderAndFillList(cmd,
            reader =>
            {
                return FillUserInfo(reader);

            });

        }

        public User GetUserInfo(int userId)
        {
            SqlCommand cmd = new SqlCommand("spd_Get_User_Info");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_Id", userId);
            using (SqlDataReader reader = AcpDbContext.ExecuteReader(cmd))
            {
                var user = new User();
                while (reader.Read())
                {
                    user = FillUserInfo(reader);
                }
                return user;
            }
        }

        public int UpdateAcpInfo(User user)
        {
            SqlCommand cmd = new SqlCommand("spd_Acp_User_Update");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_Id", user.UserId);
            cmd.Parameters.AddWithValue("@Login_Id", user.LoginId);
            cmd.Parameters.AddWithValue("@User_Name", user.UserName);
            cmd.Parameters.AddWithValue("@User_Email", user.Email);
            cmd.Parameters.AddWithValue("@User_Password", user.Password);
            cmd.Parameters.AddWithValue("@Is_Deleted", user.IsDeleted);
            cmd.Parameters.AddWithValue("@Created_By", user.CreatedBy);
            cmd.Parameters.AddWithValue("@Updated_By", user.UpdatedBy);
            return AcpDbContext.ExecuteNonQuery(cmd);
        }

        private User FillUserInfo(SqlDataReader reader)
        {
            var user = new User();
            user.UserId = reader.GetInt32(0);
            user.LoginId = reader.GetString(1);
            user.UserName = reader.GetString(2);
            user.Email = reader.GetString(3);
            user.Password = reader.GetString(4);
            user.IsDeleted = reader.GetBoolean(5);
            user.CreatedDate = reader.GetNullableDateTime(6);
            user.CreatedBy = reader.GetInt32(7);
            user.UpdatedDate = reader.GetNullableDateTime(8);
            user.UpdatedBy = reader.GetInt32(9);
            return user;
        }
    }
}
