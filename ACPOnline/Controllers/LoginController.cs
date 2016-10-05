using ACPOnline.Business;
using ACPOnline.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ACPOnline.Controllers
{
    public class LoginController : Controller
    {
        private UserBusiness bus = null;

        public LoginController()
        {
            bus = new UserBusiness();
        }
        // GET: Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel vm, string returnUrl)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View();
            //}

            var auth = bus.AuthendicateUser(vm.User.LoginId, vm.User.Password);

            if(auth.IsSuccess)
            {
                FormsAuthentication.SetAuthCookie(vm.User.LoginId, false);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Create", "ACP");
                }
            }
            else
            {
                return View();
            }
        }

        private bool AuthenticateAD(string userName, string password)
        {

            DirectoryEntry entry = new
            DirectoryEntry("LDAP://cts.com", userName, password);
            try
            {
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + userName + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //lblmsg.Text = ex.Message;
                return false;
                throw new Exception("Error authenticating user. " + ex.Message);
            }
            return true;
        }

        public string GetUserName(string strUserId)
        {
            string strReturn = "";
            DirectoryEntry myDirectory = new DirectoryEntry("LDAP://cts.com", "mossirsa", "password-1");
            DirectorySearcher mySearcher = new DirectorySearcher(myDirectory);
            SearchResultCollection mySearchResultColl = default(SearchResultCollection);
            SearchResult mySearchResult = default(SearchResult);
            ResultPropertyCollection myResultPropColl = default(ResultPropertyCollection);
            ResultPropertyValueCollection myResultPropValueColl = default(ResultPropertyValueCollection);
            try
            {
                //Build LDAP query 
                mySearcher.Filter = ("(&(objectClass=user)(samaccountname=" + strUserId + "))");
                mySearchResultColl = mySearcher.FindAll();

                // Get the search result from the collection 
                if (mySearchResultColl != null && mySearchResultColl.Count > 0)
                {
                    mySearchResult = mySearchResultColl[0];
                    // Get the properties, they contain the usefull info 
                    myResultPropColl = mySearchResult.Properties;
                    //// Return the requested property.. displayname, mail, etc 

                    myResultPropValueColl = myResultPropColl["CN"];

                    strReturn = myResultPropValueColl[0].ToString();
                }
                else
                    strReturn = string.Empty;
                return strReturn;

            }

            //Handling the exception by logging the error message
            catch (Exception oExp)
            {
                if (strReturn != string.Empty)
                {
                    strReturn = string.Empty;
                }
                throw oExp;
            }//END OF CATCH LOOP
            //Garbage Collection Section
            finally
            {
                myDirectory = null;
                mySearcher = null;
                mySearchResultColl = null;
                myResultPropColl = null;
                myResultPropValueColl = null;

            }//END OF FINALLY
        }
    }
}