using System;

namespace Client
{
    public class Bill
    {
        public int IdBill { get; set; }
        //public string Login { get; set; }
        public string CreateDate { get; set; }
        public string Balance { get; set; }
            
        public override string ToString() => $"{IdBill};{CreateDate};{Balance}";
    }
}
