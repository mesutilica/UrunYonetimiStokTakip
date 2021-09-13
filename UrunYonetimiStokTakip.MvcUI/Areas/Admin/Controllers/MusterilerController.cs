using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using BL;
using UrunYonetimiStokTakip.MvcUI.Models;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class MusterilerController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();
        MusteriManager manager = new MusteriManager();

        // GET: Admin/Musteriler
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: Admin/Musteriler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = manager.Get(id.Value);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Admin/Musteriler/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                manager.Add(musteri);
                
                return RedirectToAction("Index");
            }

            return View(musteri);
        }

        // GET: Admin/Musteriler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = manager.Get(id.Value);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                manager.Update(musteri);
                
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        // GET: Admin/Musteriler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = manager.Get(id.Value);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Admin/Musteriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri musteri = manager.Get(id);
            manager.Delete(musteri.Id);
            
            return RedirectToAction("Index");
        }

    }
}
