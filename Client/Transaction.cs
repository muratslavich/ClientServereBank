using System;

namespace Client
{
    internal class Transaction
    {
        public string SenderId { get; set; }
        public string RecieveId { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string TransactId { get; set; }

        public override string ToString() => $"{TransactId};{RecieveId};{SenderId};{Amount};{Date}";
    }
}