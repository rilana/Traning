using System;
using MiniATS.Billing;

namespace MiniATS
{
    class FillData
    {
        public static Company CreaterCompany()
        {
            var ats = new ATS.Ats();
            var company = new Company(ats);
            var a1 = new Subscriber() { NameSubscriber = "Ivan" };
            var a2 = new Subscriber() { NameSubscriber = "Nastya" };
            var a3 = new Subscriber() { NameSubscriber = "Petr" };
            company.AddTariffPlane("Simple", 50000, 200, new TimeSpan(0, 20, 0));
            company.AddTariffPlane("NoSimple", 150000, 0, new TimeSpan(0, 20, 0));
            company.CreateContract(a1, new DateTime(2015, 01, 12));
            company.CreateContract(a2, new DateTime(2015, 01, 12));
            company.CreateContract(a3, new DateTime(2015, 01, 10));
            return company;
        }
    }
}
