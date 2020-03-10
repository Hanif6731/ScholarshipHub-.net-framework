using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    public class OrganisationController : Controller
    {
        public ActionResult Check()
        {
            string username = @Session["Username"].ToString();
            if (username==null)
            {
                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Index");
        }
        public OrganisationController()
        {
            
        }
        IOrganisationRepository OrgRepo = new OrganisationRepository();
        IUserRepository userRepo = new UserRepository();

        [HttpGet]
        public ActionResult Index()
        {
            string username = @Session["Username"].ToString();
          var org=  OrgRepo.GetOrganisation(username);
            Session["Name"] = org.Name;
            Session["OrgID"] = org.id;
            Session["Email"] = org.Email;
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
           string username= @Session["Username"].ToString();
            return View(OrgRepo.GetOrganisation(username));
        }
        [HttpGet]
        public ActionResult Personal()
        {
            string username = @Session["Username"].ToString();
            return View(OrgRepo.GetOrganisation(username));
        }
        [HttpPost]
        public ActionResult Personal(Organisation org)
        {

            try
            {
                Session["Username"] = org.Username;



                OrgRepo.UpdatePersonal(org);

                return RedirectToAction("Profile");
            }
            catch
            {
                TempData["error"] = "Some Field is Blank!";
                 return RedirectToAction("Personal");
            }


               


        }
        [HttpGet]
        public ActionResult Address( )
        {
            string username = @Session["Username"].ToString();
            return View(OrgRepo.GetOrganisation(username));

        }
        [HttpPost]
        public ActionResult Address(Organisation org)
        {
            try
            {
               
                OrgRepo.UpdatePersonal(org);

                return RedirectToAction("Profile");
            }
            catch
            {
                TempData["error"] = "Some Field is Blank!";
                return RedirectToAction("Address");
            }


        }
        [HttpGet]
        public ActionResult Attachment()
        {
            string username = @Session["Username"].ToString();
            return View(OrgRepo.GetOrganisation(username));

        }
        [HttpPost]
        public ActionResult Attachment(Organisation org)
        {

            try
            {

            
                string fileName1 = Path.GetFileNameWithoutExtension(org.ApprovalFile.FileName);
                string extension1 = Path.GetExtension(org.ApprovalFile.FileName);
                fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                org.ApprovalPath = fileName1;
                fileName1 = Path.Combine(Server.MapPath("~/Organization/Approval/"), fileName1);
                org.ApprovalFile.SaveAs(fileName1);

                string fileName2 = Path.GetFileNameWithoutExtension(org.InformationFile.FileName);
                string extension2 = Path.GetExtension(org.InformationFile.FileName);
                fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                org.Information = fileName2;
                fileName2 = Path.Combine(Server.MapPath("~/Organization/Information/"), fileName2);
                org.InformationFile.SaveAs(fileName2);

                OrgRepo.UpdatePersonal(org);

                return RedirectToAction("Profile");
            }
            catch
            {
                TempData["error"] = "File  path  is Blank!";
                return RedirectToAction("Attachment");
            }


        }



        [HttpGet]
        public ActionResult Password()
        {

            string username = @Session["Username"].ToString();
            return View(OrgRepo.GetOrganisation(username));

        }
        [HttpPost]
        public ActionResult Password(Organisation org)
        {

            try
            {
              
      
                OrgRepo.UpdatePersonal(org);

                return RedirectToAction("Profile");
            }
            catch
            {
                TempData["error"] = "Password Field is Blank!";
                return RedirectToAction("Password");
            }

        }


      
    }
}