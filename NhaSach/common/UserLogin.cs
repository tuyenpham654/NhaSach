using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaSach.common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string GroupID { set; get; }
    }
}