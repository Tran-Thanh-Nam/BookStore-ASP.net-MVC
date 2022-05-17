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
    public class tblKhachHangsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblKhachHangs
        public ActionResult Index()
        {
            return View(db.tblKhachHangs.ToList());
        }

        // GET: Admin/tblKhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhachHang tblKhachHang = db.tblKhachHangs.Find(id);
            if (tblKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tblKhachHang);
        }

        // GET: Admin/tblKhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblKhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_kh,ten_kh,dia_chi,sdt")] tblKhachHang tblKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.tblKhachHangs.Add(tblKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblKhachHang);
        }

        // GET: Admin/tblKhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhachHang tblKhachHang = db.tblKhachHangs.Find(id);
            if (tblKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tblKhachHang);
        }

        // POST: Admin/tblKhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_kh,ten_kh,dia_chi,sdt")] tblKhachHang tblKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblKhachHang);
        }

        // GET: Admin/tblKhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKhachHang tblKhachHang = db.tblKhachHangs.Find(id);
            if (tblKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(tblKhachHang);
        }

        // POST: Admin/tblKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKhachHang tblKhachHang = db.tblKhachHangs.Find(id);
            db.tblKhachHangs.Remove(tblKhachHang);
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
