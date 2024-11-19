using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
using System.IO;

namespace NhaSach.Areas.admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: admin/SanPham
        NhaSachEntities db = new NhaSachEntities();

        public ActionResult Index()
        {
            List<SANPHAM> lst = db.SANPHAMs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            SetVỉewbag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SANPHAM sp, HttpPostedFileBase uploadhinh)
        {
            
                db.SANPHAMs.Add(sp);
                db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.SANPHAMs.ToList().Last().MaSP.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "SP" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/SanPham"), _FileName);
                uploadhinh.SaveAs(_path);

                SANPHAM usp = db.SANPHAMs.FirstOrDefault(x => x.MaSP == sp.MaSP);
                usp.HinhSP = _FileName;
                db.SaveChanges();

            }
            return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int id)
        {
            SANPHAM sp = db.SANPHAMs.FirstOrDefault(c => c.MaSP == id);
            SetVỉewbag(sp.TheLoai);
            SetVỉewbag(sp.NCC);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(SANPHAM sp, HttpPostedFileBase uploadhinh)
        {
            SANPHAM usp = db.SANPHAMs.FirstOrDefault(c => c.MaSP == sp.MaSP);
        
            usp.MaSP = sp.MaSP;
            usp.NamSX = sp.NamSX;
            usp.NCC = sp.NCC;
            usp.TheLoai = sp.TheLoai;
            usp.TenSP = sp.TenSP;
            usp.Gia = sp.Gia;
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = sp.MaSP;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "SP" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/SanPham"), _FileName);
                uploadhinh.SaveAs(_path);
                usp.HinhSP = _FileName;

            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public void SetVỉewbag(int? selectedid = null)
        {
            ViewBag.TheLoai = new SelectList(db.LOAISANPHAMs.ToList(), "MaLoai", "TenLoai", selectedid);
            ViewBag.NCC = new SelectList(db.NHACUNGCAPs.ToList(), "MaNCC", "TenNCC", selectedid);
        }
        public ActionResult Delete(int id)
        {
            SANPHAM sp = db.SANPHAMs.FirstOrDefault(c => c.MaSP == id);
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}