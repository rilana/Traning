using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public class Product:IProduct
    {
        public string Name
        {
            get;
            set;
        }

        public int ShelfLife
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }
        public int EnergyValue
        {
            get;
            set;
        }
    }
}
