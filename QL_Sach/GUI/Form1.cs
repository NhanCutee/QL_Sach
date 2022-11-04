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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Chọn cấu trúc dữ liệu";
        }

        private void button_BatDau_Click(object sender, EventArgs e)
        {
            if (radioButton_LibListT.Checked == true)
            {
                this.Hide();
                Form2 f = new Form2();
                f.Show();
            }
            else
            {
                MessageBox.Show("Chức năng đang được phát triển.\nHãy chọn chức năng khác.","Thông báo");
            }
            
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
