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
    public partial class stockalert : Form
    {
        public stockalert()
        {
            InitializeComponent();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        productbll bll = new productbll();
        productdto dto = new productdto();
        private void stockalert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.product = dto.product.Where(x => x.stockamount <= 10).ToList();
            bunifuDataGridView1.DataSource = dto.product;
            bunifuDataGridView1.Columns[0].HeaderText = "Product Name";
            bunifuDataGridView1.Columns[1].HeaderText = "Category Name";
            bunifuDataGridView1.Columns[2].HeaderText = "Stock Amount";
            bunifuDataGridView1.Columns[3].HeaderText = "Price";
            bunifuDataGridView1.Columns[4].Visible = false;
            bunifuDataGridView1.Columns[5].Visible = false;
        }
    }
}
