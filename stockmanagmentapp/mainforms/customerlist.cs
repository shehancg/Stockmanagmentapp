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
    public partial class customerlist : Form
    {
        public customerlist()
        {
            InitializeComponent();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            customerform frm = new customerform();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
