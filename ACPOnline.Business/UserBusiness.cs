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

        public List<Roles> GetAllUserRolesInfo()
        {
            return da.GetAllUserRolesInfo();
        }

        public User GetUserInfo(int userId)
        {
            return da.GetUserInfo(userId);
        }

        public int UpdateUserInfo(User user)
        {
            var s = da.UpdateUserInfo(user);
            if (user.UserRoles != null && user.UserRoles.Count() != 0)
            {
                foreach (var role in user.UserRoles)
                {
                    da.UpdateUserAccessInfo(user.UserId, role);
                }
            }
            return s;
        }

        public AuthResult AuthendicateUser(string loginId, string password)
        {
            return da.AuthendicateUser(loginId, password);
        }
    }
}
