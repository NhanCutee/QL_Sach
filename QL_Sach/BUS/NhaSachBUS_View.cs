﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class NhaSachBUS_View
    {
        private string loaiDS;
        private List<NhaSachDTO> nhasachList;
        private NhaSachBUS_ListT nhasachListT;
        private NhaSachBUS_DSDac nhasachDSD;
        private NhaSachBUS_DSLienKet nhasachDSLK;
        public List<NhaSachDTO> NhaSachList { get => nhasachList; }

        public NhaSachBUS_View(string enter_loaiDS)
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

        //fix loi file being use by another process
        public bool luuFile()
        {
            FileStream fs = new FileStream("NhaSachList.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, nhasachList);
            fs.Close();

            return true;
        }
        public bool docFile()
        {
            FileStream fs = null;
            try { fs = new FileStream("NhaSachList.dat", FileMode.Open); }
            catch { return false; }
            if (fs == null)
                return false;
            BinaryFormatter bf = new BinaryFormatter();
            nhasachList = (List<NhaSachDTO>)bf.Deserialize(fs);
            fs.Close();
            if (nhasachList.Count == 0)
                return false;
            //ghi vao loai du lieu hien tai
            chuyenDoiDuLieu();
            return true;
        }

        public bool docFile(string location)
        {
            FileStream fs = null;
            try { fs = new FileStream(location, FileMode.Open); }
            catch { return false; }
            if (fs == null)
                return false;
            BinaryFormatter bf = new BinaryFormatter();
            nhasachList = (List<NhaSachDTO>)bf.Deserialize(fs);
            fs.Close();
            if (nhasachList.Count == 0)
                return false;
            //ghi vao loai du lieu hien tai
            chuyenDoiDuLieu();
            return true;
        }

        private void chuyenDoiDuLieu()
        {
            if (loaiDS == "LibListT")
            {
                foreach (NhaSachDTO ns in nhasachList)
                {
                    nhasachListT.themNhaSach(ns);
                }
            }
            else if (loaiDS == "DSDac")
            {
                foreach (NhaSachDTO ns in nhasachList)
                {
                    nhasachDSD.themNhaSach(ns);
                }
            }
            else if (loaiDS == "DSLK")
            {
                foreach (NhaSachDTO ns in nhasachList)
                {
                    nhasachDSLK.themNhaSach(ns);
                }
            }

        }

        public List<NhaSachDTO> timKiem(string tuKhoa)
        {
            List<NhaSachDTO> dsKetQua = new List<NhaSachDTO>();
            List<NhaSachDTO> dsKetQua_MaNhaSach = new List<NhaSachDTO>();
            List<NhaSachDTO> dsKetQua_TenNhaSach = new List<NhaSachDTO>();
            List<NhaSachDTO> dsKetQua_DiaChi = new List<NhaSachDTO>();
            List<NhaSachDTO> dsKetQua_TenQuanLi = new List<NhaSachDTO>();
            List<NhaSachDTO> dsKetQua_SoLuongNhanVien = new List<NhaSachDTO>();
           

            foreach (NhaSachDTO ns in nhasachList)
            {
                if (ns.MaNhaSach == tuKhoa.ToUpper())
                {
                    dsKetQua_MaNhaSach.Add(ns);
                    continue;
                }
                else if (ns.TenNhaSach == tuKhoa)
                {
                    dsKetQua_TenNhaSach.Add(ns);
                    continue;
                }
                else if (ns.DiaChi == tuKhoa)
                {
                    dsKetQua_DiaChi.Add(ns);
                    continue;
                }
                else if (ns.TenQuanLi == tuKhoa)
                {
                    dsKetQua_TenQuanLi.Add(ns);
                    continue;
                }
                else if (ns.SoLuongNhanVien.ToString() == tuKhoa)
                {
                    dsKetQua_SoLuongNhanVien.Add(ns);
                    continue;
                }
                
            }

            dsKetQua = dsKetQua.Concat(dsKetQua_MaNhaSach).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenNhaSach).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_DiaChi).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenQuanLi).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_SoLuongNhanVien).ToList();
    

            return dsKetQua;
        }
    }

    }

