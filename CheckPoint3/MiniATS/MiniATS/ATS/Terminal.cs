using System;

namespace MiniATS.ATS
{
    public class Terminal
    {
        Port _port = new Port();

        public Port Port
        {
            get { return _port; }
            set { _port = value; }
        }
      
        // Port1
        public Terminal(Port port)
        {
            Port = port;
            Port.ToTerminal += Ring;
        }

        public void OnOffPort()
        {
            Port.PortState = Port.PortState == PortState.Disabled ? PortState.Сonnected : PortState.Disabled;
        }

        public void StartCall(int telephoneNumber)
        {
            if (Port.PortState == PortState.Сonnected)
            {
                var arg = new CallingArg()
                {
                    OutCalling = Port,
                    InNumberPhone = telephoneNumber
                };
               
                Calling += Port.CallFromTerminal;
                Port.PortState = PortState.Busy;
                OnCalling(arg);
                Calling -= Port.CallFromTerminal;
            }
            else
            {
                Console.WriteLine("No signal");
            }
        }

        public bool Ring(CallingArg e)
        {
           Console.WriteLine("Ring.... "+Port.IdPort);
           var rr=new Random();
           var zz = rr.Next(2);
           if (zz==1) 
               Port.PortState=PortState.Busy;
           return zz == 1;
        }

        
        public void FinishCall()
        {
            if (Port.PortState == PortState.Busy)
            {
                //Calling -= Port.CallFromTerminal;
                FinishCalling += Port.FinishTerminal;
                OnFinish();
                FinishCalling-=Port.FinishTerminal;
            }

        }

        public event Action<object> FinishCalling;
        protected virtual void OnFinish()
        {
            var handler = FinishCalling;
            if (handler != null)
            {
                handler(this);
            }
        }

        public event EventHandler<CallingArg> Calling;
        protected virtual void OnCalling(CallingArg e)
        {
            var handler =Calling;
            if (handler != null)
            {
                handler(this, e);
            }
 
        }
    }
}
