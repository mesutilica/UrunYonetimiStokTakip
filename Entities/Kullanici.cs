namespace Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool Aktif { get; set; }
    }
}
