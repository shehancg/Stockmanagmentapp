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
using stockmanagmentapp.BLL;
using stockmanagmentapp.DAL.DTO;

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
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.categories;
        }

        categorydto dto = new categorydto();
        categorybll bll = new categorybll();

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void categorylist_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            bunifuDataGridView1.DataSource = dto.categories;
            bunifuDataGridView1.Columns[0].Visible = false;
            bunifuDataGridView1.Columns[1].HeaderText = "Cateogry Name";

        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            List<cateogorydetaildto> list = dto.categories;
            list = list.Where(x => x.categoryname.Contains(bunifuTextBox1.Text)).ToList();
            bunifuDataGridView1.DataSource = list;
        }
        cateogorydetaildto detail = new cateogorydetaildto();
        public cateogorydetaildto detil = new cateogorydetaildto();
        public bool isupdate = false;

        private void bunifuDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new cateogorydetaildto();
            detail.id = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.categoryname = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (detail.id == 0)
                MessageBox.Show("Please select a category from table ");
            else
            {
                newcategoryform form = new newcategoryform();
                form.detail = detail;
                form.isupdate = true;
                this.Hide();
                form.ShowDialog();
                this.Visible = true;

                bll = new categorybll();
                dto = bll.Select();
                bunifuDataGridView1.DataSource = dto.categories;

            }
        }
    }
}
