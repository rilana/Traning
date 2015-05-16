using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public struct Stuffing
    {
     
        public string Description
        {
            get;
            set;
        }
        public Stuffing(string description)
            : this()
        {
          
            Description = description;
        }
    }
}
