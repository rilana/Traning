using WatcherModel;

namespace FillFolderInDatabase
{
    interface IOperationToDatabase
    {
        void AddOrder(OrderFromFile order);
        void DeleteOrders(string nameFile);
    }
}
