using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class SachBUS_View
    {
        private string loaiDS;
        private List<SachDTO> sachList;
        private SachBUS_ListT sachListT;
        private SachBUS_DSD sachDSD;
        private SachBUS_DSLienKet sachDSLK;
        public List<SachDTO> SachList { get => sachList; }


        public SachBUS_View(string enter_loaiDS)
        {
            loaiDS = enter_loaiDS;
            if (loaiDS == "LibListT")
            {
                sachListT = new SachBUS_ListT();
                sachList = sachListT.SachList;
            }
            else if (loaiDS == "DSDac")
            {
                sachDSD = new SachBUS_DSD();
                sachList = sachDSD.SachList;
            }
            else if (loaiDS == "DSLK")
            {
                sachDSLK = new SachBUS_DSLienKet();
                sachList = sachDSLK.SachList;
            }


        }

        public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            if (loaiDS == "LibListT")
            {
                sachListT.themSach(enter_maSach,enter_tenSach,enter_theLoai,enter_tenTacGia,enter_nhaXuatBan,enter_ngayXuatBan,enter_ghiChu,enter_gia);
                sachList = sachListT.SachList;
            }
            else if (loaiDS == "DSDac")
            {
                sachDSD.themSach(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                sachList = sachDSD.SachList;
            }
            else if (loaiDS == "DSLK")
            {
                sachDSLK.themSach(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                sachList = sachDSLK.SachList;
            }
        }
        public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            if (loaiDS == "LibListT")
            {
                sachListT.suaSach(index,enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                sachList = sachListT.SachList;
            }
            else if (loaiDS == "DSDac")
            {
                sachDSD.suaSach(index,enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                sachList = sachDSD.SachList;
            }
            else if (loaiDS == "DSLK")
            {
                sachDSLK.suaSach(index, enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                sachList = sachDSLK.SachList;
            }
        }

        public void xoaSach(int index)
        {
            if (loaiDS == "LibListT")
            {
                sachListT.xoaSach(index);
                sachList = sachListT.SachList;
            }
            else if (loaiDS == "DSDac")
            {
                sachDSD.xoaSach(index);
                sachList = sachDSD.SachList;
            }
            else if (loaiDS == "DSLK")
            {
                sachDSLK.xoaSach(index);
                sachList = sachDSLK.SachList;
            }

        }
        public void xoaTatCa()
        {
            if (loaiDS == "LibListT")
            {
                sachListT.xoaTatCa();
                sachList = sachListT.SachList;
            }
            else if (loaiDS == "DSDac")
            {
                sachDSD.xoaTatCa();
                sachList = sachDSD.SachList;
            }
            else if (loaiDS == "DSLK")
            {
                sachDSLK.xoaTatCa();
                sachList = sachDSLK.SachList;
            }
        }
        public int soLuongSach()
        {
            int soLuong = 0;
            if (loaiDS == "LibListT")
            {
                soLuong= sachListT.soLuongSach();
            }
            else if (loaiDS == "DSDac")
            {
                soLuong= sachDSD.soLuongSach();  
            }
            else if (loaiDS == "DSLK")
            {
                soLuong = sachDSLK.soLuongSach();
            }

            return soLuong;
        }

        //fix loi file being use by another process
        public bool luuFile()
        {
            FileStream fs = new FileStream("SachList.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, sachList);
            fs.Close();

            return true;
        }
        public bool docFile()
        {
            FileStream fs = null;
            try {fs=new FileStream("SachList.dat", FileMode.Open); }
            catch { return false; }
            if (fs == null)
                return false;
            BinaryFormatter bf = new BinaryFormatter();
            sachList = (List<SachDTO>)bf.Deserialize(fs);
            fs.Close();
            if (sachList.Count == 0)
                return false;
            //ghi vao loai du lieu hien tai
            chuyenDoiDuLieu();
            return true;
        }

        public bool docFile(string location)
        {
            FileStream fs = null;
            try { fs=new FileStream(location, FileMode.Open); }
            catch { return false; }
            if (fs == null)
                return false;
            BinaryFormatter bf = new BinaryFormatter();
            sachList = (List<SachDTO>)bf.Deserialize(fs);
            fs.Close();
            if (sachList.Count == 0)
                return false;
            //ghi vao loai du lieu hien tai
            chuyenDoiDuLieu();
            return true;
        }

        private void chuyenDoiDuLieu()
        {
            if (loaiDS == "LibListT")
            {
               foreach(SachDTO sach in sachList)
               {
                    sachListT.themSach(sach);
               }
            }
            else if (loaiDS == "DSDac")
            {
                foreach (SachDTO sach in sachList)
                {
                    sachDSD.themSach(sach);
                }
            }
            else if (loaiDS == "DSLK")
            {
                foreach (SachDTO sach in sachList)
                {
                    sachDSLK.themSach(sach);
                }
            }

        }

    }
}
