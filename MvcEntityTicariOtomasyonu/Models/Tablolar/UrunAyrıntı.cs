using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class UrunAyrıntı
    {
        [Key]
        public int AyrintiId { get; set; }
        //***************************************
        [Column(TypeName="VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(2250)]
        public string UrunBilgi { get; set; }
    }
}