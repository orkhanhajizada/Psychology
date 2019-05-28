using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.VwModels;
using PsychologyCenter.Models;
namespace PsychologyCenter.Controllers
{
    public class BlogController : BaseController
    {
        
        public ActionResult Index(int? Category)
        {
            VwBlog model = new VwBlog();

            model.Blogs = _context.Blogs.Include("BlogCategory").Include("Comments").Include("Likes").Include("ReadCounts").Where(b => (Category != null ? b.BlogCategoryId == Category : true)).OrderByDescending(b => b.Date).Skip(0).Take(4).ToList();

            model.Categories = _context.BlogCategories.ToList();
                
            model.BlogCategory = Category;

           

            return View(model);
        }




        public ActionResult Read(string Slug)
        {
            Blog blog = _context.Blogs.FirstOrDefault(f => f.Slug == Slug);
            if (blog != null)
            {
                string userIP = GetIPAddress();
                ReadCount read = _context.ReadCounts.FirstOrDefault(f => f.BlogId == blog.Id && f.Ip == userIP);
                if (read == null)
                {
                    ReadCount readCount = new ReadCount();
                    readCount.BlogId = blog.Id;
                    readCount.Ip = userIP;
                    readCount.Date = DateTime.Now;
                    _context.ReadCounts.Add(readCount);
                    _context.SaveChanges();
                }

            }

            VwBlogRead model = new VwBlogRead();

            model.Blogs = _context.Blogs.OrderByDescending(b => b.Date).ToList();

            model.Blog = _context.Blogs.FirstOrDefault(s => s.Slug == Slug);

            model.Categories = _context.BlogCategories.ToList();

            model.Comments = _context.Comments.Where(w => w.IsActive == true).ToList();

            model.Likes = _context.Likes.Where(l => l.BlogId == l.Blog.Id).ToList();

            model.ReadCounts = _context.ReadCounts.Where(r => r.BlogId == r.Blog.Id).ToList();
            

            if (string.IsNullOrEmpty(Slug))
            {
                return HttpNotFound();
            }


            if (model == null)
            {
                return HttpNotFound();
            }

           

            return View(model);
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