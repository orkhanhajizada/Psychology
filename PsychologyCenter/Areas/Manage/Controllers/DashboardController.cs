using PsychologyCenter.Areas.Manage.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsychologyCenter.Areas.Manage.Controllers
{

    [Auth]
    public class DashboardController : Controller
    {
            public ActionResult Index()
            {
                if (Session["AdminLogin"] == null)
                {
                    return RedirectToAction("index", "login");

                }

                return View();
            }
    }
}