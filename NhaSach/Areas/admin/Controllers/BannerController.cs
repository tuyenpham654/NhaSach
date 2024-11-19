using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
using System.IO;

namespace NhaSach.Areas.admin.Controllers
{
    public class BannerController : BaseController
    {
        // GET: admin/Banner
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<BANNER> lst = db.BANNERs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(BANNER bn, HttpPostedFileBase uploadhinh)
        {

            db.BANNERs.Add(bn);
            db.SaveChanges();

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.BANNERs.ToList().Last().ID.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "bn" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/Banner"), _FileName);
                uploadhinh.SaveAs(_path);

                BANNER ubn = db.BANNERs.FirstOrDefault(x => x.ID == bn.ID);
                ubn.HinhBN = _FileName;
                db.SaveChanges();

            }

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            BANNER bn = db.BANNERs.FirstOrDefault(c => c.ID == id);
           


            return View(bn);
        }
        [HttpPost]
        public ActionResult Edit(BANNER bn, HttpPostedFileBase uploadhinh)
        {
            BANNER ubn = db.BANNERs.FirstOrDefault(c => c.ID == bn.ID);

            
            ubn.Noidung = bn.Noidung;
            ubn.TinhTrang = bn.TinhTrang;
            
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = bn.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "bn" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/Banner"), _FileName);
                uploadhinh.SaveAs(_path);
                ubn.HinhBN = _FileName;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int ID)
        {
            BANNER bn = db.BANNERs.FirstOrDefault(c => c.ID == ID);
            db.BANNERs.Remove(bn);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}