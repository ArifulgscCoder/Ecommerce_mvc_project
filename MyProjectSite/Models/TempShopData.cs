using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public class TempShopData
    {
        public static int UserID { get; set; }
        public static List<OrderDetail> items { get; set; }
    }
}