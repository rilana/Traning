using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public class Chocolate:Product,IGramm,IStuffing
    {
        public int Gramm
        {
            get;
            set;
        }

        public Stuffing? stuffing
        {
            get;
            set;
        }
    }
}
