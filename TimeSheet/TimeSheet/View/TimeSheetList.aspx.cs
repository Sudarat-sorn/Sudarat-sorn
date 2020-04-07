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

        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            
            string txtPath = Server.MapPath("Sheet/") + "NewSheet.txt";

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Id", typeof(int)),
                                new DataColumn("ProjectId", typeof(string)),
                                new DataColumn("Username", typeof(string)),
                                new DataColumn("Description", typeof(string)),
                                new DataColumn("Hours",typeof(float)),
                                new DataColumn ("CreatedDate",typeof(string))});

            string txtData = File.ReadAllText(txtPath);
            foreach (string row in txtData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split('|'))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }
            gvSheet.DataSource = dt;
            gvSheet.DataBind();
        }
    }
}