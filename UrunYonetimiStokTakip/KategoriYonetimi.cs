using BL;
using Entities;
using System;
using System.Windows.Forms;

namespace UrunYonetimiStokTakip
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        KategoriManager manager = new KategoriManager();
        void Yukle()
        {
            dgvKategoriler.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            txtKategoriAdi.Text = string.Empty;
            txtKategoriAciklamasi.Text = string.Empty;
            lblEklenmeTarihi.Text = string.Empty;
            lblId.Text = "0";
            cbDurum.Checked = false;
        }
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
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
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception hata) //buradaki hata nesnesinden hata detaylarına ulaşabiliriz
            {
                MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin!" + hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Update(
                new Kategori
                {
                    Id = int.Parse(lblId.Text),
                    KategoriAdi = txtKategoriAdi.Text,
                    Aciklamasi = txtKategoriAciklamasi.Text,
                    Aktif = cbDurum.Checked,
                    EklenmeTarihi = Convert.ToDateTime(lblEklenmeTarihi.Text)
                }
                );
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception hata) //buradaki hata nesnesinden hata detaylarına ulaşabiliriz
            {
                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!n\\Boş Alan Bırakmadan Tekrar Deneyin!");
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
                    var sonuc = manager.Delete(int.Parse(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblId.Text = dgvKategoriler.CurrentRow.Cells[0].Value.ToString();
                txtKategoriAdi.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
                if(dgvKategoriler.CurrentRow.Cells[2].Value != null) txtKategoriAciklamasi.Text = dgvKategoriler.CurrentRow.Cells[2].Value.ToString();
                lblEklenmeTarihi.Text = dgvKategoriler.CurrentRow.Cells[3].Value.ToString();
                cbDurum.Checked = Convert.ToBoolean(dgvKategoriler.CurrentRow.Cells[4].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt Atanırken Hata Oluştu!");
            }   
        }

        private void markaYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            this.Close();
            markaYonetimi.ShowDialog();
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
