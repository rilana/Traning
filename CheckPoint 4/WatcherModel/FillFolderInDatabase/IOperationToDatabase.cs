using WatcherModel;

namespace FillFolderInDatabase
{
    interface IOperationToDatabase
    {
        void AddOrder(OrderFromFile order);
        Manager GetManager(string name);
        Client GetClient(string name);
        Goods GetGoods(string name);
        NameFile GetNameFile(string name);
        void DeleteOrders(string nameFile);
    }
}
