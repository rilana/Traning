using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
     //содержание на 100 гр. продукта
    public struct NutritionalValue
    {
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

        public NutritionalValue(double proteins, double fats, double carbohydrates)
            : this()
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
        
     }
}
