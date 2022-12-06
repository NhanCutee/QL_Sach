using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.DTO
{
    [Serializable]
    class NhanVienDTO
    {
        private string maNV;
        private string tenNV;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private string nhaSachLamViec;
        private string diaChi;

        public NhanVienDTO(NhanVienDTO nv)
        {
            this.maNV = nv.maNV;
            this.tenNV = nv.tenNV;
            this.gioiTinh = nv.gioiTinh;
            this.ngaySinh = nv.ngaySinh;
            this.nhaSachLamViec = nv.nhaSachLamViec;
            this.diaChi = nv.diaChi;
        }

        public NhanVienDTO(string maNV, string tenNV, bool gioiTinh, DateTime ngaySinh, string nhaSachLamViec, string diaChi)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.nhaSachLamViec = nhaSachLamViec;
            this.diaChi = diaChi;
        }
        public NhanVienDTO()
        {
            this.maNV = "";
            this.tenNV = "";
            this.gioiTinh = true;
            this.ngaySinh = DateTime.Today;
            this.nhaSachLamViec = "";
            this.diaChi = "";
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string NhaSachLamViec { get => nhaSachLamViec; set => nhaSachLamViec = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }

}
