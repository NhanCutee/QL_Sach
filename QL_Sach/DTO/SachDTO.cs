using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.DTO
{
    class SachDTO
    {
        //Thong tin do an
        private string maSach;
        private string tenSach;
        private string theLoai;
        private string tenTacGia;
        private string nhaXuatBan;
        private DateTime? ngayXuatBan;
        private string ghiChu;
        private int gia;

        public SachDTO()
        {
            this.maSach = "N/A";
            this.tenSach = "N/A";
            this.theLoai = "N/A";
            this.tenTacGia = "N/A";
            this.nhaXuatBan = "N/A";
            this.ngayXuatBan = null;
            this.ghiChu = "N/A";
            this.gia = 0;
        }
        public SachDTO(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            this.maSach = enter_maSach;
            this.tenSach = enter_tenSach;
            this.theLoai = enter_theLoai;
            this.tenTacGia = enter_tenTacGia;
            this.nhaXuatBan = enter_nhaXuatBan;
            this.ngayXuatBan = enter_ngayXuatBan;
            this.ghiChu = enter_ghiChu;
            this.gia=enter_gia;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
        public string NhaXuatBan { get => nhaXuatBan; set => nhaXuatBan = value; }
        public DateTime? NgayXuatBan { get => ngayXuatBan; set => ngayXuatBan = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int Gia { get => gia; set => gia = value; }
    }
}
