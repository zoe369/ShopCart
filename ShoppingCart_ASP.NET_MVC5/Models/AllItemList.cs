using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart_ASP.NET_MVC5.Models
{
    public class AllItemList
    {
        public int car_id {get; set;}
        public string car_marca { get; set; }
        public int car_price { get; set; } 
        public string car_model { get; set; }
        public string car_image { get; set; }
        public int count { get; set; }
    }
}