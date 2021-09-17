using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        SliderManager sliderManager = new SliderManager();

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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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