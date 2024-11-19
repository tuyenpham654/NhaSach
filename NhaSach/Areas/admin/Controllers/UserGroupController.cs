using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
namespace NhaSach.Areas.admin.Controllers
{
    public class UserGroupController : BaseController
    {
        // GET: admin/UserGroup
       
        NhaSachEntities db = new NhaSachEntities();
        public ActionResult Index()
        {
            List<USERGROUP> lst = db.USERGROUPs.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(USERGROUP lsp)
        {
            
                db.USERGROUPs.Add(lsp);
                db.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
        public ActionResult Edit(int id)
        {
            USERGROUP lsp = db.USERGROUPs.FirstOrDefault(c => c.ID == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Edit(USERGROUP lsp)
        {
            USERGROUP ulsp = db.USERGROUPs.FirstOrDefault(c => c.ID == lsp.ID);
            ulsp.ID = lsp.ID;
            ulsp.Name = lsp.Name;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            USERGROUP lsp = db.USERGROUPs.FirstOrDefault(c => c.ID == id);
            db.USERGROUPs.Remove(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}