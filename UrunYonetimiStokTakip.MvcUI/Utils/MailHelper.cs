using Entities;
using System;
using System.Net;
using System.Net.Mail;

namespace UrunYonetimiStokTakip.MvcUI.Utils
{
    public class MailHelper
    {
        public static bool SendMail(Iletisim iletisim)
        {
            try
            {
                SmtpClient client = new SmtpClient("mail.siteadi.com", 587);
                client.Credentials = new NetworkCredential("mail kullanıcı adı buraya","mail şifresi buraya");
                //client.EnableSsl = true; eğer mail ssl ile çalışıyorsa

                MailMessage message = new MailMessage();
                message.From = new MailAddress("info@siteadi.com");
                message.To.Add("mesajingidecegiadres@siteadi.com");
                message.Subject = "Siteden mesaj var";
                message.Body = $"<p>İsim : {iletisim.Adi} {iletisim.Soyadi}</p><p>Email : {iletisim.Email}</p><p>Mesaj : {iletisim.Mesaj}</p>";
                message.IsBodyHtml = true;

                client.Send(message);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}