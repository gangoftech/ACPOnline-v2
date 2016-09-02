using ACPOnline.DataAccess;
using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Business
{
    public class AcpBusiness
    {
        private AcpDataAccess da = null;

        public  AcpBusiness()
        {
            da = new AcpDataAccess();
        }

        public Acp GetAcpInfo(int acpID)
        {
            return da.GetAcpInfo(acpID);
        }
    }
}
