using System;
using System.Net;
using System.Web.Mvc;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        //KategoriManager manager = new KategoriManager();
        Repository<Kategori> manager = new Repository<Kategori>();
        // GET: Admin/Kategori
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    kategori.EklenmeTarihi = DateTime.Now;
                    var sonuc = manager.Add(kategori);
                    if (sonuc > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else ModelState.AddModelError("", "Kayıt Eklenemedi!");
                }
                catch (Exception hata) //buradaki hata nesnesinden hata detaylarına ulaşabiliriz
                {
                    ModelState.AddModelError("", "Hata Oluştu! Kayıt Eklenemedi!");
                }
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = manager.Get(id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }
        [HttpPost]
        public ActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                manager.Update(kategori);

                return RedirectToAction("Index");
            }
            return View(kategori);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = manager.Get(id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                Kategori kategori = manager.Get(id.Value);
                manager.Delete(kategori.Id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("","Hata oluştu!");
            }
            return RedirectToAction("Index");
        }
    }
}