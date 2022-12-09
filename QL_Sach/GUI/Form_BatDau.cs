using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Sach.GUI
{
    public partial class Form_BatDau : Form
    {
        public Form_BatDau()
        {
            InitializeComponent();
            this.Text = "Chọn cấu trúc dữ liệu";
        }

        private void button_BatDau_Click(object sender, EventArgs e)
        {
            int tab = 1;
            if (radioButton_Sach.Checked == true)
                tab = 1;
            else if (radioButton_NhaSach.Checked == true)
                tab = 2;
            else
                tab = 3;

            string loaiDS = "LibListT";
            if (radioButton_LibListT.Checked == true)
                loaiDS = "LibListT";
            else if (radioButton_DSDac.Checked == true)
                loaiDS = "DSDac";
            else 
                loaiDS = "DSLK";

            this.Hide();
            Form_QLChụng f = new Form_QLChụng(loaiDS,tab);
            f.ShowDialog();
            this.Close();
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
