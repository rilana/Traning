using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public abstract class Confection:IConfection
    {
        private int sugar;
        public int energyvalue;
        public int gramm;

        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public NutritionalValue NutritionalValue { get; set; }
        public int Sugar
        {
            get 
            {
                return sugar; 
            }
            set
            {
                if (sugar >= 0) sugar = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int EnergyValue
        {
            get
            {
                return energyvalue;
            }
            set
            {
                if (energyvalue >= 0) energyvalue = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Gramm
        {
            get
            {
                return gramm;
            }
            set
            {
                if (gramm >= 0) gramm = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public Confection()
        { }
        public Confection(string Name, Manufacturer Manufacturer, NutritionalValue NutritionalValue,int Sugar,
            int EnergyValue,int Gramm)
        {
            this.Name = Name;
            this.Manufacturer = Manufacturer;
            this.NutritionalValue = NutritionalValue;
            this.Sugar = Sugar;
            this.EnergyValue = EnergyValue;
            this.Gramm = Gramm;

        }

        public override string ToString()
        {
            return "Название - " + Name + ", производитель - " + Manufacturer + ", количество калл. - " + EnergyValue +
                " вес - " + Gramm + " гр., кол. сахара - " + Sugar + " белки - " + NutritionalValue.Fats + " гр. жиры - " + NutritionalValue.Proteins +
                " гр. углеводы - " + NutritionalValue.Carbohydrates + " гр.";
        }
       
        
    }
}
