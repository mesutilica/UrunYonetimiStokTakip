using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class SiparislerController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();

        SiparisManager manager = new SiparisManager();
        MusteriManager musteri = new MusteriManager();
        UrunManager urun = new UrunManager();

        // GET: Admin/Siparisler
        public ActionResult Index()
        {
            var siparisler = manager.GetAll();//db.Siparisler.Include(s => s.Musteri).Include(s => s.Urun);
            return View(siparisler);
        }

        // GET: Admin/Siparisler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = manager.Get(id.Value);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: Admin/Siparisler/Create
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(musteri.GetAll(), "Id", "Adi");
            ViewBag.UrunId = new SelectList(urun.GetAll(), "Id", "UrunAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                manager.Add(siparis);
                
                return RedirectToAction("Index");
            }

            ViewBag.MusteriId = new SelectList(musteri.GetAll(), "Id", "Adi", siparis.MusteriId);
            ViewBag.UrunId = new SelectList(urun.GetAll(), "Id", "UrunAdi", siparis.UrunId);
            return View(siparis);
        }

        // GET: Admin/Siparisler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = manager.Get(id.Value);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriId = new SelectList(musteri.GetAll(), "Id", "Adi", siparis.MusteriId);
            ViewBag.UrunId = new SelectList(urun.GetAll(), "Id", "UrunAdi", siparis.UrunId);
            return View(siparis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                manager.Update(siparis);
                
                return RedirectToAction("Index");
            }
            ViewBag.MusteriId = new SelectList(musteri.GetAll(), "Id", "Adi", siparis.MusteriId);
            ViewBag.UrunId = new SelectList(urun.GetAll(), "Id", "UrunAdi", siparis.UrunId);
            return View(siparis);
        }

        // GET: Admin/Siparisler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = manager.Get(id.Value);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Admin/Siparisler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = manager.Get(id);
            manager.Delete(siparis.Id);
            
            return RedirectToAction("Index");
        }

    }
}
