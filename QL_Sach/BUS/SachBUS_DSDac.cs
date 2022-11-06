using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class SachBUS_DSD
    {
        private SachDTO[] sachDTO;
        private int n;

        public List<SachDTO> SachList
        {
            get {
            List<SachDTO> kq = new List<SachDTO>();
                for (int i=0; i < this.n;i++)
                    kq.Add(sachDTO[i]);
                return kq;
            }
        }
        public int N { get => n; set => n = value; }

        public SachBUS_DSD()
        {
            sachDTO = new SachDTO[100];
            n = 0;
        }
        public void themSach(SachDTO sach)
        {

            sachDTO[n] = sach;
            n++;
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
            sachDTO[n] = sach;
            n++;
        }
        public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            sachDTO[index].MaSach = enter_maSach;
            sachDTO[index].TenSach = enter_tenSach;
            sachDTO[index].TheLoai = enter_theLoai;
            sachDTO[index].TenTacGia = enter_tenTacGia;
            sachDTO[index].NhaXuatBan = enter_nhaXuatBan;
            sachDTO[index].NgayXuatBan = enter_ngayXuatBan;
            sachDTO[index].GhiChu = enter_ghiChu;
            sachDTO[index].Gia = enter_gia;
        }


        ~SachBUS_DSD()
        {
            sachDTO = null;
        }
        public void xoaSach(int vt)
        {
            for (int i = vt; i < this.n-1; i++)
                sachDTO[i] = sachDTO[i + 1];
            this.n--;
        }
        public void xoaTatCa()
        {
            this.n=0;
        }

        public int soLuongSach()
        {
            return this.n;
        }

    }
}
