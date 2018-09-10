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
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult PostData()
        {
            return View();
        }

        public ActionResult GetAllValues()
        {
            List<Activity> list = new List<Activity>();
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync("http://localhost:54300/api/Activity").Result;
            list = result.Content.ReadAsAsync<List<Activity>>().Result;
            ViewBag.name = "Activity";
            return View(list);
        }

        public ActionResult PostOperation()
        {
            Activity activity = new Activity();
            string activityName = Request.Params["activityName"];
            string activityDuration = Request.Params["activityDuration"];
            string activityDate = Request.Params["activityDate"];
            string cost = Request.Params["cost"];
            string IsSaved = Request.Params["IsSaved"];
            string IsBooked = Request.Params["IsBooked"];
            activity.activityName = activityName;
            activity.activityDuration = activityDuration;
            activity.activityDate = Convert.ToDateTime( activityDate);
            activity.cost = Convert.ToInt32(cost);
            activity.IsSaved = Convert.ToBoolean(IsSaved);
            activity.IsBooked = Convert.ToBoolean(IsBooked);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50339/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:54300/api/Activity/";
            var response = httpClient.PostAsJsonAsync(uri, activity);
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
            var uri = "http://localhost:54300/api/Activity/" + query[1];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return View();
        }

    }
}