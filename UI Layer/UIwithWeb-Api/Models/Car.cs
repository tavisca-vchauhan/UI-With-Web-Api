using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIwithWeb_Api.Models
{
    public partial class Car
    {
        public int carId { get; set; }
        public string carName { get; set; }
        public string carCompany { get; set; }
        public string carModel { get; set; }
        public int cost { get; set; }
        public string color { get; set; }
        public string engine { get; set; }
        public bool IsSaved { get; set; }
        public bool IsBooked { get; set; }
    }
}