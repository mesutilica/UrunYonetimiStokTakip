using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());//entity frameworkdeki database sýnýfý içerisinde yer alan SetInitializer metoduna kendi yazdýðýmýz DatabaseInitializer sýnýfýný yolluyoruz, böylece bu sýnýf içerisindeki yapýlandýrma ayarlarý iþlenecek
        }

        public virtual DbSet<Kategori> Kategoriler { get; set; } //veritabaný tablolarýmýzý temsil eden yapýlar..
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Siparis> Siparisler { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritabanýnda oluþacak olan tablolarýn isimlerine s takýsý gelmemesi için
            base.OnModelCreating(modelBuilder);
        }
        //Migratiton : Veritabaný güncelleme
        public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>//DropCreateDatabaseIfModelChanges<DatabaseContext> //CreateDatabaseIfNotExists eðer veritabaný yoksa oluþtur <DatabaseContext> içerisindeki dbset lere göre
        {
            protected override void Seed(DatabaseContext context)//Seed metodu veritabaný oluþturulduktan sonra devreye girip iþlem yapmamýzý saðlar
            {
                if (!context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(
                        new Kullanici()
                        {
                            Aktif = true,
                            KullaniciAdi = "Admin",
                            Sifre = "123456"
                        }
                        );
                    context.SaveChanges();
                }
                base.Seed(context);
            }
        }
    }    
}
/*
 * Migration Ýþlemleri ile veritabanýný silmeden tablolarý güncelleyebilir veya tabloda class larda yaptýðýmýz deðiþiklikleri kullanarak güncelleme yapabiliyoruz.
 * Migrationu Aktif Etmek Ýçin Yapýlacaklar
 * 1-Öncelikle PMC package manager console kapalý ise onu VS nun üst menüsünde view > other windows > package manager console yolunu kullanarak aktif ediyoruz. PMC ile komutlar kullanarak paket yükleme (Entity framework vb), migration iþlemler vb yapabilmek için.
 * 2-PMC ekranýnda komut çalýþtýracaðýmýz projeyi (DAL katmaný) Default project alanýndan seçiyoruz. EF nin bu katmanda yüklü olmasý gerekir!
 * 3-Komut satýrýna enable-migrations komutunu yazýp enter ile çalýþtýrdýk ve DAL katmanýnda Migrations klasörü ve içindeki classlar oluþmasý lazým iþlem baþarýlý ise, iþlem baþarýsýz olursa EF sürümünü son sürüme almayý dene, yine çalýþmazsa sürüm düþürerek dene, katmanlardaki EF sürümlerinin ayný sürüm olduðundan emin ol
 * 4-Oluþan Migrations ý veritabanýna uygulamak için PMC ye update-database yazýp enter a basmamýz gerek.
 * 5-Daha sonra model class larýmýzda yapacaðýmýz deðiþiklik sonrasý veritabanýný güncellemek için Add-Migration Migrationismi þeklinde Migrationa bir isim vererek enter diyoruz
 * 6-Eklediðimiz Migration ý iþlemek için yine update-database komutunu çalýþtýrýyoruz
 */