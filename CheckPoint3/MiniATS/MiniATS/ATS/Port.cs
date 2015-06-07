using System;

namespace MiniATS.ATS
{
    public class Port 
    {

        //Terminal terminal=new Terminal();
        public int IdPort { get; set; }

        public PortState PortState { get; set; }

        public void CallFromTerminal(object sender, CallingArg e)
        {
            OnPortCall(e);
        }
        public void FinishTerminal(object sender, CallingArg e)
        {
            
            OnPortFinishCall(e);
        }

        public bool CallFromAts(CallingArg e)
        {
            return OnTerminal(e);
        }

        public event EventHandler<CallingArg> PortFinishCall;
        protected virtual void OnPortFinishCall(CallingArg e)
        {
            if (PortFinishCall != null)
                PortFinishCall(this, e);
        }

        public event EventHandler<CallingArg> PortCall;
        protected virtual void OnPortCall(CallingArg e)
        {
            if (PortCall != null)
                PortCall(this, e);
        }

        public event Func<CallingArg, bool> ToTerminal;
        protected virtual bool OnTerminal(CallingArg arg)
        {
            var handler = ToTerminal;
            bool temp=false;
            if (handler != null)
            {
               temp = handler(arg);
            }
            return temp;

        }


     
    }
}
