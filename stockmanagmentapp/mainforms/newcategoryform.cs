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
    public partial class newcategoryform : Form
    {
        public newcategoryform()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //creating instance from categorybll
        categorybll bll = new categorybll();
        private void newcategoryform_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text.Trim() == "")
                MessageBox.Show("Category Name is Empty");
            else
            {
                cateogorydetaildto category = new cateogorydetaildto();
                category.categoryname = bunifuTextBox1.Text;
                if (bll.Insert(category))
                {
                    MessageBox.Show("Category was Added Successfully");
                    bunifuTextBox1.Clear();
                }
            }
        }
    }
}
