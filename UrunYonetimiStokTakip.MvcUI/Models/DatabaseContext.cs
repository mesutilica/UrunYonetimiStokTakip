using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace UrunYonetimiStokTakip.MvcUI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {
            
        }

        public virtual DbSet<Kategori> Kategoriler { get; set; } //veritabanı tablolarımızı temsil eden yapılar..
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Siparis> Siparisler { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //veritabanında oluşacak olan tabloların isimlerine s takısı gelmemesi için
            base.OnModelCreating(modelBuilder);
        }        
        
    }
}