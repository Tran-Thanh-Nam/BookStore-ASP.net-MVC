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
    public class tblNCCsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblNCCs
        public ActionResult Index()
        {
            return View(db.tblNCCs.ToList());
        }

        // GET: Admin/tblNCCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNCC tblNCC = db.tblNCCs.Find(id);
            if (tblNCC == null)
            {
                return HttpNotFound();
            }
            return View(tblNCC);
        }

        // GET: Admin/tblNCCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblNCCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_ncc,ten_ncc,dia_chi,sdt")] tblNCC tblNCC)
        {
            if (ModelState.IsValid)
            {
                db.tblNCCs.Add(tblNCC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblNCC);
        }

        // GET: Admin/tblNCCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNCC tblNCC = db.tblNCCs.Find(id);
            if (tblNCC == null)
            {
                return HttpNotFound();
            }
            return View(tblNCC);
        }

        // POST: Admin/tblNCCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_ncc,ten_ncc,dia_chi,sdt")] tblNCC tblNCC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNCC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblNCC);
        }

        // GET: Admin/tblNCCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNCC tblNCC = db.tblNCCs.Find(id);
            if (tblNCC == null)
            {
                return HttpNotFound();
            }
            return View(tblNCC);
        }

        // POST: Admin/tblNCCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblNCC tblNCC = db.tblNCCs.Find(id);
            db.tblNCCs.Remove(tblNCC);
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
