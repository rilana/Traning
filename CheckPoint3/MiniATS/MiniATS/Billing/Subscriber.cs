
using MiniATS.ATS;
using System;

namespace MiniATS.Billing
{
    public class Subscriber
    {
        public event Action<object> ChangeBalance;
        public event EventHandler<FilterSpecification> Specification;
        public event Func<object, TariffPlane, DateTime, bool> ChangeTarif;
        public event Action<object> ToTerminate;

        public string NameSubscriber { get; set; }
        public Terminal Terminal { get; set; }
        private int _balance;

        public int Balance
        {
            get
            {
                return _balance;
            } 
            private set
            {
                 if ((_balance<0)&&(value>0))
                 
                 {
                     OnChangeBalance();
                 }
                _balance = value;
            }
        }
        public void ToChangeTariff(TariffPlane tarif, DateTime date)
        {
            Console.WriteLine(OnChangeTarif(tarif, date)
                ? "You have successfully changed the tariff"
                : "You can not change the tariff (you have changed the rate this month)");
        }

        public void ReFill(int addMoney)
        {
            Balance += addMoney;
        }

        public void ToTerminateContract()
        {
            OnToTerminate();
        }

        public void GetSpecification(DateTime dateStart,DateTime dateEnd, SortReport sortReport)
        {
            OnSpecification(new FilterSpecification() { Start = dateStart, End = dateEnd,SortReport = sortReport});
        }
        
        protected virtual void OnToTerminate()
        {
            if (ToTerminate != null)
                ToTerminate(this);
        }
       
        protected virtual bool OnChangeTarif(TariffPlane tarifPlane, DateTime date)
        {
            return ChangeTarif != null && ChangeTarif(this,tarifPlane,date);
        }

      
        protected virtual void OnChangeBalance()
        {
            if (ChangeBalance != null)
                ChangeBalance(this);
        }
       
        protected virtual void OnSpecification(FilterSpecification e)
        {
            if (Specification != null)
                Specification(this, e);
        }
        
    }
}
