using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class SachBUS_View
    {
        private string loaiDS;
        private List<SachDTO> sachList;
        private SachBUS_ListT sachListT;
        private SachBUS_DSD sachDSD;
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
                //sachDSD.suaSach(index,enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                sachList = sachDSD.SachList;
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
                //sachDSD.xoaSach(index);
                sachList = sachDSD.SachList;
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
                //sachDSD.xoaTatCa;
                sachList = sachDSD.SachList;
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
                //soLuong= sachDSD.soLuongSach();
                
            }
            return soLuong;
        }

    }
}
