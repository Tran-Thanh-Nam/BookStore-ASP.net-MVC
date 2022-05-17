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
    public class tblCTPhieuNhapsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblCTPhieuNhaps
        public ActionResult Index()
        {
            var tblCTPhieuNhaps = db.tblCTPhieuNhaps.Include(t => t.tblPhieuNhap).Include(t => t.tblSach);
            return View(tblCTPhieuNhaps.ToList());
        }

        // GET: Admin/tblCTPhieuNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCTPhieuNhap tblCTPhieuNhap = db.tblCTPhieuNhaps.Find(id);
            if (tblCTPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(tblCTPhieuNhap);
        }

        // GET: Admin/tblCTPhieuNhaps/Create
        public ActionResult Create()
        {
            ViewBag.ma_pn = new SelectList(db.tblPhieuNhaps, "ma_pn", "ma_pn");
            ViewBag.ma_sach = new SelectList(db.tblSaches, "ma_sach", "ten_sach");
            return View();
        }

        // POST: Admin/tblCTPhieuNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_pn,ma_sach,so_luong,don_gia")] tblCTPhieuNhap tblCTPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.tblCTPhieuNhaps.Add(tblCTPhieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_pn = new SelectList(db.tblPhieuNhaps, "ma_pn", "ma_pn", tblCTPhieuNhap.ma_pn);
            ViewBag.ma_sach = new SelectList(db.tblSaches, "ma_sach", "ten_sach", tblCTPhieuNhap.ma_sach);
            return View(tblCTPhieuNhap);
        }

        // GET: Admin/tblCTPhieuNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCTPhieuNhap tblCTPhieuNhap = db.tblCTPhieuNhaps.Find(id);
            if (tblCTPhieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_pn = new SelectList(db.tblPhieuNhaps, "ma_pn", "ma_pn", tblCTPhieuNhap.ma_pn);
            ViewBag.ma_sach = new SelectList(db.tblSaches, "ma_sach", "ten_sach", tblCTPhieuNhap.ma_sach);
            return View(tblCTPhieuNhap);
        }

        // POST: Admin/tblCTPhieuNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_pn,ma_sach,so_luong,don_gia")] tblCTPhieuNhap tblCTPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCTPhieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_pn = new SelectList(db.tblPhieuNhaps, "ma_pn", "ma_pn", tblCTPhieuNhap.ma_pn);
            ViewBag.ma_sach = new SelectList(db.tblSaches, "ma_sach", "ten_sach", tblCTPhieuNhap.ma_sach);
            return View(tblCTPhieuNhap);
        }

        // GET: Admin/tblCTPhieuNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCTPhieuNhap tblCTPhieuNhap = db.tblCTPhieuNhaps.Find(id);
            if (tblCTPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(tblCTPhieuNhap);
        }

        // POST: Admin/tblCTPhieuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCTPhieuNhap tblCTPhieuNhap = db.tblCTPhieuNhaps.Find(id);
            db.tblCTPhieuNhaps.Remove(tblCTPhieuNhap);
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
