using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLNS.Models;

namespace QLNS.Controllers
{ 
    public class danhsachsController : Controller
    {
        QLNSEntities dt = new QLNSEntities();
        // GET: danhsachsp/
        int pagesize = 1;
        public ActionResult Index(int id, int? page = 1)
        {
            int cpage = page ?? 1;
            List<tblSach> l = dt.tblSaches.Where(n => n.ma_the_loai == id).ToList();
            string strName = dt.tblSaches.SingleOrDefault(m => m.ma_the_loai == id).tblTheLoai.ten_the_loai;
            ViewBag.Tenloai = strName;
            ViewBag.list = l.ToPagedList(cpage, pagesize);
            ViewBag.id = id;
            return View();
        }
    }
}