using System;
using System.Threading;
using MiniATS.Billing;

namespace MiniATS
{
    class Program
    {
        static void Main(string[] args)
        {
            var ats = new ATS.Ats();
            ATS.Ats.FillCallToList();
            var company=new Company(ats);
            BillingSystem.FillCallToList();

            var a1 = new Subscriber() { NameSubscriber = "Ivan" };
            var a2 = new Subscriber() { NameSubscriber = "Nastya" };
            var a3 = new Subscriber() { NameSubscriber = "Petr" };
            company.CreateContract(a1,new DateTime(2015,01,12));
            company.CreateContract(a2, new DateTime(2015, 01, 12));
            company.CreateContract(a3, new DateTime(2015, 01, 10));

            a1.GetSpecification(new DateTime(2015, 6, 1), DateTime.Now);
            //company.BilingSystem.ToCalculation(2015, 6);
            a1.ReFill(70000);
           // company.Disconect();

            a1.Terminal.StartCall(112);
            Thread.Sleep(2000);
            a3.Terminal.StartCall(112);
            a1.Terminal.FinishCall();

            a2.Terminal.StartCall(111);
            Thread.Sleep(2000);
            a2.Terminal.FinishCall();

          

            a3.Terminal.OnOffPort();
            a1.Terminal.StartCall(113);
            Thread.Sleep(2000);
            a1.Terminal.FinishCall();

            a1.Terminal.StartCall(112);
            Thread.Sleep(2000);
            a1.Terminal.FinishCall();


            BillingSystem.FillCallToFile();
            ATS.Ats.FillCallToFile();
            Console.WriteLine("Finish");
            Console.ReadLine();

            
          

         

            
        }
    }
}
