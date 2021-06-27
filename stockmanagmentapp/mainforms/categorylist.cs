using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stockmanagmentapp.mainforms;

namespace stockmanagmentapp.mainforms
{
    public partial class categorylist : Form
    {
        public categorylist()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            newcategoryform frm = new newcategoryform();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
