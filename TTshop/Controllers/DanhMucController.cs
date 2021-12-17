using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTshop.Models;

namespace TTshop.Controllers
{
    public class DanhMucController : Controller
    {
        QuanLyDongHoEntities data = new QuanLyDongHoEntities();
        // GET: DanhMuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhmucPartial()
        {
            var danhmuc = data.HANGSANXUATs.ToList();
            return PartialView(danhmuc);
        }
    }
}