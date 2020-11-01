using System;
using System.Net.Mail;
using System.Net;

namespace DataBase
{
    class GeneralMessages
    {
        public static void SendEmailNewLoan(string sendEmail, DateTime LastDate, DateTime FirstDate) //послать имейл от клиента пользователя
        {
            MailAddress from = new MailAddress("aurel1us.mar@yandex.ru", "MoneyMota");
            MailAddress to = new MailAddress(sendEmail);
            string message = "";
            MailMessage m = new MailMessage(from, to);
            //m.Attachments.Add(new Attachment(@"C:\gg\PS\EWryYElXsAsIOSA.jpg"));
            m.Subject = "Информация о вашем займе";
            m.Body = "";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential("aurel1us.mar@yandex.ru", "qwrnvtxewxwdckco");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public static void SendEmailNewStatus(string sendEmail, DateTime LastDate, DateTime FirstDate) //послать имейл от клиента оператора
        {
            MailAddress from = new MailAddress("aurel1us.mar@yandex.ru", "MoneyMota");
            MailAddress to = new MailAddress(sendEmail);
            string message = "";
            MailMessage m = new MailMessage(from, to);
            //m.Attachments.Add(new Attachment(@"C:\gg\PS\EWryYElXsAsIOSA.jpg"));
            m.Subject = "Изменение статса вашего займа!";
            m.Body = "";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential("aurel1us.mar@yandex.ru", "qwrnvtxewxwdckco");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
