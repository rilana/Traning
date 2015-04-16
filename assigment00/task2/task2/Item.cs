using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Item
    {
        private string name;
        private int count;
        private int cost;
        private int totalCost;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
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
