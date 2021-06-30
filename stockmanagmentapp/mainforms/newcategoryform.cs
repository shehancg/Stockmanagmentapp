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
        public cateogorydetaildto detail = new cateogorydetaildto();
        public bool isupdate = false;
        private void newcategoryform_Load(object sender, EventArgs e)
        {
            if (isupdate)
                bunifuTextBox1.Text = detail.categoryname;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text.Trim() == "")
                MessageBox.Show("Category Name is Empty");
            else
            {
                if(!isupdate)//added
                {
                    cateogorydetaildto category = new cateogorydetaildto();
                    category.categoryname = bunifuTextBox1.Text;
                    if(bll.Insert(category))
                    {
                        MessageBox.Show("Category was added");
                        bunifuTextBox1.Clear();
                    }
                }
                else if(isupdate)
                {
                    if (detail.categoryname == bunifuTextBox1.Text.Trim())
                        MessageBox.Show("There are no changes");
                    else
                    {
                        detail.categoryname = bunifuTextBox1.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Category Was Update");
                            this.Close();

                        }
                    }
                }
            }
        }
    }
}
