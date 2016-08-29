using ACPOnline.DataAccess;
using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Business
{
    public class MainBusiness
    {
        private MainDataAccess da = null;

        public  MainBusiness()
        {
            da = new MainDataAccess();
        }

        public Info GetAcpInfo(int acpID)
        {
            return da.GetAcpInfo(acpID);
        }
    }
}
