using System;

namespace MiniATS.Billing
{
    public class Contract
    {
        public Subscriber Subscriber { get; set; }
        public DateTime DateTimeContract { get; set; }
        public int NumberPhone { get; set; }
        public int NumberContract { get; set; }
        public TariffPlane TarifPlane { get; set; }

    }
}
