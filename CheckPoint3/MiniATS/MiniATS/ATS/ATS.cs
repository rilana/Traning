using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniATS.ATS
{
    public class Ats
    {
        public event EventHandler<CallData> RegistryCalls;
        public event Func<CallingArg, bool> Сonnected;

        public Dictionary<int, Port> Ports = new Dictionary<int, Port>();
        private readonly Dictionary<int, Port> _disabledPorts = new Dictionary<int, Port>();
        private readonly List<CallData> _activeCalls = new List<CallData>();
        public List<CallData> AllCalls = new List<CallData>(); 

        protected virtual void OnRegistryCalls(CallData e)
        {
            var handler = RegistryCalls;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual bool OnСonnected(CallingArg arg)
        {
            var handler = Сonnected;
            var temp = false;
            if (handler != null)
            {
                temp = handler(arg);

            }
            return temp;
        }
      
        public void AddNew(Port port, int number)
        {
            port.PortCall += CallGetPort;
            port.PortFinishCall += CallFinishPort;
            Ports.Add(number,port);
        }

        public void SwitchOffPort(int numberPhone)
        {
            Ports[numberPhone].PortCall -= CallGetPort;
            Ports[numberPhone].PortFinishCall -= CallFinishPort;
            _disabledPorts.Add(numberPhone, Ports[numberPhone]);
            Ports.Remove(numberPhone);
        }

        public void SwitchOnPort(int numberPhone)
        {
            _disabledPorts[numberPhone].PortCall += CallGetPort;
            _disabledPorts[numberPhone].PortFinishCall += CallFinishPort;
            Ports.Add(numberPhone, _disabledPorts[numberPhone]);
            _disabledPorts.Remove(numberPhone);
        }

        public Port GeneratyPort(int numberPhone)
        {
            var concat=Ports.Values.Concat(_disabledPorts.Values).ToList();
            var nport = new Port() { IdPort = concat.Any() ? concat.Max(x => x.IdPort) + 1:1 };
            AddNew( nport,numberPhone);
            return nport;
        }

        private void RegistryCall(CallData e)
        {
            AllCalls.Add(e);
            OnRegistryCalls(e);
        }

        public void CallGetPort(object sender, CallingArg e)
        {
            var outCaling = Ports.FirstOrDefault(x => x.Value == (Port)sender).Key;
            var callData = new CallData()
            {
                OutPhone = outCaling,
                InPhone = e.InNumberPhone,
                DateTimeStart = DateTime.Now
            };
            e.OutNumberPhone = outCaling;
            Console.WriteLine("{0} -> {1}", outCaling, e.InNumberPhone);
            var connect = false;
            if (Ports.ContainsKey(e.InNumberPhone))
            {
                var portIn = Ports[e.InNumberPhone];
                if (portIn.PortState != PortState.Сonnected)
                {
                    Console.WriteLine("{0} buzzy...", e.InNumberPhone);
                }
                else
                {
                    var answer = portIn.CallFromAts(e);
                    Console.WriteLine(answer ? "Speaking" : "No hang");
                    if (answer)
                    {
                        ((Port) sender).PortState = PortState.Busy;
                        _activeCalls.Add(callData);
                        connect = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("The phone number {0} is not in service Ats", e.InNumberPhone);
            }
            if (!connect)
            {
                ((Port)sender).PortState = PortState.Сonnected;
                callData.DateTimeEnd = callData.DateTimeStart;
                RegistryCall(callData);
            }
        }

        public void CallFinishPort(object sender)
        {
            var numberPhoneFinish = Ports.FirstOrDefault(x => x.Value == (Port)sender).Key;
            var item = _activeCalls.Find(x => x.OutPhone == numberPhoneFinish || x.InPhone == numberPhoneFinish);
            Ports.FirstOrDefault(x => x.Key == item.InPhone).Value.PortState = PortState.Сonnected;
            Ports.FirstOrDefault(x => x.Key == item.OutPhone).Value.PortState = PortState.Сonnected;
            item.DateTimeEnd = DateTime.Now.AddMinutes(5);
            _activeCalls.Remove(item);
            RegistryCall(item);
        }
      }
}
