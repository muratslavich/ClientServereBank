using Bank;
using System;

namespace Server
{
    internal class RegService
    {
        private string[] _separetedData;
        private int _regResult;

        public int RegResult
        {
            get
            {
                return _regResult;
            }

            set
            {
                _regResult = value;
            }
        }

        public RegService(string[] _separetedData)
        {
            this._separetedData = _separetedData;
        }

        internal int AddNewUser()
        {
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            RegResult = connect.DoRegistration(_separetedData);
            connect.DbClose(); 

            return RegResult;
        }
    }
}