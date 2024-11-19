using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;

namespace NhaSach.Areas.admin.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: admin/HoaDon
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<HOADON> lst = db.HOADONs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HOADON hd)
        {
            
                db.HOADONs.Add(hd);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int id)
        {
            HOADON hd = db.HOADONs.FirstOrDefault(c => c.MaHD == id);
            return View(hd);
        }
        [HttpPost]
        public ActionResult Edit(HOADON hd)
        {
            HOADON uhd = db.HOADONs.FirstOrDefault(c => c.MaHD == hd.MaHD);
            uhd.MaHD = hd.MaHD;
            uhd.MaKH = hd.MaKH;
            uhd.NgayLap = hd.NgayLap;
            uhd.TongGT = hd.TongGT;
           

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HOADON hd = db.HOADONs.FirstOrDefault(c => c.MaHD == id);
            db.HOADONs.Remove(hd);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}