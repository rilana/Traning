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

        public ShelfLife ShelfLife
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
        public Rating Rating
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "название -"+Name+"; срок годности -"+ShelfLife.ToString()+", энергетическая ценность -"+EnergyValue;
        }
    }
}
