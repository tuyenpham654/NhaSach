using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
using NhaSach.common;
using Model.EF;




namespace NhaSach.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Slide = new Slidens().listall();
            var xsanpham = new xsanpham();
            ViewBag.Lstnew = xsanpham.lstnew(8);
            ViewBag.Lsthot = xsanpham.lsthot(8);
            ViewBag.Lstall = xsanpham.lstallsp(int.MaxValue);
            var tintuclst = new tintuclst();
            ViewBag.Tintuc = tintuclst.listalltt(5);
            return View();
        }
        public ActionResult Contact()
        {
            
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }

      
    }
}