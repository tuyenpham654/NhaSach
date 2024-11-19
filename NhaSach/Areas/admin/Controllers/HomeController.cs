using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhaSach.Areas.admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: admin/Home
       
        public ActionResult Index()
        {

            ViewData["Home"] = "Trang Chủ";
            return View();
        }
    }
}