using BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
                //MessageBox.Show(BaseDataLite.GetUserID("347389089"));
            }
            else { this.Text += " БАЗА ДАННЫХ НЕ ПОДКЛЮЧЕНА"; }
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
        }

        private void buttonClaim_Click(object sender, EventArgs e)
        {
            WorkSpaceClaim.Visible = true;
            WorkSpaceTable.Visible = false;

            #endregion
        }

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
        }

        private void OperatorClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            bd.connection.Close();
        }

        private void buttonShowNew_Click(object sender, EventArgs e)
        {
            table = bd.GetLoanbyStatus(bd, "new");
            dataGridView1.DataSource = table;
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
                MessageBox.Show("Строка поиска пуста!","Пустая строка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
