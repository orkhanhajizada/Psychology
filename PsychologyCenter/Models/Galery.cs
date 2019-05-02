using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PsychologyCenter.Models
{
    public class Galery
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required]
        [StringLength(250)]
        public string BigPhoto { get; set; }

        [Required]
        public int GaleryCategoryId { get; set; }

        public GaleryCategory GaleryCategory { get; set; }

    }
}