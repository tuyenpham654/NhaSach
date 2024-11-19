using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace NhaSach.Models
{
    public class CartItem
    {
        public SANPHAM SANPHAM { get; set; }
        public int Quantity { get; set; }
        
    }
}