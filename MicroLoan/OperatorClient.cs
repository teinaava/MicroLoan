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
            shadow.BackColor = Color.FromArgb(175, Color.Black);
        }
        private void OperatorClient_Load(object sender, EventArgs e)
        {
            BaseDataLite bd = new BaseDataLite();
            if (bd.connection.State == ConnectionState.Open)
            {
                this.Text += " БАЗА ДАННЫХ ПОДКЛЮЧЕНА";
                DataTable table = bd.ShowAll(bd,"Loan");
                dataGridView1.DataSource = table;
                //MessageBox.Show(BaseDataLite.GetUserID("347389089"));
            }
            else { this.Text += " БАЗА ДАННЫХ НЕ ПОДКЛЮЧЕНА"; }
        }
        #region Gradient
        #endregion

        private void Meunu_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(233, 83, 83), 1);
            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(233, 83, 83), Color.FromArgb(255, 239, 132), 90F);
            graph.FillRectangle(lgb, area);
            graph.DrawRectangle(pen, area);

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void TableLable_Click(object sender, EventArgs e)
        {
            WorkSpaceClaim.Visible = false;
            WorkSpaceTable.Visible = true;
        }
        private void ClaimLable_Click(object sender, EventArgs e)
        {
            WorkSpaceClaim.Visible = true;
            WorkSpaceTable.Visible = false;
        }
    }
}
