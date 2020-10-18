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


        private static string connstr = "data source=" + FindDataBase(); //строка подключения 
        public BaseDataLite()
        {
            connection = new SQLiteConnection(connstr);
            if (File.Exists(FindDataBase()) && connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private static string FindDataBase()
        {
            string str;
            using (StreamReader file = new StreamReader("./ConnPath.txt"))
            {
                str = file.ReadToEnd();
            }
            return str;
        }
        public DataTable ShowAll(BaseDataLite bd, string tablename) //Вывести всю таблицу
        {
            string query = $"SELECT * FROM {tablename}";
            command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;

        }
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
        public static bool CheckLoanID(int id)  //проверить существование id займа
        {
            SQLiteConnection conn = new SQLiteConnection(connstr);
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
        //for test 5518473851156466 cn
        public void SendClaim(int sl, int days, int cardnumber, int sump, DateTime fd, DateTime ld) //ОТПРАВИТЬ ЗАЯВКУ НА ЗАЙМ
        {
            SQLiteConnection conn = new SQLiteConnection(connstr);
            conn.Open();
            string query = $"";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static bool CheckUsersID(int id)  //ПРОВЕРИТЬ id  юзера
        {
            SQLiteConnection conn = new SQLiteConnection(connstr);
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
        public static bool CheckUserExist(string passport)       // Проверить сущестование пользователя по паспорту 
        {
            SQLiteConnection conn = new SQLiteConnection(connstr);
            conn.Open();
            string query = $"SELECT * FROM Users where passport = {passport}";
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
        public static string GetUserID(string passport)  //Получить id пользователя по паспорту 
        {
            SQLiteConnection conn = new SQLiteConnection(connstr);
            conn.Open();
            string query = $"SELECT id FROM Users where passport = {passport}";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            string res = cmd.ExecuteScalar().ToString();
            conn.Close();
            return res;
        }
        public static void CreateNewUser(int id, string name, string sname, string mname, DateTime birth, string phone, string email, string passport) //создать нового пользователя
        {
            string date_of_birth = birth.ToString("d");
            if (!CheckUserExist(passport))
            {
                SQLiteConnection conn = new SQLiteConnection(connstr);
                conn.Open();
                string query = $"INSERT INTO Users(id,name,secound_name,middle_name,birthsday,phone,email,passport) VALUES({id},{name},{sname},{mname},{date_of_birth},{phone},{email},{passport})";
                conn.Close();
            }
        }
    }
}

