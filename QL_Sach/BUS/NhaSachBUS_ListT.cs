using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace QL_Sach.BUS
{
     class NhaSachBUS_ListT
    {
        private List<NhaSachDTO> nhasachList;

        public List<NhaSachDTO> NhaSachList { get => nhasachList; set => nhasachList = value; }

        public NhaSachBUS_ListT()
        {
            this.nhasachList = new List<NhaSachDTO>();
        }

        public void themNhaSachRong()
        {
            NhaSachDTO ns = new NhaSachDTO();
            this.nhasachList.Add(ns);
        }
        public void themNhaSach(NhaSachDTO ns)
        {
            this.nhasachList.Add(ns);
        }
        public void themNhaSach(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            NhaSachDTO ns = new NhaSachDTO();
            ns.MaNhaSach = enter_maNhaSach;
            ns.TenNhaSach = enter_tenNhaSach;
            ns.DiaChi = enter_diaChi;
            ns.TenQuanLi = enter_tenQuanLi;
            ns.SoLuongNhanVien = enter_soLuongNhanVien;
            this.nhasachList.Add(ns);
        }

        public void suaNhaSach(int index, string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nhasachList[index].MaNhaSach = enter_maNhaSach;
            nhasachList[index].TenNhaSach = enter_tenNhaSach;
            nhasachList[index].DiaChi= enter_diaChi;
            nhasachList[index].TenQuanLi= enter_tenQuanLi;
            nhasachList[index].SoLuongNhanVien = enter_soLuongNhanVien;
            
        }
        public void xoaNhaSach(int index)
        {
            nhasachList.Remove(nhasachList[index]);

        }

        public int soLuongNhaSach()
        {
            return nhasachList.Count;
        }

        public void xoaTatCa()
        {
            NhaSachList.Clear();
        }


    }

}
