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
        private string m_maNV;
        private string m_tenNV;
        private bool m_gioiTinh;
        private DateTime m_ngaySinh;
        private string m_diaChi;
        private string m_nhaSachLamViec;
        private string m_chucVu;

        public string MaNV { get => m_maNV; set => m_maNV = value; }
        public string TenNV { get => m_tenNV; set => m_tenNV = value; }
        public bool GioiTinh { get => m_gioiTinh; set => m_gioiTinh = value; }
        public DateTime NgaySinh { get => m_ngaySinh; set => m_ngaySinh = value; }
        public string DiaChi { get => m_diaChi; set => m_diaChi = value; }
        public string NhaSachLamViec { get => m_nhaSachLamViec; set => m_nhaSachLamViec = value; }
        public string ChucVu { get => m_chucVu; set => m_chucVu = value; }

        public NhanVienDTO(NhanVienDTO nv)
        {
            m_maNV = nv.MaNV;
            m_tenNV = nv.TenNV;
            m_gioiTinh = nv.GioiTinh;
            m_ngaySinh = nv.NgaySinh;
            m_diaChi = nv.DiaChi;
            m_nhaSachLamViec = nv.NhaSachLamViec;
            m_chucVu = nv.ChucVu;
        }

        public NhanVienDTO()
        {
            m_maNV = "";
            m_tenNV = "";
            m_gioiTinh = true;
            m_ngaySinh = DateTime.Today;
            m_diaChi = "";
            m_nhaSachLamViec = "";
            m_chucVu = "";
        }

        public NhanVienDTO(string maNV, string tenNV, bool gioiTinh, DateTime ngaySinh, string diaChi, string nhaSachLamViec, string chucVu)
        {
            m_maNV = maNV;
            m_tenNV = tenNV;
            m_gioiTinh = gioiTinh;
            m_ngaySinh = ngaySinh;
            m_diaChi = diaChi;
            m_nhaSachLamViec = nhaSachLamViec;
            m_chucVu = chucVu;
        }
    }

}
