using System;

namespace Client
{
    internal class Transaction
    {
        public int SenderId { get; set; }
        public int RecieveId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int TransactId { get; set; }

        public override string ToString() => $"{TransactId};{RecieveId};{SenderId};{Amount};{Date}";
    }
}