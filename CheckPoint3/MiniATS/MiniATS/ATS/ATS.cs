using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniATS.ATS
{
    public class Ats
    {
        public Dictionary<Port, int> Ports=new Dictionary<Port,int>();
        private List<CallData> _activeCalls=new List<CallData>(); 
        static public List<CallData> AllCalls =new List<CallData>(); 
      
        public void Add(Port port, int number)
        {
            port.PortCall += CallGetPort;
            port.PortFinishCall += CallFinishPort;
            Ports.Add(port, number);
        }

        public Port GeneratyPort(int numberPhone)
        {
            var nport =new Port(){IdPort =Ports.Count==0?1:Ports.Keys.Max(x => x.IdPort) + 1};
            Add( nport,numberPhone);
            return nport;
        }

        private void RegistryCall(CallData e)
        {
            AllCalls.Add(e);
            OnRegistryCalls(e);

        }

        public void CallGetPort(object sender, CallingArg e)
        {
            var outCaling = Ports[((Port) sender)];
            e.OutNumberPhone= outCaling;
           var portIn = Ports.FirstOrDefault(x=>x.Value==e.InNumberPhone).Key;

            var callData = new CallData()
            {
                OutPhone = e.OutNumberPhone,
                InPhone = e.InNumberPhone,
                DateTimeStart = DateTime.Now
            };

            if (portIn.PortState != PortState.Сonnected)
            {
                Console.WriteLine("{0} buzzy...", e.InNumberPhone);
                callData.DateTimeEnd = callData.DateTimeStart;
                ((Port)sender).PortState = PortState.Сonnected;
                RegistryCall(callData);

            }
            else
            {
                Сonnected = null;
                Сonnected += portIn.CallFromAts;
                var answer = OnСonnected(e);
                Console.WriteLine(answer ? "Speaking" : "No hang");
                if (answer)
                {
                    ((Port) sender).PortState = PortState.Busy;
                    _activeCalls.Add(callData);
                   
                }
                else
                {
                    ((Port) sender).PortState = PortState.Сonnected;
                    callData.DateTimeEnd = callData.DateTimeStart;
                    RegistryCall(callData);
                }
            }
            


        }

        public void CallFinishPort(object sender, CallingArg e)
        {
            var numberPhoneFinish = Ports[(Port)sender];
            var item = _activeCalls.Find(x => x.OutPhone == numberPhoneFinish || x.InPhone == numberPhoneFinish);
            Ports.FirstOrDefault(x => x.Value == item.InPhone).Key.PortState = PortState.Сonnected;
            Ports.FirstOrDefault(x => x.Value == item.OutPhone).Key.PortState = PortState.Сonnected;
            item.DateTimeEnd = DateTime.Now;
            _activeCalls.Remove(item);

            RegistryCall(item);
        }




        public event EventHandler<CallData> RegistryCalls;
        protected virtual void OnRegistryCalls(CallData e)
        {
            var handler = RegistryCalls; 
            if (handler != null)
            {
                handler(this, e);
            }

        }

        public event Func<CallingArg, bool> Сonnected;
        protected virtual bool OnСonnected(CallingArg arg)
        {
            var handler = Сonnected;
            var temp = false;
            if (handler != null)
            {
                temp=handler(arg);

            }
            return temp;

        }
        #region fill data
        public static void FillCallToList()
        {
            
            using (var sr = new StreamReader("CallData.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var temp = line.Split(';');
                     AllCalls.Add(
                         new CallData()
                         {
                             OutPhone =Convert.ToInt32(temp[0]),
                             InPhone = Convert.ToInt32(temp[1]),
                             DateTimeStart = Convert.ToDateTime(temp[2]),
                             DateTimeEnd = Convert.ToDateTime(temp[3])
                         }
                         );
                }
            }
        }
        public static void FillCallToFile()
        {
            using (var sw = new StreamWriter("CallData.csv"))
            {
                foreach (var temp in AllCalls)
                {
                    sw.WriteLine("{0};{1};{2};{3}", temp.OutPhone, temp.InPhone, temp.DateTimeStart, temp.DateTimeEnd);
                }
            }


        }
        #endregion
    }
}
