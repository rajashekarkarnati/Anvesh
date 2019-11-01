using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentStaffApp.Models;

namespace StudentStaffApp.Controllers
{
    public class LoginController : Controller
    {

        private readonly Training_20Feb_MumbaiEntities db = new Training_20Feb_MumbaiEntities();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLogin admin)
        {
            var IsAdminExists = db.AdminLogins.Where(a => a.adminUsername == admin.adminUsername).SingleOrDefault();
            if(IsAdminExists != null)
            {
                if(IsAdminExists.adminpassword == admin.adminpassword)
                {
                    return RedirectToAction("MainPage");
                }
                else { ModelState.AddModelError("adminpassword", "Password Not matched"); }
            }
            else { ModelState.AddModelError("adminUsername", "Admin Id Not Exists"); }
            return View();
        }

        public ActionResult MainPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MainPage(string usertype)
        {
            if(usertype == "Student")
            {
                Session["usertype"] = usertype;
                return RedirectToAction("Index", "Student");
            }
            Session["usertype"] = usertype;
            return RedirectToAction("Index", "StaffDetails");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}