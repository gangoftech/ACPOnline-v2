using ACPOnline.Business;
using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;

namespace ACPOnline.Controllers
{
    public class UserController : BaseController
    {
        private UserBusiness bus = null;

        public UserController()
        {
            bus = new UserBusiness();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = new UserViewModel();
            vm.User = new User();
            vm.User.Password = Membership.GeneratePassword(8, 1);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            bus.UpdateUserInfo(vm.User);
            return View(vm);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var vm = new UserViewModel();
            vm.User = new User();
            vm.UserList = bus.GetAllUserInfo();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vm = new UserViewModel();
            vm.User = bus.GetUserInfo(id);
            return View(vm);
        }
    }
}