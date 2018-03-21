using System;

namespace BankClientServer.Menu
{
    abstract class AbstractMenu<T>
    {
        public abstract T Input { get; }
        public void ShowMessage(String mess)
        {
            Console.WriteLine(mess);
        }
    }
}
