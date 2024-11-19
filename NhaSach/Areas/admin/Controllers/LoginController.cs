using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaSach.Models;
using NhaSach.common;




namespace NhaSach.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        NhaSachEntities db = new NhaSachEntities();
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.username = Request.Cookies["username"].Value;
                ViewBag.password = Request.Cookies["password"].Value;
            }
            return View();
        }

        public void ghinhotaikhoan(string username, string password)
        {
            HttpCookie us = new HttpCookie("username");
            HttpCookie pass = new HttpCookie("password");

            us.Value = username;
            pass.Value = password;

            us.Expires = DateTime.Now.AddDays(1);
            pass.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(us);
            Response.Cookies.Add(pass);
        }

        [HttpPost]
        public ActionResult kiemtradangnhap(string username, string password, string ghinho)
        {
            if (Request.Cookies["username"] != null && Request.Cookies["username"] != null)
            {
                username = Request.Cookies["username"].Value;
                password = Request.Cookies["password"].Value;
            }

            if (checkpassword(username, password))
            {
                var userSession = new UserLogin();
                userSession.UserName = username;

                var listGroups = GetListGroupID(username);

                Session.Add("SESSION_GROUP", listGroups);
                Session.Add("USER_SESSION", userSession);

                if (ghinho == "on")
                    ghinhotaikhoan(username, password);
                return Redirect("~/admin/Home/Index");

            }
            
            return Redirect("~/admin/Login/Index");
        }
        public List<string> GetListGroupID(string userName)
        {
            var data = (from a in db.USERGROUPs
                        join b in db.USERSSes on a.ID equals b.GroupID
                        where b.UserName == userName

                        select new
                        {
                            UserGroupID = b.GroupID,
                            UserGroupName = a.Name
                        });

            return data.Select(x => x.UserGroupName).ToList();

        }
        public bool checkpassword(string username, string password)
        {
            if (db.USERSSes.Where(x => x.UserName == username && x.Password == password).Count() > 0)

                return true;
            else
                return false;


        }




        public ActionResult SignOut()
        {

            Session["USER_SESSION"] = null;
            Session["SESSION_GROUP"] = null;


            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                HttpCookie us = Request.Cookies["username"];
                HttpCookie ps = Request.Cookies["password"];

                ps.Expires = DateTime.Now.AddDays(-1);
                us.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(us);
                Response.Cookies.Add(ps);
            }

            return Redirect("/Admin/Login");
        }
    }
}