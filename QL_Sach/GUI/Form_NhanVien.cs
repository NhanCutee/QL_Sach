using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_Sach.GUI
{
    public partial class Form_NhanVien : Form
    {
        private NhanVienDTO nv;
        private bool userEnter;

        internal NhanVienDTO Nv { get => nv; set => nv = new NhanVienDTO(value); }
        public bool UserEnter { get => userEnter;}

        public Form_NhanVien()
        {
            InitializeComponent();
            nv = new NhanVienDTO();
            userEnter = false;
        }

        public Form_NhanVien(string title)
        {
            InitializeComponent();
            this.Text = title;
            label_Title.Text = title;
            nv = new NhanVienDTO();
            userEnter = false;

            //de test nhanh hon
            Random rand = new Random();
            txtMaNV.Text = Convert.ToString(rand.Next());
        }
        public Form_NhanVien(string title,string manv,string tennv,bool gioitinh,DateTime ngaysinh,string diachi,string noilv,string chucvu)
        {
            InitializeComponent();
            this.Text = title;
            label_Title.Text = title;
            userEnter = false;

            if (title == "Sửa Nhân Viên")
            {
                txtMaNV.Text = manv;
                txtTenNV.Text = tennv;
                if (gioitinh == true)
                    radNam.Checked = true;
                else
                    radNu.Checked = true;
                dtpNgaySinh.Value = ngaysinh;
                txtDC.Text = diachi;
                cmbNoiLamViec.Text =noilv;
                cmbChucVu.Text = chucvu;

                btnNhap.Text = "Sửa";
                txtMaNV.ReadOnly = true;

                txtTenNV.Select();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
        private bool checkInput()
        {
            if (!txtMaNV.Text.All(Char.IsLetterOrDigit) || txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không hợp lệ. \nKí tự hợp lệ: a-z, A-Z, 0-9");
                return false;
            }
            else if (txtTenNV.Text == "" || txtTenNV.Text.Substring(0, 1) == " ")
            {
                MessageBox.Show("Tên Nhân viên không được để trống.");
                return false;
            }
            else if ((DateTime.Today.Year - dtpNgaySinh.Value.Year) < 18)
            {
                MessageBox.Show("Tuổi nhân viên phải trên 18.");
                return false;
            }
            else if (txtDC.Text == "" || txtDC.Text.Substring(0, 1) == " ")
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return false;
            }
            else if (cmbNoiLamViec.Text == "" || cmbNoiLamViec.Text.Substring(0, 1) == " ")
            {
                MessageBox.Show("Vui lòng nhập nhà sách NV đang làm việc.");
                return false;
            }
            else if (cmbChucVu.Text == "" || cmbChucVu.Text.Substring(0, 1) == " ")
            {
                MessageBox.Show("Vui lòng nhập chức vụ nhân viên.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if(checkInput()==true)
            {
                nv = new NhanVienDTO();
                nv.MaNV = txtMaNV.Text.ToUpper();
                nv.TenNV = txtTenNV.Text;
                nv.GioiTinh = radNam.Checked;
                nv.NgaySinh = dtpNgaySinh.Value;
                nv.DiaChi = txtDC.Text;
                nv.NhaSachLamViec = cmbNoiLamViec.Text;
                nv.ChucVu = cmbChucVu.Text;

                if (btnNhap.Text == "Sửa")
                {
                    DialogResult dr = MessageBox.Show(Owner, "Bạn có chắc muốn sửa", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        userEnter = true;
                        this.Close();
                    }
                }
                else
                {
                    userEnter = true;
                    this.Close();
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpNgaySinh.Value =DateTime.Today;
            txtDC.Text = "";
            cmbNoiLamViec.Text = "Fahasa quận 8";
            cmbChucVu.Text = "Nhân viên";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            userEnter = false;
            this.Close();
        }
    }
}
