
using MiniATS.ATS;
using System;

namespace MiniATS.Billing
{
    public class Subscriber
    {
        public string NameSubscriber { get; set; }
        public Terminal Terminal { get; set; }
        int balance;
        public int Balance
        {
            get
            {
                return balance;
            } 
            private set
            {
                 if ((balance<0)&&(value>0))
                 
                 {
                     OnChangeBalance();
                 }
                balance = value;
               
            }
        }
        public bool ToChangeTarif(int IdTarif,DateTime date)
        {
            return OnChangeTarif(IdTarif, date);
        }
        public void ReFill(int addMoney)
        {
            Balance += addMoney;
        }
        public void ToTerminateContract()
        {
            OnToTerminate();
        }
        public void GetSpecification(DateTime dateStart,DateTime dateEnd)
        {
            OnSpecification(new FilterSpecification() { Start = dateStart, End = dateEnd });
            
        }

        public event Action<object> ToTerminate;
        protected virtual void OnToTerminate()
        {
            if (ToTerminate != null)
                ToTerminate(this);
        }
        public event Func<object,int,DateTime,bool> ChangeTarif;
        protected virtual bool OnChangeTarif(int arg, DateTime date)
        {
            if (ChangeTarif != null)
               return ChangeTarif(this,arg,date);
            return false;
        }
        public event Action<object> ChangeBalance;
        protected virtual void OnChangeBalance()
        {
            if (ChangeBalance != null)
                ChangeBalance(this);
        }
        public event EventHandler<FilterSpecification> Specification;
        protected virtual void OnSpecification(FilterSpecification e)
        {
            if (Specification != null)
                Specification(this, e);
        }
        
    }
}
