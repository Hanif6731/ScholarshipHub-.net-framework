using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    public class UniversityController : Controller
    {
        // GET: University
        IUniversityRepository uniRepo = new UniversityRepository();
        IUserRepository userRepo = new UserRepository();
        public ActionResult Index()
        {
            var uni = uniRepo.GetUniversity(@Session["username"].ToString());
            return View(uni);
            //return Content("Under development");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(University uni,HttpPostedFileBase ApprovalFile)
        {
            var fileName = Path.GetFileNameWithoutExtension(ApprovalFile.FileName);
            var fileExt = Path.GetExtension(ApprovalFile.FileName);
            fileName = uni.username +"-"+ fileName + fileExt;
            string uploadPath = ConfigurationManager.AppSettings["FilesPath"].ToString();
            uni.ApprovalPath = uploadPath + "\\" + fileName.ToString();
            // p.Date = DateTime.Now;

            ApprovalFile.SaveAs(uni.ApprovalPath);
            uni.ApprovalPath = fileName;
            uniRepo.Insert(uni);
            var user = new User()
            {
                Username = uni.username,
                Password=uni.password,
                Status=2
            };
            userRepo.Insert(user);



            return RedirectToAction("Login","Login");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(uniRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(University uni, HttpPostedFileBase ApprovalFile)
        {
            if (ApprovalFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(ApprovalFile.FileName);
                var fileExt = Path.GetExtension(ApprovalFile.FileName);
                fileName = uni.username + "-" + fileName + fileExt;
                string uploadPath = ConfigurationManager.AppSettings["FilesPath"].ToString();
                uni.ApprovalPath = uploadPath + "\\" + fileName.ToString();
                // p.Date = DateTime.Now;

                ApprovalFile.SaveAs(uni.ApprovalPath);
                uni.ApprovalPath = fileName;
            }
            uniRepo.Update(uni);

            var user = userRepo.GetUser(uni.username);
            user.Password = uni.password;
            userRepo.Update(user);



            return RedirectToAction("Index");
        }
    }
}