using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PsychologyCenter.Models
{
    public class Faq
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Question { get; set; }

        [Required, MinLength(250)]
        [Column(TypeName = "ntext")]
        public string Answer { get; set; }
    }
}