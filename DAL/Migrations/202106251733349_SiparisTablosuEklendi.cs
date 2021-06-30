namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiparisTablosuEklendi : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Siparis");
        }
    }
}
