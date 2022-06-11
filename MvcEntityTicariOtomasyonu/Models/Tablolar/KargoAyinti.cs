using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class KargoAyinti
    {
        [Key]
        public int KargoAyrintiId { get; set; }
        //**************************************
        [Column(TypeName="Varchar")]
        [StringLength(150)]
        public string KargoAciklama { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KargoKodu { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KargoPersonel { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KargoMüsteri { get; set; }
        //**************************************
        public string Tarihi { get; set; }
        public bool KargoDurumu { get; set; }


    }
}