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
                Client = GetClient(order.Client),
                Manager = GetManager(order.Manager),
                Goods = GetGoods(order.Good),
                NameFile = GetNameFile(order.NameFile)
            };
            _unitOfWork.ReposOrder.Insert(orderBd);
            _unitOfWork.Save();
        }
       
        public Manager GetManager(string name)
        {
            var manager =_unitOfWork.ReposManager.GetAll().FirstOrDefault(x => x.SecondName == name);
            if (manager == null)
            {
                manager = new Manager {SecondName = name, FirstName = name};
                _unitOfWork.ReposManager.Insert(manager);
            }
            return manager;
        }

        public Client GetClient(string name)
        {
            var client =_unitOfWork.ReposClient.GetAll().FirstOrDefault(x => x.SecondName == name);
            if (client== null)
            {
                client=new Client();
                client.SecondName = name;
                client.FirstName= name;
                _unitOfWork.ReposClient.Insert(client);
            }
            return client;
        }

        public NameFile GetNameFile(string name)
        {
            var nameFile = _unitOfWork.ReposNameFile.GetAll().FirstOrDefault(x => x.Name == name); 
            if (nameFile == null)
            {
                nameFile = new NameFile() { Name = name };
                _unitOfWork.ReposNameFile.Insert(nameFile);
            }
            return nameFile;
        }

        public Goods GetGoods(string name)
        {
            var goods = _unitOfWork.ReposGoods.GetAll().FirstOrDefault(x => x.NameGoods == name);
            if (goods== null)
            {
                goods = new Goods {NameGoods = name};
                _unitOfWork.ReposGoods.Insert(goods);
            }
            return goods;
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
