using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models
{
    public class GioHang
    {
        QLNSEntities db = new QLNSEntities();
        // tao thuoc tinh cho moi item trong gio hang
        public int Id { get; set; }
        public int iMaSach { set; get; }
        public string strTenSach { set; get; }
        public string strHinh { set; get; }
        public double dGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhtien { get { return dGia * iSoLuong; } }
        // tao constructop cho gio hang
        public GioHang(int ma_sach)
        {
            iMaSach = ma_sach;
            tblSach sp = db.tblSaches.Find(ma_sach);
            strTenSach= sp.ten_sach;
            sp.gia = sp.gia ?? 0;
            dGia = double.Parse(sp.gia.ToString());
            strHinh = sp.hinhanh;
            iSoLuong = 1;
        }
    }
}