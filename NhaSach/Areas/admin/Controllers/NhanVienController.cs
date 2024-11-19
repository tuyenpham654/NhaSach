using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;

namespace NhaSach.Areas.admin.Controllers
{
    public class NhanVienController : BaseController
    {
        // GET: admin/NhanVien
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<NHANVIEN> lst = db.NHANVIENs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHANVIEN nv )
        {
           
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int id)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(c => c.MaNV == id);
            return View(nv);
        }
        [HttpPost]
        public ActionResult Edit(NHANVIEN nv)
        {
            NHANVIEN unv = db.NHANVIENs.FirstOrDefault(c => c.MaNV == nv.MaNV);
            unv.GioiTinh = nv.GioiTinh;
            unv.MaNV = nv.MaNV;
            unv.SDT = nv.SDT;
            unv.TenNV = nv.TenNV;
            unv.DiaChi = nv.DiaChi;


            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(c => c.MaNV == id);
            db.NHANVIENs.Remove(nv);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}