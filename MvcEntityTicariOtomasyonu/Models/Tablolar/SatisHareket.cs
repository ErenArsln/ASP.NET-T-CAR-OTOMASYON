using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool Durum { get; set; }

        //İLİŞKİLER
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
    }
}