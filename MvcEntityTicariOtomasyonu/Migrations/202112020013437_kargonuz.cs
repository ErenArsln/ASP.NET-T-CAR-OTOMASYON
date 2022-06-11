namespace MvcEntityTicariOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargonuz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoAyintis",
                c => new
                    {
                        KargoAyrintiId = c.Int(nullable: false, identity: true),
                        KargoAciklama = c.String(maxLength: 150, unicode: false),
                        KargoKodu = c.String(maxLength: 10, unicode: false),
                        KargoPersonel = c.String(maxLength: 20, unicode: false),
                        KargoMüsteri = c.String(maxLength: 20, unicode: false),
                        Tarihi = c.String(),
                        KargoDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KargoAyrintiId);
            
            CreateTable(
                "dbo.Kargoİzleme",
                c => new
                    {
                        KargoIzlemeId = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Aciklama = c.String(maxLength: 150, unicode: false),
                        Tarihi = c.String(),
                        KargoDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KargoIzlemeId);
            
            //DropTable("dbo.KargoDetays");
            //DropTable("dbo.KargoTakips");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.KargoTakips",
            //    c => new
            //        {
            //            KargoTakipId = c.Int(nullable: false, identity: true),
            //            Aciklama = c.String(maxLength: 150, unicode: false),
            //            Personel = c.String(maxLength: 20, unicode: false),
            //            Kod = c.String(maxLength: 20, unicode: false),
            //            Cari = c.String(maxLength: 20, unicode: false),
            //            Tarih = c.DateTime(nullable: false),
            //            Durum = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.KargoTakipId);
            
            //CreateTable(
            //    "dbo.KargoDetays",
            //    c => new
            //        {
            //            KargoDetayId = c.Int(nullable: false, identity: true),
            //            Aciklama = c.String(maxLength: 150, unicode: false),
            //            Kod = c.String(maxLength: 20, unicode: false),
            //            Personel = c.String(maxLength: 20, unicode: false),
            //            Cari = c.String(maxLength: 50, unicode: false),
            //            Tarih = c.DateTime(nullable: false),
            //            Durum = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.KargoDetayId);
            
            DropTable("dbo.Kargoİzleme");
            DropTable("dbo.KargoAyintis");
        }
    }
}
