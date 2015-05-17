using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public interface IBonbon:IConfection
    {
        bool Glazed {get;}
        CandyMasses CandyMasses { get; }
    }
}
