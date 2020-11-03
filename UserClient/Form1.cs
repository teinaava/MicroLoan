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
        }

        private void textBoxSumLoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void textBoxSumLoan_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxSumLoan.Text) > 50000 || Convert.ToInt32(textBoxSumLoan.Text) > 3000)
            {
                //todo: message box !!!
                textBoxSumLoan.Text = 50000.ToString();
            }
            else
            {
                hScrollBarSum.Value = Convert.ToInt32(textBoxSumLoan.Text) / 1000;
                hScrollBarDays.Update();
            }
        }
    }
}
