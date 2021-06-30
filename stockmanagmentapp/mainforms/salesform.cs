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
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL.DTO;

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
        public salesdto dto = new salesdto();
        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salesform_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.DataSource = dto.categories;
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
            bunifuDataGridView2.DataSource = dto.customer;
            bunifuDataGridView2.Columns[0].Visible = false;
            bunifuDataGridView2.Columns[1].HeaderText = "Customer Name";
            if (dto.categories.Count > 0)
                combofull = true;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (detail.productid == 0)
                MessageBox.Show("Please select a Product from Product Table");
            else if(detail.customerid==0)
                MessageBox.Show("Please select a Customer from Customer Table");
            else if(detail.stockamount < Convert.ToInt32(bunifuTextBox5.Text))
                MessageBox.Show("You have bought more Sales than Stock ");
            else
            {
                detail.stockamount = Convert.ToInt32(bunifuTextBox5.Text);
                detail.salesdate = DateTime.Today;
                if(bll.Insert(detail))
                {
                    MessageBox.Show("Sales was Added");
                    bll = new salesbll();
                    dto = bll.Select();
                    bunifuDataGridView1.DataSource = dto.product;
                    dto.customer = dto.customer;
                    combofull = false;
                    bunifuDropdown1.DataSource = dto.categories;
                    if (dto.product.Count > 0)
                        combofull = true;
                    bunifuTextBox5.Clear();
                }
            }
        }
        bool combofull = false;
        salesbll bll = new salesbll();

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combofull)
            {
                List<productdetaildto> list = dto.product;
                list = list.Where(x => x.categoryid == Convert.ToInt32(bunifuDropdown1.SelectedValue)).ToList();
                bunifuDataGridView1.DataSource = list;
                if(list.Count==0)
                {
                    bunifuTextBox2.Clear();
                    bunifuTextBox3.Clear();
                    bunifuTextBox4.Clear();
                }
            }
        }

        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            List<customerdetaildto> list = dto.customer;
            list = list.Where(x => x.customername.Contains(bunifuTextBox6.Text)).ToList();
            bunifuDataGridView2.DataSource = list;
            if (list.Count == 0)
                bunifuTextBox1.Clear();
        }
        salesdetaildto detail = new salesdetaildto();
        private void bunifuDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.productname = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.price = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detail.stockamount = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.productid = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.categoryid = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value);
            bunifuTextBox2.Text = detail.productname;
            bunifuTextBox3.Text = detail.price.ToString();
            bunifuTextBox4.Text = detail.stockamount.ToString();
        }

        private void bunifuDataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.customername = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.customerid = Convert.ToInt32(bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value);
            bunifuTextBox1.Text = detail.customername;
        }
    }
}
