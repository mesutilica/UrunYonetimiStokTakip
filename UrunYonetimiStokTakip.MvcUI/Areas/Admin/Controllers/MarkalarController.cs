using System;
using System.Net;
using System.Web.Mvc;
using Entities;
using BL;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class MarkalarController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();
        MarkaManager manager = new MarkaManager();

        // GET: Admin/Markalar
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }

        // GET: Admin/Markalar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = manager.Get(id.Value);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // GET: Admin/Markalar/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marka marka)
        {
            if (ModelState.IsValid)
            {
                marka.EklenmeTarihi = DateTime.Now;
                manager.Add(marka);
                
                return RedirectToAction("Index");
            }

            return View(marka);
        }

        // GET: Admin/Markalar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = manager.Get(id.Value);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marka marka)
        {
            if (ModelState.IsValid)
            {
                manager.Update(marka);
                
                return RedirectToAction("Index");
            }
            return View(marka);
        }

        // GET: Admin/Markalar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = manager.Get(id.Value);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // POST: Admin/Markalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marka marka = manager.Get(id);
            manager.Delete(marka.Id);
            
            return RedirectToAction("Index");
        }

    }
}
