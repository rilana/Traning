using System;
using System.Collections.Generic;
using System.Linq;
using MiniATS.ATS;

namespace MiniATS.Billing
{
    public class Company
    {
        private List<Contract> _contracts=new List<Contract>();
        readonly List<Contract> _historyContracts = new List<Contract>();
        public readonly List<TariffPlane> _tarifPlanes=new List<TariffPlane>();
        private Ats _ats;
        public BillingSystem BilingSystem;

        public List<Contract> Contracts
        {
            get { return _contracts; }
       
        }

        public  Company(Ats ats)
        {
            _ats = ats;
            BilingSystem = new BillingSystem(_contracts);
            SubscriptionAts();
        }

        public void SubscriptionAts()
        {
            _ats.RegistryCalls += BilingSystem.Billing;
            BilingSystem.ToDisabledAbonent+= _ats.SwitchOffPort;

        }

        public void AddTariffPlane(string nameTarif, int mountCost, int minuteCost, TimeSpan freeMinute)
        {
            var id = _tarifPlanes.Any() ? _tarifPlanes.Max(x=>x.IdTariff) + 1:1; 
            _tarifPlanes.Add(
                new TariffPlane(id, nameTarif, mountCost, minuteCost, freeMinute)
                );
        }

        public void CreateContract(Subscriber subscriber, DateTime dateTimeContract)
        {
          var numberContract =_contracts.Count==0?1:_contracts.Max(x => x.NumberContract) + 1;
          var numberPhone = _contracts.Count == 0 ? 111 :_contracts.Max(x => x.NumberPhone) + 1;
         // var idabonent = _contracts. == 0 ? 111 : _contracts.Max(x => x.NumberPhone) + 1;
          subscriber.Terminal = new Terminal(_ats.GeneratyPort(numberPhone));
          subscriber.Specification += BilingSystem.ToTranscript;
          subscriber.ChangeBalance += UnlockSubscriber;
          subscriber.ToTerminate +=ToTerminateContract;
          subscriber.ChangeTarif += BilingSystem.ChangeTarifSubscriber;  
          var contract = new Contract
          {
                Subscriber = subscriber,
                DateTimeContract = dateTimeContract,
                NumberContract = numberContract,
                NumberPhone = numberPhone,
                TarifPlane = _tarifPlanes[0]
            };
          _contracts.Add(contract);
        }
        public void ToTerminateContract(object sender)
        {
            var item=_contracts.Find(x => x.Subscriber == (Subscriber)sender);
            _ats.SwitchOffPort(item.NumberPhone);
            _historyContracts.Add(item);
            item.Subscriber.Specification -= BilingSystem.ToTranscript;
            item.Subscriber.ChangeBalance -= UnlockSubscriber;
            item.Subscriber.ToTerminate -= ToTerminateContract;
            item.Subscriber.ChangeTarif -= BilingSystem.ChangeTarifSubscriber;  
          //item.Subscriber.Terminal = null;
            _contracts.Remove(item);


        }
       
        public void UnlockSubscriber(object sender)
        {
            _ats.SwitchOnPort(_contracts.Find(x => x.Subscriber == (Subscriber)sender).NumberPhone);
        }


      
    
    }
}
