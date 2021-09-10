using System;
using System.Net;
using System.Web.Mvc;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciManager manager = new KullaniciManager();
        // GET: Admin/Kullanici
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }
                
        // GET: Admin/Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kullanici/Create
        [HttpPost]
        public ActionResult Create(Kullanici kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sonuc = manager.Add(kullanici);
                    if (sonuc > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else ModelState.AddModelError("", "Kayıt Eklenemedi!");
                }                
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Eklenemedi!");
            }
            return View();
        }

        // GET: Admin/Kullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = manager.Get(id.Value);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Admin/Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(Kullanici kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    manager.Update(kullanici);

                    return RedirectToAction("Index");
                }
                return View(kullanici);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Kullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = manager.Get(id.Value);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Admin/Kullanici/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                manager.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
