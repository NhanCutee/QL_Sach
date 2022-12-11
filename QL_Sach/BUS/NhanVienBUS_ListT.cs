using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QL_nhanVien.BUS
{
    class NhanVienBUS_ListT
    {
        private List<NhanVienDTO> nhanVienList;

        public List<NhanVienDTO> NhanVienList { get => nhanVienList.ToList(); set => nhanVienList = value; }

        public NhanVienBUS_ListT()
        {
            this.nhanVienList = new List<NhanVienDTO>();
        }

        public NhanVienDTO timNV(string ma)
        {
            foreach(NhanVienDTO nv in nhanVienList)
            {
                if (ma == nv.MaNV)
                    return nv;
            }
            return null;
        }


        public void themNVRong()
        {
            NhanVienDTO nhanVien = new NhanVienDTO();
            this.nhanVienList.Add(nhanVien);
        }

        public bool themNV(NhanVienDTO nhanVien)
        {
           if(timNV(nhanVien.MaNV)==null)
           {
                this.nhanVienList.Add(nhanVien);
                return true;
           }
            return false;
        }


        public bool xoaNV(string ma)
        {
           NhanVienDTO nhanVien = timNV(ma);
            if (nhanVien != null)
            {
                nhanVienList.Remove(nhanVien);
                return true;
            }
            else
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
            return nhanVienList.Count;
        }

        public void xoaTatCa()
        {
            nhanVienList.Clear();
        }

        public List<NhanVienDTO> timTuKhoa(string tuKhoa)
        {
            List<NhanVienDTO> listKQ= new List<NhanVienDTO>();
            foreach(NhanVienDTO nv in nhanVienList)
            {
                if(nv.MaNV.ToString().ToUpper()==tuKhoa.ToUpper())
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if (nv.TenNV.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if (tuKhoa.ToUpper()=="GT:NAM" && nv.GioiTinh==true)
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "GT:NỮ" && nv.GioiTinh == false)
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if (nv.NgaySinh.ToString()==tuKhoa)
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if (nv.DiaChi.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if (nv.NhaSachLamViec.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(nv);
                    continue;
                }
                else if ("CV:" + nv.ChucVu.ToString().ToUpper() ==tuKhoa.ToUpper())
                {
                    listKQ.Add(nv);
                    continue;
                }
            }
            return listKQ.ToList();
        }

        public List<NhanVienDTO> sort(bool isUp,string thuocTinh)
        {
            List<NhanVienDTO> listKQ=nhanVienList; 
            if(isUp==true)
            {
                if(thuocTinh.ToUpper()=="MA")
                {
                    listKQ.Sort(
                        delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                        {
                            return nv1.MaNV.CompareTo(nv2.MaNV);
                        }
                        );
                }
                else if(thuocTinh.ToUpper() == "TEN")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return nv1.TenNV.CompareTo(nv2.TenNV);
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "DC")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return nv1.DiaChi.CompareTo(nv2.DiaChi);
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "GT")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return nv1.GioiTinh==true?1:-1;
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "NS")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return nv1.NgaySinh.CompareTo(nv2.NgaySinh);
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "NOILV")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return nv1.NhaSachLamViec.CompareTo(nv2.NhaSachLamViec);
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "CV")
                {
                        listKQ.Sort(
                      delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                      {
                          return nv1.ChucVu.CompareTo(nv2.ChucVu);
                      }
                      );
                }
            }
            else
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    listKQ.Sort(
                        delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                        {
                            return -(nv1.MaNV.CompareTo(nv2.MaNV));
                        }
                        );
                }
                else if (thuocTinh.ToUpper() == "TEN")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return -(nv1.TenNV.CompareTo(nv2.TenNV));
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "DC")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return -(nv1.DiaChi.CompareTo(nv2.DiaChi));
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "GT")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return - (nv1.GioiTinh == true ? 1 : -1);
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "NS")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return -(nv1.NgaySinh.CompareTo(nv2.NgaySinh));
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "NOILV")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return -(nv1.NhaSachLamViec.CompareTo(nv2.NhaSachLamViec));
                  }
                  );
                }
                else if (thuocTinh.ToUpper() == "CV")
                {
                    listKQ.Sort(
                  delegate (NhanVienDTO nv1, NhanVienDTO nv2)
                  {
                      return -(nv1.ChucVu.CompareTo(nv2.ChucVu));
                  }
                  );
                }
            }
            return listKQ;
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

            foreach (NhanVienDTO nv in nhanVienList)
            {
                if (nv.MaNV.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_MaNV.Add(nv);
                    continue;
                }
                else if (nv.ChucVu.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_ChucVu.Add(nv);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NAM" && nv.GioiTinh == true)
                {
                    dsKetQua_GioiTinh.Add(nv);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NỮ" && nv.GioiTinh == false)
                {
                    dsKetQua_GioiTinh.Add(nv);
                    continue;
                }
                else if (nv.TenNV.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_TenNV.Add(nv);
                    continue;
                }
                else if (nv.NgaySinh.ToShortDateString().Contains(tuKhoa))
                {
                    dsKetQua_NgaySinh.Add(nv);
                    continue;
                }
                else if (nv.NhaSachLamViec.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_NhaSachLamViec.Add(nv);
                    continue;
                }
                else if (nv.DiaChi.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_DiaChi.Add(nv);
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
