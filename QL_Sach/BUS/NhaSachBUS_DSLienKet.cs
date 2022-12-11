﻿using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class nodeLienKet2
    {
        private NhaSachDTO nhasachDTO;
        private nodeLienKet2 next;
        private nodeLienKet2 prev;

        public nodeLienKet2()
        {
            this.nhasachDTO= new NhaSachDTO();
            this.next = null;
            this.prev = null;
        }

        public nodeLienKet2(nodeLienKet2 anotherNode)
        {
            this.nhasachDTO = anotherNode.nhasachDTO;
            this.next = anotherNode.next;
            this.prev = anotherNode.prev;

        }
        public nodeLienKet2(NhaSachDTO enter_NhaSachDTO)
        {
            nhasachDTO = new NhaSachDTO(enter_NhaSachDTO);
            next = null;
            prev = null;
        }
        public nodeLienKet2(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nhasachDTO = new NhaSachDTO(enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
            next = null;
            prev = null;
        }
        ~nodeLienKet2() { }

        public NhaSachDTO NhaSachDTO { get => nhasachDTO; set => nhasachDTO = value; }
        public nodeLienKet2 Next { get => next; set => next = value; }
        public nodeLienKet2 Prev { get => prev; set => prev = value; }
    }
    class NhaSachBUS_DSLienKet
    {
        private int count;
        private nodeLienKet2 firstNode;

        public List<NhaSachDTO> NhaSachList
        {
            get
            {
                List<NhaSachDTO> nhasachList = new List<NhaSachDTO>();
                for (nodeLienKet2 node = firstNode; node.Next != null; node = node.Next)
                    nhasachList.Add(node.NhaSachDTO);
                return nhasachList;
            }
        }

        public NhaSachBUS_DSLienKet()
        {
            count = 0;
            firstNode = new nodeLienKet2();
        }
        public void themNhaSach(NhaSachDTO ns)
        {
            nodeLienKet2 node = new nodeLienKet2(ns);
            node.Next = firstNode;
            firstNode.Prev = node;
            firstNode = node;
            count++;
        }

        public void themNhaSach(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nodeLienKet2 node = new nodeLienKet2(enter_maNhaSach, enter_tenNhaSach, enter_diaChi, enter_tenQuanLi, enter_soLuongNhanVien);
            node.Next = firstNode;
            firstNode.Prev = node;
            firstNode = node;
            count++;
        }

        public void suaNhaSach(int index, string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nodeLienKet2 node = this.firstNode;
            for (int i = 0; i < index; i++)
                node = node.Next;
            node.NhaSachDTO.MaNhaSach = enter_maNhaSach;
            node.NhaSachDTO.TenNhaSach = enter_tenNhaSach;
            node.NhaSachDTO.DiaChi = enter_diaChi;
            node.NhaSachDTO.TenQuanLi = enter_tenQuanLi;
            node.NhaSachDTO.SoLuongNhanVien = enter_soLuongNhanVien;


        }
        //check
        public void suaNhaSach(string enter_maNhaSach, string enter_tenNhaSach, string enter_diaChi, string enter_tenQuanLi, int enter_soLuongNhanVien)
        {
            nodeLienKet2 node = this.firstNode;
            while (node != null)
            {
                if (node.NhaSachDTO.MaNhaSach == enter_maNhaSach)
                    break;
                node = node.Next;
            }
            node.NhaSachDTO.TenNhaSach = enter_tenNhaSach;
            node.NhaSachDTO.DiaChi = enter_diaChi;
            node.NhaSachDTO.TenQuanLi = enter_tenQuanLi;
            node.NhaSachDTO.SoLuongNhanVien = enter_soLuongNhanVien;

        }
        //check
        public void xoaNhaSach(int index)
        {
            nodeLienKet2 node = this.firstNode;
            nodeLienKet2 nodeTemp = new nodeLienKet2();
            for (int i = 0; i < index - 1; i++)
                node = node.Next;
            nodeTemp = node.Next;
            node.Next = node.Next.Next;
            nodeTemp = null;
        }
        public void xoaNhaSach(string enter_maNhaSach)
        {
            nodeLienKet2 node = this.firstNode;
            nodeLienKet2 nodeTemp;
            while (node != null)
            {
                if (node.NhaSachDTO.MaNhaSach == enter_maNhaSach)
                {
                    nodeTemp = node;
                    node = node.Prev;
                    node.Next = nodeTemp.Next;
                    nodeTemp = null;
                    break;
                }
                node = node.Next;
            }
        }

        public void xoaTatCa()
        {
            nodeLienKet2 node = this.firstNode;
            nodeLienKet2 nodeTemp;
            while (node != null)
            {
                nodeTemp = node;
                node = node.Next;
                nodeTemp = null;
            }
        }

        public int soLuongNhaSach()
        {
            return count;
        }
        public List<NhaSachDTO> timTuKhoa(string tuKhoa)
        {
            List<NhaSachDTO> listKQ = new List<NhaSachDTO>();
            nodeLienKet2 node = this.firstNode;
            while (node != null)
            {
                if (node.Next == null)
                    return listKQ.ToList();
                if (node.NhaSachDTO.MaNhaSach.ToString().ToUpper() == tuKhoa.ToUpper())
                    listKQ.Add(node.NhaSachDTO);

            }
            return listKQ.ToList();
        }



        public List<NhaSachDTO> sort(bool isUp, string thuocTinh)
        {
            NhaSachBUS_DSLienKet listKQ = new NhaSachBUS_DSLienKet();
            for (nodeLienKet2 node1 = this.firstNode; node1 != null; node1 = node1.Next) // clone 1 danh sach de sap xep ko anh huong den danh sach cu
                listKQ.themNhaSach(node1.NhaSachDTO);
            if (isUp == true)
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (nodeLienKet2 node1 = listKQ.firstNode; node1 != null; node1 = node1.Next)
                    {
                        for (nodeLienKet2 node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhaSachDTO.MaNhaSach.CompareTo(node2.NhaSachDTO.MaNhaSach) >= 1)
                            {
                                NhaSachDTO nv =node1.NhaSachDTO;
                                node1.NhaSachDTO =node2.NhaSachDTO;
                                node2.NhaSachDTO = nv;
                            }
                        }
                    }
                }                 
            }
            else
            {
                if (thuocTinh.ToUpper() == "MA")
                {
                    for (nodeLienKet2 node1 = listKQ.firstNode; node1 != null; node1 = node1.Next)
                    {
                        for (nodeLienKet2 node2 = node1.Next; node2 != null; node2 = node2.Next)
                        {
                            if (node1.NhaSachDTO.MaNhaSach.CompareTo(node2.NhaSachDTO.MaNhaSach) < 1)
                            {
                                NhaSachDTO nv = node1.NhaSachDTO;
                                node1.NhaSachDTO = node2.NhaSachDTO;
                                node2.NhaSachDTO = nv;
                            }
                        }
                    }
                }               
            }

            List<NhaSachDTO> list = new List<NhaSachDTO>();
            for (nodeLienKet2 node1 = listKQ.firstNode; node1 != null; node1 = node1.Next) 
                if(node1.NhaSachDTO.MaNhaSach!="")
                    list.Add(node1.NhaSachDTO);
            return list.ToList();
        }
    }
    }



