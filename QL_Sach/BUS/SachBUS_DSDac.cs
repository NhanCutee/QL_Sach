using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class SachBUS_DSD
    {
        private SachDTO[] sachDTO;
        private int n;

        public List<SachDTO> SachList
        {
            get {
            List<SachDTO> kq = new List<SachDTO>();
                for (int i=0; i < this.n;i++)
                    kq.Add(sachDTO[i]);
                return kq;
            }
            set
            {
                this.xoaTatCa();
                List<SachDTO> sList = value;
                foreach (SachDTO s in sList)
                {
                    this.themSach(s);
                }
            }
        }
        public int N { get => n; set => n = value; }

        public SachBUS_DSD()
        {
            sachDTO = new SachDTO[100];
            n = 0;
        }
        public void themSach(SachDTO sach)
        {

            sachDTO[n] = sach;
            n++;
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
            sachDTO[n] = sach;
            n++;
        }
        public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            sachDTO[index].MaSach = enter_maSach;
            sachDTO[index].TenSach = enter_tenSach;
            sachDTO[index].TheLoai = enter_theLoai;
            sachDTO[index].TenTacGia = enter_tenTacGia;
            sachDTO[index].NhaXuatBan = enter_nhaXuatBan;
            sachDTO[index].NgayXuatBan = enter_ngayXuatBan;
            sachDTO[index].GhiChu = enter_ghiChu;
            sachDTO[index].Gia = enter_gia;
        }


        ~SachBUS_DSD()
        {
            sachDTO = null;
        }
        public void xoaSach(int vt)
        {
            for (int i = vt; i < this.n-1; i++)
                sachDTO[i] = sachDTO[i + 1];
            this.n--;
        }
        public void xoaTatCa()
        {
            this.n=0;
        }

        public int soLuongSach()
        {
            return this.n;
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

            for (int i = 0; i < this.n; i++)
            {
                if (sachDTO[i].MaSach == tuKhoa.ToUpper())
                {
                    dsKetQua_MaSach.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].TenSach == tuKhoa)
                {
                    dsKetQua_TenSach.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].TheLoai == tuKhoa)
                {
                    dsKetQua_TheLoai.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].TenTacGia == tuKhoa)
                {
                    dsKetQua_TenTacGia.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].NhaXuatBan == tuKhoa)
                {
                    dsKetQua_NhaXuatBan.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].NgayXuatBan.ToShortDateString() == tuKhoa)
                {
                    dsKetQua_NgayXuatBan.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].Gia.ToString() == tuKhoa)
                {
                    dsKetQua_Gia.Add(sachDTO[i]);
                    continue;
                }
                else if (sachDTO[i].GhiChu == tuKhoa)
                {
                    dsKetQua_GhiChu.Add(sachDTO[i]);
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
                bf.Serialize(fs, this.SachList);
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
                this.SachList = (List<SachDTO>)bf.Deserialize(fs);
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
