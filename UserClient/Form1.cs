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
            radioButtonCard.Select();
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
                hScrollBarDays.Value = Convert.ToInt32(textBoxDays.Text);
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
         #region SwitchPanel
        private void button1_Click(object sender, EventArgs e)//Main
        {
            if (panelCreateClaim.Visible == true)
            {
                 panelMain.Visible = true;
                panelCheckClaim.Visible = false;
                panelCreateClaim.Visible = false;
                panelAbout.Visible = false;
            }
            else
            {
                panelCheckClaim.Visible = false;
                panelMain.Visible = true;
                panelAbout.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) // о нас
        {
            if (panelCreateClaim.Visible == true)
            {
                panelMain.Visible = false;
                panelCheckClaim.Visible = false;
                panelCreateClaim.Visible = false;
                panelAbout.Visible = true;
            }
            else
            {
                panelMain.Visible = false;
                panelCheckClaim.Visible = false;
                panelAbout.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)//CheckClaim
        {
            if(panelCreateClaim.Visible == true)
            {
                    panelMain.Visible = false;
                    panelCheckClaim.Visible = true;
                    panelCreateClaim.Visible = false;
                    panelAbout.Visible = false;
            }
            else
            {
                panelMain.Visible = false;
                panelCheckClaim.Visible = true;
                panelAbout.Visible = false;
            }

        }
        #endregion
        private void button2_Click(object sender, EventArgs e)//Создать новый займ
        {
            panelMain.Visible = false;
            panelCheckClaim.Visible = false;
            panelCreateClaim.Visible = true;

        }
        private void radioButtonCard_Click(object sender, EventArgs e)
        {
            labelCN.Visible = true;
            maskedCardNumber.Visible = true;
            maskedCardNumber.Text = "";
        }

        private void radioButtonCash_Click(object sender, EventArgs e)
        {
            labelCN.Visible = false;
            maskedCardNumber.Visible = false;
            maskedCardNumber.Text = "0000000000000000";
        }

        private void checkBox1_Click(object sender, EventArgs e) //Условия соглашения принять кнопку
        {
            if (checkBox1.Checked) { buttonSendClaim.Enabled = true; } else { buttonSendClaim.Enabled = false; }
        }

        private void label34_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь мог бы быть договор", "Договор");
        }

        private void buttonSendClaim_Click(object sender, EventArgs e) 
        {
            string Error = "";
            #region Valid text box
            if (CheckCreatePanelTexboxEmpty())
            {
                if (!CheckEmail(maskedEmail.Text)) { Error += "Email введен некорректно\n"; }
                if (!String.IsNullOrEmpty(Error))
                {
                    MessageBox.Show($"{Error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                }
            }
            else { MessageBox.Show($"Не все поля были заполнены", "Пустые поля !", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            #endregion
        }
        private bool CheckEmail(string email) //проверить валидность строки
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool CheckCreatePanelTexboxEmpty() //Проверка пустых полей
        {
            foreach (var cont in panelCreateClaim.Controls)
            {
                if (cont.GetType() == typeof(TextBox)) 
                {
                    TextBox tb = (TextBox)cont;
                    if (String.IsNullOrEmpty(tb.Text)) { return false; }
                }
                if(cont.GetType() == typeof(MaskedTextBox))
                {
                    MaskedTextBox mtb = (MaskedTextBox)cont;
                    if (!mtb.MaskFull) { return false; }
                }
            }
            return true;
        }

        #region Фикс тексбокосов каретки и проычегоыкупк
        private void maskedCardNumber_KeyDown(object sender, KeyEventArgs e) //фиксация каретки
        {
            if (e.KeyCode == Keys.Up)
            {
                maskedCardNumber.SelectionStart = maskedCardNumber.Text.Length;
                e.Handled = true;
            }

        }
        private void maskedCardNumber_Click(object sender, EventArgs e)
        {

            maskedCardNumber.SelectionStart = 0;
        }

        private void maskedUserBirthDay_Click(object sender, EventArgs e)
        {
            maskedUserBirthDay.SelectionStart = 0;
        }

        #endregion

    }
}
