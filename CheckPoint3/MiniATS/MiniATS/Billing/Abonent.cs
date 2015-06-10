
using MiniATS.ATS;
using System;

namespace MiniATS.Billing
{
    public class Abonent
    {
        public string NameAbonent { get; set; }
        public Terminal Terminal { get; set; }
        public int Balance { get; set; }

        public void ReFill(int addMoney)
        {
            Balance += addMoney;
        }
        public void GetSpecification(DateTime dateStart,DateTime dateEnd)
        {
            OnSpecification(new FilterSpecification() { Start = dateStart, End = dateEnd });
            
        }
        public event EventHandler<FilterSpecification> Specification;
        protected virtual void OnSpecification(FilterSpecification e)
        {
            if (Specification != null)
                Specification(this, e);
        }

    }
}
