using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class ConsecutiveController : Controller
    {
        public ActionResult ListConsecutive() => View();

        public ActionResult NewConsecutive() => View();
    }
}