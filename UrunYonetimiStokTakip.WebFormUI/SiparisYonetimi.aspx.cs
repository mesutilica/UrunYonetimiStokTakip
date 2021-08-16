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
    public partial class SiparisYonetimi : System.Web.UI.Page
    {
        SiparisManager manager = new SiparisManager();
        MusteriManager musteri = new MusteriManager();
        UrunManager urun = new UrunManager();
        void Yukle()
        {
            dgvSiparisler.DataSource = manager.GetAll();
            dgvSiparisler.DataBind();

            cbMusteriler.DataSource = musteri.GetAll();
            cbMusteriler.DataTextField = "Adi";
            cbMusteriler.DataValueField = "Id";
            cbMusteriler.DataBind();

            cbUrunler.DataSource = urun.GetAll();
            cbUrunler.DataTextField = "UrunAdi";
            cbUrunler.DataValueField = "Id";
            cbUrunler.DataBind();

            //dgvSiparisler.Columns.Remove("Urun");
            //dgvSiparisler.Columns.Remove("Musteri");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Siparis
                    {
                        MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                        SiparisNo = txtSiparisNo.Text,
                        SiparisTarihi = dtpSiparisTarihi.SelectedDate,
                        UrunId = Convert.ToInt32(cbUrunler.SelectedValue)
                    }
                    );
                if (sonuc > 0)
                {
                    Response.Redirect("SiparisYonetimi.aspx");
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
                if (lblId.Text != "0")
                {
                    var sonuc = manager.Update(
                    new Siparis
                    {
                        Id = Convert.ToInt32(lblId.Text),
                        MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                        SiparisNo = txtSiparisNo.Text,
                        SiparisTarihi = dtpSiparisTarihi.SelectedDate,
                        UrunId = Convert.ToInt32(cbUrunler.SelectedValue)
                    }
                    );
                    if (sonuc > 0)
                    {
                        Response.Redirect("SiparisYonetimi.aspx");
                    }
                }
                else
                {
                    MessageBox("Listeden güncellenecek kaydı seçiniz!");
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
                        Response.Redirect("SiparisYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        protected void dgvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvSiparisler.SelectedRow;
                var siparis = manager.Get(Convert.ToInt32(row.Cells[1].Text));
                txtSiparisNo.Text = siparis.SiparisNo;
                cbMusteriler.SelectedValue = siparis.MusteriId.ToString();
                cbUrunler.SelectedValue = siparis.UrunId.ToString();
                dtpSiparisTarihi.SelectedDate = siparis.SiparisTarihi;
                lblId.Text = row.Cells[1].Text;
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Getirilemedi!");
            }
        }

        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }
    }
}