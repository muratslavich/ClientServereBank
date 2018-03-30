using System;

namespace Client.Menu
{
    abstract class AbstractMenu<T>
    {
        public abstract T Input { get; set; }
        public virtual void ShowMessage(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}
