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
    public class SanPhamcController : Controller
    {
        // GET: SanPhamc
        public ActionResult Index()
        {
            ViewBag.Slide = new Slidens().listall();
            var xsanpham = new xsanpham();
            ViewBag.Lstnew = xsanpham.lstnew(8);
            ViewBag.Lsthot = xsanpham.lsthot(8);
            ViewBag.Lstall = xsanpham.lstallsp(int.MaxValue);
            return View();
        }
        public ActionResult Sanphmdetail()
        {
            var xsanpham = new xsanpham();
            ViewBag.Lstnew = xsanpham.lstnew(8);
            ViewBag.Lsthot = xsanpham.lsthot(8);
            ViewBag.Lstall = xsanpham.lstallsp(int.MaxValue);
            return View();
        }
        public ActionResult SPST()
        {
            ViewBag.Slide = new Slidens().listall();
            var xsanpham = new xsanpham();
            ViewBag.Lstnew = xsanpham.lstnew(8);
            ViewBag.Lsthot = xsanpham.lsthot(8);
            ViewBag.Lstall = xsanpham.lstallsp(int.MaxValue);
            return View();
        }
        public ActionResult SPvpp()
        {
            ViewBag.Slide = new Slidens().listall();
            var xsanpham = new xsanpham();
            ViewBag.Lstnew = xsanpham.lstnew(8);
            ViewBag.Lsthot = xsanpham.lsthot(8);
            ViewBag.Lstall = xsanpham.lstallsp(int.MaxValue);
            return View();
        }
    }
}