using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QL_Sach.BUS
{
    class NodeNhanVien
    {
        private NhanVienDTO nhanVien;
        private NodeNhanVien next;
        private NodeNhanVien prev;
        public NodeNhanVien()
        {
            this.nhanVien = new NhanVienDTO();
            this.next = null;
            this.prev = null;
        }

        public NodeNhanVien(NodeNhanVien anotherNode)
        {
            this.nhanVien =new NhanVienDTO(anotherNode.nhanVien);
            this.next = anotherNode.next;
            this.prev = anotherNode.prev;
        }
        public NodeNhanVien(NhanVienDTO nv)
        {
            nhanVien = new NhanVienDTO(nv);
            next = null;
            prev = null;
        }

        ~NodeNhanVien() { }

        public NhanVienDTO NhanVien { get => nhanVien; set => nhanVien = value; }
        public NodeNhanVien Next { get => next; set => next = value; }
        public NodeNhanVien Prev { get => prev; set => prev = value; }
    }
    class NhanVienBUS_DSLienKet
    {
        private NodeNhanVien m_firstNode;
        private int m_n;

        public List<NhanVienDTO> NhanVienList
        {
            get
            {
                List<NhanVienDTO> nvList = new List<NhanVienDTO>();
                NodeNhanVien node = this.m_firstNode;
                while(node!=null)
                {
                   // if (node.Next == null)
                     //   break;
                    nvList.Add(node.NhanVien);
                    node = node.Next;
                }
                return nvList;
            }
            set
            {
                this.xoaTatCa();
                List<NhanVienDTO> nvList =value;
                foreach(NhanVienDTO nv in nvList)
                {
                    this.themNV(nv);
                }
            }
        }

        public NhanVienBUS_DSLienKet()
        {
            m_firstNode = new NodeNhanVien();
            m_n = 0;
        }

        public NhanVienBUS_DSLienKet(NodeNhanVien firstNode, int n)
        {
            m_firstNode = firstNode;
            m_n = n;
        }

        public NodeNhanVien FirstNode { get => m_firstNode; set => m_firstNode = value; }
        public int N { get => m_n; set => m_n = value; }

        public NodeNhanVien timNV(string ma)
        {
            NodeNhanVien node = m_firstNode;
          while(node !=null)
            {
                if (node.NhanVien.MaNV == ma)
                    return node;
                node = node.Next;
            }
            return null;
        }

        public bool themNV(NhanVienDTO nhanVien)
        {
            if (this.timNV(nhanVien.MaNV) == null)
            {
                NodeNhanVien node = new NodeNhanVien(nhanVien);
                m_firstNode.Prev = node;
                node.Next = m_firstNode;
                m_firstNode = node;
                m_n++;
                return true;
            }
            return false;
        }


        public bool xoaNV(string ma)
        {

            NodeNhanVien node = this.FirstNode;
            if (node.Prev == null && node.NhanVien.MaNV == ma)
            {
                m_firstNode = m_firstNode.Next;
                m_firstNode.Prev = null;
                m_n--;
                return true;
            }
            else
            {
                while (node.Next !=null)
                {
                    if (node.Next.NhanVien.MaNV == ma)
                    {
                        node.Next=node.Next.Next;
                        m_n--;
                        return true;
                    }
                    node = node.Next;
                }
            }
            return false;
        }

        public bool suaNV(NhanVienDTO nv)
        {
            NodeNhanVien node = this.timNV(nv.MaNV);
            if (node != null)
            {
                node.NhanVien = new NhanVienDTO(nv);
                return true;
            }
            return false;
        }

        public int soLuongNV()
        {
            return this.m_n;

        }

        public void xoaTatCa()
        {
            NodeNhanVien nodeTemp;
            while (m_firstNode != null)
            {
                nodeTemp = m_firstNode;
                m_firstNode = m_firstNode.Next;
                nodeTemp = null;
            }
            //khoi tao lai danh sach tranh loi
            m_firstNode = new NodeNhanVien();
            m_n = 0;
        }

        public List<NhanVienDTO> timTuKhoa(string tuKhoa)
        {
            List<NhanVienDTO> listKQ = new List<NhanVienDTO>();
            NodeNhanVien node =this.m_firstNode;
            while(node !=null )
            {
                if (node.Next == null)
                    return listKQ.ToList();
                if (node.NhanVien.MaNV.ToString().ToUpper() == tuKhoa.ToUpper())
                    listKQ.Add(node.NhanVien);
                else if (node.NhanVien.TenNV.ToString().ToUpper() == tuKhoa.ToUpper())
                    listKQ.Add(node.NhanVien);
                else if (tuKhoa.ToUpper() == "GT:NAM" && node.NhanVien.GioiTinh == true)
                    listKQ.Add(node.NhanVien);
                else if (tuKhoa.ToUpper() == "GT:NỮ" && node.NhanVien.GioiTinh == false)
                    listKQ.Add(node.NhanVien);
                else if (node.NhanVien.NgaySinh.ToString() == tuKhoa)
                    listKQ.Add(node.NhanVien);
                else if (node.NhanVien.DiaChi.ToString().ToUpper() == tuKhoa.ToUpper())
                    listKQ.Add(node.NhanVien);
                else if (node.NhanVien.NhaSachLamViec.ToString().ToUpper() == tuKhoa.ToUpper())
                    listKQ.Add(node.NhanVien);
                else if ("CV:" + node.NhanVien.ChucVu.ToString().ToUpper() == tuKhoa.ToUpper())
                    listKQ.Add(node.NhanVien);
                node = node.Next;
            }
            return listKQ.ToList();
        }



        public List<NhanVienDTO> sort(bool isUp, string thuocTinh)
        {
            NhanVienBUS_DSLienKet listKQ = new NhanVienBUS_DSLienKet();
            for (NodeNhanVien node1 = this.m_firstNode; node1 != null; node1 = node1.Next) // clone 1 danh sach de sap xep ko anh huong den danh sach cu
                listKQ.themNV(node1.NhanVien);

            if (isUp == true)
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1=node1.Next )
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.MaNV.CompareTo(node2.NhanVien.MaNV) >=1) 
                            {
                                NhanVienDTO nv = new NhanVienDTO(node1.NhanVien);
                                node1.NhanVien =new NhanVienDTO(node2.NhanVien);
                                node2.NhanVien = new NhanVienDTO(nv);
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "TEN")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.TenNV.CompareTo(node2.NhanVien.TenNV) >= 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "DC")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.DiaChi.CompareTo(node2.NhanVien.DiaChi) >= 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "GT")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.GioiTinh==true)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "NS")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.NgaySinh.CompareTo(node2.NhanVien.NgaySinh) >= 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "NOILV")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.NhaSachLamViec.CompareTo(node2.NhanVien.NhaSachLamViec) >= 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "CV")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.ChucVu.CompareTo(node2.NhanVien.ChucVu) >= 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
            }

            else
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.MaNV.CompareTo(node2.NhanVien.MaNV) < 1)
                            {
                                NhanVienDTO nv = new NhanVienDTO(node1.NhanVien);
                                node1.NhanVien = new NhanVienDTO(node2.NhanVien);
                                node2.NhanVien = new NhanVienDTO(nv);
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "TEN")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.TenNV.CompareTo(node2.NhanVien.TenNV)  <1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "DC")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.DiaChi.CompareTo(node2.NhanVien.DiaChi) < 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "GT")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.GioiTinh == false)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "NS")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.NgaySinh.CompareTo(node2.NhanVien.NgaySinh) < 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "NOILV")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.NhaSachLamViec.CompareTo(node2.NhanVien.NhaSachLamViec) < 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
                else if (thuocTinh.ToUpper() == "CV")
                {
                    for (NodeNhanVien node1 = listKQ.FirstNode; node1 != null; node1 = node1.Next)
                    {
                        for (NodeNhanVien node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhanVien.ChucVu.CompareTo(node2.NhanVien.ChucVu) < 1)
                            {
                                NhanVienDTO nv = node1.NhanVien;
                                node1.NhanVien = node2.NhanVien;
                                node2.NhanVien = nv;
                            }
                        }
                    }
                }
            }

            List<NhanVienDTO> list = new List<NhanVienDTO>();
            NodeNhanVien node = listKQ.FirstNode;
            while(node !=null)
            {
                if(node.NhanVien.MaNV!="")
                    list.Add(node.NhanVien);
                node = node.Next;
            }

            return list.ToList();
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

            for(NodeNhanVien node1= this.FirstNode;node1!=null && node1.NhanVien.MaNV!="";node1=node1.Next)
            {
                if (node1.NhanVien.MaNV.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_MaNV.Add(node1.NhanVien);
                    continue;
                }
                else if (node1.NhanVien.ChucVu.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_ChucVu.Add(node1.NhanVien);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NAM" && node1.NhanVien.GioiTinh == true)
                {
                    dsKetQua_GioiTinh.Add(node1.NhanVien);
                    continue;
                }
                else if (tuKhoa.ToUpper() == "NỮ" && node1.NhanVien.GioiTinh == false)
                {
                    dsKetQua_GioiTinh.Add(node1.NhanVien);
                    continue;
                }
                else if (node1.NhanVien.TenNV.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_TenNV.Add(node1.NhanVien);
                    continue;
                }
                else if (node1.NhanVien.NgaySinh.ToShortDateString().Contains(tuKhoa))
                {
                    dsKetQua_NgaySinh.Add(node1.NhanVien);
                    continue;
                }
                else if (node1.NhanVien.NhaSachLamViec.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_NhaSachLamViec.Add(node1.NhanVien);
                    continue;
                }
                else if (node1.NhanVien.DiaChi.ToUpper().Contains(tuKhoa.ToUpper()))
                {
                    dsKetQua_DiaChi.Add(node1.NhanVien);
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
