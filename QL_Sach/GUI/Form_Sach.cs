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
    public partial class Form_Sach : Form
    {
        public string iTitle { get; set; }

        private bool userPress = false;
        public bool UserPress { get => userPress; }
       


        #region "Thong tin sach"
        private string maSach;
        private string tenSach;
        private string theLoai;
        private string tenTacGia;
        private string nhaXuatBan;
        private DateTime? ngayXuatBan;
        private string ghiChu="";
        private int gia=0;

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
        public string NhaXuatBan { get => nhaXuatBan; set => nhaXuatBan = value; }
        public DateTime? NgayXuatBan { get => ngayXuatBan; set => ngayXuatBan = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int Gia { get => gia; set => gia = value; }

        #endregion


        public Form_Sach()
        {
            InitializeComponent();
        }

        public Form_Sach(string title)
        {
            //phuong thuc khoi tao form nhap
            InitializeComponent();
            this.iTitle =title;
            this.Text = iTitle;

        }
        public Form_Sach(string title, DataGridViewRow currentRow)
        {
            InitializeComponent();
            //phuong thuc khoi tao form chinh sua
            this.iTitle = title;
            textbox_MaSach.Text = currentRow.Cells[0].Value.ToString();
            textBox_TenSach.Text = currentRow.Cells[1].Value.ToString();
            comboBox_TheLoai.Text = currentRow.Cells[2].Value.ToString();
            textBox_TacGia.Text = currentRow.Cells[3].Value.ToString();
            
            comboBox_NhaXuatBan.Text = currentRow.Cells[4].Value.ToString();
            dateTimePicker_NgayXuatBan.Value = (DateTime)currentRow.Cells[5].Value;
            textBox_GhiChu.Text = currentRow.Cells[6].Value.ToString();
            textBox_Gia.Text = currentRow.Cells[7].Value.ToString();
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
            if (!textbox_MaSach.Text.All(Char.IsLetterOrDigit) || textbox_MaSach.Text == "")
            {
                nhapDung = false;
                MessageBox.Show("Nhập sai mã sách, kí tự hợp lệ: a-z, A-Z, 0-9");
                return;
            }
            if (textBox_TenSach.Text =="" || textBox_TenSach.Text.Substring(0,1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Tên sách không được để trống.");
                return;
            }
            if (textBox_TacGia.Text == "" || textBox_TacGia.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Tên tác giả không được để trống");
                return;
            }
            if (comboBox_TheLoai.Text == "" || comboBox_TheLoai.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Thể loại không được để trống.");
                return;
            }
            if (comboBox_NhaXuatBan.Text == "" || comboBox_NhaXuatBan.Text.Substring(0, 1) == " ")
            {
                nhapDung = false;
                MessageBox.Show("Nhà xuất bản không được để trống.");
                return;
            }

            if (!textBox_Gia.Text.All(Char.IsDigit) || textBox_Gia.Text == "")
            {
                nhapDung = false;
                MessageBox.Show("Nhập sai giá tiền, kí tự hợp lệ: 0-9");
                return;
            }

            if (nhapDung)
            {
                DialogResult dialogResult;
                if(iTitle== "Nhập thông tin quyển sách")
                    dialogResult = MessageBox.Show("Nhập quyển sách?", "Chú ý", MessageBoxButtons.YesNo);
                else 
                    dialogResult = MessageBox.Show("Xác nhận sửa sách?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                userPress = true;
                maSach = textbox_MaSach.Text.ToUpper();
                tenSach = textBox_TenSach.Text;
                theLoai = comboBox_TheLoai.Text;
                tenTacGia = textBox_TacGia.Text;
                nhaXuatBan = comboBox_NhaXuatBan.Text;
                ngayXuatBan = dateTimePicker_NgayXuatBan.Value;
                ghiChu = textBox_GhiChu.Text;
                gia = Convert.ToInt32(textBox_Gia.Text);
                this.Close();
            }

        }
        private void button_NhapLai_Click(object sender, EventArgs e)
        {
            textbox_MaSach.Text = "";
            textBox_TenSach.Text = "";
            comboBox_TheLoai.Text = "";
            textBox_TacGia.Text = "";
            comboBox_NhaXuatBan.Text = "";
            dateTimePicker_NgayXuatBan.Value = dateTimePicker_NgayXuatBan.MinDate;
            textBox_GhiChu.Text = "";
            textBox_Gia.Text = "0";

            textbox_MaSach.Select();
        }
        private void button_Huy_Click(object sender, EventArgs e)
        {
            userPress = false;
            this.Close();
        }

        //Chinh sua lai them phan nhan nut TAB se qua text box tiep theo, nhan enter se nhap, nhap sai se bao loi,...
    }
}
