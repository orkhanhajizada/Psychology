using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PsychologyCenter.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required, MinLength(100)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }
    }
}