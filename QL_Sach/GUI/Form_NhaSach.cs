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
    public partial class Form_NhaSach : Form
    {
        public string iTitle { get; set; }

        private bool userPress = false;
        public bool UserPress { get => userPress; }



        #region "Thong tin sach"
        private string maNhaSach;
        private string tenNhaSach;
        private string diaChi;
        private string tenQuanLi;
        private int soLuongNhanVien;

        public string MaNhaSach { get => maNhaSach; set => maNhaSach = value; }
        public string TenNhaSach { get => tenNhaSach; set => tenNhaSach = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TenQuanLi { get => tenQuanLi; set => tenQuanLi = value; }
        public int SoLuongNhanVien { get => soLuongNhanVien; set => soLuongNhanVien = value; }

        #endregion


        public Form_NhaSach()
        {
            InitializeComponent();
        }

        public Form_NhaSach(string title)
        {
            //phuong thuc khoi tao form nhap
            InitializeComponent();
            this.iTitle = title;
            this.Text = iTitle;

        }
        public Form_NhaSach(string title, DataGridViewRow currentRow)
        {
            InitializeComponent();
            //phuong thuc khoi tao form chinh sua
            this.iTitle = title;
            textbox_MaNhaSach.Text = currentRow.Cells[0].Value.ToString();
            textBox_TenNhaSach.Text = currentRow.Cells[1].Value.ToString();
            
            textBox_DiaChi.Text = currentRow.Cells[2].Value.ToString();

            textBox_TenQuanLi.Text= currentRow.Cells[3].Value.ToString();
            textBox_SoLuongNhanVien.Text = currentRow.Cells[4].Value.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.label_Title.Text = iTitle;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Nhap_Click(object sender, EventArgs e)
        {
            bool nhapDung = true;
            //viet them dieu kien nhap, them so phan tu toi da duoc nhap, viet hoa ki tu, chuan hoa chuoi, .................
            if (!textbox_MaNhaSach.Text.All(Char.IsLetterOrDigit) || textbox_MaNhaSach.Text == "")
            {
                nhapDung = false;
                MessageBox.Show("Nhập sai mã nhà sách, kí tự hợp lệ: a-z, A-Z, 0-9");
                return;
            }
            if (textBox_TenNhaSach.Text == "" || textBox_TenNhaSach.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Tên nhà sách không được để trống.");
                return;
            }
            if (textBox_DiaChi.Text == "" || textBox_DiaChi.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            if (textBox_TenQuanLi.Text == "" || textBox_TenQuanLi.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Tên quản lí không được để trống");
                return;
            }
            if (textBox_SoLuongNhanVien.Text == "" || textBox_SoLuongNhanVien.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Số lượng nhân viên không được để trống");
                return;
            }
            if (!textBox_SoLuongNhanVien.Text.All(Char.IsDigit))
            {
                nhapDung = false;
                MessageBox.Show("Số lượng nhân viên phải là số.");
                return;
            }


            if (nhapDung)
            {
                DialogResult dialogResult;
                if (iTitle == "Nhập thông tin quyển sách")
                    dialogResult = MessageBox.Show("Nhập nhà sách?", "Chú ý", MessageBoxButtons.YesNo);
                else
                    dialogResult = MessageBox.Show("Xác nhận sửa nhà sách?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                userPress = true;
                maNhaSach = textbox_MaNhaSach.Text.ToUpper();
                tenNhaSach = textBox_TenNhaSach.Text;
                DiaChi=textBox_DiaChi.Text;
                tenQuanLi = textBox_TenQuanLi.Text;
                soLuongNhanVien=Convert.ToInt32((textBox_SoLuongNhanVien.Text)); 
                this.Close();
            }

        }
        private void button_NhapLai_Click(object sender, EventArgs e)
        {
            textbox_MaNhaSach.Text = "";
            textBox_TenNhaSach.Text = "";
            textBox_TenQuanLi.Text = "";
            textBox_DiaChi.Text = "";
            textBox_SoLuongNhanVien.Text ="";
            

            textbox_MaNhaSach.Select();
        }
        private void button_Huy_Click(object sender, EventArgs e)
        {
            userPress = false;
            this.Close();
        }

        //Chinh sua lai them phan nhan nut TAB se qua text box tiep theo, nhan enter se nhap, nhap sai se bao loi,...
    }
}
