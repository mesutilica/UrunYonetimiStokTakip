using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Iletisim : IEntity
    {
        public int Id { get; set; }
        [EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [StringLength(50), Required]
        public string Adi { get; set; }
        [StringLength(50)]
        public string Soyadi { get; set; }
        [Required]
        public string Mesaj { get; set; }
        public DateTime EklenmeTarihi { get; set; }
    }
}
