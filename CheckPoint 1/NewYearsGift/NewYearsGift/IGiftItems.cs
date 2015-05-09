using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public interface IGiftItems
    {
       string Name { get; }
       Manufacturer Manufacturer { get; }
    }
}
