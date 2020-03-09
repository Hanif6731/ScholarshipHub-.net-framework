using System;
using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScholarshipHub.Repository;

namespace ScholarshipHub.Controllers
{
    public class ApplictionsToUniversityController : Controller
    {
        IApplictionsToUniversityRepository appToUniRepo = new ApplictionsToUniversityRepository();
        // GET: ApplicationsToUniversty

        public ActionResult Index(int uniOfferId)
        {
            
            var appToUni = appToUniRepo.GetAll(uniOfferId);
            return View(appToUni);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(appToUniRepo.Get(id));
        }


        [HttpGet]
        public ActionResult Comment(int id)
        {
            return View(appToUniRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Comment(ApplictionsToUniversity appsToUni)
        {
            appToUniRepo.Update(appsToUni);
            return RedirectToAction("Index",new { uniOfferId=appsToUni.UniversityOfferID });
        }

        [HttpGet]
        public ActionResult Accept(int id)
        {
            return View(appToUniRepo.Get(id));
        }
        [HttpPost, ActionName("Accept")]
        public ActionResult ConfirmAccept(int id)
        {
            var appsToUni = appToUniRepo.Get(id);
            appsToUni.AplicationStatus = 1;
            appsToUni.ApplicationInformation = "Application is Accepted";
            appToUniRepo.Update(appsToUni);
            return RedirectToAction("Index", new { uniOfferId = appsToUni.UniversityOfferID });
        }

        [HttpGet]
        public ActionResult Reject(int id)
        {
            return View(appToUniRepo.Get(id));
        }
        [HttpPost, ActionName("Reject")]
        public ActionResult ConfirmReject(int id)
        {
            var appsToUni = appToUniRepo.Get(id);
            appsToUni.AplicationStatus = 0;
            appsToUni.ApplicationInformation = "Application is Rejected";
            appToUniRepo.Update(appsToUni);
            return RedirectToAction("Index", new { uniOfferId = appsToUni.UniversityOfferID });
        }


    }
}