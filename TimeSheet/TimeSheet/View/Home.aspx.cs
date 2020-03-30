using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSheet.Repositories;

namespace TimeSheet.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataSheet();
            }
            //TimeSheetClass tc = new TimeSheetClass();
            //tc.GetTimeSheet();
        }

        void bindDataSheet()
        {
            TimeSheetClass tc = new TimeSheetClass();
            gvSheet.DataSource = tc.GetTimeSheet();
            gvSheet.DataBind();
        }
    }
}