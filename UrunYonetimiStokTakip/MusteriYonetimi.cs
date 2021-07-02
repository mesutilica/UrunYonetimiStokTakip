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
    public partial class MusteriYonetimi : Form
    {
        public MusteriYonetimi()
        {
            InitializeComponent();
        }
        MusteriManager manager = new MusteriManager();
        void Yukle()
        {
            dgvMusteriler.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            txtAdi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtSoyadi.Text = string.Empty;            
            lblId.Text = "0";
        }
        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
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
                    Temizle();
                    Yukle();
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

        }
    }
}
