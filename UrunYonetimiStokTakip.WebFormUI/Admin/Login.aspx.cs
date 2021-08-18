using System;
using BL;
using System.Web.UI;
using System.Web.Security;

namespace UrunYonetimiStokTakip.WebFormUI.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        KullaniciManager manager = new KullaniciManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox("Kullanıcı adı ve şifre boş geçilemez!");
            }
            else
            {
                var kullanici = manager.Find(k => k.KullaniciAdi == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text && k.Aktif == true);
                if (kullanici != null)
                {
                    Session["admin"] = kullanici;
                    FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, true);
                    if (Request.QueryString["ReturnUrl"] == null)
                        Response.Redirect("/Admin/Default.aspx");
                    else Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else MessageBox("Giriş Başarısız!");
            }
        }

        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
    }
}