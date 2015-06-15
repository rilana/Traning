using System;
using MiniATS.Billing;
using System.IO;
using MiniATS.ATS;
using System.Collections.Generic;

namespace MiniATS
{
    class FillData
    {
        public static Company CreaterCompany()
        {
            var ats = new Ats();
            var company = new Company(ats) {BilingSystem = {_billingDates = FillCallToList()}};

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
        #region fill data
        public static List<BillingData> FillCallToList()
        {
            var _billingDates=new List<BillingData>();
            using (var sr = new StreamReader("BillingData.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var temp = line.Split(';');
                    _billingDates.Add(
                         new BillingData()
                         {
                             OutPhone = Convert.ToInt32(temp[0]),
                             InPhone = Convert.ToInt32(temp[1]),
                             DateTimeStart = Convert.ToDateTime(temp[2]),
                             DateTimeEnd = Convert.ToDateTime(temp[3]),
                             Cost = Convert.ToInt32(temp[4]),
                             IdTariff = Convert.ToInt32(temp[5])
                         }
                         );
                }
            }
            return _billingDates;
        }

        public static void FillCallToFile(List<BillingData> _billingDates)
        {
            using (var sw = new StreamWriter("BillingData.csv"))
            {
                foreach (var temp in _billingDates)
                {
                    sw.WriteLine("{0};{1};{2};{3};{4};{5}",
                        temp.OutPhone,
                        temp.InPhone,
                        temp.DateTimeStart,
                        temp.DateTimeEnd,
                        temp.Cost,
                        temp.IdTariff);
                }
            }
        }
        #endregion
    }
}
