using System.Security.Cryptography;
using System.Text;

namespace Client.Services
{
    abstract class AbstractService
    {
        public abstract string Answer { get; }

        public virtual string CalculateHash(string pass)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }


    }
}