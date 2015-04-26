using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public interface IGramm:IProduct
    {
        int Gramm { get; }
    }
}
