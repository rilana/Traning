using System;

namespace MiniATS.ATS
{
    public class Terminal
    {
        private Port _port;
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
            switch (Port.PortState)
            {
                case PortState.Сonnected:
                    var arg = new CallingArg()
                    {
                        OutCalling = Port,
                        InNumberPhone = telephoneNumber
                    };
                    Port.PortState = PortState.Busy;
                    Port.CallFromTerminal(this, arg);
                   break;
                case PortState.Busy:
                    Console.WriteLine("Previous conversation is not over");
                    break;
                default:
                    Console.WriteLine("No signal");
                    break;
            }
        }

        public bool Ring(CallingArg e)
        {
           Console.WriteLine("Ring.... "+Port.IdPort);
           var rr=new Random();
           var zz = rr.Next(2);
           if (zz == 1)
               Port.PortState = PortState.Busy;
            return  zz == 1;
        }
        
        public void FinishCall()
        {
            if (Port.PortState == PortState.Busy)
            {
               
                Port.FinishTerminal(this);
            }
        }
    }
}
