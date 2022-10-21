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
        List<SachBUS> sachList;
        public Form2()
        {
            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sachList = new List<SachBUS>();
            LoadSach();

        }
        private void LoadSach()
        {
            dataGridView.DataSource = sachList.ToList();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            //john cena 
        }
    }
}
