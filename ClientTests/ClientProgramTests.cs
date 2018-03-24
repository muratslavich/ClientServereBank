using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ClientTests
{
    [TestFixture]
    public class ClientProgramTests
    {

        [Test]
        public void StartProgramm_IncorrectInput_ThrowException()
        {

            Client.ClientProgramm pr = new Client.ClientProgramm();



            Assert.Throws<InvalidOperationException>(() => pr.StartProgram());
        }


    }
}
