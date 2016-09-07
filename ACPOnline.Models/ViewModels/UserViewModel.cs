using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Models
{
    public class UserViewModel
    {
        public User User { get; set; }

        public IList<User> UserList { get; set; }
    }
}
