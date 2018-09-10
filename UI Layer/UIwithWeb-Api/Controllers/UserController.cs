using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIwithWeb_Api.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ShowUserContent()
        {
            return View();
        }
    }
}