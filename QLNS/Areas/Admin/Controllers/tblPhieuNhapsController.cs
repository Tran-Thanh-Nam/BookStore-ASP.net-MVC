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
    public class tblPhieuNhapsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblPhieuNhaps
        public ActionResult Index()
        {
            var tblPhieuNhaps = db.tblPhieuNhaps.Include(t => t.tblCTPhieuNhap).Include(t => t.tblNCC);
            return View(tblPhieuNhaps.ToList());
        }

        // GET: Admin/tblPhieuNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuNhap tblPhieuNhap = db.tblPhieuNhaps.Find(id);
            if (tblPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(tblPhieuNhap);
        }

        // GET: Admin/tblPhieuNhaps/Create
        public ActionResult Create()
        {
            ViewBag.ma_pn = new SelectList(db.tblCTPhieuNhaps, "ma_pn", "ma_pn");
            ViewBag.ma_ncc = new SelectList(db.tblNCCs, "ma_ncc", "ten_ncc");
            return View();
        }

        // POST: Admin/tblPhieuNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_pn,ma_nv,ma_ncc,ngay_nhap")] tblPhieuNhap tblPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.tblPhieuNhaps.Add(tblPhieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_pn = new SelectList(db.tblCTPhieuNhaps, "ma_pn", "ma_pn", tblPhieuNhap.ma_pn);
            ViewBag.ma_ncc = new SelectList(db.tblNCCs, "ma_ncc", "ten_ncc", tblPhieuNhap.ma_ncc);
            return View(tblPhieuNhap);
        }

        // GET: Admin/tblPhieuNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuNhap tblPhieuNhap = db.tblPhieuNhaps.Find(id);
            if (tblPhieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_pn = new SelectList(db.tblCTPhieuNhaps, "ma_pn", "ma_pn", tblPhieuNhap.ma_pn);
            ViewBag.ma_ncc = new SelectList(db.tblNCCs, "ma_ncc", "ten_ncc", tblPhieuNhap.ma_ncc);
            return View(tblPhieuNhap);
        }

        // POST: Admin/tblPhieuNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_pn,ma_nv,ma_ncc,ngay_nhap")] tblPhieuNhap tblPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPhieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_pn = new SelectList(db.tblCTPhieuNhaps, "ma_pn", "ma_pn", tblPhieuNhap.ma_pn);
            ViewBag.ma_ncc = new SelectList(db.tblNCCs, "ma_ncc", "ten_ncc", tblPhieuNhap.ma_ncc);
            return View(tblPhieuNhap);
        }

        // GET: Admin/tblPhieuNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPhieuNhap tblPhieuNhap = db.tblPhieuNhaps.Find(id);
            if (tblPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(tblPhieuNhap);
        }

        // POST: Admin/tblPhieuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPhieuNhap tblPhieuNhap = db.tblPhieuNhaps.Find(id);
            db.tblPhieuNhaps.Remove(tblPhieuNhap);
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
