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
            foreach(SachDTO sach in sachDTO)
                {
                    kq.Add(sach);
                }
                return kq;
            }
        }
        public int N { get => n; set => n = value; }

        public SachBUS_DSD()
        {
            sachDTO = new SachDTO[100];
            n = 0;
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

        ~SachBUS_DSD()
        {
            sachDTO = null;
        }
        public void xoaSach()
        {
            n = 0;
        }
        public void xoa1sach(SachBUS_DSD ds, int vt)
        {
            for (int i = vt; i > ds.n; i++)
                ds.sachDTO[i] = ds.sachDTO[i + 1];
        }

    }
}
