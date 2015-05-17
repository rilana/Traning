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

        public Caramel()
            : base()
        { }

        public Caramel(string name, Manufacturer Manufacturer, NutritionalValue NutritionalValue, int Sugar,
            int EnergyValue, int Gramm, BasedSugar BasedSugar, Stuffing? Stuffing)
            :base(name,Manufacturer,NutritionalValue,Sugar,
            EnergyValue,Gramm)
        {
            this.BasedSugar = BasedSugar;
            this.Stuffing = Stuffing;
        }
    }
}
