using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public struct Stuffing
    {
       
        public string Name {
            get;
            set;
        }
        public string Description {
            get;
            set;
        }
        public Stuffing(string name, string description):this()
        {
            Name = name;
            Description =description;
        }


    }
}
