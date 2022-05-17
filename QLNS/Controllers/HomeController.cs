using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class HomeController : Controller
    {
        QLNSEntities dc = new QLNSEntities();
        int pagesize = 4;// co 2 san pham tren 1 trang
                         // page : sp moi, p2:spsv
        public ActionResult Index(int? page = 1, int? p2 = 1)
        {
            //lay so trang
            int ipage = (page ?? 1); //tra ve page if page is not null, else return 1
            List<tblSach> spmoi = dc.tblSaches.ToList();
            ViewBag.spmoi = spmoi.ToPagedList(ipage, pagesize);
            return View();
        }

        public PartialViewResult _leftmenu()
        {
            // lay ds loai san pham
            return PartialView("_leftmenu", dc.tblTheLoais.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblKhachHang u)
        {
            if (ModelState.IsValid)
            {
                    var v = dc.tblKhachHangs.Where(a=>a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.ma_kh;
                        Session["LogedUserFullname"] = v.ten_kh;
                        Session["User"] = v;
                        if (v.quyen == 1)
                        {
                            return RedirectToAction("Index", "Index", new { area = "Admin"});
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = ""});
                        }
                    }
            }
            return View(u);
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogeUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Dangxuat()
        {

            Session["LogedUserID"] = null;
            Session["LogedUserFullname"] = null;
            Session["User"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy( tblKhachHang user)
        {
            if (ModelState.IsValid)
            {
                dc.tblKhachHangs.Add(user);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

    }
}