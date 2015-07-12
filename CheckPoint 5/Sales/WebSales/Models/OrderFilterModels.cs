using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatcherModel;

namespace WebSales.Models
{
    public class OrderFilterModels : FilterModels
    {
        public string searchString { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}