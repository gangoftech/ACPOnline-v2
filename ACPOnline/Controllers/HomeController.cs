using ACPOnline.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACPOnline.Controllers
{
    public class HomeController : BaseController
    {
        private AcpBusiness bus = null;

        public HomeController()
        {
            bus = new AcpBusiness();
        }

        public ActionResult Index()
        {
            //bus.GetAcpInfo(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}