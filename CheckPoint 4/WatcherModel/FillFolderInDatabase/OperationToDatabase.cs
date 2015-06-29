using System.Linq;
using WatcherModel;
using WatcherModel.Repository;

namespace FillFolderInDatabase
{
    class OperationToDatabase:IOperationToDatabase
    {
        private ModelContainer _context = new ModelContainer();
        private UnitOfWork _unitOfWork;
      
        public OperationToDatabase()
        {
            _unitOfWork=new UnitOfWork(_context);
        }

        public void AddOrder(OrderFromFile order)
        {
            var orderBd = new Order
            {
                Date = order.Date,
                Cost = order.Cost,
                Client =_unitOfWork.GetClient(order.Client),
                Manager =_unitOfWork.GetManager(order.Manager),
                Goods =_unitOfWork.GetGoods(order.Good),
                NameFile =_unitOfWork.GetNameFile(order.NameFile)
            };
            _unitOfWork.ReposOrder.Insert(orderBd);
            _unitOfWork.Save();
        }

      
       
        public void DeleteOrders(string nameFile)
        {
            var nameFileDelete = _unitOfWork.ReposNameFile.GetAll().FirstOrDefault(x => x.Name == nameFile);
            if (nameFileDelete != null)
            {
                var deleteOrder = _unitOfWork.ReposOrder.GetAll().Where(x => x.IdFile == nameFileDelete.Id);
                foreach (var item in deleteOrder)
                {
                    _unitOfWork.ReposOrder.Delete(item);
                }
                _unitOfWork.ReposNameFile.Delete(nameFileDelete);
                _unitOfWork.Save();
            }
        }
    }
}
