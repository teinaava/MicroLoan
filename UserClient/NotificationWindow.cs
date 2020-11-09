using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserClient
{
    public partial class NotificationWindow : Form
    {
        internal static string text;
        public NotificationWindow(string id ,int sum,int days,string sumpaid)
        {
            InitializeComponent();
            button1.Visible = false;
            labelsum.Visible = false;
            paidtextboxsum.Visible = false;
            labelText.Text =
                $"Ваш займ №{id} на сумму:{sum} руб. был принят к рассмотрению\n"+
                $"К выплате: {sumpaid} дней\n"+
                $"Срок:{days}\n"+
                $"В ближайщее время оператор рассмотрит вашу заявку.\nО принятии или отклонении заявки,\nвы сможете узнать в соответствующием сообщении\n"+
                $"или в приложении,в разделе <<Заявка>> по номеру заявки";
            buttonOK.Text = "ОК";
        }
        public NotificationWindow(string id, int sum, int days, string sumpaid, string buttonname)
        {
            InitializeComponent();
            labelText.Text = $"№ {id} \n";
            buttonOK.Text = buttonname;
            button1.Visible = true;
            labelsum.Visible = true;
            paidtextboxsum.Visible = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            text = paidtextboxsum.Text;
            DialogResult dialogResult = MessageBox.Show($"Ваш уверены что хотите совершить платеж на сумму {text} руб.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void paidtextboxsum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
            text = paidtextboxsum.Text;
        }
    }
}
