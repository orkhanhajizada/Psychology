using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.DAL;
using PsychologyCenter.Areas.Manage.Models;
using System.Web.Helpers;
using PsychologyCenter.Areas.Manage.Filters;

namespace PsychologyCenter.Areas.Manage.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly PsychologyContext _context = new PsychologyContext();


        public ActionResult Index()
        {

            //return Content(Crypto.HashPassword("1234"));

            if (Session["AdminLogin"] != null)
            {
                return RedirectToAction("index", "dashboard");
            }
            return View();

        }


        public ActionResult Login(Admin admin)
        {
            if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
            {
                Session["LoginError"] = "Email and password must fill";
                return RedirectToAction("index");
            }

            Admin adm = _context.Admins.FirstOrDefault(a => a.Email == admin.Email);



            if (adm != null)
            {
                if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                {
                    Session["AdminLogin"] = true;
                    Session["Admin"] = adm;
                    return RedirectToAction("index", "dashboard");
                }
            }

            Session["LoginError"] = "Email or password incorrect";
            return RedirectToAction("index");


        }

        public ActionResult Logout()
        {
            Session["AdminLogin"] = null;

            Session["Admin"] = null;

            Session.Clear();

            return RedirectToAction("index");
        }
    }
}