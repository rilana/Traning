using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class Caramel:Confection,ICaramel,IStuffing
    {
        public Stuffing? Stuffing{get;set;}
        public BasedSugar BasedSugar { get; set; }
    }
}
