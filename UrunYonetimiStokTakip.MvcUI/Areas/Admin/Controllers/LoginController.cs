using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BL;

namespace UrunYonetimiStokTakip.MvcUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        KullaniciManager manager = new KullaniciManager();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string sifre)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sifre))
            {
                TempData["Mesaj"] = "Kullanıcı adı ve şifre boş geçilemez!";
            }
            else
            {
                var kullanici = manager.Find(k => k.Email == email && k.Sifre == sifre && k.Aktif == true);
                if (kullanici != null)
                {
                    Session["admin"] = kullanici;
                    FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, true);
                    if (Request.QueryString["ReturnUrl"] == null) return Redirect("/Admin/Default");
                    else return Redirect(Request.QueryString["ReturnUrl"]);
                }
                else TempData["Mesaj"] = "Giriş Başarısız!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("admin");
            FormsAuthentication.SignOut();

            return Redirect("/Admin/Login");
        }
    }
}