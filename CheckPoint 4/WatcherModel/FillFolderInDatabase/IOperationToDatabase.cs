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
        void AddOrders(List<OrderFromFile> order);
        Manager GetManager(string name);
        Client GetClient(string name);
        Goods GetGoods(string name);
        void DeleteOrders(string name, DateTime date);
    }
}
