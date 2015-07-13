using System.Collections.Generic;
using WatcherModel;

namespace WebSales.Models
{
    public class OrderFilterModels : FilterModels
    {
        public string SearchString { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}