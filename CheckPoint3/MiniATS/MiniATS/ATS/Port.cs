using System;

namespace MiniATS.ATS
{
    public class Port 
    {
        public event Action<object> PortFinishCall;
        public event EventHandler<CallingArg> PortCall;
        public event Func<CallingArg, bool> ToTerminal;
        //Terminal terminal=new Terminal();
        public int IdPort { get; set; }
        public PortState PortState { get; set; }
        //+/-
        public void CallFromTerminal(object sender, CallingArg e)
        {
            OnPortCall(e);
        }
        //+/-
        public void FinishTerminal(object sender)
        {
            OnPortFinishCall();
        }
        //+/-
        public bool CallFromAts(CallingArg e)
        {
            return OnTerminal(e);
        }

        protected virtual void OnPortFinishCall()
        {
            if (PortFinishCall != null)
                PortFinishCall(this);
        }
      
        protected virtual void OnPortCall(CallingArg e)
        {
            var handler = PortCall;
            if (handler != null)
            {
                handler(this, e);
            }
            else
            {
                PortState = PortState.Сonnected;
                Console.WriteLine("Ats does not answer!");
            }
        }
        
        protected virtual bool OnTerminal(CallingArg arg)
        {
            var handler = ToTerminal;
            var temp=false;
            if (handler != null)
            {
               temp = handler(arg);
            }
            return temp;
        }
    }
}
