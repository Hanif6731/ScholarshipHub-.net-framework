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
    public class ApplicationToOrganizationController : Controller
    {
        IApplicationToOrganizationRepository App = new ApplicationToOrganizationRepository();
        IOrganizationStudentRepository stRepo = new OrganizationStudentRepository();
        IOrganizationOfferRepository offRepo = new OrganizationOfferRepository();
        [HttpGet]
        public ActionResult StudentApplication()
        {
            return View(App.GetApp());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Organisation");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(stRepo.Get(id));
        }
        [HttpGet]
        public ActionResult Approve(int id)
        {
            return View(App.Get(id));
        }
        [HttpPost,ActionName("Approve")]
        public ActionResult Approves(int id)
        {
            var a = App.Get(id);
            var b = offRepo.Get(a.organizationsOfferID);
            var seat = b.totalseat;
            int x = Int32.Parse(seat) - 1;
           
            if (x >= 0)
            {
                b.totalseat = x.ToString();
                offRepo.Update(b);
                a.AplicationStatus = 1;
                App.Update(a);

                return RedirectToAction("StudentApplication");
            }
            else
            {
                TempData["error"] = "Opps! Seat is fill Up !";
                return RedirectToAction("Approve");
            }
          
           
        }
        [HttpGet]
        public ActionResult Approvelist()
        {
            return View(App.GetApprove());
        }

        [HttpGet]
        public ActionResult Reject(int id)
        {
            return View(App.Get(id));
        }
        [HttpPost,ActionName("Reject")]
        public ActionResult Rejects(int id)
        {
            try
            {
                var a = App.Get(id);
                a.AplicationStatus = 2;
                App.Update(a);
                return RedirectToAction("StudentApplication");
            }
            catch
            {
                return RedirectToAction("Reject");
            }
          
        }
    }
}