using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;
namespace QL_Sach.BUS
{
    internal class NhaSachBUS_DSDac
    {
        private NhaSachDTO[] nhasachDTO;
        private int n;

        public List<NhaSachDTO> NhaSachList
        {
            get
            {
                List<NhaSachDTO> kq = new List<NhaSachDTO>();
                for (int i = 0; i < this.n; i++)
                    kq.Add(nhasachDTO[i]);
                return kq;
            }
        }
        public int N { get => n; set => n = value; }

        public NhaSachBUS_DSDac()
        {
            nhasachDTO = new NhaSachDTO[100];
            n = 0;
        }
        public void themNhaSach(NhaSachDTO ns)
        {

            nhasachDTO[n] = ns;
            n++;
        }
        public void themNhaSach(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
     
            NhaSachDTO ns = new NhaSachDTO();
            ns.MaNhaSach=enter_maNhaSach;
            ns.TenNhaSach = enter_tenNhaSach;
            ns.DiaChi=enter_diaChi;
            ns.TenQuanLi = enter_tenQuanLi;
            ns.SoLuongNhanVien = enter_soLuongNhanVien;
            nhasachDTO[n] = ns;
            n++;
        }
        public void suaNhaSach(int index, string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nhasachDTO[index].MaNhaSach = enter_maNhaSach;
            nhasachDTO[index].TenNhaSach = enter_tenNhaSach;
            nhasachDTO[index].DiaChi = enter_diaChi;
            nhasachDTO[index].TenQuanLi = enter_tenQuanLi;
            nhasachDTO[index].SoLuongNhanVien = enter_soLuongNhanVien;
            
        }


        ~NhaSachBUS_DSDac()
        {
            nhasachDTO = null;
        }
        public void xoaNhaSach(int vt)
        {
            for (int i = vt; i < this.n - 1; i++)
                nhasachDTO[i] = nhasachDTO[i + 1];
            this.n--;
        }
        public void xoaTatCa()
        {
            this.n = 0;
        }

        public int soLuongNhaSach()
        {
            return this.n;
        }
        public List<NhaSachDTO> timTuKhoa(string tuKhoa)
        {
            List<NhaSachDTO> listKQ = new List<NhaSachDTO>();
            for (int i = 0; i < this.n; i++)
            {
                if (nhasachDTO[i].MaNhaSach.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(nhasachDTO[i]);
                    continue;
                }               
            }
            return listKQ.ToList();
        }
        public List<NhaSachDTO> sort(bool isUp, string thuocTinh)
        {
            NhaSachDTO[] listKQ = this.nhasachDTO;
            int nKQ = this.n;
            if (isUp == true)
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].MaNhaSach.CompareTo(listKQ[j].MaNhaSach) >= 0)
                            {
                                NhaSachDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }

            }
            else
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].MaNhaSach.CompareTo(listKQ[j].MaNhaSach) <= 0)
                            {
                                NhaSachDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
            }

            List<NhaSachDTO> list = new List<NhaSachDTO>();

            for (int i = 0; i < nKQ; i++)
            {
                list.Add(listKQ[i]);
            }
            return list.ToList();
        }
    }
}

