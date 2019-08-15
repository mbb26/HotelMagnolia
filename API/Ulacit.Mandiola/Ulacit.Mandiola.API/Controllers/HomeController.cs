using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ulacit.Mandiola.API.Controllers
{
    /// <summary>A controller for handling homes.</summary>
    public class HomeController : Controller
    {
        /// <summary>Gets the index.</summary>
        /// <returns>A response stream to send to the Index View.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}