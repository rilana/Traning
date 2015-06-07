using System;

namespace MiniATS.Billing
{
    public class Contract
    {
        public Abonent Abonent { get; set; }
        public DateTime DateTimeContract { get; set; }
        public int NumberPhone { get; set; }
        public int NumberContract { get; set; }
        public TarifPlane TarifPlane { get; set; }

    }
}
