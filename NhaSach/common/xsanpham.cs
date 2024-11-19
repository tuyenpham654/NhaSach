using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;


namespace NhaSach.common
{
    public class xsanpham
    {
        Model1 db = null;
        public xsanpham()
        {
            db = new Model1();
        }
        public List<SANPHAM> lstnew(int top)
        {
            return db.SANPHAMs.OrderByDescending(x => x.MaSP).Take(top).ToList();
        }
        public List<SANPHAM> lsthot(int top)
        {
            return db.SANPHAMs.OrderByDescending(x => x.Hot !=null&&x.Hot>DateTime.Now).Take(top).ToList();
        }
        public List<SANPHAM> lstallsp(int top)
        {
            return db.SANPHAMs.Take(top).ToList();
        }
        //public List<SANPHAM> Viewdetail(int top) => db.SANPHAMs.Find(top);

    }
}