using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Contacts.Services
{
    /// <summary>
    /// Summary description for autoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class autoComplete : System.Web.Services.WebService
    {

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string SearchNames()
        {
            return "Hello World";
        }
    }
}
