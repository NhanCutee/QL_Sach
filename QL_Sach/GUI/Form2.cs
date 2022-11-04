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
        SachBUS_ListT sachBUS;
        private List<SachDTO> sachList;

        public Form2()
        {
            
            InitializeComponent();
            this.Text = "Quản lý sách";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sachBUS = new SachBUS_ListT();
            LoadSach();

        }
        private void LoadSach()
        {
            dataGridView.DataSource = sachBUS.SachList.ToList();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            //dung de test
            //sachBUS.themSachRong();
           // LoadSach();
           // return;

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
                    sachBUS.xoaSach(i);

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
                    sachBUS.suaSach(index, f.MaSach, f.TenSach, f.TheLoai, f.TenTacGia, f.NhaXuatBan, (DateTime)f.NgayXuatBan, f.GhiChu, f.Gia);
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
            if (sachBUS.soLuongSach() == 0)
            {
                MessageBox.Show("Danh sách rỗng, không thể xóa", "Thông báo");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Chú ý, TOÀN BỘ danh sách sẽ bị xóa", "Chú ý", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            sachBUS.reset();
            LoadSach();
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Sach.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, sachList);
            fs.Close();
            
            

        }

        private void button_Doc_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            FileStream fs = new FileStream("Sach.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            sachList = (List<SachDTO>)bf.Deserialize(fs);
            fs.Close();
            LoadSach();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
