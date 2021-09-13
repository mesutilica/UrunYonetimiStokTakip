using System;
using System.ComponentModel;

namespace Entities
{
    public class Siparis : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Sipariş No")]
        public string SiparisNo { get; set; }
        [DisplayName("Müşteri No")]
        public int MusteriId { get; set; }
        [DisplayName("Ürün No")]
        public int UrunId { get; set; }
        [DisplayName("Sipariş Tarihi")]
        public DateTime SiparisTarihi { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
