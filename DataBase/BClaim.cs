using System;
using System.Net;
using BaseData;

namespace ClientUser
{
    //public enum Status
    //{
    //    opened, accepted, closed, rejected //открыто,принято,закрыто,отклонено
    //}
    //public enum Type
    //{
    //    card,cash //карта, наличка
    //}
    public class BClaim
    {//dd
        public BClaim()
        {

        }
        BaseDataLite bd = new BaseDataLite();
        private int id; //id заявки
        private int sumLoan; //сумма заzвки
        private int days; // Days
        private DateTime fdate; //дата заявки.
        private string cardnumber; //номер карты
        private int sumpaid; //сумма к выплате
        private DateTime ldate; //посл. дата выплаты
        private int fineday; // дней штрафа
        private int paidout; // уже выплачено
        public string type; //Тип выплаты
        public string status; //Статус заявки

        #region Porps
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public DateTime LastDate { get { return ldate; } set { ldate = value; } }
        public int SumPaid { get { return sumpaid; } set { sumpaid = value; } }
        public string CardNumber { get { return cardnumber; } set { cardnumber = value; } }
        public int SumLoan { get { return sumLoan; } set { sumLoan = value; } }
        public DateTime FirstDate { get { return fdate; } set { fdate = value; } }
        public int Days{ get { return days; } set { days = value; } }
        public int Fine { get { return fineday; } set { fineday = value; } }
        public int PaidOut { get { return paidout; } set { paidout = value; } }
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

        }   //claim id.lenght = 6   user id.lenght = 4 doc id.Length = 5
        public static int SumPiad(int s,double i,int n)
        {
            i /= 100;
            double v = s * i * n;
            return Convert.ToInt32(Math.Round(v, 0)) + s;
        }
        #endregion

    }
}
