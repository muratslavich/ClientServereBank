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
    public partial class BillMenuForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public BillMenuForm(Bill currentBill)
        {
            InitializeComponent();

            TransactionListService service = new TransactionListService(currentBill.IdBill.ToString());
            string answer = service.Answer;

            if (answer.IndexOf("<0x") > -1)
            {

            }

            else
            {
                List<Transaction> transactList = new ResponseHandler().ResponseHandlerListToTransaction(answer);
                bindingSource1.DataSource = transactList;
                dataGridView1.DataSource = bindingSource1;

                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
        }
               
    }
}
