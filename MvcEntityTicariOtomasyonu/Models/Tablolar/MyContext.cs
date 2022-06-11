using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class MyContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekats { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<UrunAyrıntı> UrunAyrıntıs { get; set; }
        public DbSet<Yapilacaklar> yapilacaklars { get; set; }
        public DbSet<Kargoİzleme> Kargoİzlemes { get; set; }
        public DbSet<KargoAyinti> KargoAyintis { get; set; }
        public DbSet<CariMesaj> cariMesajs { get; set; }
    }
}