using System;
using System.ComponentModel;

namespace Entities
{
    public class Urun : IEntity
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int MarkaId { get; set; }
        [DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public decimal UrunFiyati { get; set; }
        public int Kdv { get; set; }
        [DisplayName("Stok")]
        public int StokMiktari { get; set; }
        public int Iskonto { get; set; }
        public decimal ToptanFiyat { get; set; }
        public string Resim { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Marka Marka { get; set; }
    }
}
