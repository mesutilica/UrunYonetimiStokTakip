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
    public partial class UrunYonetimi : System.Web.UI.Page
    {
        UrunManager manager = new UrunManager();
        KategoriManager kategoriManager = new KategoriManager();
        MarkaManager markaManager = new MarkaManager();
        void Yukle()
        {
            //dgvUrunler.AutoGenerateColumns = false;
            dgvUrunler.DataSource = manager.GetAll();
            dgvUrunler.DataBind();
            cbUrunKategorisi.DataSource = kategoriManager.GetAll();
            cbUrunKategorisi.DataBind();
            cbUrunMarkasi.DataSource = markaManager.GetAll();
            cbUrunMarkasi.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrunFiyati.Text)) //Veritabanında not null olarak işaretli tüm sütunlar için bu şekilde boş geçilemez kontrolü yaptırmak gerekir
            {
                try
                {
                    string urunResmi = "";
                    if (fuResim.HasFile)
                    {
                        fuResim.SaveAs(Server.MapPath("/Img/" + fuResim.FileName));
                        urunResmi = fuResim.FileName;
                    }
                    var sonuc = manager.Add(
                        new Urun
                        {
                            UrunAdi = txtUrunAdi.Text,
                            UrunFiyati = decimal.Parse(txtUrunFiyati.Text),
                            Aciklama = rtbUrunAciklamasi.Text,
                            Aktif = cbDurum.Checked,
                            EklenmeTarihi = DateTime.Now,
                            Iskonto = int.Parse(txtIskonto.Text),
                            Kdv = int.Parse(txtKdv.Text),
                            StokMiktari = int.Parse(txtStokMiktari.Text),
                            ToptanFiyat = decimal.Parse(txtUrunFiyati.Text),
                            KategoriId = int.Parse(cbUrunKategorisi.SelectedValue.ToString()),
                            MarkaId = int.Parse(cbUrunMarkasi.SelectedValue.ToString()),
                            Resim = urunResmi
                        }
                        );

                    if (sonuc > 0)
                    {
                        Response.Redirect("UrunYonetimi.aspx");
                    }
                }
                catch (Exception)
                {
                    MessageBox("Hata Oluştu! Kayıt Eklenemedi! Lütfen Tüm Alanları Doldurup Tekrar Deneyiniz!");
                }
            }
            else MessageBox("Ürün Fiyatı Boş Geçilemez!");
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrunFiyati.Text)) //Veritabanında not null olarak işaretli tüm sütunlar için bu şekilde boş geçilemez kontrolü yaptırmak gerekir
            {
                try
                {
                    int urunId = Convert.ToInt32(lblId.Text);
                    if (urunId > 0)
                    {
                        string urunResmi = "";
                        if (fuResim.HasFile)
                        {
                            fuResim.SaveAs(Server.MapPath("/Img/" + fuResim.FileName));
                            urunResmi = fuResim.FileName;
                        }
                        else urunResmi = hfResim.Value;
                        var sonuc = manager.Update(
                        new Urun
                        {
                            Id = urunId,
                            UrunAdi = txtUrunAdi.Text,
                            UrunFiyati = decimal.Parse(txtUrunFiyati.Text),
                            Aciklama = rtbUrunAciklamasi.Text,
                            Aktif = cbDurum.Checked,
                            EklenmeTarihi = DateTime.Now,
                            Iskonto = int.Parse(txtIskonto.Text),
                            Kdv = int.Parse(txtKdv.Text),
                            StokMiktari = int.Parse(txtStokMiktari.Text),
                            ToptanFiyat = decimal.Parse(txtUrunFiyati.Text),
                            KategoriId = int.Parse(cbUrunKategorisi.SelectedValue.ToString()),
                            MarkaId = int.Parse(cbUrunMarkasi.SelectedValue.ToString()),
                            Resim = urunResmi
                        }
                        );
                        if (sonuc > 0)
                        {
                            Response.Redirect("UrunYonetimi.aspx");
                        }
                    }
                    else MessageBox("Listeden Bir Ürün Seçiniz!");
                }
                catch (Exception)
                {
                    MessageBox("Hata Oluştu! Kayıt Güncellenemedi! Lütfen Tüm Alanları Doldurup Tekrar Deneyiniz!");
                }
            }
            else MessageBox("Ürün Fiyatı Boş Geçilemez!");
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
                        Response.Redirect("UrunYonetimi.aspx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        void MessageBox(string mesaj)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Uyarı", $"<script>alert('{mesaj}')</script>");
        }

        protected void dgvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvUrunler.SelectedRow;
            var musteri = manager.Get(Convert.ToInt32(row.Cells[1].Text));

            try
            {
                lblId.Text = row.Cells[1].Text;
                int urunId = Convert.ToInt32(lblId.Text);
                if (urunId > 0)
                {
                    var urun = manager.Get(urunId);
                    if (urun != null)
                    {
                        txtIskonto.Text = urun.Iskonto.ToString();
                        txtKdv.Text = urun.Kdv.ToString();
                        txtStokMiktari.Text = urun.StokMiktari.ToString();
                        txtUrunAdi.Text = urun.UrunAdi;
                        txtUrunFiyati.Text = urun.UrunFiyati.ToString();
                        rtbUrunAciklamasi.Text = urun.Aciklama;
                        cbDurum.Checked = urun.Aktif;
                        lblEklenmeTarihi.Text = urun.EklenmeTarihi.ToString();
                        cbUrunKategorisi.SelectedValue = urun.KategoriId.ToString();
                        cbUrunMarkasi.SelectedValue = urun.MarkaId.ToString();
                        hfResim.Value = urun.Resim;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox("Kayıt Atanırken Hata Oluştu!");
            }
        }
    }
}