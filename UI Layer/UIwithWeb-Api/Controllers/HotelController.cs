using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using UIwithWeb_Api.Models;

namespace UIwithWeb_Api.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult AllHotels()
        {
            return View();
        }
        public ActionResult PostData()
        {
            return View();
        }

        public ActionResult GetAllValues()
        {
            List<Hotel> list = new List<Hotel>();
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync("http://localhost:54300/api/Hotel").Result;
            list = result.Content.ReadAsAsync<List<Hotel>>().Result;
            ViewBag.name = "Hotel";
            return View(list);
        }

        public ActionResult PostOperation()
        {
            Hotel hotel = new Hotel();
            string hotelName = Request.Params["hotelName"];
            string address = Request.Params["address"];
            string fare = Request.Params["fare"];
            string roomsAvailable = Request.Params["roomsAvailable"];
            string rating = Request.Params["rating"];
            string wifiAvailability = Request.Params["wifiAvailability"];
            string IsSaved = Request.Params["IsSaved"];
            string IsBooked = Request.Params["IsBooked"];
            hotel.hotelName = hotelName;
            hotel.address = address;
            hotel.fare = Convert.ToInt32(fare);
            hotel.roomsAvailable = Convert.ToInt32(roomsAvailable);
            hotel.rating = Convert.ToInt32(rating);
            hotel.wifiAvailability = Convert.ToBoolean( wifiAvailability);
            hotel.IsSaved = Convert.ToBoolean(IsSaved);
            hotel.IsBooked = Convert.ToBoolean(IsBooked);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50339/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:54300/api/Hotel/";
            var response = httpClient.PostAsJsonAsync(uri, hotel);
            return View();
        }

        public ActionResult PutData()
        {
            string values = Request.Params["Save"];
            string[] query = values.Split(',');
            int operation = Convert.ToInt32(query[0]);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50339/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:54300/api/Hotel/" + query[1];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return View();
        }

    }
}