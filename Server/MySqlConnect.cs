using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;

namespace Bank
{
    class MySqlConnect
    {
        //измените имя бд на ваше, а также имя пользователя и пароль если нужно
        private readonly string connStr = "server=localhost;user=root;database=bank;port=3306;password=root;";
        private MySqlConnection conn;

        public void DbConnect()
        {
            conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Подключаемся к MySQL...");
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        internal string GetBillList(string[] _separetedData)
        {
            int accId = 0;
            String bills = null;

            string login = _separetedData[1];
            string query = "SELECT Account.id_Account FROM Account WHERE login='" + login + "';";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                accId = reader.GetInt32(0);
            }

            DbClose();
            DbConnect();

            string queryToBills = "SELECT * FROM bank.bill WHERE Account_id_Account='" + accId + "';";
            MySqlCommand commandToBills = new MySqlCommand(queryToBills, conn);
            MySqlDataReader readerToBills = commandToBills.ExecuteReader();

            List<string> billsList = new List<string>();
            
            while (readerToBills.Read())
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 3; i++)
                {
                    sb.Append(readerToBills.GetValue(i).ToString() + ";");
                }
                sb.Append(readerToBills.GetValue(3).ToString());

                billsList.Add(sb.ToString());
            }

            bills = String.Join(",", billsList);

            return bills;

        }

        //INSERT INTO Account(
        //    name,
        //    surname,
        //    login,
        //    birth_date,
        //    pass
        //)

        //VALUES(
        //	'obama',
        //	'barak',
        //	'president',
        //	'01.05.1964',
        //	'wet'	
        //);
        internal int DoRegistration(string[] _separetedData)
        {
            int resultRegistration = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Account( name, surname, birth_date, login, pass )   ");
            sb.Append("VALUES ( '" + _separetedData[1] + "',  ");
            sb.Append("'" + _separetedData[2] + "',  ");
            sb.Append("'" + _separetedData[3] + "',  ");
            sb.Append("'" + _separetedData[4] + "',  ");
            sb.Append("'" + _separetedData[5] + "'   ");
            sb.Append(");");

            string query = sb.ToString();

            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();

            resultRegistration = 1;

            return resultRegistration;
        }

        internal int CheckAuthorization(string[] separetedData)
        {
            string login = separetedData[1];
            string pass = separetedData[2];

            int resultCheck = 0;

            // query
            string query = "SELECT Account.login, Account.pass FROM Account WHERE login=" + "'" + login + "'" + "AND pass=" + "'" + pass + "'" + "";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string checkLogin = reader.GetString(0);
                string checkPass = reader.GetString(1);

                if (login == checkLogin && pass == checkPass)
                {
                    resultCheck = 1;
                }

                // .... add another check !!!!!!!!!!!!!!!
            }

            return resultCheck;
        }

        public void DbClose()
        {
            conn.Close();
            Console.WriteLine("Соединение закрыто. Готово!");
        }

        internal string ConductTransfer(string[] separetedData)
        {
            throw new NotImplementedException();
        }

        internal string GetMyTransactions(string[] separetedData)
        {
            throw new NotImplementedException();
        }

        internal string CloseBillQuery(string[] separetedData)
        {
            string query = "DELETE FROM bank.bill WHERE id_Bill='" + separetedData[1] + "';";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();

            return "1";
        }

        internal string AddNewBill(string[] separetedData)
        {
            string resultedBill = null;
            int accId = 0;

            string login = separetedData[1];
            string query = "SELECT Account.id_Account FROM Account WHERE login='" + login + "';";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                accId = reader.GetInt32(0);
            }

            DbClose();
            DbConnect();

            string queryToInsert = "INSERT INTO Bill (create_date, balance, Account_id_Account ) VALUES( CURRENT_DATE(), '0', '" + accId + "' );";
            MySqlCommand commandToInsert = new MySqlCommand(queryToInsert, conn);
            commandToInsert.ExecuteNonQuery();

            resultedBill = "1";

            return resultedBill;
        }
    }
}
