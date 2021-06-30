using System;

namespace Entities
{
    public class Siparis : IEntity
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public DateTime SiparisTarihi { get; set; }
    }
}
