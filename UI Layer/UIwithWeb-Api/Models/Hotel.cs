using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIwithWeb_Api.Models
{
    public partial class Hotel
    {
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string address { get; set; }
        public int fare { get; set; }
        public int roomsAvailable { get; set; }
        public int rating { get; set; }
        public bool wifiAvailability { get; set; }
        public bool IsSaved { get; set; }
        public bool IsBooked { get; set; }
    }
}