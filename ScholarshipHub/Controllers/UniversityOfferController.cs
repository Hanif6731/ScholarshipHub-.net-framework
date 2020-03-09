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
    public class UniversityOfferController : Controller
    {
        // GET: UniversityOffer
        IUniversityOfferRepository uniOfferRepo = new UniversityOfferRepository();
        public ActionResult Index()
        {
            return View(uniOfferRepo.GetAll((int)@Session["universityId"]));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UniversityOffer offer)
        {
            uniOfferRepo.Insert(offer);
            return RedirectToAction("Index");
        }
    }
}