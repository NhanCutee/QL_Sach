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


namespace QL_Sach.GUI
{
    public partial class Form2 : Form
    {
        Form3 f;
        SachBUS sachBUS;
        public Form2()
        {
            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sachBUS = new SachBUS();
            LoadSach();

        }
        private void LoadSach()
        {
            dataGridView.DataSource = sachBUS.SachList.ToList();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            string fTitle = "Nhập thông tin quyển sách";
            f = new Form3(fTitle);
            f.ShowDialog();
            if(f.UserPress==true)
            {
                sachBUS.themSach(f.MaSach, f.TenSach, f.TheLoai, f.TenTacGia, f.NhaXuatBan, (DateTime)f.NgayXuatBan, f.GhiChu, f.Gia);
            }    

            LoadSach();
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            sachBUS.xoaSach(index);
            LoadSach();
        }

        private void button_ChinhSua_Click(object sender, EventArgs e)
        {
            string fTitle = "Sửa thông tin quyển sách";
           
            DataGridViewRow currentRow = dataGridView.SelectedRows[0];

            f = new Form3(fTitle,currentRow);
            f.ShowDialog();

            //Dang lam chinh sua, them code sua sach o day
           // MessageBox.Show(currentRow.Cells[5].Value.ToString());
             


        }
    }
}
