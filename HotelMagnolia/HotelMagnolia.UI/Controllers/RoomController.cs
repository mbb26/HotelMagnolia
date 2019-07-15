using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class RoomController : Controller
    {
        public ActionResult Edit() => View();

        public ActionResult EditPrices() => View();

        public ActionResult ListRoom() => View();

        public ActionResult ListPrice() => View();

        public ActionResult NewRoom() => View();

        public ActionResult NewPrice() => View();
    }
}