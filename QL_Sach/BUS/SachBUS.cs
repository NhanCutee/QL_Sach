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
    }
}
