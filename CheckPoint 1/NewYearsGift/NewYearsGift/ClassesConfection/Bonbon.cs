using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class Bonbon:Confection,IBonbon
    {
        public bool Glazed {get;set;}
        public CandyMasses CandyMasses { get; set; }

        public Bonbon()
            : base()
        { }

        public Bonbon(string name, Manufacturer Manufacturer, NutritionalValue NutritionalValue, int Sugar,
            int EnergyValue, int Gramm, bool Glazed, CandyMasses CandyMasses)
            :base(name,Manufacturer,NutritionalValue,Sugar,
            EnergyValue,Gramm)
        {
            this.Glazed = Glazed;
            this.CandyMasses = CandyMasses;
        }
       
    }
}
