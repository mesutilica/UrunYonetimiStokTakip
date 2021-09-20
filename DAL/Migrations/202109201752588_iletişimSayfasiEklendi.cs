namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletişimSayfasiEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        Adi = c.String(nullable: false, maxLength: 50),
                        Soyadi = c.String(maxLength: 50),
                        Mesaj = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Iletisim");
        }
    }
}
