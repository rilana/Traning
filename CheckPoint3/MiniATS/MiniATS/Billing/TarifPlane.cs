
namespace MiniATS.Billing
{
    public struct TarifPlane
    {
        public string NameTarif { get; set; }
        public int MonthCost { get; set; }
        public int MinuteCost { get; set; }
        public int FreeMinute { get; set; }

        public  TarifPlane(string nameTarif, int mountCost,int minuteCost,int freeMinute):this()
        {
            NameTarif = nameTarif;
            MonthCost = mountCost;
            MinuteCost = minuteCost;
            FreeMinute = freeMinute;
        }
    }
}
