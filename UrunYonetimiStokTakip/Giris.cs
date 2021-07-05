using BL;
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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş geçilemez!");
            }
            else
            {
                var kullanici = manager.Find(k => k.KullaniciAdi == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text);
                if (kullanici != null)
                {                    
                    Menu menu = new Menu();
                    menu.Show();                    
                }
                else MessageBox.Show("Giriş Başarısız!");
            }            
        }
    }
}
