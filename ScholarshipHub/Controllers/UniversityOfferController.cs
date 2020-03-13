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
            try
            {
                if (offer.Deadline < DateTime.Today || offer.StartDate < DateTime.Today)
                {
                    TempData["error"] = "Start date and deadline should greater or equal to today";
                    return RedirectToAction("Create");
                }
                if (offer.Deadline<offer.StartDate)
                {
                    TempData["error"] = "deadline should greater than statrtdate";
                    return RedirectToAction("Create");
                }
                uniOfferRepo.Insert(offer);
            }
            catch
            {
                TempData["error"] = "Some fields are empty";
                return RedirectToAction("Create");
            }
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
            try
            {

                if (offer.Deadline < DateTime.Today || offer.StartDate < DateTime.Today)
                {
                    TempData["error"] = "Start date and deadline should greater or equal to today";
                    return RedirectToAction("Edit",new { offer.id});
                }
                if (offer.Deadline < offer.StartDate)
                {
                    TempData["error"] = "deadline should greater than statrtdate";
                    return RedirectToAction("Edit", new { offer.id });
                }
                uniOfferRepo.Update(offer);
            }
            catch
            {
                TempData["error"] = "Some fields are empty";
                return RedirectToAction("Edit",new { offer.id });
            }
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