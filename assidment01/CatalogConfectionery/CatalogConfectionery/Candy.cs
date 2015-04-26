using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public class Candy:Product,IStuffing
    {
        public Stuffing? stuffing
        {
            get;
            set;
        }
    }
}
