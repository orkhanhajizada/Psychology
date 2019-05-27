using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychologyCenter.Models;

namespace PsychologyCenter.VwModels
{
    public class VwHome
    {
        public List<Slider> Sliders { get; set; }

        public About About { get; set; }

        public List<OpeningHour> OpeningHours { get; set; }

        public List<Timeline> Timelines { get; set; }

        public List<Service> Services { get; set; }

        public List<ChooseUs> ChooseUs { get; set; }

        public List<Specialist> Specialists { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<Galery> Galeries { get; set; }

        public List<GaleryCategory> GaleryCategories { get; set; }

        public List<Faq> Faqs { get; set; }

        public List<Phrase> Phrases { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }
    }
}