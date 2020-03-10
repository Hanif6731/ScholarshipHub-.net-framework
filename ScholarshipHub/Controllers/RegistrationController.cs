using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;
using ScholarshipHub.Validation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipHub.Controllers
{
    
    public class RegistrationController : Controller
    {
        IUniversityRepository uniRepo = new UniversityRepository();
        IUserRepository userRepo = new UserRepository();
        IStudentRepository studentRepo = new StudentRepository();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Student student,HttpPostedFileBase ImageFile, HttpPostedFileBase CVFile)
        {
            
            
            
            var user = new User()
            {
                Username = student.Username,
                Password = student.Password,
                Status = 1
            };
            var fileName = Path.GetFileNameWithoutExtension(CVFile.FileName);
            var fileExt = Path.GetExtension(CVFile.FileName);
            fileName = student.Username + "-" + fileName + fileExt;
            var fileUpdatePath = ConfigurationManager.AppSettings["FilesPath"];
            student.CVPath = fileUpdatePath + "\\" + fileName;
            CVFile.SaveAs(student.CVPath);
            student.CVPath = fileName;

            fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            fileExt = Path.GetExtension(ImageFile.FileName);
            fileName = student.Username + "-" + fileName + fileExt;
            fileUpdatePath = ConfigurationManager.AppSettings["ImagesPath"];
            student.ImagePath = fileUpdatePath + "\\" + fileName;
            ImageFile.SaveAs(student.ImagePath);
            student.ImagePath = fileName;

            studentRepo.Insert(student);
            userRepo.Insert(user);
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ActionResult CreateUniversity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUniversity(University uni,string conPass, HttpPostedFileBase ApprovalFile)
        {
            try
            {
                var user = new User()
                {
                    Username = uni.username,
                    Password = uni.password,
                    Status = 2
                };
                if (userRepo.GetUser(user.Username) != null)
                {
                    TempData["error"] = "User Already exists!!!";
                    return RedirectToAction("OrganizationRegistration");
                }
                if (Validate.name(uni.Name) && uni.password.Equals(conPass) && Validate.IsValidEmail(uni.email)
                    && Validate.pass(uni.password))
                {
                    var fileName = Path.GetFileNameWithoutExtension(ApprovalFile.FileName);
                    var fileExt = Path.GetExtension(ApprovalFile.FileName);
                    fileName = uni.username + "-" + fileName + fileExt;
                    string uploadPath = ConfigurationManager.AppSettings["FilesPath"].ToString();
                    uni.ApprovalPath = uploadPath + "\\" + fileName.ToString();
                    // p.Date = DateTime.Now;

                    ApprovalFile.SaveAs(uni.ApprovalPath);
                    uni.ApprovalPath = fileName;
                    uniRepo.Insert(uni);
                    
                    userRepo.Insert(user);

                }
                else
                {
                    TempData["error"] = "Some fields are invalid. Password should be atleast 6 character long";
                    return RedirectToAction("CreateUniversity");
                }
            }
            catch
            {
                TempData["error"] = "Some fields are empty";
                return RedirectToAction("CreateUniversity");
            }

            return RedirectToAction("Login", "Login");
        }

        IOrganisationRepository OrgRepo = new OrganisationRepository();
        [HttpGet]
        public ActionResult OrganizationRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrganizationRegistration(Organisation org)
        {

            try
            {

                var user = new User()
                {
                    Username = org.Username,
                    Password = org.Password,
                    Status = 3
                };

                if (userRepo.GetUser(user.Username) != null)
                {
                    TempData["error"] = "User Already exists!!!";
                    return RedirectToAction("OrganizationRegistration");
                }


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



                OrgRepo.Insert(org);
                userRepo.Insert(user);

                ModelState.Clear();
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                TempData["error"] = "NULL Value OF Some Filed!";
                return RedirectToAction("OrganizationRegistration");

            }






        }

    }
}