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
    public class tblPhieuXuatsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblPhieuXuats
        public ActionResult Index()
        {
            var tblPhieuXuats = db.tblPhieuXuats.Include(t => t.tblCTPhieuXuat).Include(t => t.tblKhachHang).Include(t => t.tblNhanVien);
            return View(tblPhieuXuats.ToList());
        }

        // GET: Admin/tblPhieuXuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuXuat tblPhieuXuat = db.tblPhieuXuats.Find(id);
            if (tblPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tblPhieuXuat);
        }

        // GET: Admin/tblPhieuXuats/Create
        public ActionResult Create()
        {
            ViewBag.ma_px = new SelectList(db.tblCTPhieuXuats, "ma_px", "ma_px");
            ViewBag.ma_kh = new SelectList(db.tblKhachHangs, "ma_kh", "ten_kh");
            ViewBag.ma_nv = new SelectList(db.tblNhanViens, "ma_nv", "ho_ten");
            return View();
        }

        // POST: Admin/tblPhieuXuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_px,ma_nv,ma_kh,ngay_xuat")] tblPhieuXuat tblPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.tblPhieuXuats.Add(tblPhieuXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_px = new SelectList(db.tblCTPhieuXuats, "ma_px", "ma_px", tblPhieuXuat.ma_px);
            ViewBag.ma_kh = new SelectList(db.tblKhachHangs, "ma_kh", "ten_kh", tblPhieuXuat.ma_kh);
            ViewBag.ma_nv = new SelectList(db.tblNhanViens, "ma_nv", "ho_ten", tblPhieuXuat.ma_nv);
            return View(tblPhieuXuat);
        }

        // GET: Admin/tblPhieuXuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuXuat tblPhieuXuat = db.tblPhieuXuats.Find(id);
            if (tblPhieuXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_px = new SelectList(db.tblCTPhieuXuats, "ma_px", "ma_px", tblPhieuXuat.ma_px);
            ViewBag.ma_kh = new SelectList(db.tblKhachHangs, "ma_kh", "ten_kh", tblPhieuXuat.ma_kh);
            ViewBag.ma_nv = new SelectList(db.tblNhanViens, "ma_nv", "ho_ten", tblPhieuXuat.ma_nv);
            return View(tblPhieuXuat);
        }

        // POST: Admin/tblPhieuXuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_px,ma_nv,ma_kh,ngay_xuat")] tblPhieuXuat tblPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPhieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_px = new SelectList(db.tblCTPhieuXuats, "ma_px", "ma_px", tblPhieuXuat.ma_px);
            ViewBag.ma_kh = new SelectList(db.tblKhachHangs, "ma_kh", "ten_kh", tblPhieuXuat.ma_kh);
            ViewBag.ma_nv = new SelectList(db.tblNhanViens, "ma_nv", "ho_ten", tblPhieuXuat.ma_nv);
            return View(tblPhieuXuat);
        }

        // GET: Admin/tblPhieuXuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuXuat tblPhieuXuat = db.tblPhieuXuats.Find(id);
            if (tblPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tblPhieuXuat);
        }

        // POST: Admin/tblPhieuXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPhieuXuat tblPhieuXuat = db.tblPhieuXuats.Find(id);
            db.tblPhieuXuats.Remove(tblPhieuXuat);
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
