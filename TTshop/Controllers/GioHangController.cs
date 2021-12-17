using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTshop.Models;

namespace TTshop.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: GioHang

 
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iMASP, string strURL)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == iMASP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sanpham = lstGioHang.Find(n => n.iMASP == iMASP);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMASP);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSOLUONG++;
                return Redirect(strURL);
            }
        }
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == iMaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMASP == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSOLUONG = int.Parse(f["txtSOLUONG"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {

            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == iMaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMASP == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMASP == iMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "TTShop");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "TTShop");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSOLUONG);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "TTShop");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }

        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "TTShop");
            }
            //Thêm đơn hàng
            DONHANG ddh = new DONHANG();
            NGUOIDUNG kh = (NGUOIDUNG)Session["use"];
            List<GioHang> gh = LayGioHang();
            ddh.MAND = kh.MAND;
            ddh.NGAYDAT = DateTime.Now;
            db.DONHANGs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                CHITIETDONHANG ctDH = new CHITIETDONHANG();
                ctDH.MADON = ddh.MADON;
                ctDH.MASP = item.iMASP;
                ctDH.SOLUONG = item.iSOLUONG;
                ctDH.DONGIA = (decimal)item.dDONGIA;
                db.CHITIETDONHANGs.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        
        public ActionResult XacNhanDonHang()
        {
            return View();
        }

    }
}