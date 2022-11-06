using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_Sach.DTO;

namespace QL_Sach.BUS
{
       class nodeLienKet
        {
            private SachDTO sachDTO;
            private nodeLienKet next;
            private nodeLienKet prev;
            public nodeLienKet()
            {
                this.next = null;
                this.prev = null;
            }

            public nodeLienKet(nodeLienKet anotherNode)
            {
                this.sachDTO = anotherNode.sachDTO;
                this.next = anotherNode.next;
                this.prev = anotherNode.prev;

            }
            public nodeLienKet(SachDTO enter_SachDTO)
            {
                sachDTO = new SachDTO(enter_SachDTO);
                next = null;
                prev = null;
            }
            public nodeLienKet(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                sachDTO = new SachDTO(enter_maSach,enter_tenSach,enter_theLoai,enter_tenTacGia,enter_nhaXuatBan,enter_ngayXuatBan,enter_ghiChu,enter_gia);
                next = null;
                prev = null;
            }
            ~nodeLienKet() { }

            public SachDTO SachDTO { get => sachDTO; set => sachDTO = value; }
            public nodeLienKet Next { get => next; set => next = value; }
            public nodeLienKet Prev { get => prev; set => prev = value; }
        }
        class SachBUS_DSLienKet
        {
            private int count;
            private nodeLienKet firstNode;

            public List<SachDTO> SachList 
        {
            get 
            {
                List<SachDTO> sachList = new List<SachDTO>();
                for (nodeLienKet node = firstNode; node.Next != null; node = node.Next)
                    sachList.Add(node.SachDTO);
                return sachList;
            }
        }

            public SachBUS_DSLienKet()
            {
                count =0;
                firstNode=new nodeLienKet();
            }
        public void themSach(SachDTO sach)
        {
            nodeLienKet node = new nodeLienKet(sach);
            node.Next = firstNode;
            firstNode.Prev = node;
            firstNode = node;
            count++;
        }

        public void themSach(string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                nodeLienKet node = new nodeLienKet(enter_maSach, enter_tenSach, enter_theLoai, enter_tenTacGia, enter_nhaXuatBan, enter_ngayXuatBan, enter_ghiChu, enter_gia);
                node.Next = firstNode;
                firstNode.Prev = node;
                firstNode = node;
                count++;
            }

            public void suaSach(int index, string enter_maSach, string enter_tenSach, string enter_theLoai, string enter_tenTacGia, string enter_nhaXuatBan, DateTime enter_ngayXuatBan, string enter_ghiChu, int enter_gia)
            {
                nodeLienKet node = this.firstNode;
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
                nodeLienKet node = this.firstNode;
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
                nodeLienKet node = this.firstNode;
                nodeLienKet nodeTemp = new nodeLienKet();
                for (int i = 0; i < index-1; i++)
                    node = node.Next;
                nodeTemp = node.Next;
                node.Next = node.Next.Next;
                nodeTemp = null;          
            }
            public void xoaSach(string enter_maSach)
            {
                nodeLienKet node = this.firstNode;
                nodeLienKet nodeTemp;
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

            public void xoaTatCa()
            {
                nodeLienKet node = this.firstNode;
                nodeLienKet nodeTemp;
                while (node!=null)
                {
                    nodeTemp = node;
                    node = node.Next;
                    nodeTemp = null;
                }
            }

        public int soLuongSach()
        {
            return count;
        }


    }
}

