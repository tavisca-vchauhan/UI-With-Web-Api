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
    public class AirController : Controller
    {
        // GET: Air
        public ActionResult PostData()
        {
            return View();
        }

        public ActionResult GetAllValues()
        {
            List<Air> list = new List<Air>();
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync("http://localhost:54300/api/Air").Result;
            list = result.Content.ReadAsAsync<List<Air>>().Result;
            ViewBag.name = "Air";
            return View(list);
        }

        public ActionResult PostOperation()
        {
            Air air = new Air();
            string ticketNumber = Request.Params["ticketNumber"];
            string departureStation = Request.Params["departureStation"];
            string destinationStation = Request.Params["destinationStation"];
            DateTime  arrivalTime = Convert.ToDateTime(Request.Params["arrivalTime"]);
            DateTime departureTime = Convert.ToDateTime(Request.Params["departureTime"]);
            string duration = Request.Params["duration"];
            string price = Request.Params["price"];
            string IsSaved = Request.Params["IsSaved"];
            string IsBooked = Request.Params["IsBooked"];
            air.ticketNumber = Convert.ToInt32(ticketNumber);
            air.departureStation = departureStation;
            air.destinationStation = destinationStation;
            air.arrivalTime = arrivalTime.TimeOfDay;
            air.departureTime = departureTime.TimeOfDay;
            air.duration = duration;
            air.price = Convert.ToInt32(price);
            air.IsSaved = Convert.ToBoolean(IsSaved);
            air.IsBooked = Convert.ToBoolean(IsBooked);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50339/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:54300/api/Air/";
            var response = httpClient.PostAsJsonAsync(uri, air);
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
            var uri = "http://localhost:54300/api/Air/" + query[1];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return View();
        }
    }
}