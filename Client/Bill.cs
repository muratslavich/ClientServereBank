using System;

namespace Client
{
    class Bill
    {
        public int IdBill { get; set; }
        public string Login { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Balance { get; set; }
            
        public override string ToString() => $"{IdBill};{Login};{CreateDate};{Balance}";
    }
}
