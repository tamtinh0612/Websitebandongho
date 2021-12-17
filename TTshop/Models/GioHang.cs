using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTshop.Models;

namespace TTshop.Models
{
    public class GioHang
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        public int iMASP { get; set; }
        public string sTENSP { get; set; }
        public string sANHBIA { get; set; }
        public double dDONGIA { get; set; }
        public int iSOLUONG { get; set; }
        public double ThanhTien
        {
            get { return iSOLUONG * dDONGIA; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MASP)
        {
            iMASP = MASP;
            SANPHAM sp = db.SANPHAMs.Single(n => n.MASP == iMASP);
            sTENSP = sp.TENSP;
            sANHBIA = sp.ANHBIA;
            dDONGIA = double.Parse(sp.GIATIEN.ToString());
            iSOLUONG = 1;
        }

    }
}