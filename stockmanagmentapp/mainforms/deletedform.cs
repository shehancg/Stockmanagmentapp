using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockmanagmentapp.mainforms
{
    public partial class deletedform : Form
    {
        public deletedform()
        {
            InitializeComponent();
        }

        private void deletedform_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.Items.Add("Category");
            bunifuDropdown1.Items.Add("Product");
            bunifuDropdown1.Items.Add("Customer");
            bunifuDropdown1.Items.Add("Sales");
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
