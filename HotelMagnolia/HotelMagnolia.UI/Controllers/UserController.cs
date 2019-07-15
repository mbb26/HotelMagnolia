using System.Web.Mvc;

namespace HotelMagnolia.UI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Admin() => View();

        public ActionResult AssignRole() => View();

        public ActionResult ChangePassword() => View();

        public ActionResult EditUser() => View();

        public ActionResult Index() => View();

        public ActionResult ListRoles() => View();

        public ActionResult ListUser() => View();

        public ActionResult NewUser() => View();
    }
}