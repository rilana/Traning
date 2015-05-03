using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogConfectionery
{
    class Program
    {
        static void Main(string[] args)
        {
            CatalogProduct pr = new CatalogProduct();
            pr.Add(new Candy()
            {
                Name = "Bon amur",
                ShelfLife = new ShelfLife(6,0,0),
                EnergyValue = 124,
                CreationDate = new DateTime(2014, 11, 18),
                stuffing = new Stuffing()
                {
                    Name = "soft caramel"
                },
                Rating=Rating.Average
            });
            pr.Add(new Cake()
            {
                Name = "Гора самоцветов",
                ShelfLife = new ShelfLife(0, 3, 0),
                CreationDate = new DateTime(2014, 1, 28),
                EnergyValue = 200,
                Rating = Rating.High
            });
            pr.Add(new Chocolate()
            {
                Name = "Идеал",
                ShelfLife = new ShelfLife(3, 0, 0),
                EnergyValue = 104,
                CreationDate = new DateTime(2014, 8, 15),
                stuffing = null,
                Gramm=90,
                Rating = Rating.Average
            });
            BoxOfCandy boxcandy = new BoxOfCandy() 
            {
                Name = "Сладости",
                ShelfLife = new ShelfLife(12, 0, 0),
                EnergyValue = 143, 
                Gramm = 400,
                Rating = Rating.Low
            };
            boxcandy.Add(new Stuffing("Ореховая начинка","с лесными орехами"));
            boxcandy.Add(new Stuffing("молочная начинка", ""));
            pr.Add(boxcandy);
            foreach (var item in pr)
            {
               
                Console.Write(item.ToString());
                var itemStuffing=item as IStuffing;
                if ((itemStuffing != null)&&(itemStuffing.stuffing!=null))
                {
                    Console.Write(" c {0}", itemStuffing.stuffing.Value.Name);
                }
                var boxItem = item as BoxOfCandy;

                if (boxItem != null)
                {
                    foreach (var i in boxItem)
                    {
                        Console.Write(" c {0}", i.Name);
                    }
                   
                }
                Console.WriteLine();
            }
            
            //----сортировка------
            Console.WriteLine("----сортировка по сроку годности------");
            pr.SortShelfLife();
            foreach (var item in pr)
            {
                Console.WriteLine("название -{0}, срок годности -{1}", item.Name, item.ShelfLife);
            }
            Console.WriteLine("----сортировка по рейтингу------");
            pr.SortRating();
            foreach (var item in pr)
            {
                Console.WriteLine("название -{0}, срок годности -{1}", item.Name, item.Rating);
            }
            //-------------
            Console.ReadLine();
            
        }
    }
}
