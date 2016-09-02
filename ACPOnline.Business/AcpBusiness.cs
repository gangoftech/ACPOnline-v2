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

        public List<Acp> GetAllAcpInfo()
        {
            return da.GetAllAcpInfo();
        }

        public Acp GetAcpInfo(int acpID)
        {
            return da.GetAcpInfo(acpID);
        }

        public int UpdateAcpInfo(AcpViewModel acpVM)
        {
            return da.UpdateAcpInfo(acpVM.Acp);
        }
    }
}
