using MongoDBWithDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDBWithDotNet.Controllers
{
    public class HomeController : Controller
    {
        MongoContext ctx = new MongoContext();
        public ActionResult Index()
        {
            
            var emp= ctx.GetEmployeeDepartment("Mohit");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}