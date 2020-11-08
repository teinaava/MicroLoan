using BaseData;
using ClientOP;
using ClientUser;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
namespace MicroLoan
{
    public partial class OperatorClient : Form
    {
        public OperatorClient()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        BaseDataLite bd = new BaseDataLite();
        DataTable table;
        private void OperatorClient_Load(object sender, EventArgs e)
        {
            if (bd.connection.State == ConnectionState.Open)
            {
                this.Text += " БАЗА ДАННЫХ ПОДКЛЮЧЕНА";
                DataTable table = bd.ShowAll(bd, "Loan");
                dataGridView1.DataSource = table;
                SetTableName(dataGridView1);
            }
            else { this.Text += " БАЗА ДАННЫХ НЕ ПОДКЛЮЧЕНА"; WorkSpaceClaim.Enabled = false; WorkSpaceTable.Enabled = false; }
            listBoxSearchType.SetSelected(0, true);
            listBoxTypeVision.SetSelected(0, true);
            dataGridView1.AllowUserToAddRows = false;
        }
        private void Meunu_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(233, 83, 83), 1);
            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(233, 83, 83), Color.FromArgb(255, 239, 132), 90F);
            graph.FillRectangle(lgb, area);
            graph.DrawRectangle(pen, area);

        }

        #region Buttons
        private void buttonTable_Click(object sender, EventArgs e)
        {
            WorkSpaceClaim.Visible = false;
            WorkSpaceTable.Visible = true;
            WorkSpaceHelp.Visible = false;
        }

        private void buttonClaim_Click(object sender, EventArgs e)
        {
            WorkSpaceClaim.Visible = true;
            WorkSpaceTable.Visible = false;
            WorkSpaceHelp.Visible = false;

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WorkSpaceHelp.Visible = true;
            WorkSpaceClaim.Visible = false;
            WorkSpaceTable.Visible = false;
        }
        #endregion

        private void listBoxTypeVision_Click(object sender, EventArgs e)
        {
            SearchtextBox.Text = "";
            if (listBoxTypeVision.GetSelected(0))
            {
                listBoxSearchType.Enabled = false;
                labelClaimSearchType.Enabled = true;
            }
            else
            {
                listBoxSearchType.Enabled = true;
                labelClaimSearchType.Enabled = false;
            }
        }
        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            
            if (listBoxTypeVision.GetSelected(0))
            {
                table = bd.ShowAll(bd, "Loan");
                dataGridView1.DataSource = table;
            }
            else
            {
                table = bd.ShowAll(bd, "Users");
                dataGridView1.DataSource = table;
            }
            SetTableName(dataGridView1);
        }

        private void OperatorClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            bd.connection.Close();
        }

        private void buttonShowNew_Click(object sender, EventArgs e)
        {
            table = bd.GetLoanbyStatus(bd, "открыто");
            dataGridView1.DataSource = table;
            SetTableName(dataGridView1);
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(SearchtextBox.Text))
            {
                if (listBoxSearchType.Enabled == true)
                {
                    if (listBoxSearchType.GetSelected(0) == true)
                    {
                        table = bd.GetUserbyName(bd, FirstUpper(SearchtextBox.Text.ToLower()));
                        dataGridView1.DataSource = table;
                    }
                    else
                    {
                        table = bd.GetUserbyID(bd, SearchtextBox.Text);
                        dataGridView1.DataSource = table;
                    }
                }
                else
                {
                    table = bd.GetLoanbyID(bd, SearchtextBox.Text);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                MessageBox.Show("Строка поиска пуста!", "Пустая строка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SetTableName(dataGridView1);
        }

        private void SearchtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listBoxSearchType.Enabled == true)
            {
                if (listBoxSearchType.GetSelected(0))
                {
                    char letter = e.KeyChar;
                    if (!Char.IsLetter(letter) && e.KeyChar != 8) { e.Handled = true; }
                }
                else
                {
                    char number = e.KeyChar;
                    if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
                }
            }
            else
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
            }
        }

        private void listBoxSearchType_Click(object sender, EventArgs e)
        {
            SearchtextBox.Text = "";
        }
        public static string FirstUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1) : "");
        }

        private void textBoxIDClaim_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void textBoxFineDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8) { e.Handled = true; }
        }
        #region LaonObject
        BClaim claim = new BClaim();
        #endregion
        #region UserObject
        User user = new User();
        #endregion
        private void buttonOpenClaim_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxIDClaim.Text))
            {
                DataTable loantb = bd.GetLoanbyID(bd, $"{textBoxIDClaim.Text}");
                if (loantb != null)
                {

                    try
                    {
                        DataTable usertb = bd.GetUserbyID(bd, $"{Convert.ToInt32(loantb.Rows[0][5])}");
                        groupBox1.Enabled = true;
                        #region claimdata
                        //GetDataFromBD
                        claim = BaseDataLite.FillClaim(Convert.ToInt32(textBoxIDClaim.Text), bd);
                        //Write data to claim interface
                        labelLoanID.Text = $"№{claim.Id}";
                        lableLoanSum.Text = $"{claim.SumLoan}";
                        labelDays.Text = $"{claim.Days}";
                        lableFineDays.Text = $"{claim.Fine}";
                        labelCardNumber.Text = $"{claim.CardNumber}";
                        labelType.Text = claim.type.ToLower(); ;
                        labelStatus.Text = claim.status.ToLower();
                        double proc = 1.0;
                        if (claim.SumLoan > 35000)
                        {
                            proc = 2.0;
                        }
                        double sumfine = (double)claim.SumLoan * (proc / 100.0) * (double)claim.Fine;
                        labelPaidOUT.Text = $"{claim.PaidOut}/{claim.SumPaid} \nвключая штраф:{sumfine}руб.({(sumfine/claim.SumLoan)*100}%)";
                        #endregion
                        #region userdata
                        //GetDataFromBD
                        user.Id = Convert.ToInt32(loantb.Rows[0][5]);
                        user.Name = Convert.ToString(usertb.Rows[0][1]);
                        user.SecoundName = Convert.ToString(usertb.Rows[0][2]);
                        user.MiddleName = Convert.ToString(usertb.Rows[0][3]);
                        user.Passport = Convert.ToString(usertb.Rows[0][7]);
                        user.BirthDay = Convert.ToDateTime(usertb.Rows[0][4]);
                        user.Phone = Convert.ToString(usertb.Rows[0][5]);
                        user.Email = Convert.ToString(usertb.Rows[0][6]);
                        //Write data to claim interface
                        labelClientId.Text = $"{user.Id}";
                        labelName.Text = $"{user.SecoundName} {user.Name} {user.MiddleName}";
                        labelPass.Text = user.Passport;
                        labelBirthday.Text = user.BirthDay.ToString("d");
                        labelPhone.Text = user.Phone.ToString();
                        labelEmail.Text = user.Email;
                        #endregion
                    }
                    catch (Exception)
                    {
                        groupBox1.Enabled = false;
                        MessageBox.Show("Ой, что-то пошло не так ;(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (Convert.ToInt32(lableFineDays.Text) > 0)
                    {
                        lableFineDays.ForeColor = Color.FromArgb(180, 37, 23);
                        label12.ForeColor = Color.FromArgb(180, 37, 23);
                    }
                    switch (labelStatus.Text.ToLower())
                    {
                        case "открыто":
                            labelStatus.ForeColor = Color.FromArgb(236, 214, 22);
                            buttonSendDecision.Enabled = true;
                            buttonAddFine.Enabled = false;
                            buttonCloseClaim.Enabled = false;
                            break;
                        case "принято":
                            labelStatus.ForeColor = Color.FromArgb(44, 218, 65);
                            buttonSendDecision.Enabled = false;
                            buttonAddFine.Enabled = true;
                            buttonCloseClaim.Enabled = true;
                            break;
                        case "закрыто":
                            labelStatus.ForeColor = Color.FromArgb(140, 140, 140);
                            buttonSendDecision.Enabled = false;
                            buttonAddFine.Enabled = false;
                            buttonCloseClaim.Enabled = false;
                            break;
                        case "отклонено":
                            labelStatus.ForeColor = Color.FromArgb(180, 37, 23);
                            buttonSendDecision.Enabled = false;
                            buttonAddFine.Enabled = true;
                            buttonCloseClaim.Enabled = false;
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
            else { MessageBox.Show("Строка пуста!", "Пустая строка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        } // Отрисовка заявки
        private void buttonSendUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить изменения ?", "Сохранить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string tablename;
                    if (listBoxTypeVision.GetSelected(0))
                    {
                        tablename = "Loan";
                    }
                    else
                    {
                        tablename = "Users";
                    }
                    table = (DataTable)dataGridView1.DataSource;
                    BaseDataLite.UpdateBaseDate(table, tablename);
                    MessageBox.Show("Таблица успешно сохранена.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("Ой, что-то пошло не так ;(\nВозможно вы оставлили пустую строку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonDeleateOLD_Click(object sender, EventArgs e) // Удалить все отклоненые заявки.
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(" Вы уверены что хотите удалить отклоненые заявки ?\n Это приведет к тому, что пользователи утратят доступ к увдомлению об отклонении.\n Уведомление отправленные на почту не удалятся.", "Удалить ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    BaseDataLite.DeleateOld();
                    MessageBox.Show("Успешно удаленно", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ой, что-то пошло не так ;(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddFine_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDataLite.SetFine(Convert.ToInt32(textBoxFineDays.Text), Convert.ToInt32(labelLoanID.Text.Substring(1)), claim);
                MessageBox.Show("Штрафные дни увеличены", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ой, что-то пошло не так ;(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSendDecision_Click(object sender, EventArgs e)
        {
            DecideForm f = new DecideForm();
            DialogResult result = f.ShowDialog();
            try
            {
                if (result == DialogResult.Yes)
                {
                    BaseDataLite.SetNewStatus(Convert.ToInt32(labelLoanID.Text.Substring(1)), "принято");
                    buttonSendDecision.Enabled = false;
                    MessageBox.Show("Заявка принята", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelStatus.ForeColor = Color.FromArgb(44, 218, 65);
                    labelStatus.Text = "принято";
                    DataBase.GeneralMessages.SendEmailNewStatus(labelEmail.Text, "принято", labelName.Text, BaseDataLite.FillClaim(Convert.ToInt32(labelLoanID.Text.Substring(1)), bd));

                }
                else if (result == DialogResult.No)
                {
                    BaseDataLite.SetNewStatus(Convert.ToInt32(labelLoanID.Text.Substring(1)), "отклонено");
                    buttonSendDecision.Enabled = false;
                    MessageBox.Show("Заявка отклонена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelStatus.ForeColor = Color.FromArgb(180, 37, 23);
                    labelStatus.Text = "отклонено";
                    DataBase.GeneralMessages.SendEmailNewStatus(labelEmail.Text, "отклонено", labelName.Text, BaseDataLite.FillClaim(Convert.ToInt32(labelLoanID.Text.Substring(1)), bd));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ой, что-то пошло не так ;(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCloseClaim_Click(object sender, EventArgs e)
        {
            if (labelStatus.Text == "принято") 
            {
                buttonCloseClaim.Enabled = true;
                DialogResult dialogResult = MessageBox.Show("Вы уверены что хотитие закрыть заявку ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    BaseDataLite.SetNewStatus(Convert.ToInt32(labelLoanID.Text.Substring(1)), "закрыто");
                    MessageBox.Show("Заявка закрыта", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelStatus.ForeColor = Color.FromArgb(140, 140, 140);
                    labelStatus.Text = "закрыто";
                    DataBase.GeneralMessages.SendEmailNewStatus(labelEmail.Text, "закрыто", labelName.Text, BaseDataLite.FillClaim(Convert.ToInt32(labelLoanID.Text.Substring(1)), bd));
                } 
            }
        }
        private void SetTableName(DataGridView dataGrid)
        {
            if (dataGrid.ColumnCount == 13)
            {
                dataGrid.Columns[0].HeaderText = "Номер заявки";
                dataGrid.Columns[1].HeaderText = "Оплата в день";
                dataGrid.Columns[2].HeaderText = "Сумма кредита";
                dataGrid.Columns[3].HeaderText = "Срок";
                dataGrid.Columns[4].HeaderText = "Дата первой оплаты";
                dataGrid.Columns[5].HeaderText = "Номер клиента";
                dataGrid.Columns[6].HeaderText = "Номер документа";
                dataGrid.Columns[7].HeaderText = "Номер карты";
                dataGrid.Columns[8].HeaderText = "Статус";
                dataGrid.Columns[9].HeaderText = "Тип выплаты";
                dataGrid.Columns[10].HeaderText = "Сумма к оплате";
                dataGrid.Columns[11].HeaderText = "Просроченно дней";
                dataGrid.Columns[12].HeaderText = "Выплачено";
            }
            else 
            {
                dataGrid.Columns[0].HeaderText = "Номер клиента";
                dataGrid.Columns[1].HeaderText = "Имя";
                dataGrid.Columns[2].HeaderText = "Фамилия";
                dataGrid.Columns[3].HeaderText = "Отчество";
                dataGrid.Columns[4].HeaderText = "День рождения";
                dataGrid.Columns[5].HeaderText = "Телефон";
                dataGrid.Columns[6].HeaderText = "Email";
                dataGrid.Columns[7].HeaderText = "Паспорт";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files(.pdf)|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                LoadingScreen(true);
                File.WriteAllBytes(saveFileDialog.FileName, BaseDataLite.GetFile(Convert.ToInt32(labelLoanID.Text)));
                LoadingScreen(false);
                MessageBox.Show("Ваш файл был успешно загружен и сохранен", "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ой, что-то пошло не так ;(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadingScreen(false);
            }
        }
        public void LoadingScreen(bool freez)
        {
            if (freez)
            {
                this.Enabled = false;
                labelLoading.BringToFront();
                labelLoading.Visible = true;

            }
            else
            {
                labelLoading.Visible = false;
                this.Enabled = true;
            }
        }
    }
}
