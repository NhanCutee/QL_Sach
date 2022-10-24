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

            public LinkedListNode(SachDTO enter_SachDTO)
            {
                sachDTO = new SachDTO(enter_SachDTO);
                next = null;
            }
            public LinkedListNode(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                sachDTO = new SachDTO(enter_maSach,enter_tenSach,enter_theLoai,enter_tenTacGia,enter_nhaXuatBan,enter_ngayXuatBan,enter_ghiChu,enter_gia);
                next = null;
            }

            public SachDTO SachDTO { get => sachDTO; set => sachDTO = value; }
            public LinkedListNode Next { get => next; set => next = value; }
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
            }
            public void themDauBangSachDTO(SachDTO enter_sachDTO)
            {
                LinkedListNode node = new LinkedListNode(enter_sachDTO);
                node.Next = firstNode;
            }

        }
    }
}
