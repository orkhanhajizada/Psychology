using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyCenter.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BlogId { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public Blog Blog { get; set; }
    }
}