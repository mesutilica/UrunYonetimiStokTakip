using System;
using BL;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UrunYonetimiStokTakip.WebFormUI
{
    public partial class KategoriYonetimi : System.Web.UI.Page
    {
        KategoriManager manager = new KategoriManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
            dgvKategoriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                new Kategori
                {
                    KategoriAdi = txtKategoriAdi.Text,
                    Aciklamasi = txtKategoriAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = DateTime.Now
                }
                );
                if (sonuc > 0)
                {
                    Response.Redirect("KategoriYonetimi.aspx");
                    //Yukle();
                    //MessageBox.Show("Kayıt Eklendi!");
                }
                else lblMesaj.Text = "Kayıt Eklenemedi!";
            }
            catch (Exception hata) //buradaki hata nesnesinden hata detaylarına ulaşabiliriz
            {
                lblMesaj.Text = "Hata Oluştu! Kayıt Eklenemedi!";
                //MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin!" + hata.Message);
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {

        }
    }
}