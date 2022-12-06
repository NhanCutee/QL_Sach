using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_nhanVien.BUS
{
    class NhanVienBUS_ListT
    {
        private List<NhanVienDTO> nhanVienList;

        public List<NhanVienDTO> NhanVienList { get => nhanVienList.ToList(); set => nhanVienList = value; }

        public NhanVienBUS_ListT()
        {
            this.nhanVienList = new List<NhanVienDTO>();
        }

        public NhanVienDTO timNV(string ma)
        {
            foreach(NhanVienDTO nv in nhanVienList)
            {
                if (ma == nv.MaNV)
                    return nv;
            }
            return null;
        }


        public void themNVRong()
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            this.nhanVienList.Add(nhanVien);
        }

        public bool themNV(NhanVienDTO nhanVien)
        {
            if(timNV(nhanVien.MaNV)==null)
            {
                this.nhanVienList.Add(nhanVien);
                return true;
            }
            return false;
        }


        public bool xoaNV(string ma)
        {
           NhanVienDTO nhanVien = timNV(ma);
            if (nhanVien != null)
            {
                nhanVienList.Remove(nhanVien);
                return true;
            }
            else
                return false;
        }

        public bool suaNV(NhanVienDTO nv)
        {
            NhanVienDTO nhanVien = timNV(nv.MaNV);
            if (nhanVien != null)
            {
                nhanVien.TenNV = nv.TenNV;
                nhanVien.GioiTinh = nv.GioiTinh;
                nhanVien.NgaySinh = nv.NgaySinh;
                nhanVien.NhaSachLamViec = nv.NhaSachLamViec;
                nhanVien.DiaChi = nv.DiaChi;
                return true;
            }
            else
                return false;
        }

        public int soLuongNV()
        {
            return nhanVienList.Count;
        }

        public void xoaTatCa()
        {
            nhanVienList.Clear();
        }
        
    }
}
