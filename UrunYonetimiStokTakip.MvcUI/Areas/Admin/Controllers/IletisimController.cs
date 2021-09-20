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

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class IletisimController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();
        IletisimManager db = new IletisimManager();

        // GET: Admin/Iletisim
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Admin/Iletisim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Get(id.Value);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }

        // GET: Admin/Iletisim/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                iletisim.EklenmeTarihi = DateTime.Now;
                db.Add(iletisim);
                
                return RedirectToAction("Index");
            }

            return View(iletisim);
        }

        // GET: Admin/Iletisim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Get(id.Value);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Update(iletisim);
                
                return RedirectToAction("Index");
            }
            return View(iletisim);
        }

        // GET: Admin/Iletisim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Get(id.Value);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }

        // POST: Admin/Iletisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iletisim iletisim = db.Get(id);
            db.Delete(iletisim.Id);
            
            return RedirectToAction("Index");
        }

    }
}