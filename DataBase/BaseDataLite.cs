using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace BaseData
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
        //for test 5518473851156466 cn

        public void SendClaim(int sl, int days, int cardnumber, int sump, DateTime fd, DateTime ld)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = DataBase.db");
            conn.Open();
            string query = $"";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static bool CheckUsersID(int id)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = DataBase.db");
            conn.Open();
            string query = $"SELECT * FROM Users where id = {id}";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt); ;
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        public static bool CheckID(int id)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = DataBase.db");
            conn.Open();
            string query = $"SELECT * FROM Loan where id = {id}";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt); ;
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else { return false; }
        }
        //public static bool CheckUserExist(User)
        //{
        //    SQLiteConnection conn = new SQLiteConnection("Data Source = DataBase.db");
        //    conn.Open();
        //    string query = $"SELECT * FROM Loan where id = {id}";
        //}
        #endregion
    }
}
