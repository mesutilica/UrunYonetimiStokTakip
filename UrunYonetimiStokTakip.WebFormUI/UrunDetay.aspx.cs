using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UrunYonetimiStokTakip.WebFormUI
{
    public partial class UrunDetay : System.Web.UI.Page
    {
        UrunManager manager = new UrunManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["urunId"] != null)
                {
                    var urunid = int.Parse(Request.QueryString["urunId"]);
                    UrunBilgi(urunid);
                }
            }
            catch (Exception)
            {
                baslik.InnerText = "Hata Oluştu!";
            }
        }
        void UrunBilgi(int id)
        {
            var urun = manager.Get(id);
            if (urun != null)
            {
                baslik.InnerText = urun.UrunAdi;
                ImgUrunResim.ImageUrl = "/Img/" + urun.Resim;
                ltUrunBilgileri.Text = urun.Aciklama;
            }
        }
    }
}