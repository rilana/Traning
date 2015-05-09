using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public interface IConfection:IGiftItems
    {
        int Sugar { get; }
        NutritionalValue NutritionalValue { get; }
        int EnergyValue { get; }
        int Gramm { get; }
    }
}
