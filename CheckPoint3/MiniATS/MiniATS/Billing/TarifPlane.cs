
using System;
namespace MiniATS.Billing
{
    public struct TarifPlane
    {
        private readonly int _idtarif;
        public int IdTarif { get; set; }
        public string NameTarif { get; set; }
        public int MonthCost { get; set; }
        public int MinuteCost { get; set; }
        public TimeSpan FreeMinute { get; set; }

        public  TarifPlane(int idtarif,string nameTarif, int mountCost,int minuteCost,TimeSpan freeMinute):this()
        {
            _idtarif = idtarif;
            IdTarif=IdTarif;
            NameTarif = nameTarif;
            MonthCost = mountCost;
            MinuteCost = minuteCost;
            FreeMinute = freeMinute;
        }
    }
}
