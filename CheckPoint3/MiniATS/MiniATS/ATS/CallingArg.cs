using System;

namespace MiniATS.ATS
{
    public class CallingArg:EventArgs
    {
        public PortState PortState { get; set; }
        public Port OutCalling { get; set; }
        public int InNumberPhone { get; set; }
        public int OutNumberPhone { get; set; }
    }
}
