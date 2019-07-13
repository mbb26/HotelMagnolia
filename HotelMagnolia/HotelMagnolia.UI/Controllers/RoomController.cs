using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class RoomController : Controller
    {
        public ActionResult Edit() => View();

        public ActionResult EditPrices() => View();
    }
}