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
    public class tblSachesController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblSaches
        public ActionResult Index()
        {
            var tblSaches = db.tblSaches.Include(t => t.tblNXB).Include(t => t.tblTacGia).Include(t => t.tblTheLoai);
            return View(tblSaches.ToList());
        }

        // GET: Admin/tblSaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSach tblSach = db.tblSaches.Find(id);
            if (tblSach == null)
            {
                return HttpNotFound();
            }
            return View(tblSach);
        }

        // GET: Admin/tblSaches/Create
        public ActionResult Create()
        {
            ViewBag.ma_nxb = new SelectList(db.tblNXBs, "ma_nxb", "ten_nxb");
            ViewBag.ma_tac_gia = new SelectList(db.tblTacGias, "ma_tac_gia", "ten_tac_gia");
            ViewBag.ma_the_loai = new SelectList(db.tblTheLoais, "ma_the_loai", "ten_the_loai");
            return View();
        }

        // POST: Admin/tblSaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_sach,ten_sach,ma_tac_gia,ma_the_loai,ma_nxb,nam_xb")] tblSach tblSach)
        {
            if (ModelState.IsValid)
            {
                db.tblSaches.Add(tblSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_nxb = new SelectList(db.tblNXBs, "ma_nxb", "ten_nxb", tblSach.ma_nxb);
            ViewBag.ma_tac_gia = new SelectList(db.tblTacGias, "ma_tac_gia", "ten_tac_gia", tblSach.ma_tac_gia);
            ViewBag.ma_the_loai = new SelectList(db.tblTheLoais, "ma_the_loai", "ten_the_loai", tblSach.ma_the_loai);
            return View(tblSach);
        }

        // GET: Admin/tblSaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSach tblSach = db.tblSaches.Find(id);
            if (tblSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_nxb = new SelectList(db.tblNXBs, "ma_nxb", "ten_nxb", tblSach.ma_nxb);
            ViewBag.ma_tac_gia = new SelectList(db.tblTacGias, "ma_tac_gia", "ten_tac_gia", tblSach.ma_tac_gia);
            ViewBag.ma_the_loai = new SelectList(db.tblTheLoais, "ma_the_loai", "ten_the_loai", tblSach.ma_the_loai);
            return View(tblSach);
        }

        // POST: Admin/tblSaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_sach,ten_sach,ma_tac_gia,ma_the_loai,ma_nxb,nam_xb")] tblSach tblSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_nxb = new SelectList(db.tblNXBs, "ma_nxb", "ten_nxb", tblSach.ma_nxb);
            ViewBag.ma_tac_gia = new SelectList(db.tblTacGias, "ma_tac_gia", "ten_tac_gia", tblSach.ma_tac_gia);
            ViewBag.ma_the_loai = new SelectList(db.tblTheLoais, "ma_the_loai", "ten_the_loai", tblSach.ma_the_loai);
            return View(tblSach);
        }

        // GET: Admin/tblSaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSach tblSach = db.tblSaches.Find(id);
            if (tblSach == null)
            {
                return HttpNotFound();
            }
            return View(tblSach);
        }

        // POST: Admin/tblSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSach tblSach = db.tblSaches.Find(id);
            db.tblSaches.Remove(tblSach);
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
