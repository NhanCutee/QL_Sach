using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
    class SachBUS_LinkedList
    {
       class LinkedListNode
        {
            private SachDTO sachDTO;
            private LinkedListNode next;
            private LinkedListNode prev;
            public LinkedListNode()
            {
                this.sachDTO = new SachDTO();
                this.next = null;
                this.prev = null;

            }

            public LinkedListNode(LinkedListNode anotherNode)
            {
                this.sachDTO = anotherNode.sachDTO;
                this.next = anotherNode.next;
                this.prev = anotherNode.prev;

            }
            public LinkedListNode(SachDTO enter_SachDTO)
            {
                sachDTO = new SachDTO(enter_SachDTO);
                next = null;
                prev = null;
            }
            public LinkedListNode(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                sachDTO = new SachDTO(enter_maSach,enter_tenSach,enter_theLoai,enter_tenTacGia,enter_nhaXuatBan,enter_ngayXuatBan,enter_ghiChu,enter_gia);
                next = null;
                prev = null;
            }
            ~LinkedListNode() { }

            public SachDTO SachDTO { get => sachDTO; set => sachDTO = value; }
            public LinkedListNode Next { get => next; set => next = value; }
            public LinkedListNode Prev { get => prev; set => prev = value; }
        }
        class LinkedList
        {
            private int count;
            private LinkedListNode firstNode;
            //private LinkedListNode lastNode;

            public LinkedList()
            {
                count =0;
                firstNode=null;
                //lastNode = null;
            }
            public void themDauBangSachDTO(SachDTO enter_sachDTO)
            {
                LinkedListNode node = new LinkedListNode(enter_sachDTO);
                node.Next = firstNode;
                node.Prev = null;
                firstNode.Prev=node;
                firstNode = node;
                count++;
            }
            public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                LinkedListNode node = new LinkedListNode(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                node.Next = firstNode;
                node.Prev = null;
                firstNode.Prev = node;
                firstNode = node;
                count++;
            }
            //check

            public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                LinkedListNode node = this.firstNode;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                node.SachDTO.MaSach = enter_maSach;
                node.SachDTO.TenSach =enter_tenSach;
                node.SachDTO.TheLoai = enter_theLoai;
                node.SachDTO.TenTacGia = enter_tenTacGia;
                node.SachDTO.NhaXuatBan = enter_nhaXuatBan;
                node.SachDTO.NgayXuatBan = enter_ngayXuatBan;
                node.SachDTO.Gia = enter_gia;
                node.SachDTO.GhiChu = enter_ghiChu;
            }
            //check
            public void suaSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                LinkedListNode node = this.firstNode;
                while(node!=null)
                {
                    if (node.SachDTO.MaSach == enter_maSach)
                        break;
                    node = node.Next;
                }
                node.SachDTO.TenSach = enter_tenSach;
                node.SachDTO.TheLoai = enter_theLoai;
                node.SachDTO.TenTacGia = enter_tenTacGia;
                node.SachDTO.NhaXuatBan = enter_nhaXuatBan;
                node.SachDTO.NgayXuatBan = enter_ngayXuatBan;
                node.SachDTO.Gia = enter_gia;
                node.SachDTO.GhiChu = enter_ghiChu;
            }
            //check
            public void xoaSach(int index)
            {
                LinkedListNode node = this.firstNode;
                LinkedListNode nodeTemp = new LinkedListNode();
                for (int i = 0; i < index-1; i++)
                    node = node.Next;
                nodeTemp = node.Next;
                node.Next = node.Next.Next;
                nodeTemp = null;          
            }
            public void xoaSach(string enter_maSach)
            {
                LinkedListNode node = this.firstNode;
                LinkedListNode nodeTemp;
                while (node != null)
                {
                    if (node.SachDTO.MaSach == enter_maSach)
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

            public int soLuongSach()
            {
                return count;
            }

            public void xoaTatCa()
            {
                LinkedListNode node = this.firstNode;
                LinkedListNode nodeTemp;
                while (node!=null)
                {
                    nodeTemp = node;
                    node = node.Next;
                    nodeTemp = null;
                }
            }

        }
    }
}
