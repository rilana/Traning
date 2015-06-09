using System;
using System.Collections.Generic;
using System.Linq;
using MiniATS.ATS;
using System.IO;

namespace MiniATS.Billing
{
    public class Company
    {
        List<Contract> _contracts=new List<Contract>();
        readonly List<TarifPlane> _tarifPlanes=new List<TarifPlane>();
        static List<BillingData> _billingDates = new List<BillingData>();

        private Ats Ats;
       // private BillingSystem BilingSystem;
        public  Company(Ats ats)
        {
            Ats = ats;
            AddTarifPlane("Simple", 50000, 200, new TimeSpan(0,20,0));
            SubscriptionAts();
           // BilingSystem = new BillingSystem();
        }

        public void SubscriptionAts()
        {
            Ats.RegistryCalls += Billing;
        }

        public void AddTarifPlane(string nameTarif, int mountCost, int minuteCost, TimeSpan freeMinute)
        {
            _tarifPlanes.Add(
                new TarifPlane(1,nameTarif, mountCost, minuteCost, freeMinute)
                );
        }

        public void CreateContract(Abonent abonent, DateTime dateTimeContract)
        {
          var numberContract =_contracts.Count==0?1:_contracts.Max(x => x.NumberContract) + 1;
          var numberPhone = _contracts.Count == 0 ? 111 :_contracts.Max(x => x.NumberPhone) + 1;
          abonent.Terminal=new Terminal(Ats.GeneratyPort(numberPhone));
          var contract = new Contract()
            {
                Abonent = abonent,
                DateTimeContract = dateTimeContract,
                NumberContract = numberContract,
                NumberPhone = numberPhone,
                TarifPlane = _tarifPlanes[0]
            };
          _contracts.Add(contract);
        }

        public void Billing(object sender, CallData e)
        {
            var ibillingdata=new BillingData(e);

            var contractOut = _contracts.Find(x => x.NumberPhone == e.OutPhone);
            // pay minute net free minute
            var tempDuration = ibillingdata.Duration;
            var freeMinute=GetFreeMinute(contractOut,e.DateTimeStart);
            tempDuration = tempDuration <= freeMinute ? TimeSpan.Zero :  tempDuration - freeMinute;
            var minuteDuration = tempDuration.Seconds > 0 ? tempDuration.Minutes + 1 : tempDuration.Minutes;

            ibillingdata.Cost = minuteDuration * contractOut.TarifPlane.MinuteCost;
            ibillingdata.IdTariff = contractOut.TarifPlane.IdTarif;

            Console.WriteLine("Billing...");
            _billingDates.Add(ibillingdata);
        }

        private TimeSpan GetFreeMinute (Contract contract,DateTime dateStart)
        {
            TimeSpan durationMont = _billingDates.Where(x => x.OutPhone == contract.NumberPhone
                                   && x.DateTimeStart.Month == dateStart.Month && x.DateTimeStart <= dateStart
                                   && x.DateTimeStart >= contract.DateTimeContract)
                                   .Select(x=>x.Duration)
                                   .Aggregate(new TimeSpan(0), (p, v) => p.Add(v));

            return durationMont>=contract.TarifPlane.FreeMinute?TimeSpan.Zero:contract.TarifPlane.FreeMinute-durationMont;
           
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
                             OutPhone =Convert.ToInt32(temp[0]),
                             InPhone = Convert.ToInt32(temp[1]),
                             DateTimeStart = Convert.ToDateTime(temp[2]),
                             DateTimeEnd = Convert.ToDateTime(temp[3]),
                             Cost = Convert.ToInt32(temp[4]),
                             IdTariff=Convert.ToInt32(temp[5])
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
