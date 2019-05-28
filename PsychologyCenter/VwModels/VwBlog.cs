using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PsychologyCenter.Models;

namespace PsychologyCenter.VwModels
{
    public class VwBlog
    {
      
        public List<Blog> Blogs { get; set; }

        public List<BlogCategory> Categories { get; set; }

        public int? BlogCategory { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }

        public List<ReadCount> ReadCounts { get; set; }

    }

    public class VwBlogRead
    {
        public Blog Blog { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<BlogCategory> Categories { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }

        public List<ReadCount> ReadCounts { get; set; }
    }
}