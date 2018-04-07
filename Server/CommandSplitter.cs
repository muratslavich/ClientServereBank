namespace Server
{
    class CommandSplitter
    {
        private string data;
        private char delimiter = '|';

        public CommandSplitter(string data)
        {
            this.data = data;
        }

        public string[] ParseData()
        {
            string[] separeted = data.Split(delimiter);
            return separeted;
        }
    }
}
