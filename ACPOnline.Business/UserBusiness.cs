using ACPOnline.DataAccess;
using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Business
{
    public class UserBusiness
    {
        private UserDataAccess da = null;

        public UserBusiness()
        {
            da = new UserDataAccess();
        }

        public List<User> GetAllUserInfo()
        {
            return da.GetAllUserInfo();
        }

        public User GetUserInfo(int userId)
        {
            return da.GetUserInfo(userId);
        }

        public int UpdateUserInfo(User user)
        {
            return da.UpdateUserInfo(user);
        }

        public AuthResult AuthendicateUser(string loginId, string password)
        {
            return da.AuthendicateUser(loginId, password);
        }
    }
}
