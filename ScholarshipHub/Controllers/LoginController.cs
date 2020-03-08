using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        IUserRepository userRepo = new UserRepository();
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
            if (userRepo.Get(u) == 1)
            {
                var user = userRepo.GetUser(u.Username);
                Session["Username"] = u.Username;
                if (user.Status == 0)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Status == 1)
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (user.Status == 2)
                {
                    return RedirectToAction("Index", "University");
                }
                else if (user.Status == 3)
                {
                    return RedirectToAction("Index", "Organization");
                }
            }
            TempData["error"] = "Wrong Credentials!!";
            return RedirectToAction("Login");
            //return Content("Login Under development... admin status 0, student status 1, university status 2, organisation status 3... happy coding");
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