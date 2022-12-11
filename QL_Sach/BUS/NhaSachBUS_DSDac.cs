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
            set
            {
                this.xoaTatCa();
                List<NhaSachDTO> nsList = value;
                foreach (NhaSachDTO ns in nsList)
                {
                    this.themNhaSach(ns);
                }
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

        public bool luuFile()
        {
            try
            {
                FileStream fs = new FileStream("NhaSachData.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this.NhaSachList);
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
                FileStream fs = new FileStream("NhaSachData.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.NhaSachList = (List<NhaSachDTO>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
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


            for (int i = 0; i < this.n; i++)
            {
                if (nhasachDTO[i].MaNhaSach == tuKhoa.ToUpper())
                {
                    dsKetQua_MaNhaSach.Add(nhasachDTO[i]);
                    continue;
                }
                else if (nhasachDTO[i].TenNhaSach == tuKhoa)
                {
                    dsKetQua_TenNhaSach.Add(nhasachDTO[i]);
                    continue;
                }
                else if (nhasachDTO[i].DiaChi == tuKhoa)
                {
                    dsKetQua_DiaChi.Add(nhasachDTO[i]);
                    continue;
                }
                else if (nhasachDTO[i].TenQuanLi == tuKhoa)
                {
                    dsKetQua_TenQuanLi.Add(nhasachDTO[i]);
                    continue;
                }
                else if (nhasachDTO[i].SoLuongNhanVien.ToString() == tuKhoa)
                {
                    dsKetQua_SoLuongNhanVien.Add(nhasachDTO[i]);
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

