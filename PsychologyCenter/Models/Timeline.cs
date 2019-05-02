using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PsychologyCenter.Models
{
    public class Timeline
    {
        public int Id { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Text { get; set; }
    }
}