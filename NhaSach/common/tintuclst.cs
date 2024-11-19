using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace NhaSach.common
{
    public class tintuclst
    {
        Model1 db = null;
        public tintuclst()
        {
            db = new Model1();
        }
        public List<TINTUC> listalltt(int top)
        {
            return db.TINTUCs.OrderBy(x => x.ID).Take(top).ToList();
        }
    }
}