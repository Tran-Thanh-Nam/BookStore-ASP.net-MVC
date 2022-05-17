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
    public class tblNXBsController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblNXBs
        public ActionResult Index()
        {
            return View(db.tblNXBs.ToList());
        }

        // GET: Admin/tblNXBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNXB tblNXB = db.tblNXBs.Find(id);
            if (tblNXB == null)
            {
                return HttpNotFound();
            }
            return View(tblNXB);
        }

        // GET: Admin/tblNXBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblNXBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_nxb,ten_nxb,dia_chi,email,tt_nguoi_dai_dien")] tblNXB tblNXB)
        {
            if (ModelState.IsValid)
            {
                db.tblNXBs.Add(tblNXB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblNXB);
        }

        // GET: Admin/tblNXBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNXB tblNXB = db.tblNXBs.Find(id);
            if (tblNXB == null)
            {
                return HttpNotFound();
            }
            return View(tblNXB);
        }

        // POST: Admin/tblNXBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_nxb,ten_nxb,dia_chi,email,tt_nguoi_dai_dien")] tblNXB tblNXB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNXB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblNXB);
        }

        // GET: Admin/tblNXBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNXB tblNXB = db.tblNXBs.Find(id);
            if (tblNXB == null)
            {
                return HttpNotFound();
            }
            return View(tblNXB);
        }

        // POST: Admin/tblNXBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblNXB tblNXB = db.tblNXBs.Find(id);
            db.tblNXBs.Remove(tblNXB);
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
