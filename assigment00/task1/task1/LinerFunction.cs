using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class LinerFunction
    {
        private int a;
        private int b;
        public int A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public int B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }
       
        public int YotX(int x)
        {
            int y;
            y = a * x + b;
            return y;
        }
    }
}
