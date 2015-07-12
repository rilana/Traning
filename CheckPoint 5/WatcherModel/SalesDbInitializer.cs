using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatcherModel
{
    class SalesDbInitializer : DropCreateDatabaseAlways<ModelContainer>
    {
        protected override void Seed(ModelContainer context)
        {
            Manager manager1 = new Manager() { FirstName = "Svetlaj", SecondName = "Svetlaj" };
            Manager manager2 = new Manager() { FirstName = "Redkij", SecondName = "Redkij" };
            Manager manager3 = new Manager() { FirstName = "Belaev", SecondName = "Belaev" };
            context.ManagerSet.Add(manager1);
            context.ManagerSet.Add(manager2);
            context.ManagerSet.Add(manager3);

            Client cl1 = new Client() { FirstName = "Slovej", SecondName = "Slovej" };
            Client cl2 = new Client() { FirstName = "Petrov", SecondName = "Petrov" };
            Client cl3 = new Client() { FirstName = "Ivanov", SecondName = "Ivanov" };
            Client cl4 = new Client() { FirstName = "Burij", SecondName = "Burij" };
            context.ClientSet.Add(cl1);
            context.ClientSet.Add(cl2);
            context.ClientSet.Add(cl3);
            context.ClientSet.Add(cl4);

            Goods g1 = new Goods() { NameGoods = "Pen" };
            Goods g2 = new Goods() { NameGoods = "Pencil" };
            Goods g3 = new Goods() { NameGoods = "Postcard" };
            Goods g4 = new Goods() { NameGoods = "Folder" };
            Goods g5 = new Goods() { NameGoods = "Clips" };
            context.GoodsSet.Add(g1);
            context.GoodsSet.Add(g2);
            context.GoodsSet.Add(g3);
            context.GoodsSet.Add(g4);
            context.GoodsSet.Add(g5);

            List<NameFile> files = new List<NameFile>(){
                new NameFile() { Name ="Svetlaj_1962015" },
                new NameFile() { Name = "Svetlaj_2262015" },
                new NameFile() { Name = "Svetlaj_2362015" },
                new NameFile() { Name = "Redkij_1962015" },
                new NameFile() { Name = "Redkij_0962015" },
                new NameFile() { Name = "Redkij_2962015" },
                new NameFile() { Name = "Redkij_1162015" },
                new NameFile() { Name = "Belaev_1962015" },
                new NameFile() { Name = "Belaev_1762015" },
                new NameFile() { Name = "Belaev_2362015" }
            };
            context.NameFileSet.AddRange(files);

            List<Order> orders = new List<Order>(){
                new Order(){Client=cl1,Goods=g1,Manager=manager1,NameFile= files[0],Cost=14000,Date=new DateTime(2015,6,19)},
                new Order(){Client=cl3,Goods=g2,Manager=manager1,NameFile= files[0],Cost=19000,Date=new DateTime(2015,6,19)},
                new Order(){Client=cl1,Goods=g4,Manager=manager1,NameFile= files[1],Cost=24000,Date=new DateTime(2015,6,22)},
                new Order(){Client=cl1,Goods=g1,Manager=manager1,NameFile= files[1],Cost=25000,Date=new DateTime(2015,6,22)},
                new Order(){Client=cl2,Goods=g1,Manager=manager1,NameFile= files[2],Cost=10000,Date=new DateTime(2015,6,23)},

                new Order(){Client=cl1,Goods=g4,Manager=manager2,NameFile= files[3],Cost=22000,Date=new DateTime(2015,6,19)},
                new Order(){Client=cl2,Goods=g5,Manager=manager2,NameFile= files[3],Cost=34000,Date=new DateTime(2015,6,19)},
                new Order(){Client=cl2,Goods=g3,Manager=manager2,NameFile= files[4],Cost=44000,Date=new DateTime(2015,6,9)},
                new Order(){Client=cl1,Goods=g1,Manager=manager2,NameFile= files[4],Cost=4000,Date=new DateTime(2015,6,9)},
                new Order(){Client=cl3,Goods=g2,Manager=manager2,NameFile= files[6],Cost=12000,Date=new DateTime(2015,6,11)},
                new Order(){Client=cl2,Goods=g2,Manager=manager2,NameFile= files[6],Cost=16000,Date=new DateTime(2015,6,11)},
                new Order(){Client=cl2,Goods=g3,Manager=manager2,NameFile= files[6],Cost=22000,Date=new DateTime(2015,6,11)},
                new Order(){Client=cl3,Goods=g1,Manager=manager2,NameFile= files[5],Cost=12000,Date=new DateTime(2015,6,22)},

                new Order(){Client=cl3,Goods=g5,Manager=manager3,NameFile= files[7],Cost=22000,Date=new DateTime(2015,6,19)},
                new Order(){Client=cl2,Goods=g4,Manager=manager3,NameFile= files[7],Cost=15000,Date=new DateTime(2015,6,19)},
                new Order(){Client=cl2,Goods=g4,Manager=manager3,NameFile= files[8],Cost=26000,Date=new DateTime(2015,6,17)},
                new Order(){Client=cl3,Goods=g1,Manager=manager3,NameFile= files[8],Cost=12000,Date=new DateTime(2015,6,17)},
                new Order(){Client=cl1,Goods=g3,Manager=manager3,NameFile= files[9],Cost=4000,Date=new DateTime(2015,6,23)},
            };

            context.OrderSet.AddRange(orders);
            base.Seed(context);
        }
    }
}
