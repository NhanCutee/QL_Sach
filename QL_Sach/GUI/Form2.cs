using QL_Sach.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QL_Sach
{
    public partial class Form2 : Form
    {
        SachBUS sachBUS;
        public Form2()
        {
            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sachBUS = new SachBUS();
            sachBUS.themSach();
            LoadSach();

        }
        private void LoadSach()
        {
            dataGridView.DataSource = sachBUS.SachList.ToList();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            
            List<SachBUS> list = new List<SachBUS>();
            dataGridView.DataSource = list;
            
            sachBUS.themSach();
            LoadSach();
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            sachBUS.xoaSach(index);
            LoadSach();
        }

       
    }
}
