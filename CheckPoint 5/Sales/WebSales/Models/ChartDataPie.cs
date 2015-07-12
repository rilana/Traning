using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSales.Models
{
    public class ChartDataPie
    {
        public ChartDataPie(string str, int totalCost,int totalSales)
        {
            TotalCostOrSales= totalCost;
            if (str == "Total sales") TotalCostOrSales = totalSales; 
        }

        public string LastNameManager { get; set; }
        public int TotalCostOrSales { get; set; }       
    }
}