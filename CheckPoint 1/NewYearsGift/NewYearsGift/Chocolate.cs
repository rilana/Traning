using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class Chocolate:Confection,IChocolate,IStuffing
    {
        public int cocao { get; set; }
        public Stuffing Stuffing { get; set; }
        
    }
}
