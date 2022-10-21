using QL_Sach.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sach.BUS
{
    class SachBUS
    {
        private List<SachDTO> sachList;

        internal List<SachDTO> SachList { get => sachList; set => sachList = value; }

        public SachBUS()
        {
            this.sachList = new List<SachDTO>();
        }

        public void themSach()
        {
            SachDTO sach = new SachDTO();
            this.sachList.Add(sach);
        }
        public void xoaSach(int index)
        {
            sachList.Remove(sachList[index]);

        }

        public int soLuongSach()
        {
            return sachList.Count;
        }
        public SachDTO layRaSachThu(int n)
        {
            return sachList[n];
        }
    }
}
