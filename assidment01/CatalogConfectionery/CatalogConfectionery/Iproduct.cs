using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public interface IProduct
    {
        string Name { get; }
        TimeSpan ShelfLife { get; }
        DateTime CreationDate { get; }
        int EnergyValue { get; }
        Rating Rating { get; }
    }
}
