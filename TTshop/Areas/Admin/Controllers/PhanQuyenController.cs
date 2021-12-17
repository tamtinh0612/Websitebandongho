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
    public class PhanQuyenController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: Admin/PhanQuyen
        public ActionResult Index()
        {
            return View(db.PHANQUYENs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDQUYEN,TENQUYEN")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.PHANQUYENs.Add(pHANQUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHANQUYEN);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDQUYEN,TENQUYEN")] PHANQUYEN pHANQUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHANQUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHANQUYEN);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            if (pHANQUYEN == null)
            {
                return HttpNotFound();
            }
            return View(pHANQUYEN);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHANQUYEN pHANQUYEN = db.PHANQUYENs.Find(id);
            db.PHANQUYENs.Remove(pHANQUYEN);
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
