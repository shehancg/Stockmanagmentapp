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
    }
}
