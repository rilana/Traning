using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    enum TypeTr
    {
        AcuteAngled,
        Obtuse,
        Orthogonal,
    }
    class Triangle
    {
       
        private int a;
        private int b;
        private int c;
        public int A
        {
            get
            {
                return a;
            }
            
        }
        public int B
        {
            get
            {
                return b;
            }
            
        }
        public int C
        {
            get
            {
                return c;
            }
            
        }
       private TypeTr typeTringle;
       public TypeTr Typetringle
        {
            get
            {
                return typeTringle;
            }
        }
        public Triangle(int a,int b,int c)
        {

            change_side(a, b, c);
        }
        public bool change_side(int a,int b,int c)
        {
            if (Correct(a, b, c))
            {
                this.a = a;
                this.b = b;
                this.c = c;
                _GetTypeTr();
                return true;

            }
            else
            {
                return false;
            }
        }
        private bool Correct(int a, int b, int c)
        {
          
            if ((a*b*c!=0 )&&(a + b > c) && (a + c > b) && (b + c > a))
            {
               
                return true;
            }
            return false;
        }
       
        private void _GetTypeTr()
        {
            if ((a>=b)&&(a>=c))
            {
                typeTringle = GetTypeTr(a, b, c);
            }
            else if ((b >= a) && (b >= c))
            {
                typeTringle = GetTypeTr(b, a, c);
            }
            else
            {
                typeTringle = GetTypeTr(c, a, b);
            }
            
        }
        private TypeTr GetTypeTr(int h,int k,int l)
        {
            if (h * h == k * k + l * l) return TypeTr.Orthogonal;
            else if (h * h > k * k + l * l) return TypeTr.Obtuse;
            else return TypeTr.AcuteAngled;
        }

    }
}
