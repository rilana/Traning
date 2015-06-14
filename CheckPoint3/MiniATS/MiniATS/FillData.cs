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

            a1.ReFill(50000);
            a2.ReFill(15000);
            a3.ReFill(50000);

            company.AddTariffPlane("Simple", 50000, 200, new TimeSpan(0, 20, 0));
            company.AddTariffPlane("NoSimple", 150000, 0, new TimeSpan(0, 0, 0));


            company.CreateContract(a1, new DateTime(2015, 01, 12),company._tarifPlanes[0]);
            company.CreateContract(a2, new DateTime(2015, 01, 12),company._tarifPlanes[1]);
            company.CreateContract(a3, new DateTime(2015, 01, 10), company._tarifPlanes[0]);
            return company;
        }
    }
}
