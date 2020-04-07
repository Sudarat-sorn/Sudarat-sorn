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
using TimeSheet.Controller;
using TimeSheet.Repositories;

namespace TimeSheet.View
{
    public partial class InsertTimeSheet : BaseRequest
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int i = 1;
                ddlHours.Items.Insert(0, new ListItem("-- Select--", ""));
                for (double h = 0; h <= 24; h += 0.5)
                {
                    ddlHours.Items.Insert(i, new ListItem(h.ToString(), h.ToString()));
                    i++;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProjectId.Text))
                {
                    showAlertError("alertProjectId", "กรุณากรอก Project Id");
                    return;
                }
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    showAlertError("alertUsernameErr", "กรุณากรอก Username");
                    return;
                }
                if (string.IsNullOrEmpty(txtDes.Text))
                {
                    showAlertError("alertDesErr", "กรุณากรอก Description");
                    return;
                }
                if (string.IsNullOrWhiteSpace(ddlHours.SelectedValue))
                {
                    showAlertError("alertHoursErr", "กรุณาเลือก Hours");
                    return;
                }

                DateTime timestamp = DateTime.Now;
                string timenow = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                TimeSheetClass TcClass = new TimeSheetClass();
                TimeSheetModel data = new TimeSheetModel()
                {
                    ProjectId = txtProjectId.Text,
                    Username = txtUsername.Text,
                    Description = txtDes.Text,
                    Hours = float.Parse(ddlHours.SelectedItem.Value),
                    CreatedDate = Convert.ToDateTime(timenow)
                };
                TcClass.insertSheet(data);

                FileInfo FileIn = new FileInfo(Server.MapPath("Sheet/NewSheet.txt"));
                if (FileIn.Exists)
                {
                    FileIn.Delete();

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
                showAlertSuccess("alertSuccess", "Insert Success");
            }
            catch (SqlException sqlEx)
            {
                showAlertError("alertSqlErr", sqlEx.Message);

            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);

            }

        }
    }
}