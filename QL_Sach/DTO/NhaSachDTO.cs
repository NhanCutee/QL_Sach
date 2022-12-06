using QL_Sach.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.DTO
{
    [Serializable]
    class NhaSachDTO
    {
        //Thong tin Nha Sach
        private string maNhaSach;
        private string tenNhaSach;
        private string diaChi;
        private string tenQuanLi;
        private int soLuongNhanVien;

        public NhaSachDTO()
        {
            this.maNhaSach = "";
            this.tenNhaSach = "";
            this.diaChi = "";
            this.tenQuanLi = "";
            this.soLuongNhanVien = 0;
        }
        public NhaSachDTO(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            this.maNhaSach = enter_maNhaSach;
            this.tenNhaSach = enter_tenNhaSach;
            this.diaChi = enter_diaChi;
            this.tenQuanLi = enter_tenQuanLi;
            this.soLuongNhanVien = enter_soLuongNhanVien;
        }
        public NhaSachDTO(NhaSachDTO enter_NhaSachDTO)
        {
            this.maNhaSach = enter_NhaSachDTO.MaNhaSach;
            this.tenNhaSach = enter_NhaSachDTO.TenNhaSach;
            this.diaChi = enter_NhaSachDTO.DiaChi;
            this.tenQuanLi = enter_NhaSachDTO.tenQuanLi;
            this.soLuongNhanVien = enter_NhaSachDTO.soLuongNhanVien;
        }

        public string MaNhaSach { get => maNhaSach; set => maNhaSach = value; }
        public string TenNhaSach { get => tenNhaSach; set => tenNhaSach = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TenQuanLi { get => tenQuanLi; set => tenQuanLi = value; }
        public int SoLuongNhanVien { get => soLuongNhanVien; set => soLuongNhanVien = value; }
    }
}
