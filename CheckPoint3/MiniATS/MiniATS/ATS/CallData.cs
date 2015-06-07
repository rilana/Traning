using System;

namespace MiniATS.ATS
{
    public class CallData:EventArgs
    {
        public int OutPhone { get; set; }
        public int InPhone { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }

    }
}
