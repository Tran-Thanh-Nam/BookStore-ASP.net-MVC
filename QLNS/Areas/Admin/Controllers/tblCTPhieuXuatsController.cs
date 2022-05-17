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
    public class tblCTPhieuXuatsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblCTPhieuXuats
        public ActionResult Index()
        {
            var tblCTPhieuXuats = db.tblCTPhieuXuats.Include(t => t.tblPhieuXuat);
            return View(tblCTPhieuXuats.ToList());
        }

        // GET: Admin/tblCTPhieuXuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCTPhieuXuat tblCTPhieuXuat = db.tblCTPhieuXuats.Find(id);
            if (tblCTPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tblCTPhieuXuat);
        }

        // GET: Admin/tblCTPhieuXuats/Create
        public ActionResult Create()
        {
            ViewBag.ma_px = new SelectList(db.tblPhieuXuats, "ma_px", "ma_px");
            return View();
        }

        // POST: Admin/tblCTPhieuXuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_px,ma_sach,so_luong,don_gia")] tblCTPhieuXuat tblCTPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.tblCTPhieuXuats.Add(tblCTPhieuXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_px = new SelectList(db.tblPhieuXuats, "ma_px", "ma_px", tblCTPhieuXuat.ma_px);
            return View(tblCTPhieuXuat);
        }

        // GET: Admin/tblCTPhieuXuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCTPhieuXuat tblCTPhieuXuat = db.tblCTPhieuXuats.Find(id);
            if (tblCTPhieuXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_px = new SelectList(db.tblPhieuXuats, "ma_px", "ma_px", tblCTPhieuXuat.ma_px);
            return View(tblCTPhieuXuat);
        }

        // POST: Admin/tblCTPhieuXuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_px,ma_sach,so_luong,don_gia")] tblCTPhieuXuat tblCTPhieuXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCTPhieuXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_px = new SelectList(db.tblPhieuXuats, "ma_px", "ma_px", tblCTPhieuXuat.ma_px);
            return View(tblCTPhieuXuat);
        }

        // GET: Admin/tblCTPhieuXuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCTPhieuXuat tblCTPhieuXuat = db.tblCTPhieuXuats.Find(id);
            if (tblCTPhieuXuat == null)
            {
                return HttpNotFound();
            }
            return View(tblCTPhieuXuat);
        }

        // POST: Admin/tblCTPhieuXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCTPhieuXuat tblCTPhieuXuat = db.tblCTPhieuXuats.Find(id);
            db.tblCTPhieuXuats.Remove(tblCTPhieuXuat);
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
