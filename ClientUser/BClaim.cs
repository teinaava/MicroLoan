using System;
using System.Collections.Generic;
using System.Text;
using ClientOP;
using MicroLoan;

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
    class BClaim
    {
        public BClaim()
        {

        }

        BaseDataLite bd = new BaseDataLite();
        private int id; //id заявки
        private int sumLoan; //сумма заzвки
        private int days; // Days
        private DateTime fdate; //дата заявки.
        private int cardnumber;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                
            }
            
        }




    }
}
