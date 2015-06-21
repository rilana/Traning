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

        private WatcherModel.Order MappingOrderToBD(Order order)
        {
           WatcherModel.Order orderBd=new WatcherModel.Order();
           orderBd.Date = order.Date;
           orderBd.Cost = order.Cost;
           orderBd.Client = AddNewClient(order.Client);
           orderBd.Manager = AddNewManager(order.Manager);
           orderBd.Goods = AddNewGood(order.Good);
           return orderBd; 
        }
       
        public void AddOrders(List<Order> orders)
        {
            Console.WriteLine("filling to base "+orders[0].Manager);
             foreach (var item in orders)
              {
                  WatcherModel.Order orderBd = MappingOrderToBD(item);
                  _context.OrderSet.Add(orderBd);
              }
              _context.SaveChanges();
              Console.WriteLine("stop filling to base " + orders[0].Manager);
        }

        public Manager AddNewManager(string name)
        {
            var manager = _context.ManagerSet.FirstOrDefault(x => x.SecondName == name);
            if (manager == null)
            {
                manager = new Manager {SecondName = name, FirstName = name};
                _context.ManagerSet.Add(manager);
            }
            _context.SaveChanges();
            return manager;
        }

        public Client AddNewClient(string name)
        {
            var client = _context.ClientSet.FirstOrDefault(x => x.SecondName == name);
            if (client== null)
            {
                client=new Client();
                client.SecondName = name;
                client.FirstName= name;
                _context.ClientSet.Add(client);
            }
            _context.SaveChanges();
            return client;
        }

        public Goods AddNewGood(string name)
        {
            var goods = _context.GoodsSet.FirstOrDefault(x => x.NameGoods ==name);
            if (goods== null)
            {
                goods=new Goods();
                goods.NameGoods =name;
                _context.GoodsSet.Add(goods);
            }
            _context.SaveChanges();
            return goods;
        }

        public void DeleteOrders(List<Order> order)
        {
            throw new NotImplementedException();
        }
    }
}
