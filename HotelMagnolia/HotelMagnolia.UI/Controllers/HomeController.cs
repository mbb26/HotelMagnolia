using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Success()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }
        public ActionResult Failure()
        {
            ViewBag.FailureMessage = TempData["FailureMessage"];
            return View();
        }
    }
}