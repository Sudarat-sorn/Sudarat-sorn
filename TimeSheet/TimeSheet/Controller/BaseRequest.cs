using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSheet.Controller
{
    public class BaseRequest : System.Web.UI.Page
    {
        public void showAlertSuccess(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertSuccess('" + msg + "');", true);
        }
        public void showAlertError(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertError('" + msg + "');", true);
        }
    }
}