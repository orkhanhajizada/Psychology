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

            model.Blogs = _context.Blogs.Include("BlogCategory").Include("Comments").Include("Likes").Where(b => (Category != null ? b.BlogCategoryId == Category : true)).OrderByDescending(b => b.Date).Skip(0).Take(4).ToList();

            model.Categories = _context.BlogCategories.ToList();
                
            model.BlogCategory = Category;

            return View(model);
        }
        public PartialViewResult PartialBlog()
        {
            List<PsychologyCenter.Models.Blog> Blogs = _context.Blogs.Include("Comments").ToList();
            return PartialView(Blogs);
        }


        public JsonResult GetBlogPartJs(int? CategoryId, int page = 1)
        {
            var data = _context.Blogs.Include("BlogCategory").Where(b => (CategoryId != null ? b.BlogCategoryId == CategoryId : true)).OrderByDescending(b => b.Date).Skip((page - 1) * 4).Take(4).ToList();

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
                    blog.Likes,
                    blog.Comments,
                    Date = blog.Date.ToString("dd MMMM yyyy"),
                    Photo = Url.Content("~/Uploads") + "/" + blog.Photo,
                    
                })
            }, JsonRequestBehavior.AllowGet);
        }




        public ActionResult Read(string Slug)
        {
            VwBlogRead model = new VwBlogRead();

            model.Blogs = _context.Blogs.OrderByDescending(b => b.Date).ToList();

            model.Blog = _context.Blogs.FirstOrDefault(s => s.Slug == Slug);

            model.Categories = _context.BlogCategories.ToList();

            model.Comments = _context.Comments.Where(w => w.IsActive == true).ToList();

            model.Likes = _context.Likes.Where(l => l.BlogId == l.Blog.Id).ToList();


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
       

    }
}