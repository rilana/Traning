using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class Chocolate:Confection,IChocolate,IStuffing
    {
        private int cocoa;
        public int Cocao 
        {
            get
            {
                return cocoa;
            }
            set
            {
                if (cocoa >= 0) cocoa = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public Stuffing? Stuffing { get; set; }

        public Chocolate()
            : base()
        { }

        public Chocolate(string name, Manufacturer Manufacturer, NutritionalValue NutritionalValue,int Sugar,
            int EnergyValue,int Gramm, int Cocao,Stuffing? Stuffing)
            :base(name,Manufacturer,NutritionalValue,Sugar,
            EnergyValue,Gramm)
        {
            this.Cocao = Cocao;
            this.Stuffing = Stuffing;
        }

    }
}
