using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacakId { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string YapilacakBaslik { get; set; }

        //******************************************
        [Column(TypeName = "Bit")]
        public bool Durum { get; set; }
    }
}