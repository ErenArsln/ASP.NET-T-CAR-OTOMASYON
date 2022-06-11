using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class CariMesaj
    {
        [Key]
        public int MesajId { get; set; }
        //**************************************
        [Column(TypeName="Varchar")]
        [StringLength(25)]
        public string MesajGonderen { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string MesajAlan { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(75)]
        public string Konu { get; set; }
        //**************************************
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string İcerik { get; set; }
        //**************************************
        public DateTime Tarih { get; set; }
        //**************************************
        public bool Durum{ get; set; }
    }
}