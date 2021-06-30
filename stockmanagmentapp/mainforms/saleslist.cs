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
    public partial class saleslist : Form
    {
        public saleslist()
        {
            InitializeComponent();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = general.isnumber(e);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            salesform frm = new salesform();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.sales;
            cleanfilter();
        }
        salesbll bll = new salesbll();
        salesdto dto = new salesdto();

        private void saleslist_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.sales;
            bunifuDataGridView1.Columns[0].HeaderText = "Customer Name";
            bunifuDataGridView1.Columns[1].HeaderText = "Product Name";
            bunifuDataGridView1.Columns[2].HeaderText = "Category Name";
            bunifuDataGridView1.Columns[6].HeaderText = "Sales Amount";
            bunifuDataGridView1.Columns[7].HeaderText = "Price";
            bunifuDataGridView1.Columns[8].HeaderText = "Sales Date";
            bunifuDataGridView1.Columns[3].Visible = false;
            bunifuDataGridView1.Columns[4].Visible = false;
            bunifuDataGridView1.Columns[5].Visible = false;
            bunifuDataGridView1.Columns[9].Visible = false;
            bunifuDataGridView1.Columns[10].Visible = false;
            bunifuDropdown1.DataSource = dto.categories;
            bunifuDropdown1.DisplayMember = "CategoryName";
            bunifuDropdown1.ValueMember = "ID";
            bunifuDropdown1.SelectedIndex = -1;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            List<salesdetaildto> list = dto.sales;
            if (bunifuTextBox2.Text.Trim() != "")
                list = list.Where(x => x.productname.Contains(bunifuTextBox2.Text)).ToList();
            if (bunifuTextBox1.Text.Trim() != "")
                list = list.Where(x => x.customername.Contains(bunifuTextBox1.Text)).ToList();
            if (bunifuDropdown1.SelectedIndex != -1)
                list = list.Where(x => x.categoryid == Convert.ToInt32(bunifuDropdown1.SelectedValue)).ToList();
            if (bunifuTextBox3.Text.Trim() != "")
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
            if (bunifuTextBox4.Text.Trim() != "")
            {
                if (bunifuRadioButton3.Checked)
                    list = list.Where(x => x.price == Convert.ToInt32(bunifuTextBox3.Text)).ToList();
                else if (bunifuRadioButton2.Checked)
                    list = list.Where(x => x.price > Convert.ToInt32(bunifuTextBox3.Text)).ToList();
                else if (bunifuRadioButton1.Checked)
                    list = list.Where(x => x.price < Convert.ToInt32(bunifuTextBox3.Text)).ToList();
                else
                    MessageBox.Show("Please Select a Sales Group");
            }
            if (bunifuCheckBox1.Checked)
                list = list.Where(x => x.salesdate > bunifuDatePicker1.Value && x.salesdate < bunifuDatePicker2.Value).ToList();
            bunifuDataGridView1.DataSource = list;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            cleanfilter();
        }

        private void cleanfilter()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
            bunifuRadioButton1.Checked = false;
            bunifuRadioButton2.Checked = false;
            bunifuRadioButton3.Checked = false;
            bunifuRadioButton7.Checked = false;
            bunifuRadioButton8.Checked = false;
            bunifuRadioButton9.Checked = false;
            bunifuDatePicker1.Value = DateTime.Today;
            bunifuDatePicker2.Value = DateTime.Today;
            bunifuCheckBox1.Checked = false;
            bunifuDropdown1.SelectedIndex = -1;
            bunifuDataGridView1.DataSource = dto.sales;
        }
    }
}
