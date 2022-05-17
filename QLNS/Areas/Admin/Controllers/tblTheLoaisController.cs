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
    public class tblTheLoaisController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblTheLoais
        public ActionResult Index()
        {
            return View(db.tblTheLoais.ToList());
        }

        // GET: Admin/tblTheLoais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTheLoai tblTheLoai = db.tblTheLoais.Find(id);
            if (tblTheLoai == null)
            {
                return HttpNotFound();
            }
            return View(tblTheLoai);
        }

        // GET: Admin/tblTheLoais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblTheLoais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_the_loai,ten_the_loai")] tblTheLoai tblTheLoai)
        {
            if (ModelState.IsValid)
            {
                db.tblTheLoais.Add(tblTheLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTheLoai);
        }

        // GET: Admin/tblTheLoais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTheLoai tblTheLoai = db.tblTheLoais.Find(id);
            if (tblTheLoai == null)
            {
                return HttpNotFound();
            }
            return View(tblTheLoai);
        }

        // POST: Admin/tblTheLoais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_the_loai,ten_the_loai")] tblTheLoai tblTheLoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTheLoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTheLoai);
        }

        // GET: Admin/tblTheLoais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTheLoai tblTheLoai = db.tblTheLoais.Find(id);
            if (tblTheLoai == null)
            {
                return HttpNotFound();
            }
            return View(tblTheLoai);
        }

        // POST: Admin/tblTheLoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTheLoai tblTheLoai = db.tblTheLoais.Find(id);
            db.tblTheLoais.Remove(tblTheLoai);
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
