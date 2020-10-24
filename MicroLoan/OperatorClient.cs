using BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
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
    }
}
