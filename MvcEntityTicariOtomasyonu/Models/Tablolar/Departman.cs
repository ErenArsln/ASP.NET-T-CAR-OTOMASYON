using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        //*************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        //*************************************
        public bool Durum { get; set; }

        //İLİŞKİLER
        public ICollection<Personel> Personels { get; set; }
    }
}