using System;

namespace Entities
{
    public class Marka : IEntity
    {
        public int Id { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklamasi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
