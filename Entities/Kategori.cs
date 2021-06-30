using System;

namespace Entities
{
    public class Kategori : IEntity
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklamasi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
