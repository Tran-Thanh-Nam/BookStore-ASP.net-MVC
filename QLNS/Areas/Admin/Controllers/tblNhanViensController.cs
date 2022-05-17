using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Areas.Admin.Controllers
{
    public class tblNhanViensController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblNhanViens
        public ActionResult Index()
        {
            return View(db.tblNhanViens.ToList());
        }

        // GET: Admin/tblNhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNhanVien tblNhanVien = db.tblNhanViens.Find(id);
            if (tblNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tblNhanVien);
        }

        // GET: Admin/tblNhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblNhanViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_nv,ho_ten,ngay_sinh,sdt")] tblNhanVien tblNhanVien)
        {
            if (ModelState.IsValid)
            {
                db.tblNhanViens.Add(tblNhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblNhanVien);
        }

        // GET: Admin/tblNhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNhanVien tblNhanVien = db.tblNhanViens.Find(id);
            if (tblNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tblNhanVien);
        }

        // POST: Admin/tblNhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_nv,ho_ten,ngay_sinh,sdt")] tblNhanVien tblNhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblNhanVien);
        }

        // GET: Admin/tblNhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNhanVien tblNhanVien = db.tblNhanViens.Find(id);
            if (tblNhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tblNhanVien);
        }

        // POST: Admin/tblNhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblNhanVien tblNhanVien = db.tblNhanViens.Find(id);
            db.tblNhanViens.Remove(tblNhanVien);
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
