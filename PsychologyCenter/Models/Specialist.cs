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

        [StringLength(250)]
        public string SpecItem1 { get; set; }

        [StringLength(250)]
        public string SpecItem2 { get; set; }

        [StringLength(250)]
        public string SpecItem3 { get; set; }

        [StringLength(250)]
        public string SpecItem4 { get; set; }

        [StringLength(250)]
        public string SpecItem5 { get; set; }

        [StringLength(250)]
        public string SpecItem6 { get; set; }

        [Required]
        [StringLength(250)]
        public string Icon { get; set; }
        
        public string IsActive { get; set; }
    }
}