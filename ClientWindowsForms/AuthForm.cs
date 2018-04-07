using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Services;
using BankClientServer.Utils;
using Client.Utils;
using Client;

namespace ClientWindowsForms
{
    public partial class AuthForm : Form
    {
        private string _login;
        private string _pass;
        private string[] _input = new string[2];

        public AuthForm()
        {
            InitializeComponent();
            socketStatus.Text = "Подключение установленно:  " + SocketClient._sender.Connected.ToString();
            if (!SocketClient._sender.Connected) authButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login = loginTextBox.Text;
            _pass = passTextBox.Text;
            _input[0] = _login;
            _input[1] = _pass;
            AbstractService service = new AuthService(_input);
            string answer = service.Answer;
            if (answer.IndexOf("<0x") > -1)
            {
                ErrorsHandler err = new ErrorsHandler();
                string mess = err.GetErrorMessage(service.Answer);
                MessageBox.Show($"{mess}",  "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                User user = new User(_login);

                UserMenuForm userMenu = new UserMenuForm(user);
                userMenu.Show();
                this.Hide();
            } 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm reg = new RegForm();
            reg.Show();
            this.Hide();
        }
    }
}
