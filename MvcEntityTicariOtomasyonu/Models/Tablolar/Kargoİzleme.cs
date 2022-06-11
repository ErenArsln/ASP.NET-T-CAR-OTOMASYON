using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Kargoİzleme
    {
        [Key]
        public int KargoIzlemeId { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Aciklama { get; set; }
        //**************************************
        public string Tarihi { get; set; }
        public bool KargoDurumu { get; set; }
    }
}