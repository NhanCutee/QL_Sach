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
            if (radioButton_Sach.Checked == true)
            {
                //this.Hide();
                //Form2 f = new Form2("LibListT");
                //f.ShowDialog();
                //this.Close();
            }
            else if (radioButton_NhanVien.Checked == true)
            {
                //this.Hide();
                //Form2 f = new Form2("DSDac");
                //f.ShowDialog();
                //this.Close();
            }
            else if (radioButton_NhaSach.Checked == true)
            {
                //this.Hide();
                //Form2 f = new Form2("DSLK");
                //f.ShowDialog();
                //this.Close();
            }
            else
            {
                //MessageBox.Show("Chức năng đang được phát triển.\nHãy chọn chức năng khác.", "Thông báo");
            }

            if (radioButton_LibListT.Checked == true)
            {
                this.Hide();
                Form_QLChụng f = new Form_QLChụng("LibListT");
                f.ShowDialog();
                this.Close();
            }
            else if (radioButton_DSDac.Checked == true)
            {
                this.Hide();
                Form_QLChụng f = new Form_QLChụng("DSDac");
                f.ShowDialog();
                this.Close();
            }
            else if (radioButton_DSLK.Checked == true)
            {
                this.Hide();
                Form_QLChụng f = new Form_QLChụng("DSLK");
                f.ShowDialog();
                this.Close();
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
