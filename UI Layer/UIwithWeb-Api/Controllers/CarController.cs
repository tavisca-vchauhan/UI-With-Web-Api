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
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult PostOperation()
        {
            Car car = new Car();
            string carName = Request.Params["carName"];
            string carCompany = Request.Params["carCompany"];
            string carModel = Request.Params["carModel"];
            string cost = Request.Params["cost"];
            string color = Request.Params["color"];
            string engine = Request.Params["engine"];
            string IsSaved = Request.Params["IsSaved"];
            string IsBooked = Request.Params["IsBooked"];
            car.carName = carName;
            car.carCompany = carCompany;
            car.carModel = carModel;
            car.cost = Convert.ToInt32(cost);
            car.color = color;
            car.engine = engine;
            car.IsSaved = Convert.ToBoolean(IsSaved);
            car.IsBooked = Convert.ToBoolean(IsBooked);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50339/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:54300/api/Car/";
            var response = httpClient.PostAsJsonAsync(uri, car);
            return View();
        }
        public ActionResult PostData()
        {
            return View();
            
        }

        public ActionResult PutData()
        {
            string values = Request.Params["Save"];
            string[] query = values.Split(',');
            int operation = Convert.ToInt32( query[0]);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50339/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:54300/api/Car/" + query[1];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return View();
        }

        public ActionResult GetAllValues()
        {
            List<Car> list = new List<Car>();
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync("http://localhost:54300/api/Car/").Result;
            list = result.Content.ReadAsAsync<List<Car>>().Result;
            ViewBag.name = "Car";
            return View(list);
        }
    }
}