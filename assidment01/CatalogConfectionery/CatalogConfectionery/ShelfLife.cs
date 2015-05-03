using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public struct ShelfLife 
    {
        private byte hour;
        private byte day;
        private byte month;// считаем что в одном месяце 30 дней

        public byte Hour
        {
            get { return hour; }
            set
            {
                 hour = value;
            }
        }
        public byte Day
        {
            get { return day; }
            set
            {
               day = value;
             }
        }
        public byte Month
        {
            get { return month; }
            set
            {
                 month = value;
            }
        }

        public int GetHour
        {
            get { return (Month * 30 + Day )* 24 + Hour; }
        }
        public double GetDay 
        {
            get
            {
                return Month * 30 + Day + Hour / 24;
            }
        }
        
        public ShelfLife(byte month,byte day,byte hour)
        {
            this.month = month;
            this.day = day;
            this.hour = hour;
        }
        public override string ToString()
        {
            string str = "";
            if (Month != 0)
            {
                str = Month + " мес.";
            }
            else if (Day != 0)
            {
                str = Day + " дн.";
            }
            else
            {
                str = Hour + " час.";
            }
           

                return str;
        }
    }
}
