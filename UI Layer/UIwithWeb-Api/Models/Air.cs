using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIwithWeb_Api.Models
{
    public partial class Air
    {
        public int airId { get; set; }
        public int ticketNumber { get; set; }
        public string departureStation { get; set; }
        public string destinationStation { get; set; }
        public System.TimeSpan arrivalTime { get; set; }
        public System.TimeSpan departureTime { get; set; }
        public string duration { get; set; }
        public int price { get; set; }
        public bool IsSaved { get; set; }
        public bool IsBooked { get; set; }
    }
}