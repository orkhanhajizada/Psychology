using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PsychologyCenter.Models
{
    public class Like
    {

        public int Id { get; set; }

        public int BlogId { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Ip { get; set; }

        public Blog Blog { get; set; }
    }
}