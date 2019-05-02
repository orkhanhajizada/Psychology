using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PsychologyCenter.Models
{
    public class Phrase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }


        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required]
        public int OrderBy { get; set; }
    }
}