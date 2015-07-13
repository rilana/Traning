using System;
namespace WebSales.Models
{
    public class ChartGoodsDate
    {
        public string DateStr { get; set; }
        public DateTime Date
        {
            get
            {
                return Convert.ToDateTime(DateStr);
            }
        }
        public int CountGoods { get; set; }
    }
}