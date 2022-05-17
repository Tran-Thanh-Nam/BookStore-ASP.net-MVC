using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;
using System.Data.Entity;

namespace QLNS.Controllers
{
    public class TacGiaController : Controller
    {
        QLNSEntities db = new QLNSEntities();
        // GET: TacGia
        public ActionResult tg1()
        {
            return View(db.tblSaches.Include(t => t.tblTacGia).Where(t => t.ma_tac_gia == 1).ToList());
        }
        public ActionResult tg2()
        {
            return View(db.tblSaches.Include(t => t.tblTacGia).Where(t => t.ma_tac_gia == 2).ToList());
        }
        public ActionResult tg3()
        {
            return View(db.tblSaches.Include(t => t.tblTacGia).Where(t => t.ma_tac_gia == 3).ToList());
        }
    }
}