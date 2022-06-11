using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariAd { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        //***************************************
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        //***************************************
        public bool Durum { get; set; }


        //İLİŞKİLER
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}