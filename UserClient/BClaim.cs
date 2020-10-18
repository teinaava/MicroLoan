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
        BaseDataLite bd = new BaseDataLite();
        private int id; //id заявки
        private int sumLoan; //сумма заzвки
        private int days; // Days
        private DateTime fdate; //дата заявки.
        private int cardnumber; //номер карты
        private int sumpaid; //сумма к выплате
        private DateTime ldate; //посл. дата выплаты
        private int fineday; // дней штрафа
        private int paidout; // уже выплачено
        private Type type;
        private Status status;

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
                    if (!BaseDataLite.CheckLoanID(id)) { break; }
                    
                }
            }
        }
        public DateTime LastDate { get { return ldate; } set { ldate = value; } }
        public int SumPaid { get { return sumpaid; } set { sumpaid = value; } }
        public int CardNumber { get { return cardnumber; } set { cardnumber = value; } }
        public int SumLoan { get { return sumLoan; } set { sumLoan = value; } }
        public DateTime FirstDate { get { return fdate; } set { fdate = value; } }
        public int Days{ get { return days; } set { days = value; } }
        public int Fine { get { return days; } set { fineday = value; } }
        public int PaidOut { get { return days; } set { paidout = value; } }
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
        public static double DailyPaid(int s,double i,int n) // s – сумма кредита, i – ежедневная ставка, n – срок на который берется кредит.
        {
            double v = (((s / n) / 100) * n) + (s / n);
            return Math.Round(v);
        }
        // Сумму выплаты = DailyPaid() * кол-во дней
        #endregion

    }
}
