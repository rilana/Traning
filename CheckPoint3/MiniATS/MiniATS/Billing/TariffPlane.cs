
using System;
namespace MiniATS.Billing
{
    public struct TariffPlane
    {
        public int IdTariff { get; set; }
        public string NameTariff { get; set; }
        public int MonthCost { get; set; }
        public int MinuteCost { get; set; }
        public TimeSpan FreeMinute { get; set; }

        public  TariffPlane(int idtariff,string nameTariff, int mountCost,int minuteCost,TimeSpan freeMinute):this()
        {
            IdTariff = idtariff;
            IdTariff=IdTariff;
            NameTariff = nameTariff;
            MonthCost = mountCost;
            MinuteCost = minuteCost;
            FreeMinute = freeMinute;
        }
    }
}
