using System;
using System.Threading;
using MiniATS.Billing;
using MiniATS.ATS;

namespace MiniATS
{
    class Program
    {
        static void Main(string[] args)
        {
           Ats.FillCallToList();
           BillingSystem.FillCallToList();

           var company=FillData.CreaterCompany();
           var a1 = company.Contracts[0].Subscriber;
           var a2 = company.Contracts[1].Subscriber;
           var a3 = company.Contracts[2].Subscriber;

            a2.GetSpecification(new DateTime(2015, 6, 1), DateTime.Now,SortReport.Duration);
            company.BilingSystem.ToCalculation(2015, 6);
           //a2.ToTerminateContract();
           //a2.GetSpecification(new DateTime(2015, 6, 1), DateTime.Now, SortReport.Duration);

            a1.ToChangeTariff(company._tarifPlanes[1],DateTime.Now);
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
