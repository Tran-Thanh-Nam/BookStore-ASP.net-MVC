using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class ChitietController : Controller
    {
        QLNSEntities db = new QLNSEntities();
        // GET: Chitiet
        public ActionResult Index(int id)
        {
            tblSach sp = db.tblSaches.Find(id);
            return View(sp);
        }
    }
}