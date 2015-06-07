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

    }
}
