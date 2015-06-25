using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WatcherModel;

namespace FillFolderInDatabase
{
    class FillInDatabase:IOperationToDatabase
    {
        private ModelContainer _context = new ModelContainer();
        private object locker;

        public  FillInDatabase(object locker)
        {
            this.locker = locker;
        }

        private WatcherModel.Order MappingOrderToBD(OrderFromFile order)
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
           return orderBd; 
        }
        
        public void AddOrders(List<OrderFromFile> orders)
        {
             Console.WriteLine("filling to base "+orders[0].Manager);
             if (IsReplace(orders[0])) DeleteOrders(orders[0].Manager, orders[0].Date);
             foreach (var item in orders)
              {
                  WatcherModel.Order orderBd = MappingOrderToBD(item);
                  _context.OrderSet.Add(orderBd);
              }
              _context.SaveChanges();
              Console.WriteLine("stop filling to base " + orders[0].Manager);
        }

        public Manager GetManager(string name)
        {
            var manager = _context.ManagerSet.FirstOrDefault(x => x.SecondName == name);
            if (manager == null)
            {
                manager = new Manager {SecondName = name, FirstName = name};
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
        private bool IsReplace(OrderFromFile order)
        {
            bool replace = false;
            var manager = _context.ManagerSet.FirstOrDefault(x => x.SecondName == order.Manager);
            if ((manager != null)
                && (_context.OrderSet.Any(x => x.IdManager == manager.Id && x.Date.Day == order.Date.Day &&
                                            x.Date.Month == order.Date.Month && x.Date.Year == order.Date.Year)))
                replace = true;
            return replace;
        }
        public void DeleteOrders(string name, DateTime date)
        {
            var idManager = _context.ManagerSet.FirstOrDefault(x => x.SecondName == name).Id;
            var deleteQuery = _context.OrderSet.Where(x => x.IdManager == idManager && x.Date.Day == date.Day
                                                  &&x.Date.Month == date.Month&&x.Date.Year == date.Year).ToList();
            foreach (var item in deleteQuery)
            {
                _context.OrderSet.Remove(item);
            }
            if (deleteQuery.Count > 0) _context.SaveChanges();
        }
       
    }
}
