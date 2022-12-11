using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            set
            {
                this.xoaTatCa();
                List<SachDTO> sList = value;
                foreach (SachDTO s in sList)
                {
                    this.themSach(s);
                }
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

        public List<SachDTO> timKiem(string tuKhoa)
        {
            List<SachDTO> dsKetQua = new List<SachDTO>();
            List<SachDTO> dsKetQua_MaSach = new List<SachDTO>();
            List<SachDTO> dsKetQua_TenSach = new List<SachDTO>();
            List<SachDTO> dsKetQua_TheLoai = new List<SachDTO>();
            List<SachDTO> dsKetQua_TenTacGia = new List<SachDTO>();
            List<SachDTO> dsKetQua_NhaXuatBan = new List<SachDTO>();
            List<SachDTO> dsKetQua_NgayXuatBan = new List<SachDTO>();
            List<SachDTO> dsKetQua_Gia = new List<SachDTO>();
            List<SachDTO> dsKetQua_GhiChu = new List<SachDTO>();

            for(nodeLienKet node1=this.firstNode;node1!=null && node1.SachDTO.MaSach !="";node1=node1.Next)
            {
                if (node1.SachDTO.MaSach == tuKhoa.ToUpper())
                {
                    dsKetQua_MaSach.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.TenSach == tuKhoa)
                {
                    dsKetQua_TenSach.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.TheLoai == tuKhoa)
                {
                    dsKetQua_TheLoai.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.TenTacGia == tuKhoa)
                {
                    dsKetQua_TenTacGia.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.NhaXuatBan == tuKhoa)
                {
                    dsKetQua_NhaXuatBan.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.NgayXuatBan.ToShortDateString() == tuKhoa)
                {
                    dsKetQua_NgayXuatBan.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.Gia.ToString() == tuKhoa)
                {
                    dsKetQua_Gia.Add(node1.SachDTO);
                    continue;
                }
                else if (node1.SachDTO.GhiChu == tuKhoa)
                {
                    dsKetQua_GhiChu.Add(node1.SachDTO);
                    continue;
                }
            }

            dsKetQua = dsKetQua.Concat(dsKetQua_MaSach).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenSach).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TheLoai).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_TenTacGia).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NhaXuatBan).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_NgayXuatBan).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_Gia).ToList();
            dsKetQua = dsKetQua.Concat(dsKetQua_GhiChu).ToList();

            return dsKetQua;
        }

        public bool luuFile()
        {
            try
            {
                FileStream fs = new FileStream("SachData.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this.SachList);
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
                FileStream fs = new FileStream("SachData.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                this.SachList = (List<SachDTO>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}

