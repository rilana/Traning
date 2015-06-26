using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WatcherModel;
using WatcherModel.Repository;

namespace FillFolderInDatabase
{
    class OperationToDatabase:IOperationToDatabase
    {
        private ModelContainer _context = new ModelContainer();
        public static readonly object locker=new object();

        private IRepository<Order> reposOrder;
        private IRepository<Manager> reposManager;
        private IRepository<NameFile> reposNameFile;
        private IRepository<Client> reposClient;
        private IRepository<Goods> reposGoods;

        public OperationToDatabase()
        {
            reposClient = new Repository<Client>(_context);
            reposManager = new Repository<Manager>(_context);
            reposOrder = new Repository<Order>(_context);
            reposGoods = new Repository<Goods>(_context);
            reposNameFile = new Repository<NameFile>(_context);
        }

        public void AddOrder(OrderFromFile order)
        {            
           WatcherModel.Order orderBd=new WatcherModel.Order();
           orderBd.Date = order.Date;
           orderBd.Cost = order.Cost;
           lock (locker)
           {
               orderBd.Client = GetClient(order.Client);
               orderBd.Manager = GetManager(order.Manager);
               orderBd.Goods = GetGoods(order.Good);
           }
           orderBd.NameFile = GetNameFile(order.NameFile);
           reposOrder.Insert(orderBd);
           reposOrder.SaveChanges();
           //_context.OrderSet.Add(orderBd);
           //_context.SaveChanges();
        }
        
        //public void AddOrderRange(List<OrderFromFile> orders)
        //{
        //     Console.WriteLine("filling to base "+orders[0].Manager);
        //     if (IsReplace(orders[0])) DeleteOrders(orders[0].Manager, orders[0].Date);
        //     foreach (var item in orders)
        //      {
        //          WatcherModel.Order orderBd = MappingOrderToBD(item);
        //          _context.OrderSet.Add(orderBd);
        //      }
        //      _context.SaveChanges();
        //      Console.WriteLine("stop filling to base " + orders[0].Manager);
        //}

        public Manager GetManager(string name)
        {
            //var manager = _context.ManagerSet.FirstOrDefault(x => x.SecondName == name);
            var manager =reposManager.GetAll().FirstOrDefault(x => x.SecondName == name);
            if (manager == null)
            {
                manager = new Manager {SecondName = name, FirstName = name};
                reposManager.Insert(manager);
                _context.ManagerSet.Add(manager);
                _context.SaveChanges();
            }
            return manager;
        }

        public Client GetClient(string name)
        {
            var client = _context.ClientSet.FirstOrDefault(x => x.SecondName == name);
            if (client== null)
            {
                client=new Client();
                client.SecondName = name;
                client.FirstName= name;
                _context.ClientSet.Add(client);
                _context.SaveChanges();
            }
            return client;
        }

        public NameFile GetNameFile(string name)
        {
            var nameFile = _context.NameFileSet.FirstOrDefault(x => x.Name == name); 
            if (nameFile == null)
            {
                nameFile = new NameFile() { Name = name };
                _context.NameFileSet.Add(nameFile);
            }
            return nameFile;
        }

        public Goods GetGoods(string name)
        {
            var goods = _context.GoodsSet.FirstOrDefault(x => x.NameGoods ==name);
            if (goods== null)
            {
                goods=new Goods();
                goods.NameGoods =name;
                _context.GoodsSet.Add(goods);
                _context.SaveChanges();
            }
            return goods;
        }

        //private bool IsReplace(OrderFromFile order)
        //{
        //    bool replace = false;
        //    //var manager = _context.ManagerSet.FirstOrDefault(x => x.SecondName == order.Manager);
        //    //if ((manager != null)
        //    //    && (_context.OrderSet.Any(x => x.IdManager == manager.Id && x.Date.Day == order.Date.Day &&
        //    //                                x.Date.Month == order.Date.Month && x.Date.Year == order.Date.Year)))
        //    //replace = true;
        //    return replace;
        //}

        public void DeleteOrders(string nameFile)
        {
            var nameFileDelete = _context.NameFileSet.FirstOrDefault(x => x.Name == nameFile);
            var deleteOrder = _context.OrderSet.Where(x => x.IdFile == nameFileDelete.Id);
            foreach (var item in deleteOrder)
            {
                _context.OrderSet.Remove(item);
            }
            if (nameFileDelete != null)
            {
                _context.NameFileSet.Remove(nameFileDelete);
                _context.SaveChanges();
            }
        }
    }
}
