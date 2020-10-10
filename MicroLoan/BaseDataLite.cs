using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Text;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ClientOP
{
    public class BaseDataLite
    {
        
        public SQLiteConnection connection;
        SQLiteDataAdapter adapter = null;
        private DataTable table = null;
        SQLiteCommand command = null;
        public BaseDataLite()
        {
            connection = new SQLiteConnection($"Data Source=DataBase.db");
            connection.Close();
            if (File.Exists("./DataBase.db") && connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public DataTable ShowAll(BaseDataLite bd, string tablename)
        {
            string query = $"SELECT * FROM {tablename}";
            command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static string GetPath()
        {
            if (File.Exists("./DataBase.db"))
            {
                return Path.GetFullPath("DataBase.db");
            }
            else
            {
                return null;
            }
        }
        #region OperatorQuery
        public DataTable GetUserbyName(BaseDataLite bd, string sname)  //Получить все записи по фамилии
        {
            string query = $"";
            command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable GetUserbyID(BaseDataLite bd, string id)  //Получить все записи по id заявки
        {
            string query = $"";
            command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable GetLoanbyStatus(BaseDataLite bd, string status) //Получить все записи опр. статуса заявки
        {
            string query = $"";
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        #endregion
        #region UserQuery

        public bool CheckID(int id)
        {
            string query = $"SELECT * FROM Loan where id = {id}";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataAdapter  adapter = new SQLiteDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            bool res;
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else { res = false; }
            return res;
        }
        #endregion
    }
}
