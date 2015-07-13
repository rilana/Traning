using System;
using System.ComponentModel.DataAnnotations;

namespace WebSales.Models
{
    public abstract class FilterDateModels
    {
        private DateTime _dateStart = new DateTime(2015, 6, 1);//new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        private DateTime _dateFinish = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFinish
        {
            get { return _dateFinish; }
            set { _dateFinish = value; }
        }

    }
}