using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_nhanVien.BUS;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class SachBUS
    {
        private string loaiDS;
        private List<SachDTO> sachList;
        private SachBUS_ListT sachListT;
        private SachBUS_DSD sachDSD;
        private SachBUS_DSLienKet sachDSLK;
        public List<SachDTO> SachList { get => sachList; }
        public string LoaiDS { get => loaiDS; }

        public SachBUS(string enter_loaiDS)
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

        public bool luuFile()
        {
            if (loaiDS == "LibListT")
            {
                return sachListT.luuFile();
            }
            else if (loaiDS == "DSDac")
            {
                return sachDSD.luuFile();
            }
            else if (loaiDS == "DSLK")
            {
                return sachDSLK.luuFile();
            }
            else return false;
        }

        public bool docFile()
        {
            if (loaiDS == "LibListT")
            {
                if (!sachListT.docFile())
                    return false;
                sachList = sachListT.SachList;
                return true;
            }
            else if (loaiDS == "DSDac")
            {
                if (!sachDSD.docFile())
                    return false;
                sachList = sachDSD.SachList;
                return true;
            }
            else if (loaiDS == "DSLK")
            {
                if (!sachDSLK.docFile())
                    return false;
                sachList = sachDSLK.SachList;
                return true;
            }
            else return false;
        }

        private bool chuyenDoiDuLieu()
        {
            try
            {
                if (loaiDS == "LibListT")
                {
                    foreach (SachDTO nv in sachList)
                    {
                        sachListT.themSach(nv);
                    }
                }
                else if (loaiDS == "DSDac")
                {
                    foreach (SachDTO nv in sachList)
                    {
                        sachDSD.themSach(nv);
                    }
                }
                else if (loaiDS == "DSLK")
                {
                    foreach (SachDTO nv in sachList)
                    {
                        sachDSLK.themSach(nv);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SachDTO> timKiem(string tuKhoa)
        {
            if (loaiDS == "LibListT")
                return sachListT.timKiem(tuKhoa);
            else if (loaiDS == "DSDac")
                return sachDSD.timKiem(tuKhoa);
            else if (loaiDS == "DSLK")
                return sachDSLK.timKiem(tuKhoa);
            else
                return new List<SachDTO>();
        }

        public bool chuyenCauTrucDL(string ctdl)
        {
            if (ctdl == "LibListT")
            {
                sachListT = new SachBUS_ListT();
                loaiDS = "LibListT";
                if (!chuyenDoiDuLieu())
                    return false;
                sachList = sachListT.SachList;
                return true;
            }
            else if (ctdl == "DSDac")
            {
                sachDSD = new SachBUS_DSD();
                loaiDS = "DSDac";
                if (!chuyenDoiDuLieu())
                    return false;
                sachList = sachDSD.SachList;
                return true;
            }
            else if (ctdl == "DSLK")
            {
                sachDSLK = new SachBUS_DSLienKet();
                loaiDS = "DSLK";
                if (!chuyenDoiDuLieu())
                    return false;
                sachList = sachDSLK.SachList;
                return true;
            }
            else
                return false;
        }

    }
}
