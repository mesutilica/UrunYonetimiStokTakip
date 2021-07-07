using BL;
using Entities;
using System;
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
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox.Show("Lütfen * işaretli alanları doldurunuz!");
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
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Eklendi!");
                    }
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
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text))
                {
                    MessageBox.Show("Lütfen * işaretli alanları doldurunuz!");
                }
                else
                {
                    if (lblId.Text == "0")
                    {
                        MessageBox.Show("Listeden güncellenecek kaydı seçiniz!");
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
                            Temizle();
                            Yukle();
                            MessageBox.Show("Kayıt Güncellendi!");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!");
            }
        }

        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvMusteriler.CurrentRow.Cells[0].Value.ToString();
                txtAdi.Text = dgvMusteriler.CurrentRow.Cells[1].Value.ToString();
                txtSoyadi.Text = dgvMusteriler.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvMusteriler.CurrentRow.Cells[3].Value.ToString();
                txtTelefon.Text = dgvMusteriler.CurrentRow.Cells[4].Value.ToString();
                txtAdres.Text = dgvMusteriler.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception )
            {
                MessageBox.Show("Hata Oluştu!");
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
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                    else MessageBox.Show("Kayıt Silinemedi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            this.Close();
            markaYonetimi.ShowDialog();
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KategoriYonetimi kategoriYonetimi = new KategoriYonetimi();
            this.Close();
            kategoriYonetimi.ShowDialog();
        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunYonetimi urunYonetimi = new UrunYonetimi();
            this.Close();
            urunYonetimi.ShowDialog();
        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            this.Close();
            kullaniciYonetimi.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
