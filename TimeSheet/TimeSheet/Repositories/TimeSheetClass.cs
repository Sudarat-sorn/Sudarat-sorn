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
        public DataSet GetTimeSheet()
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
    }
}