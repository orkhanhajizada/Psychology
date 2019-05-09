using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.DAL;
using PsychologyCenter.Models;

namespace PsychologyCenter.Controllers
{
    public class BaseController : Controller
    {

        protected readonly PsychologyContext _context = new PsychologyContext();

        public BaseController()
        {
            ViewBag.Setting = _context.Settings.FirstOrDefault();

        }
    }
}