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

            model.Blogs = _context.Blogs.OrderByDescending(b => b.Date).Take(4).ToList();

            model.Galeries = _context.Galeries.Include("GaleryCategory").OrderByDescending(g => g.Id).ToList();

            model.GaleryCategories = _context.GaleryCategories.ToList();

            model.Faqs = _context.Faqs.OrderBy(f => f.Id).ToList();

            model.Comments = _context.Comments.Where(w => w.IsActive == true).ToList();

            model.Likes = _context.Likes.Where(l => l.BlogId == l.Blog.Id).ToList();

            model.ReadCounts = _context.ReadCounts.Where(r => r.BlogId == r.Blog.Id).ToList();

            model.Phrases = _context.Phrases.OrderByDescending(p => p.OrderBy).ToList();


            return View(model);
        }


        public JsonResult Message(string name, string email, string number,string date, string message)
        {

            DateTime returnDate = Convert.ToDateTime(date);

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
            MailMessage.Body = string.Format(body, name, email, number, returnDate.ToString("dd.MM.yyyy HH:mm"), message);
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
            Session["MessageSent"] = true;
           
            return Json(new {status="200" }  ,JsonRequestBehavior.AllowGet);
        }


        public JsonResult ContactMessage(string name1, string email1, string phone1, string subject1, string message1)
        {



            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(email1) || string.IsNullOrEmpty(message1) || string.IsNullOrEmpty(subject1) || string.IsNullOrEmpty(phone1))
            {
                Response.StatusCode = 406;
                return Json("Bütün məlumatlar doldurulmalıdır!", JsonRequestBehavior.AllowGet);
            }

            string body = "<ul><li>Ad soyad : {0}</li><li>E-poçt : {1}</li><li>Mobil nömrə : {2}</li><li>Başlıq :  {3}</li></ul><p>{4}</p>";
            var MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress("h.orkhan1907@gmail.com"));  // replace with valid value 
            MailMessage.From = new MailAddress(email1);  // replace with valid value
            MailMessage.Subject = "Your email subject";
            MailMessage.Body = string.Format(body, name1, email1, phone1, subject1, message1);
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
            Session["Message1Sent"] = true;

            return Json(new { status = "200" }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Like(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(f => f.Id == id);
            if (blog != null)
            {
                string userIP = GetIPAddress();
                Like like = _context.Likes.FirstOrDefault(f => f.BlogId == id && f.Ip == userIP);
                if (like == null)
                {
                    Like likePost = new Like();
                    likePost.BlogId = id;
                    likePost.Ip = userIP;
                    likePost.Date = DateTime.UtcNow.AddHours(4);
                    _context.Likes.Add(likePost);
                    _context.SaveChanges();
                    return Json(new { Status = "200" }, JsonRequestBehavior.AllowGet);
                }
             
            }
            return Json(new { Status = "404" }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CommentBlog(string name, string message, int blogId)
        {
            Blog blog = _context.Blogs.FirstOrDefault(f => f.Id == blogId);
            if (blog != null)
            {

                Comment comment = new Comment();
                comment.Name = name;
                comment.BlogId = blog.Id;
                comment.Date = DateTime.UtcNow.AddHours(4);
                comment.Content = message;
                comment.IsActive = false;
                _context.Comments.Add(comment);
                _context.SaveChanges();

                return Json(new { Status = "200" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = "404" }, JsonRequestBehavior.AllowGet);
        }


        public string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            string ip = context.Request.ServerVariables["REMOTE_ADDR"];
            return ip;
        }


        
    }
}