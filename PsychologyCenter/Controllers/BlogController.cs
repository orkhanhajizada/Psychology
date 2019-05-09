using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsychologyCenter.Controllers
{
    public class BlogController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

    }
}