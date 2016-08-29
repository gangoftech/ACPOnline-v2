using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace ACPOnline.DataAccess
{
    public class BaseDataAccess
    {
        public Database AcpDbContext = null;

        public BaseDataAccess()
        {
            AcpDbContext = new Database("ACP");
        }
    }
}
