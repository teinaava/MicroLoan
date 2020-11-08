using BaseData;
using ClientUser;
using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (!string.IsNullOrEmpty(textBoxSumLoan.Text) && !string.IsNullOrEmpty(textBoxDays.Text)) 
            {
                labelPaidSum.Text = CountSumPiad(Convert.ToInt32(textBoxSumLoan.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
                labelDailYPaid.Text = CountDailyPaid(Convert.ToInt32(labelPaidSum.Text), Convert.ToInt32(textBoxDays.Text)).ToString();
            }
        }

        private void textBoxSumLoan_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSumLoan.Text) && !string.IsNullOrEmpty(textBoxDays.Text))
            {
                if (Convert.ToInt32(textBoxSumLoan.Text) > 50000 || Convert.ToInt32(textBoxSumLoan.Text) < 3000)
                {
                    textBoxSumLoan.Text = 50000.ToString();
                }
                else
                {
                    hScrollBarSum.Value = Convert.ToInt32(textBoxSumLoan.Text) / 1000;
                    hScrollBarSum.Update();
                }
            }
        }

        private void textBoxDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void textBoxDays_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSumLoan.Text) && !string.IsNullOrEmpty(textBoxDays.Text))
            {
                if (Convert.ToInt32(textBoxDays.Text) > 30 || Convert.ToInt32(textBoxDays.Text) < 7)
                {
                    textBoxDays.Text = 30.ToString();
                }
                else
                {
                    hScrollBarDays.Value = Convert.ToInt32(textBoxDays.Text);
                    hScrollBarDays.Update();
                }
            }
        }
        private int CountSumPiad(int sum, int days)
        {
            double rate = 1;
            if (sum > 30000)
            {
                rate = 1.5;
            }
            return (int)BClaim.SumPiad(sum, rate, days);
        }
        private double CountDailyPaid(double sumpaid, double days)
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
            if (panelCreateClaim.Visible == true)
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
            textBoxSumLoan.Text = $"{hScrollBarSum.Value * 1000}";
            textBoxDays.Text = hScrollBarDays.Value.ToString();
            panelMain.Visible = false;
            panelCheckClaim.Visible = false;
            panelCreateClaim.Visible = true;
            labelCreateSumLoan.Text = textBoxSumLoan.Text;
            labelCreatePaidSum.Text = labelPaidSum.Text;

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

        private void buttonSendClaim_Click(object sender, EventArgs e) // ОТПРАВКА ЗАЯВКИ !!!!!!!!!!!!!!!!!!!!!!!!
        {
            string Error = "";
            #region Valid text box
            if (CheckCreatePanelTexboxNotEmpty())
            {
                if (!CheckEmail(maskedEmail.Text)) { Error += "Email введен некорректно\n"; }
                if (maskedUserPhone.Text.Substring(1, 1) != "7") { Error += "Номер телефона введен некорректно\n"; }
                DateTime dDate;
                if (!DateTime.TryParse(maskedUserBirthDay.Text, out dDate))
                {
                    Error += "Дата рождения введена некорректно\n";
                }
                else
                {
                    if (DateTime.Now.Year - DateTime.Parse(maskedUserBirthDay.Text).Year < 18) { Error += "Вам менее 18 лет\n"; }
                }
                if (!DateTime.TryParse(maskedTextBoxFirstDay.Text, out dDate))
                {
                    Error += "Дата первой оплаты введена некорректно\n";
                }
                else
                {
                    DateTime dateTime = DateTime.Parse(maskedTextBoxFirstDay.Text);
                    if (dateTime.Day >= DateTime.Now.Day + 10 && dateTime <= DateTime.Now)
                    {
                        Error += "Дата первого платежа более 10 дней. И не может быть раньше или сегодня.\n";
                    }
                    
                }
                if (String.IsNullOrEmpty(FileAddres))
                {
                    Error += "Вы не загрузили копию паспорта\n";
                }
                if (!String.IsNullOrEmpty(Error))
                {
                    MessageBox.Show($"{Error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    CreateClaim();
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
        private bool CheckCreatePanelTexboxNotEmpty() //Проверка пустых полей
        {
            foreach (var cont in panelCreateClaim.Controls)
            {
                if (cont.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)cont;
                    if (String.IsNullOrEmpty(tb.Text)) { return false; }
                }
                if (cont.GetType() == typeof(MaskedTextBox))
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

            maskedCardNumber.SelectionStart = maskedCardNumber.MaskedTextProvider.LastAssignedPosition + 1;
        }
        private void maskedUserBirthDay_Click(object sender, EventArgs e)
        {
            maskedUserBirthDay.SelectionStart = maskedUserBirthDay.MaskedTextProvider.LastAssignedPosition + 1;
        }
        private void maskedTextBoxFirstDay_Click(object sender, EventArgs e)
        {
            maskedTextBoxFirstDay.SelectionStart = maskedTextBoxFirstDay.MaskedTextProvider.LastAssignedPosition + 1;
        }
        private void textBoxUserPassport_Click(object sender, EventArgs e)
        {
            // if (textBoxUserPassport.Mask.Length = ) { textBoxUserPassport.SelectionStart = 0; }
            textBoxUserPassport.SelectionStart = textBoxUserPassport.MaskedTextProvider.LastAssignedPosition + 1;
        }
        private void textBoxUserPassport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBoxUserPassport.SelectionStart = textBoxUserPassport.Text.Length;
                e.Handled = true;
            }
        }
        private void maskedUserPhone_Click(object sender, EventArgs e)
        {
            maskedUserPhone.SelectionStart = maskedUserPhone.MaskedTextProvider.LastAssignedPosition + 1;
        }
        private void maskedUserPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                maskedUserPhone.SelectionStart = maskedUserPhone.Text.Length;
                e.Handled = true;
            }
        }

        private void textBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (!Char.IsLetter(letter) && e.KeyChar != 8) { e.Handled = true; }
        }
        private void textBoxUserSecName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (!Char.IsLetter(letter) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void textBoxUserMidName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (!Char.IsLetter(letter) && e.KeyChar != 8) { e.Handled = true; }
        }
        #endregion
        string FileAddres = "";
        private void buttonLoadFile_Click(object sender, EventArgs e) //Загрузить файл.
        {
            try
            {
                openFileDialog1.Filter = "PDF files(.pdf)|*.pdf";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    FileAddres = openFileDialog1.FileName;
                    labelFileName.Text = $"Файл: {Path.GetFileNameWithoutExtension(FileAddres)}";
                }
            }
            catch (Exception)
            {

                MessageBox.Show($"Ой, что то пошло не так.\nВозможно файл сейчас открыт,закройте его и загрузите ещё раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void CreateClaim() // Создание заявки и отправка
        {
            BClaim claim = new BClaim();
            User user = new User();
            #region Claim
            while (true)
            {
                claim.Id = BClaim.GenerateID(6);
                if (!BaseDataLite.CheckLoanID(claim.Id)) { break; }
            }
            claim.SumLoan = Convert.ToInt32(textBoxSumLoan.Text);
            claim.Days = Convert.ToInt32(textBoxDays.Text);
            claim.FirstDate = DateTime.Parse(maskedTextBoxFirstDay.Text);
            if (radioButtonCard.Checked) { claim.CardNumber = maskedCardNumber.Text; } else { claim.CardNumber = "-"; }
            claim.SumPaid = Convert.ToInt32(labelPaidSum.Text);
            claim.LastDate = claim.FirstDate.AddDays(claim.Days);
            claim.Fine = 0;
            claim.PaidOut = 0;
            if (radioButtonCard.Checked)
            {
                claim.type = "карта";
            }
            else
            {
                claim.type = "наличка";
            }
            claim.status = "открыто";
            #endregion
            #region User
            if (!BaseDataLite.CheckUserExist(textBoxUserPassport.Text))
            {
                while (true)
                {
                    user.Id = BClaim.GenerateID(4);
                    if (!BaseDataLite.CheckUsersID(user.Id)) { break; }
                }
                user.Name = textBoxUserName.Text;
                user.SecoundName = textBoxUserSecName.Text;
                user.MiddleName = textBoxUserMidName.Text;
                user.BirthDay = DateTime.Parse(maskedUserBirthDay.Text);
                user.Phone = maskedUserPhone.Text;
                user.Email = maskedEmail.Text;
                user.Passport = textBoxUserPassport.Text;
                LoadingScreen(true);
                BaseDataLite.CreateNewUser(user.Id, user.Name, user.SecoundName, user.MiddleName, user.BirthDay, user.Phone, user.Email, user.Passport);
                LoadingScreen(false);
            }
            else
            {
                user.Id = BaseDataLite.GetUserID(textBoxUserPassport.Text);
            }

            #endregion
            #region Docs
            int docid;
            while (true)
            {
                docid = BClaim.GenerateID(5);
                if (!BaseDataLite.CheckDocID(claim.Id)) { break; }
            }
            #endregion
            if (!BaseDataLite.CheckSeveralLoan(user.Id))
            {

                try
                {
                    LoadingScreen(true);
                    BaseDataLite.SendClaim(claim.Id, claim.SumPaid / claim.Days, claim.SumLoan, claim.Days, claim.FirstDate, user.Id, docid, claim.CardNumber, claim.SumPaid, claim.Fine, claim.PaidOut, claim.type, claim.status);
                    BaseDataLite.SendFile(FileAddres, docid);
                    LoadingScreen(false);
                    NotificationWindow f = new NotificationWindow($"{claim.Id}", claim.SumLoan, claim.Days, $"{claim.SumPaid}");
                    DialogResult result = f.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (panelCreateClaim.Visible == true)
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
                }
                catch (Exception)
                {
                    LoadingScreen(false);
                    MessageBox.Show("Ой, что-то пошло не так ;(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Похоже что у вас уже есть принятые или новые заявки.\nЗавершите предыдущий займ, для того чтобы взять новый.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadingScreen(bool freez)
        {
            if (freez)
            {
                this.Enabled = false;
                ScreenLoading.BringToFront();
                ScreenLoading.Visible = true;

            }
            else
            {
                ScreenLoading.Visible = false;
                this.Enabled = true;
            }
        }
        #region Страница поиска заявки
        private void buttonFindClaim_Click(object sender, EventArgs e)
        {
            BaseDataLite bd = new BaseDataLite();
            BClaim claim = new BClaim();
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                DataTable loantb = bd.GetLoanbyID(bd, textBox1.Text);
                if (loantb != null)
                {
                    claim = BaseDataLite.FillClaim(Convert.ToInt32(textBox1.Text), bd);
                    labelClaimSumLoan.Text = $"{claim.SumLoan} руб.";
                    double proc = 1.0;
                    if (claim.SumLoan > 35000)
                    {
                        proc = 2.0;
                    }
                    double sumfine = (double)claim.SumLoan * (proc / 100.0) * (double)claim.Fine;
                    labelClaimSumPaid.Text = $"{claim.SumPaid} руб.\nвключая штраф:{sumfine}руб.({(sumfine / claim.SumLoan) * 100}%)";
                    labelClaimFineDays.Text = $"{claim.Fine} дня";
                    labelClaimPiadout.Text = $"{claim.PaidOut} руб.";
                    labelClaimStatus.Text = $"{claim.status}";
                    labelClaimDays.Text = $"{claim.Days} дней до {claim.LastDate.ToString("d")}";
                    labelClaimFirstDate.Text = $"{claim.FirstDate.ToString("d")}";
                    switch (labelClaimStatus.Text.ToLower())
                    {
                        case "открыто":
                            labelClaimStatus.ForeColor = Color.FromArgb(236, 214, 22);
                            buttonPay.Enabled = false;
                            break;
                        case "принято":
                            labelClaimStatus.ForeColor = Color.FromArgb(44, 218, 65);
                            buttonPay.Enabled = true;
                            break;
                        case "закрыто":
                            labelClaimStatus.ForeColor = Color.FromArgb(140, 140, 140);
                            buttonPay.Enabled = false;
                            break;
                        case "отклонено":
                            labelClaimStatus.ForeColor = Color.FromArgb(180, 37, 23);
                            buttonPay.Enabled = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Займ не найден!", "Займ не найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else
            {
                MessageBox.Show("Строка пуста!", "Пустая строка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            //todo:Сделать оплату
        }
    }//todo При принятии заявки дата первого платежа в день принятия. если первая дата оплаты прошла.
    //todo:обновление данных пользователя
}
    #endregion