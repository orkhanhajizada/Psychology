using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PsychologyCenter.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Slug { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [AllowHtml, Required, MinLength(250)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [AllowHtml, Required, MaxLength(250)]
        [Column(TypeName = "ntext")]
        public string MinAbout { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required]
        [StringLength(250)]
        public string TitlePhoto { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int BlogCategoryId { get; set; }

        public BlogCategory BlogCategory { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }

        public List<ReadCount> ReadCounts { get; set; }

    }
}