using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace NhaSach.common
{
    public class Slidens
    {
        Model1 db = null;
        public Slidens()
        {
            db = new Model1();
           
            
        }
        
        public List<BANNER> listall()
        {
            return db.BANNERs.Where(x => x.TinhTrang == true).OrderBy(y => y.ID).ToList();
        }

    }
}