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
    public partial class productform : Form
    {
        public productform()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }
        public productdto dto = new productdto();
        public productdetaildto detail = new productdetaildto();
        public bool isupdate = false;
        private void productform_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.DataSource = dto.category;
            bunifuDropdown1.DisplayMember = "CategoryName";
            bunifuDropdown1.ValueMember = "ID";
            bunifuDropdown1.SelectedIndex = -1;
            if(isupdate)
            {
                bunifuTextBox1.Text = detail.productname;
                bunifuTextBox2.Text = detail.price.ToString();
                bunifuDropdown1.SelectedValue = detail.categoryid;
            }
        }
        productbll bll = new productbll();
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text.Trim() == "")
                MessageBox.Show("Product Name is Empty");
            else if (bunifuDropdown1.SelectedIndex == -1)
                MessageBox.Show("Please Select a Category");
            else if (bunifuTextBox2.Text.Trim() == "")
                MessageBox.Show("Price is empty");
            else
            {
                if(!isupdate)
                {
                    productdetaildto product = new productdetaildto();
                    product.productname = bunifuTextBox1.Text;
                    product.categoryid = Convert.ToInt32(bunifuDropdown1.SelectedValue);
                    product.price = Convert.ToInt32(bunifuTextBox2.Text);
                    if (bll.Insert(product))
                    {
                        MessageBox.Show("Product was Added");
                        bunifuTextBox1.Clear();
                        bunifuTextBox2.Clear();
                        bunifuDropdown1.SelectedIndex = -1;
                    }
                }
                else
                {
                    if (detail.productname == bunifuTextBox1.Text &&
                        detail.categoryid == Convert.ToInt32(bunifuDropdown1.SelectedValue) &&
                        detail.price == Convert.ToInt32(bunifuTextBox2))
                        MessageBox.Show("There is no change");
                    else
                    {
                        detail.productname = bunifuTextBox1.Text;
                        detail.categoryid = Convert.ToInt32(bunifuDropdown1.SelectedValue);
                        detail.price = Convert.ToInt32(bunifuTextBox2.Text);
                        if(bll.Update(detail))
                        {
                            MessageBox.Show("Product was Updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
