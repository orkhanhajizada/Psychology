using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychologyCenter.Models
{
    public class Specialist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required, MinLength(250)]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        List<SpecItem> SpecItems { get; set; }
    }
}