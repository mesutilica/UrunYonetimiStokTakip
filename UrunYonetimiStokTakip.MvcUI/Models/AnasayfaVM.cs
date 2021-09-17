using System.Collections.Generic;

namespace UrunYonetimiStokTakip.MvcUI.Models
{
    public class AnasayfaVM
    {
        public List<Entities.Slider> Sliders { get; set; }
        public List<Entities.Urun> Urunler { get; set; }
    }
}