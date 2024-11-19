using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;

namespace NhaSach.Areas.admin.Controllers
{
    public class ChiTietHoaDonController : BaseController
    {
        // GET: admin/ChiTietHoaDon
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<CHITIETHOADON> lst = db.CHITIETHOADONs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(CHITIETHOADON cthd)
        {
            
                db.CHITIETHOADONs.Add(cthd);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int id)
        {
            CHITIETHOADON cthd = db.CHITIETHOADONs.FirstOrDefault(c => c.MaCTHD == id);
            SetViewBag(cthd.MaHD);
            SetViewBag(cthd.MaSP);
            return View(cthd);
        }
        [HttpPost]
        public ActionResult Edit(CHITIETHOADON cthd)
        {
            CHITIETHOADON ucthd = db.CHITIETHOADONs.FirstOrDefault(c => c.MaCTHD == cthd.MaCTHD);
            ucthd.MaCTHD = cthd.MaCTHD;
            ucthd.MaHD = cthd.MaHD;
            ucthd.MaSP = cthd.MaSP;
            ucthd.SoLuong = cthd.SoLuong;
            ucthd.ThanhTien = cthd.ThanhTien;
            ucthd.DonGia = cthd.DonGia;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public void SetViewBag(int? selectedid = null)
        {
            ViewBag.MaHD = new SelectList(db.HOADONs.ToList(), "MaHD",  "MaHD", selectedid);
            ViewBag.MaSP = new SelectList(db.SANPHAMs.ToList(), "MaSP",  "TenSP", selectedid);
        }
        public ActionResult Delete(int id)
        {
            CHITIETHOADON cthd = db.CHITIETHOADONs.FirstOrDefault(c => c.MaCTHD == id);
            db.CHITIETHOADONs.Remove(cthd);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}