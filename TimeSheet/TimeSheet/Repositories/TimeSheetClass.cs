using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TimeSheet.Repositories
{
    public class TimeSheetClass
    {
        string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
        public DataSet getTimeSheet()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            string cmdText = "SELECT * FROM [RecordDetail] ";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }

        public void insertSheet(TimeSheetModel data)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            DateTime timestamp = DateTime.Now;
            string timenow = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
            string cmdTextRaw = "INSERT INTO [RecordDetail] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
            string cmdText = string.Format(cmdTextRaw, data.ProjectId, data.Username, data.Description, data.Hours, timenow);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }

    public class TimeSheetModel
    {
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public float Hours { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}