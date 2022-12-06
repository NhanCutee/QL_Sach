using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class NhanVienBUS_DSDac
    {
        private NhanVienDTO[] dSNhanVien;
        private int n;
        public static int MAX = 100;

        public List<NhanVienDTO> NhanVienList {
            get 
            {
                List<NhanVienDTO> nvList = new List<NhanVienDTO>() ;
                foreach (NhanVienDTO nv in dSNhanVien)
                {
                    nvList.Add(nv);
                }
                return nvList;
            }
            set
            {
                List<NhanVienDTO> nvList = value;
                foreach (NhanVienDTO nv in nvList)
                {
                    this.themNV(nv);
                }
            } 
        }

        internal NhanVienDTO[] DSNhanVien { get => dSNhanVien; set => dSNhanVien = value; }
        public int N { get => n; set => n = value; }


        public NhanVienBUS_DSDac()
        {
            this.dSNhanVien = new NhanVienDTO[MAX];
            this.n = 0;
        }

        public NhanVienDTO timNV(string ma)
        {
            foreach (NhanVienDTO nv in dSNhanVien)
            {
                if (ma == nv.MaNV)
                    return nv;
            }
            return null;
        }


        public void themNVRong()
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            this.themNV(nhanVien);
        }

        public bool themNV(NhanVienDTO nhanVien)
        {
            if (timNV(nhanVien.MaNV) == null)
            {
                this.dSNhanVien[n] = nhanVien;
                n++;
                return true;
            }
            return false;
        }


        public bool xoaNV(string ma)
        {
            for (int i = 0; i < this.n && i < MAX - 1; i++)
            {
                if (this.dSNhanVien[i].MaNV == ma)
                {
                    this.dSNhanVien[i] = this.dSNhanVien[i + 1];
                    this.n--;
                    return true;
                }
            }
            if (this.dSNhanVien[MAX - 1].MaNV == ma && this.n == MAX)
            {
                this.n--;
                return true;
            }

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
            return this.n;
        }

        public void xoaTatCa()
        {
            this.dSNhanVien = new NhanVienDTO[MAX];
            this.n = 0;
        }

    }
}

