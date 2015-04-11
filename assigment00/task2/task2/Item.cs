using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Item
    {
        public string Name;
        private int count;
        private int cost;
        private int totalCost;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                GettotalCost();
            }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                GettotalCost();
            }
        }
        public int TotalCost
        {
            get 
            {
                return totalCost;
            }
        }
        public void  GettotalCost()
        {
            totalCost=count * cost;
        }
       
    }
}
