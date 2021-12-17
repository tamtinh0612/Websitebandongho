using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTshop.Models;

namespace TTshop.Controllers
{
    public class SANPHAMController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: SANPHAM
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CASIOPARTIAL()
        {
            var cs = db.SANPHAMs.Where(n=>n.MAHANG==1).Take(5).ToList();
            return PartialView(cs);
        }
        public ActionResult DONGHOTISSOTPARTIAL()
        {
            var ts = db.SANPHAMs.Where(n => n.MAHANG == 4).Take(5).ToList();
            return PartialView(ts);
        }
        public ActionResult GSHOCKPARTIAL()
        {
            var gs = db.SANPHAMs.Where(n => n.MAHANG == 5).Take(5).ToList();
            return PartialView(gs);
        }
        public ActionResult TREOTUONGPARTIAL()
        {
            var gs = db.SANPHAMs.Where(n => n.MAHANG == 6).Take(12).ToList();
            return PartialView(gs);
        }
        public ActionResult PHUKIENPARTIAL()
        {
            var pk = db.SANPHAMs.Where(n => n.MAHANG == 7).Take(16).ToList();
            return PartialView(pk);
        }
        public ActionResult ChiTietSanPham(int MASP = 0) 
        {
            var ct = db.SANPHAMs.SingleOrDefault(n => n.MASP == MASP);
                if( ct == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ct);
        }
    }
}