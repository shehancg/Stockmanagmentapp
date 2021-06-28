using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stockmanagmentapp.BLL;
using stockmanagmentapp.DAL.DTO;

namespace stockmanagmentapp.mainforms
{
    public partial class customerform : Form
    {
        public customerform()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        customerbll bll = new customerbll();

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text.Trim() == "")
                MessageBox.Show("Customer Name is Empty");
            else
            {
                customerdetaildto customer = new customerdetaildto();
                customer.customername = bunifuTextBox1.Text;
                if(bll.Insert(customer))
                {
                    MessageBox.Show("Customer was Added");
                    bunifuTextBox1.Clear();
                }
            }
        }
    }
}
