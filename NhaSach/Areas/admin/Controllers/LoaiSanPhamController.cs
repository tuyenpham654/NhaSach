using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;

namespace NhaSach.Areas.admin.Controllers
{
    public class LoaiSanPhamController : BaseController
    {
        // GET: admin/LoaiSanPham
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<LOAISANPHAM> lst = db.LOAISANPHAMs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LOAISANPHAM lsp)
        {
            
                db.LOAISANPHAMs.Add(lsp);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int id)
        {
            LOAISANPHAM lsp = db.LOAISANPHAMs.FirstOrDefault(c => c.MaLoai == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Edit(LOAISANPHAM lsp)
        {
            LOAISANPHAM ulsp = db.LOAISANPHAMs.FirstOrDefault(c => c.MaLoai == lsp.MaLoai);
            ulsp.GhiChu = lsp.GhiChu;
            ulsp.MaLoai = lsp.MaLoai;
            ulsp.TenLoai = lsp.TenLoai;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            LOAISANPHAM lsp = db.LOAISANPHAMs.FirstOrDefault(c => c.MaLoai == id);
            db.LOAISANPHAMs.Remove(lsp);
            db.SaveChanges();            return RedirectToAction("Index");
        }
    }
}