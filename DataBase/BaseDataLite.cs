using System;
using System.Data.SQLite;
using System.IO;
using System.Data;
using ClientUser;

namespace BaseData
{
    public class BaseDataLite
    {
        public SQLiteConnection connection;
        SQLiteDataAdapter adapter = null;
        private DataTable table = null;
        SQLiteCommand command = null;
        /*
         * статусы
         * new - новый
         * apply - принятый
         * closed - закрытый
         * rejected - отклоненный
         */

        private static string connstr = "data source=" + FindDataBase(); //строка подключения 
        public BaseDataLite()
        {
            connection = new SQLiteConnection(connstr);
            connection.Close();
            if (File.Exists(FindDataBase()) && connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private static string FindDataBase()
        {
            string str;
            try
            {
                using (StreamReader file = new StreamReader("./ConnPath.txt"))
                {
                    str = file.ReadToEnd();
                }
                return str;
            }
            catch (Exception)
            {
                return "";
            }                
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
            string query = $"SELECT * FROM Users where secound_name = '{sname}'";
            command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable GetUserbyID(BaseDataLite bd, string id)  //Получить всех пользователей по id заявки
        {
            string query = $"SELECT * FROM Users where id = '{id}'";
            command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable GetLoanbyStatus(BaseDataLite bd, string status) //Получить все записи опр. статуса заявки
        {
            try
            {
                string query = $"SELECT * FROM Loan where status = '{status}'";
                command = new SQLiteCommand(query, bd.connection);
                command.ExecuteNonQuery();
                adapter = new SQLiteDataAdapter(query, connection);
                table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable GetLoanbyID(BaseDataLite bd, string id) //Получить зайвку по id 
        {
            try
            {
                string query = $"SELECT * FROM Loan where id ={id} ";
                command.ExecuteNonQuery();
                adapter = new SQLiteDataAdapter(query, connection);
                table = new DataTable();
                adapter.Fill(table);
                if(table.Rows[0][0] == DBNull.Value)
                {
                    return null;
                }
                return table;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool CheckLoanID(int id)  //проверить существование id займа
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
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
        }
        //for test 5518473851156466 cn
        public static void SendClaim(int id, int paid, int sumLoan, int days, DateTime fdate, int clientid, int docs, string cardnumber, int sumpaid,
            int fineday, int paidout, string type, string status) //ОТПРАВИТЬ ЗАЯВКУ НА ЗАЙМ + paid по(читать
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                string firstday = fdate.ToString("d");
                conn.Open();
                string query = $"INSERT INTO Loan(id,paid,sum_loan,days,fdate,clientid,docs,cardnumber,status,type,sum_paid,fineday,paidout)" +
                    $" VALUES({id},{paid},{sumLoan},{days},'{firstday}',{clientid},{docs},'{cardnumber}','{status}','{type}',{sumpaid},{fineday},{paidout})";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public static bool CheckUsersID(int id)  //ПРОВЕРИТЬ id  юзера
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
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
        }
        public static bool CheckDocID(int id)  //ПРОВЕРИТЬ id  юзера
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"SELECT * FROM Docs where id = {id}";
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
        }
        public static void DeleateOld() //УДАЛИТЬ СТАРЫЕ
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"DELETE FROM Loan where (status = 'отклонено')";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                conn.Close();
            }
        }
        public static void UpdateBaseDate(DataTable tb,string table) //Обновить базу данных
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"SELECT * FROM {table}";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query,conn);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapter);
                adapter.Update(tb);
                conn.Close();
            }
        }
        public static bool CheckUserExist(string passport)       // Проверить сущестование пользователя по паспорту 
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"SELECT * FROM Users where passport = '{passport}'";
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
        }
        public static int GetUserID(string passport)  //Получить id пользователя по паспорту 
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"SELECT id FROM Users where passport = '{passport}'";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                int res = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();
                return res;
            }
        }
        public static void CreateNewUser(int id, string name, string sname, string mname, DateTime birth, string phone, string email, string passport) //создать нового пользователя
        {
            string date_of_birth = birth.ToString("d");
            if (!CheckUserExist(passport))
            {
                using (SQLiteConnection conn = new SQLiteConnection(connstr))
                {
                    conn.Open();
                    string query = $"INSERT INTO Users(id,name,secound_name,middle_name,birthsday,phone,email,passport) VALUES({id},'{name}','{sname}','{mname}','{date_of_birth}','{phone}','{email}','{passport}')";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static void SendFile(string filename, int id)     // Загружает файл в Базу данных.                   
        {                                                       //docs id генерируется для отправки в таблицы зайвок и документов
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"INSERT INTO Docs(id,File) VALUES({id},@File)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                byte[] export;
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    export = new byte[fs.Length];
                    fs.Read(export, 0, export.Length);
                }
                cmd.Parameters.Add("@File", DbType.Binary).Value = export;
                //cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        //public static byte[] GetFile(int id)  // Получает файл из БД по id заявки
        //{
        //}
        public static void SetFine(int days,int idclaim,BClaim claim)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connstr))
                {
                    conn.Open();
                    string query = $"SELECT fineday FROM Loan where id = {idclaim}";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    int res = Convert.ToInt32(cmd.ExecuteScalar());
                    days += res;
                    int proc = 1;
                    if (claim.SumPaid > 35000)
                    {
                        proc = 2;
                    }
                    int newsum = claim.SumPaid * (proc / 100) * days;
                    string query2 = $"UPDATE Loan SET fineday = {days}, WHERE (id = {idclaim})";
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
            
        }
        public static void SetNewStatus(int idclaim, string status)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connstr))
            {
                conn.Open();
                string query = $"UPDATE Loan SET status = '{status}' WHERE (id = {idclaim})";
                SQLiteCommand cmd2 = new SQLiteCommand(query, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
            };
        }
        public static BClaim FillClaim(int id,BaseDataLite bd)
        {
            DataTable loantb = bd.GetLoanbyID(bd, $"{id}");
            BClaim claim = new BClaim();
            claim.Id = id;
            claim.SumLoan = Convert.ToInt32(loantb.Rows[0][2]);
            claim.Days = Convert.ToInt32(loantb.Rows[0][3]);
            claim.Fine = Convert.ToInt32(loantb.Rows[0][11]);
            claim.CardNumber = Convert.ToString(loantb.Rows[0][7]);
            claim.type = Convert.ToString(loantb.Rows[0][9]);
            claim.status = Convert.ToString(loantb.Rows[0][8]);
            claim.PaidOut = Convert.ToInt32(loantb.Rows[0][12]);
            claim.SumPaid = Convert.ToInt32(loantb.Rows[0][10]);
            return claim;
        }
    }
}

