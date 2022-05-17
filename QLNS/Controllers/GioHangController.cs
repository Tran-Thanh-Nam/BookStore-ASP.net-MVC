using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult chonhang(int id)
        {
            // lay thong tin xem don hang da tont tai chua
            // List<GiohHang> gh = ThongTinGioHang();
            List<GioHang> gh = Session["GioHang"] as List<GioHang>;
            if (gh == null)
            {
                gh = new List<GioHang>();
                Session["GioHang"] = gh;
            }
            //kiem tra san pham co trong gio hang chua
            GioHang item = gh.Find(n => n.iMaSach == id);
            if (item == null)
            {
                //san pham chua co trong gio hang
                GioHang newitem = new GioHang(id);
                gh.Add(newitem);
            }
            else
            {
                item.iSoLuong += 1;
            }
            return RedirectToAction("XemGioHang");
        }
        public ActionResult XemGioHang()
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            //Tinh tong so luong
            int soluong = 0;
            double tongtien = 0;
            if (lst != null)
            {
                soluong = lst.Sum(n => n.iSoLuong);
                tongtien = (double)lst.Sum(n => n.dThanhtien);
            }
            ViewBag.soluong = soluong;
            ViewBag.thanhtien = tongtien;
            return View(lst);
        }

        public ActionResult Xoa(int id)
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            GioHang item = lst.Find(n => n.iMaSach == id); // tim item co masp la id
            lst.Remove(item); // xoa item tra khoi list
            return RedirectToAction("XemGioHang");
        }
        public ActionResult Capnhat(int id, FormCollection frm)
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            GioHang item = lst.Find(n => n.iMaSach == id);
            int soluong = int.Parse(frm["txtSoluong"].ToString());
            item.iSoLuong = soluong; // cap nhat so luong moi
            return RedirectToAction("XemGioHang");
        }
        public ActionResult dathang()
        {
            // kiem tra nguoi dung dang nhap chua
            if (Session["ten"] == null) //chua dang nhap
            {
                // chuyen den trang dang nhap
                Session["thanhtoan"] = 1;
                return RedirectToAction("DangNhap", "nguoidung");
            }
            else
            {
                Session.Remove("thanhtoan");
            }
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            //tinh tong so luong
            int soluong = 0;
            double tongtien = 0;
            if (lst != null)
            {
                soluong = lst.Sum(n => n.iSoLuong);
                tongtien = (double)lst.Sum(n => n.dThanhtien);
            }
            ViewBag.soluong = soluong;
            ViewBag.thanhtien = tongtien;
            return View(lst);
        }
    }

}