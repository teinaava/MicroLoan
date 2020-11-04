using ClientUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBarSum_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxSumLoan.Text = $"{hScrollBarSum.Value * 1000}";
            labelPaidSum.Text = CountSumPiad(Convert.ToInt32(textBoxSumLoan.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
            labelDailYPaid.Text = CountDailyPaid(Convert.ToInt32(labelPaidSum.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
        }
        private void hScrollBarDays_Scroll(object sender, ScrollEventArgs e)
        {
            textBoxDays.Text = hScrollBarDays.Value.ToString();
            labelPaidSum.Text = CountSumPiad(Convert.ToInt32(textBoxSumLoan.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
            labelDailYPaid.Text = CountDailyPaid(Convert.ToDouble(labelPaidSum.Text), Convert.ToDouble(textBoxDays.Text)).ToString();
        }

        private void textBoxSumLoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
            labelPaidSum.Text = CountSumPiad(Convert.ToInt32(textBoxSumLoan.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
            labelDailYPaid.Text = CountDailyPaid(Convert.ToInt32(labelPaidSum.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
        }

        private void textBoxSumLoan_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxSumLoan.Text) > 50000 || Convert.ToInt32(textBoxSumLoan.Text) < 3000)
            {
                //todo: message box !!!
                textBoxSumLoan.Text = 50000.ToString();
            }
            else
            {
                hScrollBarSum.Value = Convert.ToInt32(textBoxSumLoan.Text) / 1000;
                hScrollBarSum.Update();
            }
        }

        private void textBoxDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void textBoxDays_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxDays.Text) > 30 || Convert.ToInt32(textBoxDays.Text) < 7)
            {
                //todo: message box !!!
                textBoxDays.Text = 30.ToString();
            }
            else
            {
                hScrollBarDays.Value = Convert.ToInt32(textBoxDays);
                hScrollBarDays.Update();
            }
        }
        private int CountSumPiad(int sum,int days)
        {
            int rate = 1;
            if(sum > 30000)
            {
                rate = 2;
            }
            return (int)BClaim.SumPiad(sum, rate, days);
        }
        private double CountDailyPaid(double sumpaid,double days)
        {
            return Math.Round((double)(sumpaid / days), 2);
        }
    }
}
