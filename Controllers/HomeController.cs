using FilterWebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterWebApi.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthenticationFilter]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
