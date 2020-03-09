using System;
using ScholarshipHub.Interfaces;
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
    }
}