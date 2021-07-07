namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloBaglantilari : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                        Aciklamasi = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                        Email = c.String(),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marka",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkaAdi = c.String(),
                        Aciklamasi = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musteri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiparisNo = c.String(),
                        MusteriId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        SiparisTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musteri", t => t.MusteriId, cascadeDelete: true)
                .ForeignKey("dbo.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.MusteriId)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.Urun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriId = c.Int(nullable: false),
                        MarkaId = c.Int(nullable: false),
                        UrunAdi = c.String(),
                        Aciklama = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                        UrunFiyati = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kdv = c.Int(nullable: false),
                        StokMiktari = c.Int(nullable: false),
                        Iskonto = c.Int(nullable: false),
                        ToptanFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategori", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Marka", t => t.MarkaId, cascadeDelete: true)
                .Index(t => t.KategoriId)
                .Index(t => t.MarkaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Siparis", "UrunId", "dbo.Urun");
            DropForeignKey("dbo.Urun", "MarkaId", "dbo.Marka");
            DropForeignKey("dbo.Urun", "KategoriId", "dbo.Kategori");
            DropForeignKey("dbo.Siparis", "MusteriId", "dbo.Musteri");
            DropIndex("dbo.Urun", new[] { "MarkaId" });
            DropIndex("dbo.Urun", new[] { "KategoriId" });
            DropIndex("dbo.Siparis", new[] { "UrunId" });
            DropIndex("dbo.Siparis", new[] { "MusteriId" });
            DropTable("dbo.Urun");
            DropTable("dbo.Siparis");
            DropTable("dbo.Musteri");
            DropTable("dbo.Marka");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Kategori");
        }
    }
}
