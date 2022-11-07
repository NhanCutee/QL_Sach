using QL_Sach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class NodeBangBam
    {
        private SachDTO sachDTO;
        private NodeBangBam next;
        private NodeBangBam prev;
        public NodeBangBam()
        {
            this.next = null;
            this.prev = null;
        }

        public NodeBangBam(NodeBangBam anotherNode)
        {
            this.sachDTO = anotherNode.sachDTO;
            this.next = anotherNode.next;
            this.prev = anotherNode.prev;

        }
        public NodeBangBam(SachDTO enter_SachDTO)
        {
            sachDTO = new SachDTO(enter_SachDTO);
            next = null;
            prev = null;
        }
        public NodeBangBam(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            sachDTO = new SachDTO(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
            next = null;
            prev = null;
        }
        ~NodeBangBam() { }

        public SachDTO SachDTO { get => sachDTO; set => sachDTO = value; }
        public NodeBangBam Next { get => next; set => next = value; }
        public NodeBangBam Prev { get => prev; set => prev = value; }
    }
    class SachBUS_BangBam
    {
        private int HASHSIZE=100;
        private NodeBangBam[] bangBam;

        public SachBUS_BangBam()
        {
            this.bangBam =new NodeBangBam[HASHSIZE];
            for (int i = 0; i < HASHSIZE; i++)
                bangBam[i] = new NodeBangBam();                
        }

        private void themNode(NodeBangBam keyNode,NodeBangBam node)
        {
            NodeBangBam nodeTemp = keyNode;
            while (nodeTemp != null)
                nodeTemp = nodeTemp.Next;
            nodeTemp.Next = node;
        }
        public void themSach(SachDTO sach)
        {
            int i = 0;
            while(i<HASHSIZE)
            {
                if(bangBam[i].SachDTO.MaSach==sach.MaSach)
                {
                    themNode(bangBam[i], new NodeBangBam(sach));
                    break;
                }
                else if(bangBam[i]==null)
                {
                    bangBam[i] = new NodeBangBam(sach);
                    break;
                }
                i++;
            }
        }
        public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
        {
            SachDTO sach = new SachDTO(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
            int i = 0;
            while (i < HASHSIZE)
            {
                if (bangBam[i].SachDTO.MaSach == sach.MaSach)
                {
                    themNode(bangBam[i], new NodeBangBam(sach));
                    break;
                }
                else if (bangBam[i] == null)
                {
                    bangBam[i] = new NodeBangBam(sach);
                    break;
                }
                i++;
            }
        }



    }
}
