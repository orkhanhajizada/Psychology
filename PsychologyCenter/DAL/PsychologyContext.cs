using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PsychologyCenter.Models;
namespace PsychologyCenter.DAL
{
    public class PsychologyContext:DbContext
    {
        public PsychologyContext() : base("PsychologyContext")
        {

        }


        #region Front
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<ChooseUs> ChooseUs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Galery> Galeries { get; set; }
        public DbSet<GaleryCategory> GaleryCategories { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Timeline> Timeliness { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ReadCount> ReadCounts { get; set; }
        #endregion


    }
}