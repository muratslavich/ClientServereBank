using Bank;
using System;

namespace Server
{
    internal class AuthService
    {
        private string[] separetedData;
        private string _auth;

        // 1-auth
        // 2-log error
        // 3-pass error
        public string AuthResult
        {
            get
            {
                return _auth;
            }

            set
            {
                _auth = value;
            }
        }

        public AuthService(string[] separetedData)
        {
            this.separetedData = separetedData;
        }

        internal string CheckInBase()
        {
            // check
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            AuthResult = connect.CheckAuthorization(separetedData);
            connect.DbClose();

            return AuthResult;
        }
    }
}