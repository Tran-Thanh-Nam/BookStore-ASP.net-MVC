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
    public class tblTacGiasController : Controller
    {
        private QLNSEntities db = new QLNSEntities();

        // GET: Admin/tblTacGias
        public ActionResult Index()
        {
            return View(db.tblTacGias.ToList());
        }

        // GET: Admin/tblTacGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTacGia tblTacGia = db.tblTacGias.Find(id);
            if (tblTacGia == null)
            {
                return HttpNotFound();
            }
            return View(tblTacGia);
        }

        // GET: Admin/tblTacGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblTacGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_tac_gia,ten_tac_gia,website,ghi_chu")] tblTacGia tblTacGia)
        {
            if (ModelState.IsValid)
            {
                db.tblTacGias.Add(tblTacGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTacGia);
        }

        // GET: Admin/tblTacGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTacGia tblTacGia = db.tblTacGias.Find(id);
            if (tblTacGia == null)
            {
                return HttpNotFound();
            }
            return View(tblTacGia);
        }

        // POST: Admin/tblTacGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_tac_gia,ten_tac_gia,website,ghi_chu")] tblTacGia tblTacGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTacGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTacGia);
        }

        // GET: Admin/tblTacGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTacGia tblTacGia = db.tblTacGias.Find(id);
            if (tblTacGia == null)
            {
                return HttpNotFound();
            }
            return View(tblTacGia);
        }

        // POST: Admin/tblTacGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTacGia tblTacGia = db.tblTacGias.Find(id);
            db.tblTacGias.Remove(tblTacGia);
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
