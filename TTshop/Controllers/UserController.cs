using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTshop.Models;

namespace TTshop.Controllers
{
    public class UserController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(NGUOIDUNG nGUOIDUNG)
        {
            try
            {
                db.NGUOIDUNGs.Add(nGUOIDUNG);

                db.SaveChanges();

                if (ModelState.IsValid)
                    {
                        return RedirectToAction("DangNhap");
                    }
                return View("DangKy");

            }
            catch
            {
                return View();
            }

        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection userlog)
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.NGUOIDUNGs.SingleOrDefault(x => x.EMAIL.Equals(userMail) && x.MATKHAU.Equals(password));

            if (islogin != null)
            {
                if (userMail == "Admin@gmail.com")
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Admin/Home");
                }
                else
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "TTShop");
                }
            }
            else
            {
                ViewBag.Fail = "Đăng nhập thất bại";
                return View("DangNhap");
            }

        }
        public ActionResult DangXuat()
        {
            Session["use"] = null;
            return RedirectToAction("Index", "TTSHOP");

        }
    }
}