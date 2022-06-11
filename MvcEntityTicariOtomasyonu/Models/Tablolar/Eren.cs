using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Eren
    {
        [Key]
        public int ErenId { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(20)]
        public string irfan { get; set; }
    }
}