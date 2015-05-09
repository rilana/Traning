using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public interface IBonbon:IConfection
    {
        bool glazed {get;}
        CandyMasses CandyMasses { get; }
    }
}
