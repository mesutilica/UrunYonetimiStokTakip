using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        KategoriManager manager = new KategoriManager();
        // GET: Admin/Kategori
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }
    }
}