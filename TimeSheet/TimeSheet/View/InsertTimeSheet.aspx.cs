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
//using TimeSheet.Controller;

namespace TimeSheet.View
{
    public partial class InsertTimeSheet : System.Web.UI.Page
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

                string textProjectId = txtProjectId.Text;
                string textUsername = txtUsername.Text;
                string textDescription = txtDes.Text;
                float textHours = float.Parse(ddlHours.SelectedItem.Value);
                string textCreatedDate = timenow;

                string path = @"D:\Cshap\Web-Sudarat\TimeSheet\TimeSheet\View\Sheet\NewSheet.txt";
                List<TimeSheetModel> TcModel = new List<TimeSheetModel>();
                List<string> lines = File.ReadAllLines(path).ToList();

                foreach (var line in lines)
                {
                    string[] list = line.Split('|');
                    TimeSheetModel tc = new TimeSheetModel();

                    tc.Id = Convert.ToInt32(list[0]);
                    tc.ProjectId = list[1];
                    tc.Username = list[2];
                    tc.Description = list[3];
                    tc.Hours = (float) Convert.ToDouble(list[4]);
                    tc.CreatedDate = list[5];
                    TcModel.Add(tc);
                }
                var row = lines.Count + 1;
                TcModel.Add(new TimeSheetModel
                {
                    Id = row,
                    ProjectId = textProjectId,
                    Username = textUsername,
                    Description = textDescription,
                    Hours = textHours,
                    CreatedDate = textCreatedDate
                });

                List<string> txtfile = new List<string>();
                foreach (var sheets in TcModel)
                {
                    txtfile.Add($"{sheets.Id}|{sheets.ProjectId}|{sheets.Username}|{sheets.Description}|{sheets.Hours}|{sheets.CreatedDate}");
                }
                File.WriteAllLines(path, txtfile);
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
        void showAlertSuccess(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertSuccess('" + msg + "');", true);
        }
        void showAlertError(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertError('" + msg + "');", true);
        }
    }
}