using QL_nhanVien.BUS;
using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class NhanVienBUS
    {
        private string loaiDS;
        private List<NhanVienDTO> nhanVienList;
        private NhanVienBUS_ListT nhanVienListT;
        private NhanVienBUS_DSDac nhanVienDSDac;
        private NhanVienBUS_DSLienKet nhanVienDSLK;
        public List<NhanVienDTO> NhanVienList { 
            get
            {
                return nhanVienList.ToList();
            }
        }
        public string LoaiDS {
            get => loaiDS; 
        }

        public NhanVienBUS(string enter_loaiDS)
        {
            loaiDS = enter_loaiDS;
            nhanVienListT = new NhanVienBUS_ListT();
            nhanVienDSDac = new NhanVienBUS_DSDac();
            nhanVienDSLK = new NhanVienBUS_DSLienKet();

            if (loaiDS == "LibListT")
            {
                nhanVienList =nhanVienListT.NhanVienList;
            }
            else if (loaiDS == "DSDac")
            {
                nhanVienList = nhanVienDSDac.NhanVienList;
            }
            else if (loaiDS == "DSLK")
            {
                nhanVienList = nhanVienDSLK.NhanVienList;
            }
        }

        public NhanVienDTO timNV(string ma)
        {
            if (loaiDS == "LibListT")
            {
                return nhanVienListT.timNV(ma);
            }
            else if (loaiDS == "DSDac")
            {
                return nhanVienDSDac.timNV(ma);
            }
            else
            {
                return nhanVienDSLK.timNV(ma)==null?null: nhanVienDSLK.timNV(ma).NhanVien; //tim tra ve node nen chuyen lai
            }
        }

        public void themNV(NhanVienDTO nhanVien)
        {
            if (loaiDS == "LibListT")
            {
                nhanVienListT.themNV(nhanVien);
                nhanVienList = nhanVienListT.NhanVienList;
            }
            else if (loaiDS == "DSDac")
            {
                nhanVienDSDac.themNV(nhanVien);
                nhanVienList = nhanVienDSDac.NhanVienList;
            }
            else if (loaiDS == "DSLK")
            {
                nhanVienDSLK.themNV(nhanVien);
                nhanVienList = nhanVienDSLK.NhanVienList;
            }
        }
        public void suaNV(NhanVienDTO nhanVien)
        {
            if (loaiDS == "LibListT")
            {
                nhanVienListT.suaNV(nhanVien);
                nhanVienList = nhanVienListT.NhanVienList;
            }
            else if (loaiDS == "DSDac")
            {
                nhanVienDSDac.suaNV(nhanVien);
                nhanVienList = nhanVienDSDac.NhanVienList;
            }
            else if (loaiDS == "DSLK")
            {
                nhanVienDSLK.suaNV(nhanVien);
                nhanVienList = nhanVienDSLK.NhanVienList;
            }
        }

        public void xoaNV(string ma)
        {
            if (loaiDS == "LibListT")
            {
                nhanVienListT.xoaNV(ma);
                nhanVienList = nhanVienListT.NhanVienList;
            }
            else if (loaiDS == "DSDac")
            {
                nhanVienDSDac.xoaNV(ma);
                nhanVienList = nhanVienDSDac.NhanVienList;
            }
            else if (loaiDS == "DSLK")
            {
                nhanVienDSLK.xoaNV(ma);
                nhanVienList = nhanVienDSLK.NhanVienList;
            }
        }

        public void xoaTatCa()
        {
            if (loaiDS == "LibListT")
            {
                nhanVienListT.xoaTatCa();
                nhanVienList = nhanVienListT.NhanVienList;
            }
            else if (loaiDS == "DSDac")
            {
                nhanVienDSDac.xoaTatCa();
                nhanVienList = nhanVienDSDac.NhanVienList;
            }
            else if (loaiDS == "DSLK")
            {
                nhanVienDSLK.xoaTatCa();
                nhanVienList = nhanVienDSLK.NhanVienList;
            }
        }

        public int soLuongNV()
        {
            int soLuong = 0;
            if (loaiDS == "LibListT")
            {
                soLuong = nhanVienListT.soLuongNV();
            }
            else if (loaiDS == "DSDac")
            {
                soLuong = nhanVienDSDac.soLuongNV();
            }
            else if (loaiDS == "DSLK")
            {
                soLuong = nhanVienDSLK.soLuongNV();
            }
            return soLuong;
        }

        public bool luuFile()
        {
            try
            {
                FileStream fs = new FileStream("NhanVienData.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, nhanVienList);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool docFile()
        {
            try
            {
                FileStream fs = new FileStream("NhanVienData.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                nhanVienList = (List<NhanVienDTO>)bf.Deserialize(fs);
                chuyenDoiDuLieu();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool chuyenDoiDuLieu()
        {
            try
            {
                if (loaiDS == "LibListT")
                {
                    foreach (NhanVienDTO nv in nhanVienList)
                    {
                        nhanVienListT.themNV(nv);
                    }
                }
                else if (loaiDS == "DSDac")
                {
                    foreach (NhanVienDTO nv in nhanVienList)
                    {
                        nhanVienDSDac.themNV(nv);
                    }
                }
                else if (loaiDS == "DSLK")
                {
                    foreach (NhanVienDTO nv in nhanVienList)
                    {
                        nhanVienDSLK.themNV(nv);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<NhanVienDTO> timKiem(string tuKhoa)
        {
            List<NhanVienDTO> dsKetQua = new List<NhanVienDTO>();
            List<NhanVienDTO> dsKetQua_MaNV = new List<NhanVienDTO>();
            List<NhanVienDTO> dsKetQua_TenNV = new List<NhanVienDTO>();
            List<NhanVienDTO> dsKetQua_GioiTinh = new List<NhanVienDTO>();
            List<NhanVienDTO> dsKetQua_NgaySinh = new List<NhanVienDTO>();
            List<NhanVienDTO> dsKetQua_NhaSachLamViec = new List<NhanVienDTO>();
            List<NhanVienDTO> dsKetQua_DiaChi = new List<NhanVienDTO>();

            //Co the sua lai thanh .contain de tim linh hoat hon

            foreach (NhanVienDTO nv in nhanVienList)
            {
                if (nv.MaNV == tuKhoa.ToUpper())
                {
                    dsKetQua_MaNV.Add(nv);
                    continue;
                }
                else if (nv.TenNV == tuKhoa)
                {
                    dsKetQua_TenNV.Add(nv);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NAM" && nv.GioiTinh == true)
                {
                    dsKetQua_GioiTinh.Add(nv);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NU" && nv.GioiTinh == false)
                {
                    dsKetQua_GioiTinh.Add(nv);
                    continue;
                }
                else if (nv.NgaySinh.ToShortDateString()==tuKhoa)
                {
                    dsKetQua_NgaySinh.Add(nv);
                    continue;
                }
                else if (nv.NhaSachLamViec == tuKhoa)
                {
                    dsKetQua_NhaSachLamViec.Add(nv);
                    continue;
                }
                else if (nv.DiaChi == tuKhoa)
                {
                    dsKetQua_DiaChi.Add(nv);
                    continue;
                }

            }

            dsKetQua = dsKetQua.Concat(dsKetQua_MaNV).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenNV).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_GioiTinh).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NgaySinh).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NhaSachLamViec).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_DiaChi).ToList();
            //Thêm lọc chức vụ
            return dsKetQua;
        }

        public bool chuyenCauTrucDL(string ctdl)
        {
            if (ctdl == "LibListT")
            {
                nhanVienListT = new NhanVienBUS_ListT();
                loaiDS = "LibListT";
                if (!chuyenDoiDuLieu())
                    return false;
                nhanVienList = nhanVienListT.NhanVienList;
                return true;
            }
            else if (ctdl == "DSDac")
            {
                nhanVienDSDac = new NhanVienBUS_DSDac();
                loaiDS = "DSDac";
                if (!chuyenDoiDuLieu())
                    return false;
                nhanVienList = nhanVienDSDac.NhanVienList;
                return true;
            }
            else if (ctdl == "DSLK")
            {
                nhanVienDSLK = new NhanVienBUS_DSLienKet();
                loaiDS = "DSLK";
                if (!chuyenDoiDuLieu())
                    return false;
                nhanVienList = nhanVienDSLK.NhanVienList;
                return true;
            }
            else
                return false;
        }
    }
}
