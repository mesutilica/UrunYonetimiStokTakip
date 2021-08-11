using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.WebFormUI
{
    public partial class KullaniciYonetimi : System.Web.UI.Page
    {
        KullaniciManager manager = new KullaniciManager();
        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
            dgvKullanicilar.DataBind();
        }
        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Kullanici
                    {
                        Adi = txtAdi.Text,
                        Soyadi = txtSoyadi.Text,
                        Email = txtEmail.Text,
                        KullaniciAdi = txtKullaniciAdi.Text,
                        Sifre = txtSifre.Text,
                        Aktif = cbDurum.Checked
                    }
                    );
                if (sonuc > 0)
                {
                    Response.Redirect("KullaniciYonetimi.aspx");
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Eklenemedi!");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lblId.Text);
                if (id > 0)
                {
                    var sonuc = manager.Update(
                    new Kullanici
                    {
                        Id = id,
                        Adi = txtAdi.Text,
                        Soyadi = txtSoyadi.Text,
                        Email = txtEmail.Text,
                        KullaniciAdi = txtKullaniciAdi.Text,
                        Sifre = txtSifre.Text,
                        Aktif = cbDurum.Checked
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("KullaniciYonetimi.aspx");
                    }
                }
                else MessageBox("Listeden Kayıt Seçiniz!");
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Güncellenemedi!");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Response.Redirect("KullaniciYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        protected void dgvKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvKullanicilar.SelectedRow;
                
                var kullanici = manager.Get(Convert.ToInt32(row.Cells[1].Text));
                txtAdi.Text = kullanici.Adi;
                txtEmail.Text = kullanici.Email;
                txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                txtSifre.Text = kullanici.Sifre;
                txtSoyadi.Text = kullanici.Soyadi;
                cbDurum.Checked = kullanici.Aktif;
                //lblEklenmeTarihi.Text = kullanici.EklenmeTarihi.ToString();
                lblId.Text = kullanici.Id.ToString();

            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu!");
            }
        }
    }
}