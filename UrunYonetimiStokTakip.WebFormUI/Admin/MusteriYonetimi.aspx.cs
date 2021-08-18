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
    public partial class MusteriYonetimi : System.Web.UI.Page
    {
        MusteriManager manager = new MusteriManager();
        void Yukle(string text = "")
        {
            dgvMusteriler.DataSource = manager.GetAll(x => x.Adi.Contains(text));
            dgvMusteriler.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        protected void dgvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvMusteriler.SelectedRow;
                var musteri = manager.Get(Convert.ToInt32(row.Cells[1].Text));

                txtAdi.Text = musteri.Adi;
                txtAdres.Text = musteri.Adres;
                txtEmail.Text = musteri.Email;
                txtSoyadi.Text = musteri.Soyadi;
                txtTelefon.Text = musteri.Telefon;
                lblId.Text = musteri.Id.ToString();
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu!");
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox("Lütfen * işaretli alanları doldurunuz!");
                }
                else
                {
                    var sonuc = manager.Add(
                    new Musteri
                    {
                        Adi = txtAdi.Text,
                        Soyadi = txtSoyadi.Text,
                        Email = txtEmail.Text,
                        Telefon = txtTelefon.Text,
                        Adres = txtAdres.Text
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("MusteriYonetimi.aspx");
                    }
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
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox("Lütfen * işaretli alanları doldurunuz!");
                }
                else
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox("Listeden güncellenecek kaydı seçiniz!");
                    }
                    else
                    {
                        var sonuc = manager.Update(
                        new Musteri
                        {
                            Id = Convert.ToInt32(lblId.Text),
                            Adi = txtAdi.Text,
                            Soyadi = txtSoyadi.Text,
                            Email = txtEmail.Text,
                            Telefon = txtTelefon.Text,
                            Adres = txtAdres.Text
                        }
                        );
                        if (sonuc > 0)
                        {
                            Response.Redirect("MusteriYonetimi.aspx");
                        }
                    }
                }
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
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Response.Redirect("MusteriYonetimi.aspx");
                    }
                    else MessageBox("Kayıt Silinemedi!");
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu!");
            }
        }

        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            Yukle(txtAra.Text);
        }
    }
}