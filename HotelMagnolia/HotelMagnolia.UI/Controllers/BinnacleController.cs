using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class BinnacleController : Controller
    {
        public ActionResult CheckBinnacle() => View();

        public ActionResult CheckErrors() => View();
    }
}