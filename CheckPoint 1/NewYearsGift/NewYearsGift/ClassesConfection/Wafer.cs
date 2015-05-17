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

        public Wafer()
            : base()
         { }

        public Wafer(string name, Manufacturer Manufacturer, NutritionalValue NutritionalValue, int Sugar,
            int EnergyValue, int Gramm, Dough Dough, Stuffing? Stuffing)
            :base(name,Manufacturer,NutritionalValue,Sugar,
            EnergyValue,Gramm)
        {
            this.Dough = Dough;
            this.Stuffing = Stuffing;
        }
    }
}
