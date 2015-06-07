using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MiniATS.Billing;

namespace MiniATS
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //var port1 = new Port() { IdPort = 1};
            //var port2 = new Port() { IdPort = 2 };
            //var port3 = new Port() { IdPort = 3 };
            //var t1 = new Terminal() {Port=port1};
            //var t2 = new Terminal() { Port = port2 };
            //var t3 = new Terminal() { Port = port3 };

            //t2.Port.ToTerminal += t2.Ring;
            //t1.Port.ToTerminal += t1.Ring;
            //t3.Port.ToTerminal += t3.Ring;

            //var ats = new ATS();
            //ATS.FillCallToList();

             //ats.Add(port1, 12345);
             //ats.Add(port2, 22122);
             //ats.Add(port3, 13579);

             //t1.StartCall(22122);
             //var rr = new Random();
             //var duration = rr.Next(5000, 10000);
             //Thread.Sleep(duration);
             //t2.FinishCall();

             //t2.StartCall(13579);
             //duration = rr.Next(5000, 10000);
             //Thread.Sleep(duration);
             //t2.FinishCall();

             //t3.OnOffPort();
             //t1.StartCall(13579);
             //duration = rr.Next(5000, 10000);
             //Thread.Sleep(duration);
             //t1.FinishCall();

             //ATS.FillCallToFile();
            var ats = new ATS.Ats();
            ATS.Ats.FillCallToList();
            var company=new Company(ats);
            var a1=new Abonent(){NameAbonent = "Ivan"};
            var a2 = new Abonent() { NameAbonent = "Nastya" };
            company.CreateContract(a1,new DateTime(2015,01,12));
            company.CreateContract(a2, new DateTime(2015, 01, 12));

            a1.Terminal.StartCall(112);
            Thread.Sleep(2000);
            a1.Terminal.FinishCall();

            ATS.Ats.FillCallToFile();
            Console.WriteLine("Finish");
            Console.ReadLine();

            
          

         

            
        }
    }
}
