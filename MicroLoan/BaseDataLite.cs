using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Text;
using System.Data.Entity;

namespace ClientOP
{ 
    class BaseDataLite
    {
        public SQLiteConnection connection;
        SQLiteDataAdapter adapter = null;
        private DataTable table = null;
        public BaseDataLite()
        {
            connection = new SQLiteConnection("Data Source=database.sqlite3");
            if (File.Exists("./database.sqlite3"))
            {
                connection.Open();
            }

        }
        public DataTable ShowAll(BaseDataLite bd)
        {
            string query = "SELECT * FROM CLIENT";
            SQLiteCommand command = new SQLiteCommand(query, bd.connection);
            command.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(query,connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
