using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Menu;
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

            AbstractMenu<int> fakeEntryMenu = new FAkeEntryMenu_CorrectUserInput();
            fakeEntryMenu.Input = 1;
            pr.EntryMenu = fakeEntryMenu;
            

            Assert.DoesNotThrow(() => pr.StartProgram());
        }


    }

    internal class FAkeEntryMenu_CorrectUserInput : AbstractMenu<int>
    {
        private int fakeCorrectInput;

        public override int Input
        {
            get
            {
                return fakeCorrectInput;
            }
            set
            {
                fakeCorrectInput = value;
            }
        }
    }
}
