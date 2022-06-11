using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelYas { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelTelefon { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelMail { get; set; }
        //******************************************
        [Column(TypeName = "VarChar")]
        [StringLength(1000)]
        public string PersonelGörsel { get; set; }
        //******************************************
        public bool Durum { get; set; }

        //İLİŞKİLER
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}