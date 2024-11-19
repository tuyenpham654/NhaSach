using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
using System.IO;

namespace NhaSach.Areas.admin.Controllers
{
    public class TinTucController : BaseController
    {
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<TINTUC> lst = db.TINTUCs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TINTUC tt, HttpPostedFileBase uploadhinh)
        {
           
                db.TINTUCs.Add(tt);
                db.SaveChanges();
                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    int id = int.Parse(db.TINTUCs.ToList().Last().ID.ToString());

                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = "tin" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/TinTuc"), _FileName);
                    uploadhinh.SaveAs(_path);

                    TINTUC utt = db.TINTUCs.FirstOrDefault(x => x.ID == tt.ID);
                    utt.Hinh = _FileName;
                    db.SaveChanges();

                }
            return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int ID)
        {
            TINTUC tt = db.TINTUCs.FirstOrDefault(c => c.ID == ID);
            return View(tt);
        }
        [HttpPost]
        public ActionResult Edit(TINTUC tt,HttpPostedFileBase uploadhinh)
        {
            TINTUC utt = db.TINTUCs.FirstOrDefault(c => c.ID == tt.ID);
            utt.ID = tt.ID;
            utt.LoaiTinTuc = tt.LoaiTinTuc;
            utt.NoiDung = tt.NoiDung;
            utt.TenTinTuc = tt.TenTinTuc;
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = tt.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "tin" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/TinTuc"), _FileName);
                uploadhinh.SaveAs(_path);
                utt.Hinh = _FileName;

            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            TINTUC tt = db.TINTUCs.FirstOrDefault(c => c.ID == ID);
            db.TINTUCs.Remove(tt);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}