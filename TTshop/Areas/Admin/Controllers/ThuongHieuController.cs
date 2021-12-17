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
    public class ThuongHieuController : Controller
    {
        QuanLyDongHoEntities db = new QuanLyDongHoEntities();
        // GET: Admin/ThuongHieu
        public ActionResult Index()
        {
            return View(db.THUONGHIEUx.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATH,TENTH")] THUONGHIEU tHUONGHIEU )
        {
            if(ModelState.IsValid)
            {
                db.THUONGHIEUx.Add(tHUONGHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHUONGHIEU);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATH,TENTH")] THUONGHIEU tHUONGHIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHUONGHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHUONGHIEU);
        }

        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            if (tHUONGHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHUONGHIEU);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THUONGHIEU tHUONGHIEU = db.THUONGHIEUx.Find(id);
            db.THUONGHIEUx.Remove(tHUONGHIEU);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}