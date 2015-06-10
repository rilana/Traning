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
        private Ats Ats;
        public BillingSystem BilingSystem;
        public  Company(Ats ats)
        {
            Ats = ats;
            AddTarifPlane("Simple", 50000, 200, new TimeSpan(0,20,0));
            BilingSystem = new BillingSystem(_contracts);
            SubscriptionAts();
        }

        public void SubscriptionAts()
        {
            Ats.RegistryCalls += BilingSystem.Billing;
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
         // var idabonent = _contracts. == 0 ? 111 : _contracts.Max(x => x.NumberPhone) + 1;
          abonent.Terminal=new Terminal(Ats.GeneratyPort(numberPhone));
          abonent.Specification +=BilingSystem.ToTranscript;
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
        public void Disconect()
        {
            //block users with a negative balance
            Ats.AddDsabledPort(111);
        }

      
    
    }
}
