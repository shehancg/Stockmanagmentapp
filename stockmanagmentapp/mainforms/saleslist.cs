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
    }
}
