using Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //veritabanı değişikliklerini otomatik olarak uygula
            AutomaticMigrationDataLossAllowed = true; //olası veri kayıplarını kabul ediyorum
            //ContextKey = "DAL.DatabaseContext";
        }

        protected override void Seed(DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!context.Kullanicilar.Any())
            {
                context.Kullanicilar.Add(
                    new Kullanici()
                    {
                        Aktif = true,
                        KullaniciAdi = "Admin",
                        Sifre = "123456",
                        Adi = "Admin",
                        Email = "admin@urunyonetimistoktakip.tr.gg.tc",
                        Soyadi = ""
                    }
                    );
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}
