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
    public partial class salesform : Form
    {
        public salesform()
        {
            InitializeComponent();
        }

        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
