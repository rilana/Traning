using System;
using MiniATS.ATS;

namespace MiniATS.Billing
{
    public class BillingData:CallData
    {
        public TimeSpan Duration
        {
            get { return DateTimeEnd - DateTimeStart; }
        }

        public int Cost { get; set; }
        public int IdTariff { get; set; }

        public BillingData() { }

        public BillingData(CallData calldata)
        {
            InPhone = calldata.InPhone;
            OutPhone = calldata.OutPhone;
            DateTimeStart = calldata.DateTimeStart;
            DateTimeEnd = calldata.DateTimeEnd;
        }

    }
}
