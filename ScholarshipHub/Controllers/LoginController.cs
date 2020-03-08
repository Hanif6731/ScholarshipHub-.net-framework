using ScholarshipHub.Models;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            //return RedirectToAction("");
            return Content("Login Under development... admin status 0, student status 1, university status 2, organisation status 3... happy coding");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult RegistrationChoice()
        {
            return View();
        }

    }
}