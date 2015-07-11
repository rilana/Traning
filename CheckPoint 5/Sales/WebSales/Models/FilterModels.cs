using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSales.Models
{
    public class FilterModels
    {
        private DateTime dateStart = new DateTime(2015, 6, 1);//new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        private DateTime dateFinish = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateFinish
        {
            get { return dateFinish; }
            set { dateFinish = value; }
        }

        public int? FilterManager { get; set; }
        public int? FilterClient { get; set; }
        public int? FilterGoods { get; set; }
        public int? FilterNameFile { get; set; }
    }
}