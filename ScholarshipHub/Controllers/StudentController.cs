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
    public class StudentController : Controller
    {
        // GET: Student
        IUniversityOfferRepository uniOfferRepo = new UniversityOfferRepository();
        IOrganizationOfferRepository orgfferRepo = new OrganizationOfferRepository();
        IStudentRepository studentRepo = new StudentRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var student = studentRepo.GetStudent(@Session["username"].ToString());
            Session["studentId"] = student.id;
            return View(student);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(studentRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase ImageFile, HttpPostedFileBase CVFile)
        {
            if(ImageFile!=null)
            {
                var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                var fileExt = Path.GetExtension(ImageFile.FileName);
                fileName = student.Username + "-" + fileName + fileExt;
                var fileUpdatePath = ConfigurationManager.AppSettings["ImagesPath"];
                student.ImagePath = fileUpdatePath + "\\" + fileName;
                ImageFile.SaveAs(student.ImagePath);
                student.ImagePath = fileName;
            }
            if(CVFile!=null)
            {
                var fileName = Path.GetFileNameWithoutExtension(CVFile.FileName);
                var fileExt = Path.GetExtension(CVFile.FileName);
                fileName = student.Username + "-" + fileName + fileExt;
                var fileUpdatePath = ConfigurationManager.AppSettings["FilesPath"];
                student.CVPath = fileUpdatePath + "\\" + fileName;
                CVFile.SaveAs(student.CVPath);
                student.CVPath = fileName;

            }
            studentRepo.Update(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UniversityOffer()
        {
            return View(uniOfferRepo.GetAll());
        }
        [HttpGet]
        public ActionResult OrganizationOffer()
        {
            return View(orgfferRepo.GetAll());
        }
        [HttpGet]
        public ActionResult ApplyToOrganization(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ApplyToUniversity(int id)
        {
            return View();
        }



        
    }
}