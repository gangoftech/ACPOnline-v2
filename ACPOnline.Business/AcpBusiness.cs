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

        public AcpViewModel GetAllAcpInfo(Acp acp)
        {
            var vm = new AcpViewModel();
            var acpList = this.GetAllAcpInfo();

            if (acp.ID.HasValue)
            {
                acpList = acpList.FindAll(x => x.ID == acp.ID);
            }

            if (acp.CategoryId != 0)
            {
                acpList = acpList.FindAll(x => x.CategoryId == acp.CategoryId);
            }

            if (acp.TypeID != 0)
            {
                acpList = acpList.FindAll(x => x.TypeID == acp.TypeID);
            }

            if (acp.StatusId != 0)
            {
                acpList = acpList.FindAll(x => x.StatusId == acp.StatusId);
            }

            if (!string.IsNullOrEmpty(acp.Name))
            {
                acpList = acpList.FindAll(x => x.Name.ToLower().Contains(acp.Name.ToLower()));
            }
            vm.Acp = acp;
            vm.AcpList = acpList;
            return vm;
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
