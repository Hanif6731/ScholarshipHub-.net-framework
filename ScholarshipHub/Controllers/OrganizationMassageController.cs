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
    public class OrganizationMassageController : Controller
    {
        IOrgMessegeRepository massRepo = new OrgMessegeRepository();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Compose(Messege messege)
        {
            try
            {
                massRepo.Insert(messege);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Some Field is Blank!";

                return RedirectToAction("Compose");
            }
            
        }
        [HttpGet]
        public ActionResult ViewEmail()
        {
            try
            {
                string email = Session["Email"].ToString();

                return View(massRepo.GetMessege(email));
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(massRepo.Get(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(massRepo.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult confirmDelete(int id)
        {
            try
            {
                massRepo.Delete(id);
                return RedirectToAction("ViewEmail");
            }
            catch
            {
                return RedirectToAction("Delete");
            }
        }
        [HttpGet]
        public ActionResult Reply(int id)
        {
            return View(massRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Reply(Messege messege)
        {
            try
            {
                massRepo.Insert(messege);
                return RedirectToAction("ViewEmail");
            }
            catch
            {
                return RedirectToAction("Reply");
            }
            
        }
        [HttpGet]
        public ActionResult SentEmail()
        {
            string email = Session["Email"].ToString();
            return View(massRepo.GetMessegeset(email));
        }
        public ActionResult DetailsSent(int id)
        {
            return View(massRepo.Get(id));
        }
        [HttpGet]
        public ActionResult DeleteSent(int id)
        {
            return View(massRepo.Get(id));
        }
        [HttpPost,ActionName("DeleteSent")]
        public ActionResult DeleteSents(int id)
        {
            try
            {
                massRepo.Delete(id);
                return RedirectToAction("SentEmail");
            }
            catch
            {
                return RedirectToAction("DeleteSent");
            }
        }
    }
}