using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSheet.Repositories
{
    public class TimeSheetModel
    {
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public float Hours { get; set; }
        public string CreatedDate { get; set; }
    }
}