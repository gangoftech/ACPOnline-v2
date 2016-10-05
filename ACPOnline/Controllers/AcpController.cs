using ACPOnline.Business;
using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACPOnline.Controllers
{
    public class AcpController : BaseController
    {
        private AcpBusiness bus = null;

        public AcpController()
        {
            bus = new AcpBusiness();
        }

        // GET: Acp
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var acp = new AcpViewModel();
            acp.Acp = new Acp();
            ViewBag.AcpTypes = GetOptions();
            return View(acp);
        }

        [HttpPost]
        public ActionResult Create(AcpViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.Acp.ID = model.Acp.ID != null ? model.Acp.ID : -1;
            bus.UpdateAcpInfo(model);
            return View(model);
        }

        // GET: Acp
        public ActionResult Edit(int id)
        {
            var vm = new AcpViewModel();
            vm.Acp = bus.GetAcpInfo(id);
            return View(vm);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var vm = new AcpViewModel();
            vm.Acp = new Acp();
            vm.AcpList = bus.GetAllAcpInfo();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(Acp acp)
        {
            var vm = bus.GetAllAcpInfo(acp);
            return View(vm);
        }

        public ActionResult LoadArtifacts()
        {
            return PartialView("_Artifacts");
        }

        
       

        private List<KeyValue> GetOptions()
        {
            var options = new List<KeyValue>();
            options.Add(new KeyValue { Key = 1, Value = "Type 1" });
            options.Add(new KeyValue { Key = 2, Value = "Type 2" });
            options.Add(new KeyValue { Key = 3, Value = "Type 3" });
            return options;
        }
    }
}