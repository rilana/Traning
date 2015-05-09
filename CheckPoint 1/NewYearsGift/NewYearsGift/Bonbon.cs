using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class Bonbon:Confection,IBonbon
    {
        public bool glazed {get;set;}
        public CandyMasses CandyMasses { get; set; }
       
    }
}
