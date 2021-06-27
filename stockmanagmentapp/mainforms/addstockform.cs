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
    public partial class addstockform : Form
    {
        public addstockform()
        {
            InitializeComponent();
        }
        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTextBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }
    }
}
