using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public interface IConfection
    {
        string Name { get; }
        Manufacturer Manufacturer { get; }
        int Sugar { get; }
        NutritionalValue NutritionalValue { get; }
        int EnergyValue { get; }
        int Gramm { get; }
    }
}
