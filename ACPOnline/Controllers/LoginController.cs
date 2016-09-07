using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACPOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            //GetUserName("359951");
            return View();
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