using System;
using System.Collections.Generic;
using System.Linq;
using MiniATS.ATS;

namespace MiniATS.Billing
{
    public class Company
    {
        List<Contract> _contracts=new List<Contract>();
        readonly List<TarifPlane> _tarifPlanes=new List<TarifPlane>();

        private ATS.Ats Ats; 
        public  Company(ATS.Ats ats)
        {
            Ats = ats;
            AddTarifPlane("Simple", 50000, 200, 0);
            SubscriptionAts();
        }

        public void SubscriptionAts()
        {
            Ats.RegistryCalls += Billing;
        }

        public void AddTarifPlane(string nameTarif, int mountCost, int minuteCost, int freeMinute)
        {
            _tarifPlanes.Add(
                new TarifPlane(nameTarif, mountCost, minuteCost, freeMinute)
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
            //TODO
            Console.WriteLine("Billing...");
        }
    }
}
