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
    public class HangSanXuatController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: Admin/HangSanXuat
        public ActionResult Index()
        {
            return View(db.HANGSANXUATs.ToList());
        }

    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGSANXUAT hANGSANXUAT = db.HANGSANXUATs.Find(id);
            if (hANGSANXUAT == null)
            {
                return HttpNotFound();
            }
            return View(hANGSANXUAT);
        }
        [HttpGet]
    public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHANG, TENHANG")] HANGSANXUAT hANGSANXUAT)
        {
            if (ModelState.IsValid)
            {
                db.HANGSANXUATs.Add(hANGSANXUAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hANGSANXUAT);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGSANXUAT hANGSANXUAT = db.HANGSANXUATs.Find(id);
            if (hANGSANXUAT == null)
            {
                return HttpNotFound();
            }
            return View(hANGSANXUAT);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHANG,TENHANG")] HANGSANXUAT hANGSANXUAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hANGSANXUAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hANGSANXUAT);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGSANXUAT hANGSANXUAT = db.HANGSANXUATs.Find(id);
            if (hANGSANXUAT == null)
            {
                return HttpNotFound();
            }
            return View(hANGSANXUAT);
        }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                HANGSANXUAT hANGSANXUAT = db.HANGSANXUATs.Find(id);
                db.HANGSANXUATs.Remove(hANGSANXUAT);
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