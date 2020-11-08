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
        public NotificationWindow(string id ,int sum,int days,string sumpaid)
        {
            InitializeComponent();
            labelText.Text =
                $"Ваш займ №{id} на сумму:{sum} руб. был принят к рассмотрению\n"+
                $"К выплате: {sumpaid} дней\n"+
                $"Срок:{days}\n"+
                $"В ближайщее время оператор рассмотрит вашу заявку.\nО принятии или отклонении заявки,\nвы сможете узнать в соответствующием сообщении\n"+
                $"или в приложении,в разделе <<Заявка>> по номеру заявки";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
