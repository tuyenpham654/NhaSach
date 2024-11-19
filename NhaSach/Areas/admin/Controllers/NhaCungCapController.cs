using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;

namespace NhaSach.Areas.admin.Controllers
{
    public class NhaCungCapController : BaseController
    {
        // GET: admin/NhaCungCap
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<NHACUNGCAP> lst = db.NHACUNGCAPs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHACUNGCAP ncc)
        {
           
                db.NHACUNGCAPs.Add(ncc);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int id)
        {
            NHACUNGCAP ncc = db.NHACUNGCAPs.FirstOrDefault(c => c.MaNCC == id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(NHACUNGCAP ncc)
        {
            NHACUNGCAP uncc = db.NHACUNGCAPs.FirstOrDefault(c => c.MaNCC == ncc.MaNCC);
            uncc.MaNCC = ncc.MaNCC;
            uncc.SDT = ncc.SDT;
            uncc.TenNCC = ncc.TenNCC;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            NHACUNGCAP ncc = db.NHACUNGCAPs.FirstOrDefault(c => c.MaNCC == id);
            db.NHACUNGCAPs.Remove(ncc);
            db.SaveChanges();            return RedirectToAction("Index");
        }
    }
}