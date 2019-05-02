using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PsychologyCenter.Models
{
    public class OpeningHour
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Day { get; set; }

        [Required]
        [StringLength(250)]
        public string OpenHour { get; set; }

        [Required]
        public int OrderBy { get; set; }
    }
}