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
    class NhanVienBUS_DSDac
    {
        private NhanVienDTO[] dSNhanVien;
        private int n;
        public static int MAX = 100;

        public List<NhanVienDTO> NhanVienList {
            get 
            {
                List<NhanVienDTO> nvList = new List<NhanVienDTO>() ;
                for (int i = 0; i < this.n; i++)
                {
                    nvList.Add(dSNhanVien[i]);
                }
                return nvList;
            }
            set
            {
                this.xoaTatCa();
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
            for(int i=0;i<this.n;i++)
            {
                if (this.dSNhanVien[i].MaNV == ma)
                    return this.dSNhanVien[i];
            }
            return null;
        }

        public int timIndex(string ma)
        {
            for (int i = 0; i < this.n; i++)
            {
                if (this.dSNhanVien[i].MaNV == ma)
                    return i;
            }
            return -1;
        }


        public void themNVRong()
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            this.themNV(nhanVien);
        }

        public bool themNV(NhanVienDTO nhanVien)
        {
            if (this.timNV(nhanVien.MaNV) == null)
            {
                this.dSNhanVien[n] = nhanVien;
                n++;
                return true;
            }
            return false;
        }


        public bool xoaNV(string ma)
        {
            if (this.dSNhanVien[n - 1].MaNV == ma)
            {
                this.n--;
                return true;
            }
            else
            {
                int i = timIndex(ma);
                if (i == -1)
                    return false;
                for (int j = i; j < n; j++)
                    this.dSNhanVien[j] = this.dSNhanVien[j + 1];
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

        public List<NhanVienDTO> timTuKhoa(string tuKhoa)
        {
            List<NhanVienDTO> listKQ = new List<NhanVienDTO>();
            for (int i = 0; i < this.n; i++)
            {
                if (dSNhanVien[i].MaNV.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].TenNV.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "GT:NAM" && dSNhanVien[i].GioiTinh == true)
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "GT:NỮ" && dSNhanVien[i].GioiTinh == false)
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].NgaySinh.ToString() == tuKhoa)
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].DiaChi.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].NhaSachLamViec.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
                else if ("CV:" + dSNhanVien[i].ChucVu.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(dSNhanVien[i]);
                    continue;
                }
            }
            return listKQ.ToList();
        }



        public List<NhanVienDTO> sort(bool isUp, string thuocTinh)
        {
            NhanVienDTO[] listKQ = this.dSNhanVien;
            int nKQ = this.n;
            if (isUp == true)
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (int i = 0; i < nKQ-1; i++)
                        for (int j = i+1; j < nKQ; j++)
                            if (listKQ[i].MaNV.CompareTo(listKQ[j].MaNV)>=0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }    
                }
                else if (thuocTinh.ToUpper() == "TEN")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].TenNV.CompareTo(listKQ[j].TenNV) >= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "DC")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].DiaChi.CompareTo(listKQ[j].DiaChi) >= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "GT")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].GioiTinh==true)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "NS")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].NgaySinh.CompareTo(listKQ[j].NgaySinh) >= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "NOILV")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].NhaSachLamViec.CompareTo(listKQ[j].NhaSachLamViec) >= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "CV")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].ChucVu.CompareTo(listKQ[j].ChucVu) >= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
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
                            if (listKQ[i].MaNV.CompareTo(listKQ[j].MaNV) <= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "TEN")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].TenNV.CompareTo(listKQ[j].TenNV) <= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "DC")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].DiaChi.CompareTo(listKQ[j].DiaChi) <= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "GT")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].GioiTinh == false)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "NS")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].NgaySinh.CompareTo(listKQ[j].NgaySinh) <= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "NOILV")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].NhaSachLamViec.CompareTo(listKQ[j].NhaSachLamViec) <= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
                else if (thuocTinh.ToUpper() == "CV")
                {
                    for (int i = 0; i < nKQ - 1; i++)
                        for (int j = i + 1; j < nKQ; j++)
                            if (listKQ[i].ChucVu.CompareTo(listKQ[j].ChucVu) <= 0)
                            {
                                NhanVienDTO temp = listKQ[i];
                                listKQ[i] = listKQ[j];
                                listKQ[j] = temp;
                            }
                }
            }

            List<NhanVienDTO> list = new List<NhanVienDTO>();

            for (int i = 0; i < nKQ; i++)
            {
                list.Add(listKQ[i]);
            }
            return list.ToList() ;
        }


        public bool luuFile()
        {
            try
            {
                FileStream fs = new FileStream("NhanVienData.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this.NhanVienList);
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
                this.NhanVienList = (List<NhanVienDTO>)bf.Deserialize(fs);
                fs.Close();
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
            List<NhanVienDTO> dsKetQua_ChucVu = new List<NhanVienDTO>();

            for(int i =0;i<this.n;i++)
            {
                if (dSNhanVien[i].MaNV.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_MaNV.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].ChucVu.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_ChucVu.Add(dSNhanVien[i]);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NAM" && dSNhanVien[i].GioiTinh == true)
                {
                    dsKetQua_GioiTinh.Add(dSNhanVien[i]);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NỮ" && dSNhanVien[i].GioiTinh == false)
                {
                    dsKetQua_GioiTinh.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].TenNV.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_TenNV.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].NgaySinh.ToShortDateString().Contains(tuKhoa))
                {
                    dsKetQua_NgaySinh.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].NhaSachLamViec.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_NhaSachLamViec.Add(dSNhanVien[i]);
                    continue;
                }
                else if (dSNhanVien[i].DiaChi.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_DiaChi.Add(dSNhanVien[i]);
                    continue;
                }
            }

            dsKetQua = dsKetQua.Concat(dsKetQua_MaNV).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_ChucVu).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_GioiTinh).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenNV).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NgaySinh).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NhaSachLamViec).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_DiaChi).ToList();

            return dsKetQua;
        }

    }
}

