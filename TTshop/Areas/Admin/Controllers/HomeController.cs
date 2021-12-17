using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTshop.Models;
using PagedList;
using PagedList.Mvc;


namespace TTshop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: Admin/Home
        public ActionResult Index(int ?page)
        {
            if (page == null) page = 1;
            var sp = db.SANPHAMs.OrderBy(x => x.MASP);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(sp.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Details(int id)
        {
            var dt = db.SANPHAMs.Find(id);
            return View(dt);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var hangselected = new SelectList(db.HANGSANXUATs, "MAHANG", "TENHANG");
            ViewBag.Mahang = hangselected;
            var hdhselected = new SelectList(db.THUONGHIEUx, "MATH", "TENTH");
            ViewBag.Mahdh = hdhselected;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SANPHAM sANPHAM)
        {
            try
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = db.SANPHAMs.Find(id);
            var hangselected = new SelectList(db.HANGSANXUATs, "MAHANG", "TENHANG", dt.MAHANG);
            ViewBag.MAHANG = hangselected;
            var hdhselected = new SelectList(db.THUONGHIEUx, "MATH", "TENTH", dt.MATH);
            ViewBag.MATH = hdhselected;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Edit(SANPHAM sANPHAM)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.SANPHAMs.Find(sANPHAM.MASP);
                oldItem.TENSP = sANPHAM.TENSP;
                oldItem.GIATIEN = sANPHAM.GIATIEN;
                oldItem.MOTA = sANPHAM.MOTA;
                oldItem.ANHBIA = sANPHAM.ANHBIA;
                oldItem.HANGSANXUAT = sANPHAM.HANGSANXUAT;
                oldItem.THUONGHIEU = sANPHAM.THUONGHIEU;
                oldItem.LOAIDAY = sANPHAM.LOAIDAY;
                oldItem.MAHANG = sANPHAM.MAHANG;
                oldItem.MATH = sANPHAM.MATH;
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
          
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var dt = db.SANPHAMs.Find(id);
            return View(dt);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dt = db.SANPHAMs.Find(id);
                db.SANPHAMs.Remove(dt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}