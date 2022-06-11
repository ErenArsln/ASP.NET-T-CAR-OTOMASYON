using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        //***************************************
        public bool Durum { get; set; }

        //İLİŞKİLER 
        public ICollection<Urun> Uruns { get; set; }
    }
}