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
    public partial class Form2 : Form
    {
        Form3 f;
        SachBUS_View sachView;

        public Form2(string loaiDS)
        {
            
            InitializeComponent();
            this.Text = "Quản lý sách";
            sachView = new SachBUS_View(loaiDS);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSach();

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
            f = new Form3(fTitle);
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
                f = new Form3(fTitle, currentRow);
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
    }
}
