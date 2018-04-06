using System;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;

namespace Server
{
    class MySqlDAO
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
            string bills = null;

            string login = _separetedData[1];
            string query = $"SELECT Account.account_id FROM Account WHERE login='{login}';";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                accId = reader.GetInt32(0);
            }

            DbClose();
            DbConnect();

            string queryToBills = $"SELECT * FROM bank.bill WHERE Account_id_Account='{accId}';";
            MySqlCommand commandToBills = new MySqlCommand(queryToBills, conn);
            MySqlDataReader readerToBills = commandToBills.ExecuteReader();

            List<string> billsList = new List<string>();
            
            while (readerToBills.Read())
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(readerToBills.GetString(0) + ";");
                sb.Append(readerToBills.GetDateTime("create_date").ToString("dd/MM/yyyy") + ";");
                sb.Append(readerToBills.GetString(2));

                billsList.Add(sb.ToString());
            }

            bills = String.Join(",", billsList);

            if (billsList.Count == 0) bills = "<0x04>";

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
        internal string DoRegistration(string[] _separetedData)
        {
            string resultRegistration = null;
            string query = $"INSERT INTO Account( name, surname, birth_date, login, pass ) VALUES ( '{_separetedData[1]}', '{_separetedData[2]}', '{_separetedData[3]}', '{_separetedData[4]}', '{_separetedData[5]}');";

            MySqlCommand command = new MySqlCommand(query, conn);

            try
            {
                int affected = command.ExecuteNonQuery();
                if (affected > 0) resultRegistration = "1";
            }
            catch (MySqlException)
            {
                resultRegistration = "<0x03>";
            }

            return resultRegistration;
        }

        internal string CheckAuthorization(string[] separetedData)
        {
            string login = separetedData[1];
            string pass = separetedData[2];

            string resultCheck = null;

            // query
            string query = $"SELECT Account.login, Account.pass FROM Account WHERE login='{login}';";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string checkLogin = reader.GetString(0);
                string checkPass = reader.GetString(1);

                if (login == checkLogin && pass == checkPass)
                {
                    resultCheck = "1";
                }

                else if (login == checkLogin && pass != checkPass)
                {
                    resultCheck = "<0x02>";
                }
            }
            // SQL return null rows
            if (!reader.HasRows)
            {
                resultCheck = "<0x01>";
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
            string transferResult = null;
            string recipientBillId = separetedData[1];
            string recieverBillId = separetedData[2];
            string amount = separetedData[3];

            float recieverBalance = 0;

            string checkRecipientBillQuery = $"SELECT COUNT(*) FROM bank.transactions WHERE Bill_id_Bill='{recipientBillId}';";
            string checkAmount = $"SELECT balance FROM bank.bill WHERE bill_id='{recieverBillId}';";
            string addTransaction = $"INSERT INTO Transactions ( recipient_id, Bill_id_Bill, amount, transact_date ) VALUES ( '{recipientBillId}', '{recieverBillId}', '{amount}', current_timestamp() );";

            MySqlCommand command = new MySqlCommand(checkRecipientBillQuery, conn);
            MySqlDataReader reader = command.ExecuteReader();

            string recipient = null;

            while (reader.Read())
            {
                recipient = reader.GetValue(0).ToString();
            }

            DbClose();

            if (recipient == null)
            {
                transferResult = "<0x09>";
            }
            
            DbConnect();
            MySqlCommand commandToCheckAmmount = new MySqlCommand(checkAmount, conn);
            MySqlDataReader readerCheck = commandToCheckAmmount.ExecuteReader();
                
            while (readerCheck.Read())
            {
                recieverBalance = readerCheck.GetFloat(0);
            }

            DbClose();

            if (recieverBalance < float.Parse(amount))
            {
                transferResult = "<0x08>";
            }

            DbConnect();
            MySqlCommand commandToAddTransact = new MySqlCommand(addTransaction, conn);
            commandToAddTransact.ExecuteNonQuery();

            transferResult = "1";

            return transferResult;
        }

        internal string GetMyTransactions(string[] separetedData)
        {
            string billId = separetedData[1];
            string transactions = null;

            string queryToBills = $"SELECT * FROM bank.transactions WHERE Bill_id_Bill='{billId}';";
            MySqlCommand command = new MySqlCommand(queryToBills, conn);
            MySqlDataReader reader = command.ExecuteReader();

            List<string> transactList = new List<string>();

            while (reader.Read())
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(reader.GetString("transaction_id") + ";");
                sb.Append(reader.GetString("recipient_id") + ";");
                sb.Append(reader.GetString("amount") + ";");
                sb.Append(reader.GetString("transact_date"));
                
                transactList.Add(sb.ToString());
            }

            transactions = String.Join(",", transactList);

            if (transactList.Count == 0)
            {
                transactions = "<0x07>";
            }

            return transactions;
        }

        internal string CloseBillQuery(string[] separetedData)
        {
            string query = $"DELETE FROM bank.bill WHERE bill_id='{separetedData[1]}';";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();

            // .... to do check for remaining balance
            return "1";
        }

        internal string AddNewBill(string[] separetedData)
        {
            string resultedBill = null;
            int accId = 0;

            string login = separetedData[1];
            string query = $"SELECT Account.account_id FROM Account WHERE login='{login}';";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                accId = reader.GetInt32(0);
            }

            DbClose();
            DbConnect();

            string queryToInsert = $"INSERT INTO Bill (create_date, balance, Account_id_Account ) VALUES( CURRENT_DATE(), '0', '{accId}' );";
            MySqlCommand commandToInsert = new MySqlCommand(queryToInsert, conn);
            commandToInsert.ExecuteNonQuery();

            resultedBill = "1";

            return resultedBill;
        }
    }
}
