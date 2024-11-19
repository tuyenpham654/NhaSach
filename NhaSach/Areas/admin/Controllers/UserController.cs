using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
using System.IO;

namespace NhaSach.Areas.admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: admin/User
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<USERSS> lst = db.USERSSes.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            SetVỉewbag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(USERSS us,HttpPostedFileBase uploadhinh)
        {
            
                db.USERSSes.Add(us);
                db.SaveChanges();

                if(uploadhinh != null && uploadhinh.ContentLength >0)
                {
                    int id = int.Parse(db.USERSSes.ToList().Last().ID.ToString());

                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = "User" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/User"), _FileName);
                    uploadhinh.SaveAs(_path);

                    USERSS uus = db.USERSSes.FirstOrDefault(x => x.ID == us.ID);
                    uus.Photo = _FileName;
                    db.SaveChanges();
                 
                }   
                
                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int id)
        {
            USERSS us = db.USERSSes.FirstOrDefault(c => c.ID == id);
            SetVỉewbag(us.GroupID);


            return View(us);
        }
        [HttpPost]
        public ActionResult Edit(USERSS us, HttpPostedFileBase uploadhinh)
        {
            USERSS uus = db.USERSSes.FirstOrDefault(c => c.ID == us.ID);

            uus.ID = us.ID;
            uus.Name = us.Name;
            uus.UserName = us.UserName;
            uus.Password = us.Password;
            uus.GroupID = us.GroupID;
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = us.ID;
                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "User" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/User"), _FileName);
                uploadhinh.SaveAs(_path);           
                uus.Photo = _FileName;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public void SetVỉewbag(int? selectedid = null)
        {
            ViewBag.GroupID = new SelectList(db.USERGROUPs.ToList(), "ID", "Name", selectedid);
        }
        public ActionResult Delete(int ID)
        {
            USERSS us = db.USERSSes.FirstOrDefault(c => c.ID == ID);
            db.USERSSes.Remove(us);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}