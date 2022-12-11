using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace QL_Sach.BUS
{
    class NhaSachBUS_ListT
    {
        private List<NhaSachDTO> nhasachList;

        public List<NhaSachDTO> NhaSachList { get => nhasachList; set => nhasachList = value; }

        public NhaSachBUS_ListT()
        {
            this.nhasachList = new List<NhaSachDTO>();
        }

        public void themNhaSachRong()
        {
            NhaSachDTO ns = new NhaSachDTO();
            this.nhasachList.Add(ns);
        }
        public void themNhaSach(NhaSachDTO ns)
        {
            this.nhasachList.Add(ns);
        }
        public NhaSachDTO timNS(string ma)
        {
            foreach (NhaSachDTO ns in nhasachList)
            {
                if (ma == ns.MaNhaSach)
                    return ns;
            }
            return null;
        }
        public void themNhaSach(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            
            NhaSachDTO ns = new NhaSachDTO();
           
                ns.MaNhaSach = enter_maNhaSach;
                ns.TenNhaSach = enter_tenNhaSach;
                ns.DiaChi = enter_diaChi;
                ns.TenQuanLi = enter_tenQuanLi;
                ns.SoLuongNhanVien = enter_soLuongNhanVien;

            if (timNS(ns.MaNhaSach) == null)
            {
                this.nhasachList.Add(ns);
            }
            else
            {
                MessageBox.Show("Mã nhà sách " + ns.MaNhaSach + " đã có! Vui lòng nhập lại");
            }
        }

        public void suaNhaSach(int index, string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nhasachList[index].MaNhaSach = enter_maNhaSach;
            nhasachList[index].TenNhaSach = enter_tenNhaSach;
            nhasachList[index].DiaChi = enter_diaChi;
            nhasachList[index].TenQuanLi = enter_tenQuanLi;
            nhasachList[index].SoLuongNhanVien = enter_soLuongNhanVien;

        }
        public void xoaNhaSach(int index)
        {
            nhasachList.Remove(nhasachList[index]);

        }

        public int soLuongNhaSach()
        {
            return nhasachList.Count;
        }

        public void xoaTatCa()
        {
            NhaSachList.Clear();
        }
        public List<NhaSachDTO> timTuKhoa(string tuKhoa)
        {
            List<NhaSachDTO> listKQ = new List<NhaSachDTO>();
            foreach (NhaSachDTO ns in nhasachList)
            {
                if (ns.MaNhaSach.ToString().ToUpper() == tuKhoa.ToUpper())
                {
                    listKQ.Add(ns);
                    continue;
                }
            }
            return listKQ.ToList();
        }

        public List<NhaSachDTO> sort(bool isUp, string thuocTinh)
        {
            List<NhaSachDTO> listKQ = nhasachList;
            if (isUp == true)
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    listKQ.Sort( delegate (NhaSachDTO ns1, NhaSachDTO ns2)
                        {
                            return ns1.MaNhaSach.CompareTo(ns2.MaNhaSach);
                        }
                        );
                }
                           
            }
            else
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    listKQ.Sort( delegate (NhaSachDTO ns1, NhaSachDTO ns2)
                        {
                            return -(ns1.MaNhaSach.CompareTo(ns2.MaNhaSach));
                        }
                        );
                }
            }
            return listKQ.ToList();
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

    

