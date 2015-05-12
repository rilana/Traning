using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public abstract class Confection:GiftItems,IConfection
    {
        public int Sugar{ get;set;}
        public NutritionalValue NutritionalValue { get; set; }
        public int EnergyValue{ get;set;}
        public int Gramm{ get;set;}

       
        
    }
}
