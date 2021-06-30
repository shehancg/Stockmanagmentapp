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

        customerbll bll = new customerbll();
        customerdto dto = new customerdto();
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            customerform frm = new customerform();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.customer;
        }

        private void customerlist_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.customer;
            bunifuDataGridView1.Columns[0].Visible = false;
            bunifuDataGridView1.Columns[1].HeaderText = "Customer Name";
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            List<customerdetaildto> list = dto.customer;
            list = list.Where(x => x.customername.Contains(bunifuTextBox1.Text)).ToList();
            bunifuDataGridView1.DataSource = list;
        }
        customerdetaildto detail = new customerdetaildto();
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (detail.id == 0)
                MessageBox.Show("please select a customer from table ");
            else
            {
                customerform form = new customerform();
                form.detail = detail;
                form.isupdate = true;
                this.Hide();
                form.ShowDialog();
                this.Visible = true;
                bll = new customerbll();
                dto = bll.Select();
                bunifuDataGridView1.DataSource = dto.customer;
            }
        }

        private void bunifuDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new customerdetaildto();
            detail.id = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.customername = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
    }
}
