using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologyCenter.Models
{
    public class GaleryCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        List<Galery> Galeries { get; set; } 
    }
}