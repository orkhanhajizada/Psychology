using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.VwModels;
using PsychologyCenter.Models;
using System.Net.Mail;
using System.Net;

namespace PsychologyCenter.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            VwHome model = new VwHome();

            model.Sliders = _context.Sliders.OrderBy(s => s.OrderBy).ToList();

            model.About = _context.Abouts.FirstOrDefault();

            model.OpeningHours = _context.OpeningHours.OrderBy(o => o.OrderBy).ToList();

            model.Timelines = _context.Timeliness.OrderBy(t => t.OrderBy).ToList();

            model.Services = _context.Services.OrderBy(s => s.OrderBy).ToList();

            model.ChooseUs = _context.ChooseUs.OrderByDescending(c => c.Id).ToList();

            model.Specialists = _context.Specialists.OrderBy(s => s.Id).ToList();

            model.Blogs = _context.Blogs.OrderByDescending(b => b.Date).ToList();

            model.Galeries = _context.Galeries.Include("GaleryCategory").OrderByDescending(g => g.Id).ToList();

            model.GaleryCategories = _context.GaleryCategories.ToList();

            model.Faqs = _context.Faqs.OrderBy(f => f.Id).ToList();

            model.Comments = _context.Comments.Where(w => w.IsActive == true).ToList();

            model.Likes = _context.Likes.Where(l => l.BlogId == l.Blog.Id).ToList();

            model.Phrases = _context.Phrases.OrderByDescending(p => p.OrderBy).ToList();
            
            return View(model);
        }


        public JsonResult Message(string name, string email, string number,DateTime date, string message)
        {
            


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(number))
            {
                Response.StatusCode = 406;
                return Json("Bütün məlumatlar doldurulmalıdır!", JsonRequestBehavior.AllowGet);
            }

            string body = "<ul><li>Ad soyad : {0}</li><li>E-poçt : {1}</li><li>Mobil nömrə : {2}</li><li>Tarix :  {3}</li></ul><p>{4}</p>";
            var MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress("h.orkhan1907@gmail.com"));  // replace with valid value 
            MailMessage.From = new MailAddress(email);  // replace with valid value
            MailMessage.Subject = "Your email subject";
            MailMessage.Body = string.Format(body, name, email, number, date.ToString("dd.MM.yyyy HH:mm"), message);
            MailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential
                {
                    UserName = "h.orkhan1907@gmail.com",  // replace with valid value
                    Password = "orxan12gfb"  // replace with valid value
                }
            };

            client.Send(MailMessage);


            return Json("Mesajınız e-poçt adresimizə göndərildi", JsonRequestBehavior.AllowGet);
        }


        public JsonResult ContactMessage(string name, string email, string number, string subject, string message)
        {



            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(subject))
            {
                Response.StatusCode = 406;
                return Json("Bütün məlumatlar doldurulmalıdır!", JsonRequestBehavior.AllowGet);
            }

            string body = "<ul><li>Ad soyad : {0}</li><li>E-poçt : {1}</li><li>Mobil nömrə : {2}</li><li>Başlıq :  {3}</li></ul><p>{4}</p>";
            var MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress("h.orkhan1907@gmail.com"));  // replace with valid value 
            MailMessage.From = new MailAddress(email);  // replace with valid value
            MailMessage.Subject = "Your email subject";
            MailMessage.Body = string.Format(body, name, email, number, subject, message);
            MailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential
                {
                    UserName = "h.orkhan1907@gmail.com",  // replace with valid value
                    Password = "orxan12gfb"  // replace with valid value
                }
            };

            client.Send(MailMessage);


            return Json("Mesajınız e-poçt adresimizə göndərildi", JsonRequestBehavior.AllowGet);
        }
    }
}