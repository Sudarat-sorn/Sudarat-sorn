using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
        }

        void bindDataSheet()
        {
            TimeSheetClass tc = new TimeSheetClass();
            gvSheet.DataSource = tc.GetTimeSheet();
            gvSheet.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
            var objConn = new SqlConnection(connStr);
            objConn.Open();

            SqlDataAdapter dtAdapter;
            DataTable dt = new DataTable();
            string SelectSQL = "SELECT * FROM RecordDetail";
            dtAdapter = new SqlDataAdapter(SelectSQL, objConn);
            dtAdapter.Fill(dt);
            var count = dt.Rows.Count.ToString();
            var Total_Colume = Int32.Parse(count);

            StreamWriter StrWer = default(StreamWriter);

            StrWer = File.CreateText(Server.MapPath("Sheet/") + "NewSheet.txt");
            for (int i = 0; i <= Total_Colume - 1; i++)
            {
                StrWer.Write(dt.Rows[i]["Id"].ToString() + "|");
                StrWer.Write(dt.Rows[i]["ProjectId"].ToString() + "|");
                StrWer.Write(dt.Rows[i]["Username"].ToString() + "|");
                StrWer.Write(dt.Rows[i]["Description"].ToString() + "|");
                StrWer.Write(dt.Rows[i]["Hours"].ToString() + "|");
                StrWer.Write(dt.Rows[i]["CreatedDate"].ToString());
                StrWer.WriteLine("");
            }

            StrWer.Close();
        }
    }
}