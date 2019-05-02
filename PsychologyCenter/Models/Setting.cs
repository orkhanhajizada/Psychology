using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PsychologyCenter.Models
{
    public class Setting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Photo { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Adress { get; set; }

        [Required]
        [StringLength(250)]
        public string Facebook { get; set; }

        [Required]
        [StringLength(250)]
        public string Instagram { get; set; }

        [Required]
        [StringLength(250)]
        public string Youtube { get; set; }

        [Required]
        [StringLength(50)]
        public string Lat { get; set; }

        [Required]
        [StringLength(50)]
        public string Lng { get; set; }


        internal string FileManager(HttpPostedFileBase photo)
        {
            throw new NotImplementedException();
        }

    }
}