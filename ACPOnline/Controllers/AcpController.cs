using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACPOnline.Controllers
{
    public class AcpController : Controller
    {
        // GET: Acp
        public ActionResult Index()
        {
            return View();
        }

        // GET: Acp
        public ActionResult Create()
        {
            var acp = new AcpViewModel();
            acp.Acp = new Acp();
            ViewBag.AcpTypes = GetOptions();
            return View(acp);
        }

        // GET: Acp
        public ActionResult Edit()
        {
            var acp = new AcpViewModel();
            acp.Acp = new Acp();
            ViewBag.AcpTypes = GetOptions();
            return View(acp);
        }

        // GET: Acp
        public ActionResult Search()
        {
            var acp = new AcpViewModel();
            acp.Acp = new Acp();
            ViewBag.AcpTypes = GetOptions();
            return View(acp);
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