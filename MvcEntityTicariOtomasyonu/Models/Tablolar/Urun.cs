using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        //***********************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        //***********************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string UrunMarka { get; set; }
        //***********************************
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        //***********************************
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string UrunGorsel { get; set; }

        //İLİŞKİLER 
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        //*********************************************
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}