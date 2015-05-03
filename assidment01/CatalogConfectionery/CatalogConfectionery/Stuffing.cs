using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogConfectionery
{
    public struct Stuffing
    {
        private string name;
        private string description;
        public string Name {
            get { return name; }
            set { name=value;}
        }
        public string Description {
            get { return description; }
            set { description = value; } 
        }
        public Stuffing(string nname, string ddescription)
        {
            name = nname;
            description = ddescription;
        }


    }
}
