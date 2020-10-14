using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using BaseData;

namespace ClientUser
{
    enum Status
    {
        open, apply, closed
    }
    enum Type
    {
        card,cash
    }
    public class BClaim
    {
        public BClaim()
        {

        }
        public BClaim(int sl,int days,int cardnumber,int sump,DateTime fd,DateTime ld)
        {
            SumLoan = sl;
            Days = days;
            CardNumber = cardnumber;
            SumPaid = sump;
            FirstDate = fd;
            LastDate = ld;
        }
        BaseDataLite bd = new BaseDataLite();
        private int id; //id заявки
        private int sumLoan; //сумма заzвки
        private int days; // Days
        private DateTime fdate; //дата заявки.
        private int cardnumber;
        private int sumpaid;
        private DateTime ldate;
        #region Porps
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                while (true)
                {
                   
                    id = GenerateID(6);
                    if (!BaseDataLite.CheckID(id)) { break; }
                    
                }
            }
        }
        public DateTime LastDate { get { return ldate; } set { ldate = value; } }
        public int SumPaid { get { return sumpaid; } set { sumpaid = value; } }
        public int CardNumber { get { return cardnumber; } set { cardnumber = value; } }
        public int SumLoan { get { return sumLoan; } set { sumLoan = value; } }
        public DateTime FirstDate { get { return fdate; } set { fdate = value; } }
        public int Days{ get { return days; } set { days = value; } }
        #endregion
        #region Methods
        public static int GenerateID(int ln)
        {
            string id = "";
            Random rnd = new Random();
            for (int i = 0; i < ln; i++)
            {
                id += Convert.ToString(rnd.Next(0, 9));
            }
            return Convert.ToInt32(id);
        }   //claim id.lenght = 6   user id.lenght = 4
        public static void SendEmail(string sendEmail,DateTime LastDate, DateTime FirstDate ) //послать имейл
        {
            MailAddress from = new MailAddress("aurel1us.mar@yandex.ru", "MoneyMota");
            MailAddress to = new MailAddress(sendEmail);
            string message = "";
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment(@"C:\gg\PS\EWryYElXsAsIOSA.jpg"));
            m.Subject = "Информация о вашем займе";
            m.Body = "";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential("aurel1us.mar@yandex.ru", "qwrnvtxewxwdckco");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public static double DailyPaid(int s,double i,int n) // s – сумма кредита, i – ежедневная ставка, n – срок на который берется кредит.
        {
            double v = (((s / n) / 100) * n) + (s / n);
            return Math.Round(v);
        }
        // Сумму выплаты = DailyPaid() * кол-во дней
        #endregion

    }
}
