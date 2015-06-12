using System;
using System.Collections.Generic;
using System.Linq;
using MiniATS.ATS;

namespace MiniATS.Billing
{
    public class Company
    {
        List<Contract> _contracts=new List<Contract>();
        readonly List<Contract> _historyContracts = new List<Contract>();
        public readonly List<TariffPlane> _tarifPlanes=new List<TariffPlane>();
        private Ats Ats;
        public BillingSystem BilingSystem;
        public  Company(Ats ats)
        {
            Ats = ats;
            AddTariffPlane("Simple", 50000, 200, new TimeSpan(0,20,0));
            AddTariffPlane("NoSimple", 150000, 0, new TimeSpan(0, 20, 0));
            BilingSystem = new BillingSystem(_contracts);
            SubscriptionAts();
        }

        public void SubscriptionAts()
        {
            Ats.RegistryCalls += BilingSystem.Billing;
            BilingSystem.ToDisabledAbonent+= Ats.SwitchOffPort;

        }

        public void AddTariffPlane(string nameTarif, int mountCost, int minuteCost, TimeSpan freeMinute)
        {
            var id = _tarifPlanes.Count() == 0 ? 1 : _tarifPlanes.Max(x=>x.IdTariff) + 1; 
            _tarifPlanes.Add(
                new TariffPlane(id, nameTarif, mountCost, minuteCost, freeMinute)
                );
        }

        public void CreateContract(Subscriber subscriber, DateTime dateTimeContract)
        {
          var numberContract =_contracts.Count==0?1:_contracts.Max(x => x.NumberContract) + 1;
          var numberPhone = _contracts.Count == 0 ? 111 :_contracts.Max(x => x.NumberPhone) + 1;
         // var idabonent = _contracts. == 0 ? 111 : _contracts.Max(x => x.NumberPhone) + 1;
          subscriber.Terminal = new Terminal(Ats.GeneratyPort(numberPhone));
          subscriber.Specification += BilingSystem.ToTranscript;
          subscriber.ChangeBalance += UnlockSubscriber;
          subscriber.ToTerminate +=ToterminateContract;
          subscriber.ChangeTarif += BilingSystem.ChangeTarifSubscriber;  
          var contract = new Contract()
            {
                Subscriber = subscriber,
                DateTimeContract = dateTimeContract,
                NumberContract = numberContract,
                NumberPhone = numberPhone,
                TarifPlane = _tarifPlanes[0]
            };
          _contracts.Add(contract);
        }
        public void ToterminateContract(object sender)
        {
            var item=_contracts.Find(x => x.Subscriber == (Subscriber)sender);
            Ats.SwitchOffPort(item.NumberPhone);
            _historyContracts.Add(item);
            item.Subscriber.Terminal = null;
            _contracts.Remove(item);


        }
       
        public void UnlockSubscriber(object sender)
        {
            Ats.SwitchOnPort(_contracts.Find(x => x.Subscriber == (Subscriber)sender).NumberPhone);
        }


      
    
    }
}
