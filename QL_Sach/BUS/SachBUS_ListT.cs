using QL_Sach.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace QL_Sach.BUS
{
    class SachBUS_ListT
    {
        private List<SachDTO> sachList;

        public List<SachDTO> SachList { get => sachList; set => sachList = value; }

        public SachBUS_ListT()
        {
            this.sachList = new List<SachDTO>();
        }

        public void themSachRong()
        {
            SachDTO sach = new SachDTO();
            this.sachList.Add(sach);
        }
        public void themSach(SachDTO sach)
        {
            this.sachList.Add(sach);
        }
        public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            SachDTO sach = new SachDTO();
            sach.MaSach = enter_maSach;
            sach.TenSach = enter_tenSach;
            sach.TheLoai = enter_theLoai;
            sach.TenTacGia = enter_tenTacGia;
            sach.NhaXuatBan = enter_nhaXuatBan;
            sach.NgayXuatBan = enter_ngayXuatBan;
            sach.GhiChu = enter_ghiChu;
            sach.Gia = enter_gia;

            this.sachList.Add(sach);
        }

        public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            sachList[index].MaSach = enter_maSach;
            sachList[index].TenSach = enter_tenSach;
            sachList[index].TheLoai = enter_theLoai;
            sachList[index].TenTacGia = enter_tenTacGia;
            sachList[index].NhaXuatBan = enter_nhaXuatBan;
            sachList[index].NgayXuatBan = enter_ngayXuatBan;
            sachList[index].GhiChu = enter_ghiChu;
            sachList[index].Gia = enter_gia;
        }
        public void xoaSach(int index)
        {
            sachList.Remove(sachList[index]);

        }

        public int soLuongSach()
        {
            return sachList.Count;
        }

        public void xoaTatCa()
        {
            SachList.Clear();
        }

        public List<SachDTO> timKiem(string tuKhoa)
        {
            List<SachDTO> dsKetQua = new List<SachDTO>();
            List<SachDTO> dsKetQua_MaSach = new List<SachDTO>();
            List<SachDTO> dsKetQua_TenSach = new List<SachDTO>();
            List<SachDTO> dsKetQua_TheLoai = new List<SachDTO>();
            List<SachDTO> dsKetQua_TenTacGia = new List<SachDTO>();
            List<SachDTO> dsKetQua_NhaXuatBan = new List<SachDTO>();
            List<SachDTO> dsKetQua_NgayXuatBan = new List<SachDTO>();
            List<SachDTO> dsKetQua_Gia = new List<SachDTO>();
            List<SachDTO> dsKetQua_GhiChu = new List<SachDTO>();

            foreach (SachDTO sach in sachList)
            {
                if (sach.MaSach == tuKhoa.ToUpper())
                {
                    dsKetQua_MaSach.Add(sach);
                    continue;
                }
                else if (sach.TenSach == tuKhoa)
                {
                    dsKetQua_TenSach.Add(sach);
                    continue;
                }
                else if (sach.TheLoai == tuKhoa)
                {
                    dsKetQua_TheLoai.Add(sach);
                    continue;
                }
                else if (sach.TenTacGia == tuKhoa)
                {
                    dsKetQua_TenTacGia.Add(sach);
                    continue;
                }
                else if (sach.NhaXuatBan == tuKhoa)
                {
                    dsKetQua_NhaXuatBan.Add(sach);
                    continue;
                }
                else if (sach.NgayXuatBan.ToShortDateString() == tuKhoa)
                {
                    dsKetQua_NgayXuatBan.Add(sach);
                    continue;
                }
                else if (sach.Gia.ToString() == tuKhoa)
                {
                    dsKetQua_Gia.Add(sach);
                    continue;
                }
                else if (sach.GhiChu == tuKhoa)
                {
                    dsKetQua_GhiChu.Add(sach);
                    continue;
                }
            }

            dsKetQua = dsKetQua.Concat(dsKetQua_MaSach).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenSach).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TheLoai).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenTacGia).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NhaXuatBan).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NgayXuatBan).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_Gia).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_GhiChu).ToList();

            return dsKetQua;
        }

        public bool luuFile()
        {
            try
            {
                FileStream fs = new FileStream("SachData.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this.sachList);
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
                FileStream fs = new FileStream("SachData.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.sachList = (List<SachDTO>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
