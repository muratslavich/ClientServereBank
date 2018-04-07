using Client;
using Client.Services;
using Client.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWindowsForms
{
    public partial class UserMenuForm : Form
    {
        private User _user;
        private BindingSource bindingSource1 = new BindingSource();
        public UserMenuForm(User user)
        {
            _user = user;
            string login = user.Login;
            InitializeComponent();
            BillListService service = new BillListService(login);
            string answer = service.Answer;

            if (answer.IndexOf("<0x") > -1)
            {
                // .... to do
            }
            else
            {
                List<Bill> billList = new ResponseHandler().ResponseHandlerListToBill(answer);
                bindingSource1.DataSource = billList;
                dataGridView1.DataSource = bindingSource1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                int idBill = (int)row.Cells[0].Value;
                Bill bill = new Bill();
                bill.IdBill = idBill;

                _user.CurrentBill = bill;

                BillMenuForm billMenu = new BillMenuForm(_user.CurrentBill);
                billMenu.Show();
            }
        }
    }
}
