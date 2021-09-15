using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class UrunlerController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();

        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        MarkaManager markaManager = new MarkaManager();

        // GET: Admin/Urunler
        public ActionResult Index()
        {
            var urunler = manager.GetAll();//db.Urunler.Include(u => u.Kategori).Include(u => u.Marka);
            return View(urunler);
        }

        // GET: Admin/Urunler/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/Urunler/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi");
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Urun urun, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {                
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    urun.Resim = Resim.FileName;
                }
                urun.EklenmeTarihi = System.DateTime.Now;
                manager.Add(urun);
                
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }

        // GET: Admin/Urunler/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urun urun, HttpPostedFileBase Resim, bool cbResimSil)
        {
            if (ModelState.IsValid)
            {
                if (cbResimSil == true)
                {
                    urun.Resim = string.Empty;
                }
                if (Resim != null)
                {
                    string directory = Server.MapPath("~/Img/");
                    var fileName = Path.GetFileName(Resim.FileName);
                    Resim.SaveAs(Path.Combine(directory, fileName));
                    urun.Resim = Resim.FileName;
                }
                manager.Update(urun);
                
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            ViewBag.MarkaId = new SelectList(markaManager.GetAll(), "Id", "MarkaAdi", urun.MarkaId);
            return View(urun);
        }

        // GET: Admin/Urunler/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = manager.Get(id);
            manager.Delete(urun.Id);
            
            return RedirectToAction("Index");
        }

    }
}
