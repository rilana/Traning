using System;

namespace MiniATS.Billing
{
    public class FilterSpecification:EventArgs
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public SortReport SortReport { get; set; }
    }
}
