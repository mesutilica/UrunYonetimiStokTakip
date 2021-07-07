using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class SiparisYonetimi : Form
    {
        public SiparisYonetimi()
        {
            InitializeComponent();
        }
        SiparisManager manager = new SiparisManager();
        MusteriManager musteri = new MusteriManager();
        UrunManager urun = new UrunManager();
        void Yukle()
        {
            dgvSiparisler.DataSource = manager.GetAll();
            cbMusteriler.DataSource = musteri.GetAll();
            cbMusteriler.DisplayMember = "Adi";
            cbMusteriler.ValueMember = "Id";
            cbUrunler.DataSource = urun.GetAll();
            cbUrunler.DisplayMember = "UrunAdi";
            cbUrunler.ValueMember = "Id";
            dgvSiparisler.Columns.Remove("Urun");
            dgvSiparisler.Columns.Remove("Musteri");
        }
        private void SiparisYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Temizle()
        {
            txtSiparisNo.Text = string.Empty;
            lblId.Text = "0";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(
                    new Siparis
                    {
                        MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                        SiparisNo = txtSiparisNo.Text,
                        SiparisTarihi = dtpSiparisTarihi.Value,
                        UrunId = Convert.ToInt32(cbUrunler.SelectedValue)
                    }
                    );
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
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
                        SiparisTarihi = dtpSiparisTarihi.Value,
                        UrunId = Convert.ToInt32(cbUrunler.SelectedValue)
                    }
                    );
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt Güncellendi!");
                    }
                }
                else
                {
                    MessageBox.Show("Listeden güncellenecek kaydı seçiniz!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!");
            }
        }

        private void dgvSiparisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var siparis = manager.Get(Convert.ToInt32(dgvSiparisler.CurrentRow.Cells[0].Value));
                txtSiparisNo.Text = siparis.SiparisNo;
                cbMusteriler.SelectedValue = siparis.MusteriId;
                cbUrunler.SelectedValue = siparis.UrunId;
                dtpSiparisTarihi.Value = siparis.SiparisTarihi;
                lblId.Text = dgvSiparisler.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Getirilemedi!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi!");
            }
        }
    }
}
