using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTshop.Models;

namespace TTshop.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: Admin/NguoiDung
        public ActionResult Index()
        {
            var nguoidung = db.NGUOIDUNGs.Include(n => n.PHANQUYEN);
            return View(nguoidung.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        [HttpGet]
       public ActionResult Create()
        {
            ViewBag.IDQuyen = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN");
            return View();
        }

        // POST: Admin/Nguoidungs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAND,HOTEN,EMAIL,DIENTHOAI,MATKHAU,IDQUYEN,DIACHI")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.NGUOIDUNGs.Add(nGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDQuyen = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN", nGUOIDUNG.IDQUYEN);
            return View(nGUOIDUNG);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN", nGUOIDUNG.IDQUYEN);
            return View(nGUOIDUNG);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAND,HOTEN,EMAIL,DIENTHOAI,MATKHAU,IDQUYEN,DIACHI")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDQuyen = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN", nGUOIDUNG.IDQUYEN);
            return View(nGUOIDUNG);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nGUOIDUNG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
