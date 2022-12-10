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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using QL_Sach.DTO;

namespace QL_Sach.GUI
{
    public partial class Form_QLHeThongNhaSach : Form
    {
        Form_Sach f;
        SachBUS sachView;
        Form_NhaSach b;
        NhaSachBUS nhaView;

        public Form_QLHeThongNhaSach(string loaiDS,int tab)
        {

            InitializeComponent();

            sachView = new SachBUS(loaiDS);
            nhaView = new NhaSachBUS(loaiDS);
            dsnv = new NhanVienBUS(loaiDS);

            if (tab == 1)
                tabControl.SelectedTab = tabSach;
            else if(tab==2)
                tabControl.SelectedTab = tabNhaSach;
            else
                tabControl.SelectedTab = tabNhanVien;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSach();
            LoadNhaSach();
            loadNV();
        }
        private void LoadSach()
        {
            if (sachView.LoaiDS == "LibListT")
                radSachListT.Checked = true;
            else if (sachView.LoaiDS == "DSDac")
                radSachDSD.Checked = true;

            else
                radSachDSLK.Checked = true;

            dataGridView.DataSource = sachView.SachList.ToList();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            //dung de test
            //sachView.themSachRong();
           // LoadSach();
           // return;

            string fTitle = "Nhập thông tin quyển sách";
            f = new Form_Sach(fTitle);
            f.ShowDialog();
            if(f.UserPress==true)
            {
                sachView.themSach(f.MaSach, f.TenSach, f.TheLoai, f.TenTacGia, f.NhaXuatBan, (DateTime)f.NgayXuatBan, f.GhiChu, f.Gia);
            }    

            LoadSach();
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {         
            if (dataGridView.SelectedCells.Count > 0)
            {
                //show message box de xac nhan xoa
                DialogResult dialogResult = MessageBox.Show("Xóa sách đã chọn ?","Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;

                //De chon row truoc cac row da xoa
                int lastRow = dataGridView.SelectedCells[0].RowIndex ;

                int[] rowIndexes = (from sc in dataGridView.SelectedCells.Cast<DataGridViewCell>()
                                    select sc.RowIndex).Distinct().ToArray();
                foreach (int i in rowIndexes)
                    sachView.xoaSach(i);

                LoadSach();

                dataGridView.ClearSelection();

                try { dataGridView.Rows[lastRow].Selected = true; } catch { }
   
                }
            else
                MessageBox.Show("Hãy chọn sách cần xóa");
        }

        private void button_ChinhSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                string fTitle = "Sửa thông tin quyển sách";

                int index = dataGridView.CurrentCell.RowIndex;
                DataGridViewRow currentRow = dataGridView.Rows[index];
                f = new Form_Sach(fTitle, currentRow);
                f.ShowDialog();
                if (f.UserPress == true)
                {
                    sachView.suaSach(index, f.MaSach, f.TenSach, f.TheLoai, f.TenTacGia, f.NhaXuatBan, (DateTime)f.NgayXuatBan, f.GhiChu, f.Gia);
                }
                LoadSach();
            }
            else
                MessageBox.Show("Hãy chọn một quyển sách để sửa");
        }

        private void button_Thoát_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Thoát chương trình?", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            else
                this.Close();
        }

        private void button_XoaTatCa_Click(object sender, EventArgs e)
        {
            if (sachView.soLuongSach() == 0)
            {
                MessageBox.Show("Danh sách rỗng, không thể xóa", "Thông báo");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Chú ý, TOÀN BỘ danh sách sẽ bị xóa", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            sachView.xoaTatCa();
            LoadSach();
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            if (sachView.luuFile() == false)
            {
                MessageBox.Show("Lưu file thất bại");
                return;
            }
        }

        private void button_Doc_Click(object sender, EventArgs e)
        {
            if (sachView.docFile() == false)
            {
                MessageBox.Show("Đọc file thất bại");
                return;
            }
            LoadSach();
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            if(textBox_TimKiem.Text=="")
                MessageBox.Show("Vui lòng nhập từ khoá để tìm kiếm.");
            else if (sachView.timKiem(textBox_TimKiem.Text).Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả tương ứng.");
            }
            else
                dataGridView.DataSource = sachView.timKiem(textBox_TimKiem.Text).ToList();
        }

        private void button_Huy_Click(object sender, EventArgs e)
        {
            textBox_TimKiem.Clear();
            LoadSach();
        }


        private void radSachListT_CheckedChanged(object sender, EventArgs e)
        {
            if (radSachListT.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang ListT?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (sachView.chuyenCauTrucDL("LibListT") == false || sachView.LoaiDS != "LibListT")
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void radSachDSD_CheckedChanged(object sender, EventArgs e)
        {
            if (radSachDSD.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang DS đặc?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (sachView.chuyenCauTrucDL("DSDac") == false || sachView.LoaiDS != "DSDac")
                {
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                    radNVDSD.Checked = false;
                }
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void radSachDSLK_CheckedChanged(object sender, EventArgs e)
        {
            if (radSachDSLK.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang DS Liên kết?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (sachView.chuyenCauTrucDL("DSLK") == false || sachView.LoaiDS != "DSLK")
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }







        //----------------- NHA SACH--------------------------------------------------------

        private void button_Exit_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Thoát chương trình?", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            else
                this.Close();
        }
        private void LoadNhaSach()
        {
            if (dsnv.LoaiDS == "LibListT")
                radNSListT.Checked = true;
            else if (dsnv.LoaiDS == "DSDac")
                radNSDSD.Checked = true;

            else
                radNSDSLK.Checked = true;

            dGVNS.DataSource = nhaView.NhaSachList.ToList();
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            string bTitle = "Nhập thông tin nhà sách";
            b = new Form_NhaSach(bTitle);
            b.ShowDialog();
            if (b.UserPress == true)
            {
                nhaView.themNhaSach(b.MaNhaSach, b.TenNhaSach, b.DiaChi, b.TenQuanLi, b.SoLuongNhanVien);
            }

            LoadNhaSach();
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            if (dGVNS.SelectedCells.Count > 0)
            {
                string bTitle = "Sửa thông tin nhà sách";

                int index = dGVNS.CurrentCell.RowIndex;
                DataGridViewRow currentRow = dGVNS.Rows[index];
                b = new Form_NhaSach(bTitle, currentRow);
                b.ShowDialog();
                if (b.UserPress == true)
                {
                    nhaView.suaNhaSach(index, b.MaNhaSach, b.TenNhaSach, b.DiaChi, b.TenQuanLi, b.SoLuongNhanVien);
                }
                LoadNhaSach();
            }
            else
                MessageBox.Show("Hãy chọn một nhà sách để sửa");
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            if (dGVNS.SelectedCells.Count > 0)
            {
                //show message box de xac nhan xoa
                DialogResult dialogResult = MessageBox.Show("Xóa nhà sách đã chọn ?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;

                //De chon row truoc cac row da xoa
                int lastRow = dGVNS.SelectedCells[0].RowIndex;

                int[] rowIndexes = (from sc in dGVNS.SelectedCells.Cast<DataGridViewCell>()
                                    select sc.RowIndex).Distinct().ToArray();
                foreach (int i in rowIndexes)
                    nhaView.xoaNhaSach(i);

                LoadNhaSach();

                dGVNS.ClearSelection();

                try { dGVNS.Rows[lastRow].Selected = true; } catch { }

            }
            else
                MessageBox.Show("Hãy chọn nhà sách cần xóa");
        }

        private void button_XX_Click(object sender, EventArgs e)
        {
            if (nhaView.soLuongNhaSach() == 0)
            {
                MessageBox.Show("Danh sách rỗng, không thể xóa", "Thông báo");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Chú ý, TOÀN BỘ danh sách sẽ bị xóa", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            nhaView.xoaTatCa();
            LoadNhaSach();
        }

        private void button_DF_Click(object sender, EventArgs e)
        {
            if (nhaView.docFile() == false)
            {
                MessageBox.Show("Đọc file thất bại");
                return;
            }
            LoadNhaSach();
        }

        private void button_LF_Click(object sender, EventArgs e)
        {
            if (nhaView.luuFile() == false)
            {
                MessageBox.Show("Lưu file thất bại");
                return;
            }
        }

        private void radNSListT_CheckedChanged(object sender, EventArgs e)
        {
            if (radNSListT.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang ListT?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (nhaView.chuyenCauTrucDL("LibListT") == false || nhaView.LoaiDS != "LibListT")
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void radNSDSD_CheckedChanged(object sender, EventArgs e)
        {
            if (radNSDSD.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang DS đặc?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (nhaView.chuyenCauTrucDL("DSDac") == false || nhaView.LoaiDS != "DSDac")
                {
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                    radNVDSD.Checked = false;
                }
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void radNSDSLK_CheckedChanged(object sender, EventArgs e)
        {
            if (radNSDSLK.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang DS Liên kết?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (nhaView.chuyenCauTrucDL("DSLK") == false || nhaView.LoaiDS != "DSLK")
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dGVNS.DataSource = nhaView.timKiem(txtTimNV.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTimNV.Text = "";
            LoadNhaSach();
        }

        //--------------------------------------------------------------------------------










        //--------------------- NHAN VIEN-----------------------------------------------------------

        NhanVienBUS dsnv;

        private void loadNV()
        {
            if (dsnv.LoaiDS == "LibListT")
                radNVListT.Checked = true;
            else if (dsnv.LoaiDS == "DSDac")
                radNVDSD.Checked = true;

            else
                radNVDSLK.Checked = true;

            dgvNV.DataSource = dsnv.NhanVienList;

            lblSL.Text = dsnv.soLuongNV().ToString();
            lblSoQL.Text=dsnv.timTuKhoa("cv:Quản lí").Count().ToString();
            lblSoNV.Text = dsnv.timTuKhoa("cv:Nhân viên").Count().ToString();
            lblKhac.Text = (dsnv.soLuongNV() - (dsnv.timTuKhoa("cv:Quản lí").Count() + dsnv.timTuKhoa("cv:Nhân viên").Count())).ToString();

            lblNam.Text = dsnv.timTuKhoa("gt:Nam").Count().ToString();
            lblNu.Text = dsnv.timTuKhoa("gt:Nữ").Count().ToString();
        }
        private void loadNV(List<NhanVienDTO> nvList)
        {
            dgvNV.DataSource =nvList.ToList();
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            Form_NhanVien fNV = new Form_NhanVien("Nhập Nhân Viên");
            fNV.ShowDialog();
            if (fNV.UserEnter == true && dsnv.timNV(fNV.Nv.MaNV) == null)
            {
                dsnv.themNV(fNV.Nv);
                loadNV();
            }
            else if(fNV.UserEnter == true)
                MessageBox.Show("Nhân viên " + fNV.Nv.MaNV + " Đã tồn tại.");

        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if(txtTimNV.Text!="")
            {
                NhanVienDTO nv = dsnv.timNV(txtTimNV.Text);
                if (nv!=null)
                {
                    Form_NhanVien fNV = new Form_NhanVien("Sửa Nhân Viên",nv.MaNV,nv.TenNV,nv.GioiTinh,nv.NgaySinh,nv.DiaChi,nv.NhaSachLamViec,nv.ChucVu);
                    fNV.Nv = new NhanVienDTO(nv);
                    fNV.ShowDialog();
                    if (fNV.UserEnter == true)
                    {
                        dsnv.suaNV(fNV.Nv);
                        loadNV();
                    }
                }
                else
                    MessageBox.Show("Nhân viên " + txtTimNV.Text + " không tồn tại.");
            }
            else if(dgvNV.SelectedCells.Count>0)
            {
                NhanVienDTO nv = dsnv.timNV(dgvNV.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                if (nv != null)
                {
                    Form_NhanVien fNV = new Form_NhanVien("Sửa Nhân Viên", nv.MaNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.NhaSachLamViec, nv.ChucVu);
                    fNV.Nv = nv;
                    fNV.ShowDialog();
                    if (fNV.UserEnter == true)
                    {
                        dsnv.suaNV(fNV.Nv);
                        loadNV();
                    }
                }
                else
                    MessageBox.Show("Nhân viên " + txtTimNV.Text + " không tồn tại.");
            }
            else
                MessageBox.Show("Hãy chọn trên grid hoặc nhập mã vào tìm kiếm để sửa.");

        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            //CHO CHUC NANG XOA SACH TREN GRID VA XOA KHI NHAP MA VAO TIM KIEM
            if (txtTimNV.Text != "")
            {
                NhanVienDTO nv = dsnv.timNV(txtTimNV.Text);
                if (nv != null)
                {
                    //show message box de xac nhan xoa
                    DialogResult dialogResult = MessageBox.Show("Xóa nhân viên đã chọn ?", "Chú ý", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                    dsnv.xoaNV(nv.MaNV);
                    loadNV();
                }
                else
                    MessageBox.Show("Nhân viên " + txtTimNV.Text + " không tồn tại.");
            }
            else if (dgvNV.SelectedCells.Count > 0)
            {
                //show message box de xac nhan xoa
                DialogResult dialogResult = MessageBox.Show("Xóa nhân viên đã chọn ?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;

                int[] rowIndexes = (from sc in dgvNV.SelectedCells.Cast<DataGridViewCell>()
                                    select sc.RowIndex).Distinct().ToArray();
                List<string> MaNVCanXoa = new List<string>();
                for (int i = 0; i < rowIndexes.Length; i++)
                    MaNVCanXoa.Add(dgvNV.Rows[rowIndexes[i]].Cells[0].Value.ToString());
                foreach (string manv in MaNVCanXoa)
                    dsnv.xoaNV(manv);

                loadNV();
            }
            else
                MessageBox.Show("Hãy chọn trên grid hoặc nhập mã vào tìm kiếm để xoá.");
        }

        private void btnXoaTatCaNV_Click(object sender, EventArgs e)
        {
            if (dsnv.soLuongNV() == 0)
            {
                MessageBox.Show("Danh sách rỗng, không thể xóa", "Thông báo");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Xoá tất cả nhân viên trong danh sách?", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            dsnv.xoaTatCa();
            loadNV();
        }

        private void btnDocNV_Click(object sender, EventArgs e)
        {
            if (dsnv.docFile() == false)
            {
                MessageBox.Show("Đọc file thất bại");
                return;
            }
            loadNV();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            if (dsnv.luuFile() == false)
                MessageBox.Show("Lưu file thất bại");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thoát?", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            this.Close();
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            loadNV(dsnv.timKiem(txtTimNV.Text));
        }

        private void btnHuyTimNV_Click(object sender, EventArgs e)
        {
            txtTimNV.Text = "";
            loadNV();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void radNVListT_CheckedChanged(object sender, EventArgs e)
        {
            if(radNVListT.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang ListT?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (dsnv.chuyenCauTrucDL("LibListT") == false || dsnv.LoaiDS != "LibListT")
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void radNVDSD_CheckedChanged(object sender, EventArgs e)
        {
            if (radNVDSD.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang DS đặc?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (dsnv.chuyenCauTrucDL("DSDac") == false || dsnv.LoaiDS != "DSDac")
                {
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                    radNVDSD.Checked = false;
                }
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void radNVDSLK_CheckedChanged(object sender, EventArgs e)
        {
            if (radNVDSLK.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Chuyển sang DS Liên kết?", "Chú ý", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                if (dsnv.chuyenCauTrucDL("DSLK") == false || dsnv.LoaiDS != "DSLK")
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thất bại", "Thông báo");
                else
                    MessageBox.Show("Chuyển cấu trúc dữ liệu thành công", "Thông báo");
                loadNV();
            }
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgvNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex==2)
            {
                bool value =(bool) e.Value;
                if (value)
                    e.Value = "Nam";
                else
                    e.Value = "Nữ";
                e.FormattingApplied = true;
            }
        }

        private void lblSL_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        //--------------------------------------------------------------------------------





    }
}
