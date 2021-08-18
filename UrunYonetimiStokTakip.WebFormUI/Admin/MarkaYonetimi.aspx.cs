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
    public partial class MarkaYonetimi : System.Web.UI.Page
    {
        MarkaManager manager = new MarkaManager();
        void Yukle()
        {
            dgvMarkalar.DataSource = manager.GetAll();
            dgvMarkalar.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int islemSonucu = manager.Add(
                new Marka
                {
                    MarkaAdi = txtMarkaAdi.Text,
                    Aciklamasi = txtMarkaAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = DateTime.Now
                }
                );
                if (islemSonucu > 0)
                {
                    Response.Redirect("MarkaYonetimi.aspx");
                }
                else MessageBox("Kayıt Eklenemedi!");
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Eklenemedi!");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            if (id > 0)
            {
                int islemSonucu = manager.Update(
                    new Marka
                    {
                        Id = id,
                        MarkaAdi = txtMarkaAdi.Text,
                        Aciklamasi = txtMarkaAciklamasi.Text,
                        Aktif = cbDurum.Checked,
                        EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text)
                    }
                    );
                if (islemSonucu > 0)
                {
                    Response.Redirect("MarkaYonetimi.aspx");
                }
                else MessageBox("Kayıt Güncellenemedi!");
            }
            else MessageBox("Listeden güncellenecek kaydı seçiniz!");
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lblId.Text);

                if (id > 0)
                {
                    int islemSonucu = manager.Delete(id);
                    if (islemSonucu > 0)
                    {
                        Response.Redirect("MarkaYonetimi.aspx");
                    }
                    else MessageBox("Kayıt Silinemedi!");

                }
                else MessageBox("Listeden silinecek kaydı seçiniz!");
            }
            catch (Exception)
            {
                MessageBox("Hata Ouştu!");
            }
        }

        protected void dgvMarkalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvMarkalar.SelectedRow;
                var marka = manager.Get(Convert.ToInt32(row.Cells[1].Text));
                txtMarkaAciklamasi.Text = marka.Aciklamasi;
                txtMarkaAdi.Text = marka.MarkaAdi;
                cbDurum.Checked = marka.Aktif;
                lblEklenmeTarihi.Text = marka.EklenmeTarihi.ToString();
                lblId.Text = marka.Id.ToString();
            }
            catch (Exception)
            {
                MessageBox("Hata Ouştu!");
            }
        }

        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }

    }
}