using PsychologyCenter.VwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsychologyCenter.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            VwHome model = new VwHome();

            model.Sliders = _context.Sliders.OrderBy(s=>s.OrderBy).ToList();

            model.About = _context.Abouts.FirstOrDefault();

            model.OpeningHours = _context.OpeningHours.OrderBy(o => o.OrderBy).ToList();

            model.Timelines = _context.Timeliness.OrderBy(t => t.OrderBy).ToList();

            model.Services = _context.Services.OrderBy(s => s.OrderBy).ToList();

            model.ChooseUs = _context.ChooseUs.OrderByDescending(c => c.Id).ToList();

            model.Specialists = _context.Specialists.OrderByDescending(s => s.Id).ToList();

            model.Blogs = _context.Blogs.OrderByDescending(b => b.Date).ToList();

            model.Galeries = _context.Galeries.OrderByDescending(g => g.Id).ToList();

            model.Faqs = _context.Faqs.OrderByDescending(f => f.Id).ToList();

            model.Phrases = _context.Phrases.OrderByDescending(p => p.OrderBy).ToList();

            
            return View(model);
        }


    }
}