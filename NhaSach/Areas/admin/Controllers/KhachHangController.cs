using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;

namespace NhaSach.Areas.admin.Controllers
{
    public class KhachHangController : BaseController
    {
        // GET: admin/KhachHang
        NhaSachEntities db = new NhaSachEntities();

        public ActionResult Index()
        {
            List<KHACHHANG> lst = db.KHACHHANGs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KHACHHANG kh)
        {
            
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int id)
        {
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(c => c.ID == id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(KHACHHANG kh)
        {
            KHACHHANG ukh = db.KHACHHANGs.FirstOrDefault(c => c.ID == kh.ID);
            ukh.CMND = kh.CMND;
            ukh.DiaChi = kh.DiaChi;
            ukh.GioiTinh = kh.GioiTinh;
            ukh.ID = kh.ID;
            ukh.NgayLap = kh.NgayLap;
            ukh.NgaySinh = kh.NgaySinh;
            ukh.TenKH = kh.TenKH;
            ukh.UserName = kh.UserName;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(c => c.ID == id);
            db.KHACHHANGs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}