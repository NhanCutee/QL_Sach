using QL_Sach.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class SachBUS
    {
        private List<SachDTO> sachList;

        internal List<SachDTO> SachList { get => sachList; set => sachList = value; }

        public SachBUS()
        {
            this.sachList = new List<SachDTO>();
        }

        public void themSachRong()
        {
            SachDTO sach = new SachDTO();
            this.sachList.Add(sach);
        }

        public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            SachDTO sach = new SachDTO();
            sach.MaSach = enter_maSach;
            sach.TenSach = enter_tenSach;
            sach.TheLoai = enter_theLoai;
            sach.TenTacGia = enter_tenTacGia;
            sach.NhaXuatBan = enter_nhaXuatBan;
            sach.NgayXuatBan = enter_ngayXuatBan;
            sach.GhiChu = enter_ghiChu;
            sach.Gia = enter_gia;

            this.sachList.Add(sach);
        }

        public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            sachList[index].MaSach = enter_maSach;
            sachList[index].TenSach = enter_tenSach;
            sachList[index].TheLoai = enter_theLoai;
            sachList[index].TenTacGia = enter_tenTacGia;
            sachList[index].NhaXuatBan = enter_nhaXuatBan;
            sachList[index].NgayXuatBan = enter_ngayXuatBan;
            sachList[index].GhiChu = enter_ghiChu;
            sachList[index].Gia = enter_gia;
        }
        public void xoaSach(int index)
        {
            sachList.Remove(sachList[index]);

        }

        public int soLuongSach()
        {
            return sachList.Count;
        }
        public SachDTO layRaSachThu(int n)
        {
            return sachList[n];
        }
        public void reset()
        {
            SachList.Clear();
        }


    }
}
