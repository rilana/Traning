using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class Wafer:Confection,IWafer,IStuffing
    {
        public Dough Dough
        {
            get;
            set;
        }

        public Stuffing? Stuffing
        {
            get;
            set;
        }
    }
}
