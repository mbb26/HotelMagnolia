using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Admin() => View();

        public ActionResult AssignRole() => View();

        public ActionResult ChangePassword() => View();
    }
}