using QL_nhanVien.BUS;
using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class NhanVienBUS_View
    {
        private string loaiDS;
        private List<NhanVienDTO> nhanVienList;
        private NhanVienBUS_ListT nhanVienListT;
        private NhanVienBUS_DSDac nhanVienDSDac;
        private NhanVienBUS_DSLienKet nhanVienDSLK;
        public List<NhanVienDTO> SachList { get => nhanVienList; }


        public NhanVienBUS_View(string enter_loaiDS)
        {
            loaiDS = enter_loaiDS;
            if (loaiDS == "LibListT")
            {
                nhanVienListT = new NhanVienBUS_ListT();
                nhanVienList =nhanVienListT.NhanVienList;
            }
            else if (loaiDS == "DSDac")
            {
                nhanVienDSDac = new NhanVienBUS_DSDac();
                //nhanVienList = nhanVienDSDac.NhanVienList;
            }
            else if (loaiDS == "DSLK")
            {
                nhanVienDSLK = new NhanVienBUS_DSLienKet();
                //nhanVienList = nhanVienDSLK.NhanVienList;
            }


        }

        //public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        //{
        //    if (loaiDS == "LibListT")
        //    {
        //       nhanVienListT.themSach(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
        //        nhanVienList =nhanVienListT.NhanVienList;
        //    }
        //    else if (loaiDS == "DSDac")
        //    {
        //        nhanVienDSDac.themSach(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
        //        nhanVienList = nhanVienDSDac.NhanVienList;
        //    }
        //    else if (loaiDS == "DSLK")
        //    {
        //        nhanVienDSLK.themSach(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
        //        nhanVienList = nhanVienDSLK.NhanVienList;
        //    }
        //}
        //public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        //{
        //    if (loaiDS == "LibListT")
        //    {
        //       nhanVienListT.suaSach(index, enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
        //        nhanVienList =nhanVienListT.NhanVienList;
        //    }
        //    else if (loaiDS == "DSDac")
        //    {
        //        nhanVienDSDac.suaSach(index, enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
        //        nhanVienList = nhanVienDSDac.NhanVienList;
        //    }
        //    else if (loaiDS == "DSLK")
        //    {
        //        nhanVienDSLK.suaSach(index, enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
        //        nhanVienList = nhanVienDSLK.NhanVienList;
        //    }
        //}

        //public void xoaSach(int index)
        //{
        //    if (loaiDS == "LibListT")
        //    {
        //       nhanVienListT.xoaSach(index);
        //        nhanVienList =nhanVienListT.NhanVienList;
        //    }
        //    else if (loaiDS == "DSDac")
        //    {
        //        nhanVienDSDac.xoaSach(index);
        //        nhanVienList = nhanVienDSDac.NhanVienList;
        //    }
        //    else if (loaiDS == "DSLK")
        //    {
        //        nhanVienDSLK.xoaSach(index);
        //        nhanVienList = nhanVienDSLK.NhanVienList;
        //    }

        //}
        //public void xoaTatCa()
        //{
        //    if (loaiDS == "LibListT")
        //    {
        //       nhanVienListT.xoaTatCa();
        //        nhanVienList =nhanVienListT.NhanVienList;
        //    }
        //    else if (loaiDS == "DSDac")
        //    {
        //        nhanVienDSDac.xoaTatCa();
        //        nhanVienList = nhanVienDSDac.NhanVienList;
        //    }
        //    else if (loaiDS == "DSLK")
        //    {
        //        nhanVienDSLK.xoaTatCa();
        //        nhanVienList = nhanVienDSLK.NhanVienList;
        //    }
        //}
        //public int soLuongSach()
        //{
        //    int soLuong = 0;
        //    if (loaiDS == "LibListT")
        //    {
        //        soLuong =nhanVienListT.soLuongSach();
        //    }
        //    else if (loaiDS == "DSDac")
        //    {
        //        soLuong = nhanVienDSDac.soLuongSach();
        //    }
        //    else if (loaiDS == "DSLK")
        //    {
        //        soLuong = nhanVienDSLK.soLuongSach();
        //    }

        //    return soLuong;
        //}

        ////fix loi file being use by another process
        //public bool luuFile()
        //{
        //    FileStream fs = new FileStream("SachList.dat", FileMode.Create);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(fs, nhanVienList);
        //    fs.Close();

        //    return true;
        //}
        //public bool docFile()
        //{
        //    FileStream fs = null;
        //    try { fs = new FileStream("SachList.dat", FileMode.Open); }
        //    catch { return false; }
        //    if (fs == null)
        //        return false;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    nhanVienList = (List<NhanVienDTO>)bf.Deserialize(fs);
        //    fs.Close();
        //    if (nhanVienList.Count == 0)
        //        return false;
        //    //ghi vao loai du lieu hien tai
        //    chuyenDoiDuLieu();
        //    return true;
        //}

        //public bool docFile(string location)
        //{
        //    FileStream fs = null;
        //    try { fs = new FileStream(location, FileMode.Open); }
        //    catch { return false; }
        //    if (fs == null)
        //        return false;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    nhanVienList = (List<NhanVienDTO>)bf.Deserialize(fs);
        //    fs.Close();
        //    if (nhanVienList.Count == 0)
        //        return false;
        //    //ghi vao loai du lieu hien tai
        //    chuyenDoiDuLieu();
        //    return true;
        //}

        //private void chuyenDoiDuLieu()
        //{
        //    if (loaiDS == "LibListT")
        //    {
        //        foreach (NhanVienDTO sach in nhanVienList)
        //        {
        //           nhanVienListT.themSach(sach);
        //        }
        //    }
        //    else if (loaiDS == "DSDac")
        //    {
        //        foreach (NhanVienDTO sach in nhanVienList)
        //        {
        //            nhanVienDSDac.themSach(sach);
        //        }
        //    }
        //    else if (loaiDS == "DSLK")
        //    {
        //        foreach (NhanVienDTO sach in nhanVienList)
        //        {
        //            nhanVienDSLK.themSach(sach);
        //        }
        //    }

        //}

        //public List<NhanVienDTO> timKiem(string tuKhoa)
        //{
        //    List<NhanVienDTO> dsKetQua = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_MaSach = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_TenSach = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_TheLoai = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_TenTacGia = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_NhaXuatBan = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_NgayXuatBan = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_Gia = new List<NhanVienDTO>();
        //    List<NhanVienDTO> dsKetQua_GhiChu = new List<NhanVienDTO>();

        //    foreach (NhanVienDTO sach in nhanVienList)
        //    {
        //        if (sach.MaSach == tuKhoa.ToUpper())
        //        {
        //            dsKetQua_MaSach.Add(sach);
        //            continue;
        //        }
        //        else if (sach.TenSach == tuKhoa)
        //        {
        //            dsKetQua_TenSach.Add(sach);
        //            continue;
        //        }
        //        else if (sach.TheLoai == tuKhoa)
        //        {
        //            dsKetQua_TheLoai.Add(sach);
        //            continue;
        //        }
        //        else if (sach.TenTacGia == tuKhoa)
        //        {
        //            dsKetQua_TenTacGia.Add(sach);
        //            continue;
        //        }
        //        else if (sach.NhaXuatBan == tuKhoa)
        //        {
        //            dsKetQua_NhaXuatBan.Add(sach);
        //            continue;
        //        }
        //        else if (sach.NgayXuatBan.ToShortDateString() == tuKhoa)
        //        {
        //            dsKetQua_NgayXuatBan.Add(sach);
        //            continue;
        //        }
        //        else if (sach.Gia.ToString() == tuKhoa)
        //        {
        //            dsKetQua_Gia.Add(sach);
        //            continue;
        //        }
        //        else if (sach.GhiChu == tuKhoa)
        //        {
        //            dsKetQua_GhiChu.Add(sach);
        //            continue;
        //        }
        //    }

        //    dsKetQua = dsKetQua.Concat(dsKetQua_MaSach).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_TenSach).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_TheLoai).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_TenTacGia).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_NhaXuatBan).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_NgayXuatBan).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_Gia).ToList();
        //    dsKetQua = dsKetQua.Concat(dsKetQua_GhiChu).ToList();

        //    return dsKetQua;
        //}
    }
}
