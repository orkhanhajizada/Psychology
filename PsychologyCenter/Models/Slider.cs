using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PsychologyCenter.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title1 { get; set; }

        [Required]
        [StringLength(150)]
        public string Title2 { get; set; }

        [Required]
        [StringLength(150)]
        public string Text { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required]
        public int OrderBy { get; set; }
    }
}