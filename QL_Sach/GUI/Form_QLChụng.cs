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
    public partial class Form_QLChụng : Form
    {
        Form_Sach f;
        SachBUS sachView;
        Form_NhaSach b;
        NhaSachBUS nhaView;

        public Form_QLChụng(string loaiDS)
        {
            
            InitializeComponent();
            this.Text = "Quản lý sách";
            sachView = new SachBUS(loaiDS);
            dsnv = new NhanVienBUS(loaiDS);
            nhaView = new NhaSachBUS(loaiDS);
             
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSach();



            if (dsnv.docFile() == false)
                MessageBox.Show("Đọc file nhân viên thất bại");
            loadNV();
        }
        private void LoadSach()
        {
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
            sachView.luuFile();
        }

        private void button_Doc_Click(object sender, EventArgs e)
        {
            if(sachView.docFile()==false)
            {
                DialogResult rs = MessageBox.Show("File rỗng hoặc không tồn tại,\nbạn có muốn tự chọn file?","Thông báo",MessageBoxButtons.YesNo);
                if(rs==DialogResult.Yes)
                {
                    OpenFileDialog open = new OpenFileDialog();
                    DialogResult openFileRS = open.ShowDialog();
                    if (openFileRS == DialogResult.OK)
                    {
                        string location;
                        try
                        {
                            location = System.IO.Path.GetFullPath(open.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("Không đọc được file, hãy thử lại.", "Thông báo");
                            return;
                        }
                        if(sachView.docFile(location)==false)
                        {
                            MessageBox.Show("Không đọc được file, hãy thử lại.", "Thông báo");
                            return;
                        }
                    }
                }
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
                LoadSach();
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
                DialogResult rs = MessageBox.Show("File rỗng hoặc không tồn tại,\nbạn có muốn tự chọn file?", "Thông báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    OpenFileDialog open = new OpenFileDialog();
                    DialogResult openFileRS = open.ShowDialog();
                    if (openFileRS == DialogResult.OK)
                    {
                        string location;
                        try
                        {
                            location = System.IO.Path.GetFullPath(open.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("Không đọc được file, hãy thử lại.", "Thông báo");
                            return;
                        }
                        if (sachView.docFile(location) == false)
                        {
                            MessageBox.Show("Không đọc được file, hãy thử lại.", "Thông báo");
                            return;
                        }
                    }
                }
            }
            LoadNhaSach();
        }

        private void button_LF_Click(object sender, EventArgs e)
        {
            nhaView.luuFile();
        }
    
        //--------------------------------------------------------------------------------










        //--------------------- NHAN VIEN-----------------------------------------------------------

        NhanVienBUS dsnv;

        private void loadNV()
        {
            dgvNV.DataSource = dsnv.NhanVienList;

            if (dsnv.LoaiDS == "LibListT")
                radNVListT.Checked = true;
            else if (dsnv.LoaiDS == "DSDac")
                radNVDSD.Checked = true;
            else
                radNVDSLK.Checked = true;

            lblSL.Text = dsnv.soLuongNV().ToString();
        }
        private void loadNV(List<NhanVienDTO> nvList)
        {
            dgvNV.DataSource =nvList.ToList();

            if (dsnv.LoaiDS == "LibListT")
                radNVListT.Checked = true;
            else if (dsnv.LoaiDS == "DSDac")
                radNVDSD.Checked = true;
            else
                radNVDSLK.Checked = true;

            lblSL.Text = dsnv.soLuongNV().ToString();
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
            else
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

        //--------------------------------------------------------------------------------





    }
}
