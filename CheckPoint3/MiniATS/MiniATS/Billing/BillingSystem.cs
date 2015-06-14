using MiniATS.ATS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniATS.Billing
{
    public class BillingSystem
    {
        static List<BillingData> _billingDates = new List<BillingData>();
        List<Contract> _contracts;
        public BillingSystem(List<Contract> contracts)
        {
           _contracts = contracts;
        }
        //Calculate your one call
        public void Billing(object sender, CallData e)
        {
            var ibillingdata = new BillingData(e);
            var contractOut = _contracts.Find(x => x.NumberPhone == e.OutPhone);
            // pay minute net free minute
            var tempDuration = ibillingdata.Duration;
            var freeMinute = GetFreeMinute(contractOut, e.DateTimeStart);
            tempDuration = tempDuration <= freeMinute ? TimeSpan.Zero : tempDuration - freeMinute;
            var minuteDuration = tempDuration.Seconds > 0 ? tempDuration.Minutes + 1 : tempDuration.Minutes;

            ibillingdata.Cost = minuteDuration * contractOut.TarifPlane.MinuteCost;
            ibillingdata.IdTariff = contractOut.TarifPlane.IdTariff;

            Console.WriteLine("Billing...");
            _billingDates.Add(ibillingdata);
        }
         
        private TimeSpan GetFreeMinute(Contract contract, DateTime dateStart)
        {
            var durationMont = _billingDates.Where(x => x.OutPhone == contract.NumberPhone
                                   && x.DateTimeStart.Month == dateStart.Month && x.DateTimeStart <= dateStart
                                   && x.IdTariff==contract.TarifPlane.IdTariff)
                                   .Select(x => x.Duration)
                                   .Aggregate(new TimeSpan(0), (p, v) => p.Add(v));
            return durationMont >= contract.TarifPlane.FreeMinute ? TimeSpan.Zero : contract.TarifPlane.FreeMinute - durationMont;

        }
        // conclusion of subscriber details
        public void ToTranscript(object sender, FilterSpecification e)
        {

            var abonent = (sender as Subscriber);
            var tempcontract = _contracts.Find(x => x.Subscriber == abonent);
            var temp = from bill in _billingDates.Where(x => (x.OutPhone == tempcontract.NumberPhone
                                                        || x.InPhone == tempcontract.NumberPhone)
                                                        && x.DateTimeStart >= e.Start && x.DateTimeStart <= e.End)
                        join ab2 in _contracts on bill.OutPhone equals ab2.NumberPhone
                        join ab1 in _contracts on bill.InPhone equals ab1.NumberPhone
                        select new
                        {
                            bill.Cost, 
                            subscriberOut = ab2.Subscriber,
                            subscriberIn=ab1.Subscriber,
                            bill.DateTimeStart,
                            bill.DateTimeEnd,
                            bill.Duration

                        };
            
            
            switch (e.SortReport)
            {
                case SortReport.Data:
                    temp = temp.OrderBy(x => x.DateTimeStart);
                    break;
                case SortReport.Price:
                    temp = temp.OrderBy(x => x.Cost);
                    break;
                case SortReport.SubscriberOut:
                    temp = temp.Where(x => x.subscriberOut == abonent).OrderBy(x => x.subscriberIn.NameSubscriber); 
                    break;
                case SortReport.SubscriberIn:
                    temp = temp.Where(x => x.subscriberIn == abonent).OrderBy(x => x.subscriberOut.NameSubscriber); 
                    break;
                default:
                    temp = temp.OrderBy(x => x.Duration);
                    break;
            }

            foreach (var item in temp)
            {
                var tempOutOIn = item.subscriberOut == abonent
                                ? string.Format("->{0,10}   {1,10}", item.subscriberIn.NameSubscriber, item.Cost)
                                : string.Format("<-{0,10}   {1,10}", item.subscriberOut.NameSubscriber,0);
                Console.WriteLine("{0}  {1}   {2}   {3}", item.DateTimeStart.ToShortDateString(),
                    item.DateTimeStart.ToShortTimeString(),
                    item.Duration, tempOutOIn);
            }

            Console.WriteLine("Sum total - {0}, duration outcals - {1}, incalls - {2}",
                                            GetSumTotalMoney(tempcontract, e),
                                            GetSumTotalTimeOut(tempcontract, e),
                                             GetSumTotalTimeIn(tempcontract, e));
        }
        // return totat money for a specified period
        public int GetSumTotalMoney(Contract contract, FilterSpecification e)
        {
            return _billingDates.Where(x => x.OutPhone == contract.NumberPhone
                && x.DateTimeStart >= e.Start
                && x.DateTimeStart <= e.End).Sum(x => x.Cost);
        }

        public TimeSpan GetSumTotalTimeOut(Contract contract, FilterSpecification e)
        {
            return _billingDates.Where(x => x.OutPhone == contract.NumberPhone
                                      && x.DateTimeStart >= e.Start
                                      && x.DateTimeStart <= e.End)
                                .Select(x => x.Duration)
                                .Aggregate(new TimeSpan(0), (p, v) => p.Add(v));
        }
        // incoming calls for a specified period
        public TimeSpan GetSumTotalTimeIn(Contract contract, FilterSpecification e)
        {
            return _billingDates.Where(x => x.InPhone == contract.NumberPhone
                                      && x.DateTimeStart >= e.Start
                                      && x.DateTimeStart <= e.End)
                                .Select(x => x.Duration)
                                .Aggregate(new TimeSpan(0), (p, v) => p.Add(v));
        }
        //The calculation of the month for all subscribers
        public void ToCalculation(int year, int month)
        {
            var query = (from ab in _contracts
                         join bill in _billingDates on ab.NumberPhone equals bill.OutPhone
                         where bill.DateTimeStart.Year == year && bill.DateTimeStart.Month == month
                         select new { abonent = ab, cost = bill.Cost } into x
                         group x by x.abonent into g
                         select new 
                         {
                             abonent = g.Key.Subscriber, 
                             numberPhone=g.Key.NumberPhone,
                             sum = g.Sum(x => x.cost) + g.Key.TarifPlane.MonthCost
                         }).ToList();
            foreach (var item in query)
            {
                item.abonent.ReFill(-1* item.sum);
                if (item.abonent.Balance < 0) OnDisabledAbonent(item.numberPhone);
            }
       }
        public bool ChangeTarifSubscriber(object sender, TariffPlane tarif,DateTime date)
        {
            var item = _contracts.Find(x => x.Subscriber == (Subscriber)sender);
            var countTarif=_billingDates.Where(x => x.DateTimeStart.Year == date.Year &&
                        x.DateTimeStart.Month == date.Month&&
                        x.OutPhone==item.NumberPhone).
                        Select(x => x.IdTariff).
                        Distinct().
                        Count();
            if (countTarif < 2)
            {
                item.TarifPlane = tarif;
                return true;
            }
            return false;
            
        }
        public event Action<int> ToDisabledAbonent;
        protected virtual void OnDisabledAbonent(int arg)
        {
            var handler = ToDisabledAbonent;
            if (handler != null)
            {
               handler(arg);
            }
           
        }


        #region fill data
        public static void FillCallToList()
        {
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
        }

        public static void FillCallToFile()
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
