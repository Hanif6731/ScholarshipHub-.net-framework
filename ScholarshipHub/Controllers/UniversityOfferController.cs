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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(uniOfferRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(UniversityOffer offer)
        {
            uniOfferRepo.Update(offer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(uniOfferRepo.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            uniOfferRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(uniOfferRepo.Get(id));
        }

        [HttpGet]
        public ActionResult AppsToUniOffer(int uniOfferId)
        {
            return RedirectToAction("index", "ApplictionsToUniversity", new {uniOfferId});
        }


    }
}