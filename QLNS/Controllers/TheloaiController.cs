using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class TheloaiController : Controller
    {
        QLNSEntities db = new QLNSEntities();
        // GET: Theloai
        public ActionResult SGK()
        {
            return View(db.tblSaches.Include(t => t.tblTheLoai).Where(t => t.ma_the_loai == 1).ToList());
        }
        public ActionResult TRUYENMA()
        {
            return View(db.tblSaches.Include(t => t.tblTheLoai).Where(t => t.ma_the_loai == 2).ToList());
        }
        public ActionResult SACHTHIEUNHI()
        {
            return View(db.tblSaches.Include(t => t.tblTheLoai).Where(t => t.ma_the_loai == 3).ToList());
        }
    }
}