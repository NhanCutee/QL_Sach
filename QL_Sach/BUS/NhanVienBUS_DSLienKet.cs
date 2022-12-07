﻿using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            m_firstNode = null;
            m_n = 0;
        }

        public NhanVienBUS_DSLienKet(NodeNhanVien firstNode, int n)
        {
            m_firstNode = firstNode;
            m_n = n;
        }

        public NodeNhanVien FirstNode { get => m_firstNode; set => m_firstNode = value; }
        public int N { get => m_n; set => m_n = value; }

        public void themNVRong()
        {
            this.m_firstNode = new NodeNhanVien();
            this.m_n++;

        }

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
                node.Next = m_firstNode;
                m_firstNode = node;
                m_n++;
                return true;
            }
            return false;
        }


        public bool xoaNV(string ma)
        {
            NodeNhanVien node = this.timNV(ma);
            if (node != null)
            {
               NodeNhanVien nodeTemp;
                if (node.Prev != null)
                    nodeTemp = node;
                node = node.Next;
                m_n--;
                return true;
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
            NodeNhanVien node = m_firstNode;
            NodeNhanVien nodeTemp;
            while (node != null)
            {
                nodeTemp = node;
                node = node.Next;
                nodeTemp = null;
            }
        }

    }
}