using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScholarshipHub.Interfaces;
using ScholarshipHub.Models;
using ScholarshipHub.Repository;


namespace ScholarshipHub.Controllers
{
    public class AdminController : Controller
    {
        IAdminRepository adminRepo = new AdminRepository();
        IUserRepository userRepo = new UserRepository();
        IUniversityOfferRepository uniOfferRepo = new UniversityOfferRepository();


        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("UniversityOffer");
        }
        public ActionResult AdminPanel()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchId()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchId(String username)
        {
            return RedirectToAction("Modify");

        }
        [HttpGet]
        public ActionResult Modify(String username)
        {
            return View(adminRepo.GetAdminByID(username));
        }

        [HttpPost]

        public ActionResult Modify(FormCollection collection)
        {
            Admin ad = adminRepo.GetAdminByID(collection.Get("username"));
            ad.name = collection.Get("name");
            ad.password = collection.Get("password");
            ad.salary = Convert.ToInt32( collection.Get("salary"));
            ad.email = collection.Get("email");
            adminRepo.Update(ad);
            return RedirectToAction("AdminPanel");

        }

        [HttpGet]
        public ActionResult SearchName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchName(string name)
        {
            return RedirectToAction("ModifyAdmin");
        }

        [HttpGet]
        public ActionResult ModifyAdmin(string name)
        {
            return View(adminRepo.GetAdminByName(name));
        }

        [HttpPost]

        public ActionResult ModifyAdmin(FormCollection collection)
        {
            Admin ad = adminRepo.GetAdminByID(collection.Get("username"));
            ad.name = collection.Get("name");
            ad.password = collection.Get("password");
            ad.salary = Convert.ToInt32(collection.Get("salary"));
            ad.email = collection.Get("email");
            adminRepo.Update(ad);
            return RedirectToAction("AdminPanel");

        }

        [HttpGet]
        public ActionResult Admins()
        {
            return View(adminRepo.GetAll());
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            //return Content("Add Admin");
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(FormCollection collection)
        {

            
            var admin = new Admin()
            {
                username = collection.Get("username"),
                password = collection.Get("password"),
                name = collection.Get("name"),
                salary =Convert.ToInt32( collection.Get("salary")),
                salarystatus = 1,
                balance = Convert.ToInt32(collection.Get("salary")),
                email = collection.Get("email")

            };
            adminRepo.Insert(admin);
            var user = new User()
            {
                Username = collection.Get("username"),
                Password = collection.Get("password"),
                Status = 5
            };
            userRepo.Insert(user);


            return RedirectToAction("AdminPanel");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(adminRepo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            adminRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Myaccount()
        {
            var username = Session["Username"];
            Admin adm = adminRepo.GetAdminByID(Convert.ToString(username));
            //return Content(adm.email);
            return View(adm);

        }

        [HttpGet]
        public ActionResult withdraw()
        {
            return View(adminRepo.GetAdminByID(Session["Username"].ToString()));
        }

        [HttpPost]
        public ActionResult withdraw(string withdrawamount)
        {
            Admin adm = adminRepo.GetAdminByID(Session["Username"].ToString());

            if(adm.balance >Convert.ToInt32(withdrawamount))
            {
                adm.balance = adm.balance - Convert.ToInt32(withdrawamount);
                adminRepo.Update(adm);
                return RedirectToAction("MyAccount");
            }

            else
            {
                return Content("Insufficient Balance");
            }
        }

        [HttpGet]
        public ActionResult ClearPayment()
        {
            if (Convert.ToInt32(Session["status"].ToString()) == 0)
            {

                return View(adminRepo.GetAll());
            }
            else
                return Content("You are not Authorised");
        }

        [HttpGet]
        public ActionResult Clear(int id )
        {
            Admin adm = adminRepo.Get(id);

            if (adm.salarystatus ==0)
            {
                adm.balance = adm.balance + adm.salary;
                adm.salarystatus = 1;
                adminRepo.Update(adm);
                return RedirectToAction("ClearPayment");
            }

            else
            {
                return Content("payment Done ");
            }
        }

        [HttpGet]
        public ActionResult Payment()
        {
            return RedirectToAction("MyAccount");
        }

        [HttpGet]

        public ActionResult UniversityOffer()
        {
            return View(uniOfferRepo.GetAll());
        }
    }

}