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
using stockmanagmentapp.DAL.DAO;

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
        productbll bll = new productbll();
        productdto dto = new productdto();
        private void addstockform_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.product;
            bunifuDataGridView1.Columns[0].HeaderText = "Product Name";
            bunifuDataGridView1.Columns[1].HeaderText = "Category Name";
            bunifuDataGridView1.Columns[2].HeaderText = "Stock Amount";
            bunifuDataGridView1.Columns[3].HeaderText = "Price";
            bunifuDataGridView1.Columns[4].Visible = false;
            bunifuDataGridView1.Columns[5].Visible = false;
            bunifuDropdown1.DataSource = dto.category;
            bunifuDropdown1.DisplayMember = "CategoryName";
            bunifuDropdown1.ValueMember = "ID";
            bunifuDropdown1.SelectedIndex = -1;
            if (dto.category.Count > 0)
                dropdownfull = true;
        }
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text.Trim() == "")
                MessageBox.Show("Please select a Product from the table ");
            else if (bunifuTextBox4.Text.Trim() == "")
                MessageBox.Show("Please give a Stock Amount");
            else
            {
                int sumstock = detail.stockamount;
                sumstock += Convert.ToInt32(bunifuTextBox4.Text);
                detail.stockamount = sumstock;
                if (bll.Update(detail))
                {
                    MessageBox.Show("Stock was Added");
                    bll = new productbll();
                    dto = bll.Select();
                    bunifuDataGridView1.DataSource = dto.product;
                    bunifuTextBox4.Clear();
                }
            }
        }
        bool dropdownfull = false;
        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownfull)
            {
                List<productdetaildto> list = dto.product;
                list = list.Where(x => x.categoryid == Convert.ToInt32(bunifuDropdown1.SelectedValue)).ToList();
                bunifuDataGridView1.DataSource = list;
                if(list.Count==0)
                {
                    bunifuTextBox1.Clear();
                    bunifuTextBox3.Clear();
                    bunifuTextBox4.Clear();
                }
            }
        }
        productdetaildto detail = new productdetaildto();
        private void bunifuDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.productname = (string)bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value;
            bunifuTextBox1.Text = detail.productname;
            detail.price = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value);
            bunifuTextBox3.Text = detail.price.ToString();
            detail.stockamount = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.productid = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }
    }
}
