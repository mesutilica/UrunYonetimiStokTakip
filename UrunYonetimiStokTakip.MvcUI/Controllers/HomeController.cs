using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;
using UrunYonetimiStokTakip.MvcUI.Utils;

namespace UrunYonetimiStokTakip.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        SliderManager sliderManager = new SliderManager();
        IletisimManager Iletisim = new IletisimManager();

        public ActionResult Index()
        {
            var sayfaModeli = new Models.AnasayfaVM
            {
                Sliders = sliderManager.GetAll(),
                Urunler = manager.GetAll()
            };
            return View(sayfaModeli);
        }

        public PartialViewResult _PartialMenu()
        {
            return PartialView(kategoriManager.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Arı Yazılım Hakkımızda Sayfası.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Arı Yazılım İletişim Sayfası";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string email, string adi, string soyadi, string mesaj)
        {
            try
            {
                var formMesaj = new Iletisim
                {
                    Adi = adi,
                    EklenmeTarihi = DateTime.Now,
                    Email = email,
                    Mesaj = mesaj,
                    Soyadi = soyadi
                };
                var sonuc = Iletisim.Add(formMesaj);
                //bool mailGonderildiMi = MailHelper.SendMail(formMesaj);
                if (sonuc > 0)// && mailGonderildiMi == true
                {
                    TempData["Mesaj"] = $"Sayın {adi} {soyadi} Mesajınız İletilmiştir!";
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = $"Hata Oluştu! Sayın {adi} {soyadi} Mesajınız İletilememiştir!";
            }

            return View();
        }

        public ActionResult UrunDetay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = manager.Get(id.Value);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        public ActionResult Kategori(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var urunler = manager.GetAll(u => u.KategoriId == id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

    }
}