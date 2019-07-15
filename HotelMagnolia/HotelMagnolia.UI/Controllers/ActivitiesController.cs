using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class ActivitiesController : Controller
    {
        public ActionResult Edit() => View();

        public ActionResult ListActivities() => View();

        public ActionResult NewActivities() => View();
    }
}