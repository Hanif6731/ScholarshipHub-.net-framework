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
    public class OrganisationOfferController : Controller
    {
        IOrganizationOfferRepository Orgoffer = new OrganizationOfferRepository();
        [HttpGet]
        public ActionResult Offer()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Offer(OrganizationOffer offer)
        {
            try
            {
                Orgoffer.Insert(offer);

                return RedirectToAction("Index", "Organisation");
            }
            catch
            {
                TempData["error"] = "Some Field is Blank!";

                return RedirectToAction("Offer");
            }
           

        }
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Organisation");
        }
        [HttpGet]
        public ActionResult Offerlist()
        {
            return View(Orgoffer.GetAll());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Orgoffer.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(OrganizationOffer offer)
        {
            try
            {
                Orgoffer.Update(offer);
                return RedirectToAction("Details", new { @id = offer.id });
            }
            catch
            {
                TempData["error"] = "Some Field is Blank!";
                return RedirectToAction("Edit");
            }
           
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            return View(Orgoffer.Get(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            return View(Orgoffer.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                Orgoffer.Delete(id);
                return RedirectToAction("Offerlist");
            }
            catch
            {
                return RedirectToAction("Delete");
            }
            
        }


    }
}