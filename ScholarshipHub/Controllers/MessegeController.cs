using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    public class MessegeController : Controller
    {
        // GET: Messege
        IMessegeRepository msgRepo = new MessegeRepository();
        [HttpGet]
        public ActionResult Index(string email)
        {
            Session["email"] = email;
            return View(msgRepo.GetAll(email));
        }

        

        [HttpGet]
        public ActionResult Details(int id)
        {

            return View(msgRepo.Get(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            return View(msgRepo.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfrimDelete(int id)
        {
            msgRepo.Delete(id);
            return RedirectToAction("Index", new { email = @Session["email"].ToString() });
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Create(Messege msg)
        {
            msg.Time = DateTime.Now;
            try
            {
                msgRepo.Insert(msg);
            }
            catch
            {
                TempData["error"] = "Empty Credentials";
                return RedirectToAction("Create");
            }
            return RedirectToAction("Index",new{ email=@Session["email"]});
        }


    }
}