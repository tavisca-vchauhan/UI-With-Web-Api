using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIwithWeb_Api.Models
{
    public partial class Activity
    {
        public int activityID { get; set; }
        public string activityName { get; set; }
        public string activityDuration { get; set; }
        public System.DateTime activityDate { get; set; }
        public int cost { get; set; }
        public bool IsSaved { get; set; }
        public bool IsBooked { get; set; }
    }
}