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
    public partial class productlist : Form
    {
        public productlist()
        {
            InitializeComponent();
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            productform frm = new productform();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.product;
            cleanfilters();
        }
        productbll bll = new productbll();
        productdto dto = new productdto();

        private void productlist_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            bunifuDropdown1.DataSource = dto.category;
            bunifuDropdown1.DisplayMember = "CategoryName";
            bunifuDropdown1.ValueMember = "ID";
            bunifuDropdown1.SelectedIndex = -1;
            bunifuDataGridView1.DataSource = dto.product;
            bunifuDataGridView1.Columns[0].HeaderText = "Product Name";
            bunifuDataGridView1.Columns[1].HeaderText = "Category Name";
            bunifuDataGridView1.Columns[2].HeaderText = "Stock Amount";
            bunifuDataGridView1.Columns[3].HeaderText = "Price";
            bunifuDataGridView1.Columns[4].Visible = false;
            bunifuDataGridView1.Columns[5].Visible = false;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            List<productdetaildto> list = dto.product;
            if (bunifuTextBox1.Text.Trim() != null)
                list = list.Where(x => x.productname.Contains(bunifuTextBox1.Text)).ToList();
            if (bunifuDropdown1.SelectedIndex != -1)
                list = list.Where(x => x.categoryid == Convert.ToInt32(bunifuDropdown1.SelectedValue)).ToList();
            if(bunifuTextBox3.Text.Trim()!="")
            {
                if (bunifuRadioButton9.Checked)
                    list = list.Where(x => x.price == Convert.ToInt32(bunifuTextBox3.Text)).ToList();
                else if (bunifuRadioButton8.Checked)
                    list = list.Where(x => x.price > Convert.ToInt32(bunifuTextBox3.Text)).ToList();
                else if (bunifuRadioButton7.Checked)
                    list = list.Where(x => x.price < Convert.ToInt32(bunifuTextBox3.Text)).ToList();
                else
                    MessageBox.Show("Please Select a Price Group");
            }
            if(bunifuTextBox4.Text.Trim()!="")
            {
                if (bunifuRadioButton3.Checked)
                    list = list.Where(x => x.stockamount == Convert.ToInt32(bunifuTextBox4.Text)).ToList();
                else if (bunifuRadioButton2.Checked)
                    list = list.Where(x => x.stockamount > Convert.ToInt32(bunifuTextBox4.Text)).ToList();
                else if (bunifuRadioButton1.Checked)
                    list = list.Where(x => x.stockamount < Convert.ToInt32(bunifuTextBox4.Text)).ToList();
                else
                    MessageBox.Show("Please Select a Stock Group");
            }
            bunifuDataGridView1.DataSource = list;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            cleanfilters();
        }

        private void cleanfilters()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
            bunifuDropdown1.SelectedIndex = -1;
            bunifuRadioButton9.Checked = false;
            bunifuRadioButton8.Checked = false;
            bunifuRadioButton7.Checked = false;
            bunifuRadioButton3.Checked = false;
            bunifuRadioButton2.Checked = false;
            bunifuRadioButton1.Checked = false;
            bunifuDataGridView1.DataSource = dto.product;
        }
    }
}
