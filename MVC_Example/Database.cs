using MVC_Example.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Service.Methods
{
    public class Database
    {
        private Database()
        {
        }

        private string databaseName = "mvcdb";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static Database _instance = null;
        public static Database Instance()
        {
            if (_instance == null)
                _instance = new Database();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                conn_string.Server = "localhost";
                conn_string.UserID = "root";
                conn_string.Password = "root";
                conn_string.Database = "mvcdb";
                    if (String.IsNullOrEmpty(databaseName))
                    return false;
                connection = new MySqlConnection(conn_string.ToString());
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }

        public bool command(string query)
        {
            Debug.WriteLine("KOMUT:" + query);
            MySqlCommand com = new MySqlCommand(query, connection);
            int status = com.ExecuteNonQuery();

            if (status==1)
                return true;

            return false;
        }

        public string get(string command, string column)
        {
            Debug.WriteLine("KOMUT:" + command);
            MySqlCommand com = new MySqlCommand(command, connection);
            using (var reader = com.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader[column].ToString();
                }
            }

            return null;
        }

        public bool get_Bool(string command)
        {
            Debug.WriteLine("KOMUT:" + command);
            MySqlCommand com = new MySqlCommand(command, connection);
            using (var reader = com.ExecuteReader())
            {
                try
                {
                    if (reader.Read())
                        return true;
                }
                finally { reader.Close(); }
            }

            return false;
        }

        public List<Notes> get_Notes(string AccountID)
        {
            List<Notes> list = new List<Notes>();
            MySqlCommand cmd = new MySqlCommand("select * from Notes where account_id="+AccountID, connection);
            Debug.WriteLine("LIST:"+AccountID);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Notes()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        subject = reader["subject"].ToString(),
                        description = reader["description"].ToString(),
                        type = Convert.ToInt32(reader["type"]),
                        status = Convert.ToInt32(reader["status"]),
                        date_time = reader["date_time"].ToString()
                    });
                }

                reader.Close();
            }

            return list;
        }
    }
}
