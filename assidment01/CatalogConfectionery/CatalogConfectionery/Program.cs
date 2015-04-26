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
                ShelfLife = 15,
                EnergyValue = 124,
                CreationDate = new DateTime(2014, 11, 18),
                stuffing = new Stuffing()
                {
                    Name = "soft caramel"
                }
            });
            pr.Add(new Cake()
            {
                Name = "Гора самоцветов",
                ShelfLife = 3,
                CreationDate = new DateTime(2014, 1, 28),
                EnergyValue = 200
            });
            pr.Add(new Chocolate()
            {
                Name = "Идеал",
                ShelfLife = 45,
                EnergyValue = 104,
                CreationDate = new DateTime(2014, 8, 15),
                stuffing = null,
                Gramm=90
            });
            BoxOfCandy boxcandy= new BoxOfCandy(){Name="Сладости",ShelfLife=500,EnergyValue=143, Gramm=400};
            boxcandy.Add(new Stuffing("Ореховая начинка","с лесными орехами"));
            boxcandy.Add(new Stuffing("молочная начинка", ""));
            pr.Add(boxcandy);
            foreach (var item in pr)
            {
                Console.Write("название -{0}; срок годности -{1} дней, энергетическая ценность -{2}",
                      item.Name,item.ShelfLife,item.EnergyValue);
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
            Console.WriteLine("----сортировка------");
            pr.SortShelfLife();
            foreach (var item in pr)
            {
                Console.WriteLine("название -{0}, срок годности -{1}",item.Name,item.ShelfLife);
            }
            //-------------
            Console.ReadLine();
            
        }
    }
}
