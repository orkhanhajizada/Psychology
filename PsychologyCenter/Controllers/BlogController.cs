using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PsychologyCenter.VwModels;
using PsychologyCenter.Models;
using System.Globalization;
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
            

            if (model.Blog == null)
            {
                return RedirectToAction("index","blog");
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


        public JsonResult GetBlogPartJs(int? CategoryId, int page = 1)
        {
            var culture = CultureInfo.CurrentUICulture = new CultureInfo("az-AZ"); 

            var data = _context.Blogs.Include("BlogCategory").Include("Comments").Include("Likes").Include("ReadCounts").Where(b => (CategoryId != null ? b.BlogCategoryId == CategoryId : true)).OrderByDescending(b => b.Date).Skip((page - 1) * 4).Take(4).ToList();

            bool hasNextPage = true;

            int TotalPage = Convert.ToInt32(Math.Ceiling(_context.Blogs.Where(b => (CategoryId != null ? b.BlogCategoryId == CategoryId : true)).Count() / 4.0));

            if (TotalPage == page)
            {
                hasNextPage = false;
            }

            return Json(new
            {
                NextPage = hasNextPage,
                data = data.Select(blog => new {
                    blog.Id,
                    Url = Url.Action("read", "blog", new { Slug = blog.Slug }),
                    blog.Title,
                    blog.MinAbout,
                    DateDay = blog.Date.Day,
                    DateMounth = blog.Date.ToString("MMMM",culture),
                    Like=blog.Likes.Count(),
                    Comment = blog.Comments.Where(w => w.BlogId == blog.Id && w.IsActive==true).Count(),
                    Readcount = blog.ReadCounts.Where(r => r.BlogId == blog.Id).Count(),
                    Photo = Url.Content("~/Uploads") + "/" + blog.TitlePhoto,
                })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}