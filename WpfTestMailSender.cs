using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender
{
   public static class WpfTestMailSender
    {

       public static string smtpServerP { get; } = "smtp.yandex.ru";
       public static byte portServer {get; } = 25;


        public static void SendMail(string theme, string text, string login, string password)
        {

            try
            {

                MailAddress from    = new MailAddress("tishenko23@rostyre.com");
                MailAddress to      = new MailAddress("tishenko@programist.ru");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = from;
                mailMessage.To.Add(to);
                mailMessage.Subject = theme;
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = text;
               
                SmtpClient smtpClient = new SmtpClient(smtpServerP, portServer);
                smtpClient.Credentials = new NetworkCredential(login, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                MessageBox.Show("Письмо отрпавленно");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        

    }
}
