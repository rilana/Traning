using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatcherModel;

namespace FillFolderInDatabase
{
    interface IOperationToDatabase
    {
        void AddOrders(List<Order> order);
        Manager AddNewManager(string name);
        Client AddNewClient(string name);
        Goods AddNewGood(string name);
        void DeleteOrders(List<Order> order);
    }
}
