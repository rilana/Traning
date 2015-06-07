
using MiniATS.ATS;

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

    }
}
