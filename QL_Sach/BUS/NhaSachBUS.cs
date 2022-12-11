using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_nhanVien.BUS;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class NhaSachBUS
    {
        private string loaiDS;
        private List<NhaSachDTO> nhasachList;
        private NhaSachBUS_ListT nhasachListT;
        private NhaSachBUS_DSDac nhasachDSD;
        private NhaSachBUS_DSLienKet nhasachDSLK;
        public List<NhaSachDTO> NhaSachList { get => nhasachList; }
        public string LoaiDS { get => loaiDS;}

        public NhaSachBUS(string enter_loaiDS)
        {
            loaiDS = enter_loaiDS;
            if (loaiDS == "LibListT")
            {
                nhasachListT = new NhaSachBUS_ListT();
                nhasachList = nhasachListT.NhaSachList;
            }
            else if (loaiDS == "DSDac")
            {
                nhasachDSD = new NhaSachBUS_DSDac();
                nhasachList = nhasachDSD.NhaSachList;
            }
            else if (loaiDS == "DSLK")
            {
                nhasachDSLK = new NhaSachBUS_DSLienKet();
                nhasachList = nhasachDSLK.NhaSachList;
            }
        }
        public void themNhaSach(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            if (loaiDS == "LibListT")
            {
                nhasachListT.themNhaSach(enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
                nhasachList = nhasachListT.NhaSachList;
            }
            else if (loaiDS == "DSDac")
            {
                nhasachDSD.themNhaSach(enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
                nhasachList = nhasachDSD.NhaSachList;
            }
            else if (loaiDS == "DSLK")
            {
                nhasachDSLK.themNhaSach(enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
                nhasachList = nhasachDSLK.NhaSachList;
            }
        }
        public void suaNhaSach(int index, string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            if (loaiDS == "LibListT")
            {
                nhasachListT.suaNhaSach(index, enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
                nhasachList = nhasachListT.NhaSachList;
            }
            else if (loaiDS == "DSDac")
            {
                nhasachDSD.suaNhaSach(index, enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
                nhasachList = nhasachDSD.NhaSachList;
            }
            else if (loaiDS == "DSLK")
            {
                nhasachDSLK.suaNhaSach(index, enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
                nhasachList = nhasachDSLK.NhaSachList;
            }
        }
        public void xoaNhaSach(int index)
        {
            if (loaiDS == "LibListT")
            {
                nhasachListT.xoaNhaSach(index);
                nhasachList = nhasachListT.NhaSachList;
            }
            else if (loaiDS == "DSDac")
            {
                nhasachDSD.xoaNhaSach(index);
                nhasachList = nhasachDSD.NhaSachList;
            }
            else if (loaiDS == "DSLK")
            {
                nhasachDSLK.xoaNhaSach(index);
                nhasachList = nhasachDSLK.NhaSachList;
            }
        }
        public void xoaTatCa()
        {
            if (loaiDS == "LibListT")
            {
                nhasachListT.xoaTatCa();
                nhasachList = nhasachListT.NhaSachList;
            }
            else if (loaiDS == "DSDac")
            {
                nhasachDSD.xoaTatCa();
                nhasachList = nhasachDSD.NhaSachList;
            }
            else if (loaiDS == "DSLK")
            {
                nhasachDSLK.xoaTatCa();
                nhasachList = nhasachDSLK.NhaSachList;
            }
        }
        public int soLuongNhaSach()
        {
            int soLuong = 0;
            if (loaiDS == "LibListT")
            {
                soLuong = nhasachListT.soLuongNhaSach();
            }
            else if (loaiDS == "DSDac")
            {
                soLuong = nhasachDSD.soLuongNhaSach();
            }
            else if (loaiDS == "DSLK")
            {
                soLuong = nhasachDSLK.soLuongNhaSach();
            }

            return soLuong;
        }


        private bool chuyenDoiDuLieu()
        {
            try
            {
                if (loaiDS == "LibListT")
                {
                    foreach (NhaSachDTO nv in nhasachList)
                    {
                        nhasachListT.themNhaSach(nv);
                    }
                }
                else if (loaiDS == "DSDac")
                {
                    foreach (NhaSachDTO nv in nhasachList)
                    {
                        nhasachDSD.themNhaSach(nv);
                    }
                }
                else if (loaiDS == "DSLK")
                {
                    foreach (NhaSachDTO nv in nhasachList)
                    {
                        nhasachDSLK.themNhaSach(nv);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<NhaSachDTO> timKiem(string tuKhoa)
        {
            if (loaiDS == "LibListT")
                return nhasachListT.timKiem(tuKhoa);
            else if (loaiDS == "DSDac")
                return nhasachDSD.timKiem(tuKhoa);
            else if (loaiDS == "DSLK")
                return nhasachDSLK.timKiem(tuKhoa);
            else
                return new List<NhaSachDTO>();
        }

        public bool chuyenCauTrucDL(string ctdl)
        {
            if (ctdl == "LibListT")
            {
                nhasachListT = new NhaSachBUS_ListT();
                loaiDS = "LibListT";
                if (!chuyenDoiDuLieu())
                    return false;
                nhasachList = nhasachListT.NhaSachList;
                return true;
            }
            else if (ctdl == "DSDac")
            {
                nhasachDSD = new NhaSachBUS_DSDac();
                loaiDS = "DSDac";
                if (!chuyenDoiDuLieu())
                    return false;
                nhasachList = nhasachDSD.NhaSachList;
                return true;
            }
            else if (ctdl == "DSLK")
            {
                nhasachDSLK = new NhaSachBUS_DSLienKet();
                loaiDS = "DSLK";
                if (!chuyenDoiDuLieu())
                    return false;
                nhasachList = nhasachDSLK.NhaSachList;
                return true;
            }
            else
                return false;
        }
        public List<NhaSachDTO> timTuKhoa(string tuKhoa)
        {
            if (loaiDS == "LibListT")
                return nhasachListT.timTuKhoa(tuKhoa);
            else if (loaiDS == "DSDac")
                return nhasachDSD.timTuKhoa(tuKhoa);
            else if (loaiDS == "DSLK")
                return nhasachDSLK.timTuKhoa(tuKhoa);
            else
                return new List<NhaSachDTO>();
        }

        public List<NhaSachDTO> sort(bool isUp, string thuocTinh)
        {
            if (loaiDS == "LibListT")
                return nhasachListT.sort(isUp, thuocTinh);
            else if (loaiDS == "DSDac")
                return nhasachDSD.sort(isUp, thuocTinh);
            else if (loaiDS == "DSLK")
                return nhasachDSLK.sort(isUp, thuocTinh);
            else
                return new List<NhaSachDTO>();
        }

        public bool luuFile()
        {
            if (loaiDS == "LibListT")
            {
                return nhasachListT.luuFile();
            }
            else if (loaiDS == "DSDac")
            {
                return nhasachDSD.luuFile();
            }
            else if (loaiDS == "DSLK")
            {
                return nhasachDSLK.luuFile();
            }
            else return false;
        }

        public bool docFile()
        {
            if (loaiDS == "LibListT")
            {
                if (!nhasachListT.docFile())
                    return false;
                nhasachList = nhasachListT.NhaSachList;
                return true;
            }
            else if (loaiDS == "DSDac")
            {
                if (!nhasachDSD.docFile())
                    return false;
                nhasachList =nhasachDSD.NhaSachList;
                return true;
            }
            else if (loaiDS == "DSLK")
            {
                if (!nhasachDSLK.docFile())
                    return false;
                nhasachList = nhasachDSLK.NhaSachList;
                return true;
            }
            else return false;
        }
    }
}

    

