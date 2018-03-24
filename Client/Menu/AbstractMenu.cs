using System;

namespace BankClientServer.Menu
{
    abstract class AbstractMenu<T>
    {
        public abstract T Input { get; }
        public void ShowMessage(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}
