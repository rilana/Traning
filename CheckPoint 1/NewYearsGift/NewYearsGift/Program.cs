using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BoxOfGift boxofgit = new BoxOfGift("Сундучок Малышок");
            Worker.FillBoxOfGift(boxofgit);
           

            Console.WriteLine(boxofgit.ToString());
            //вывод на экран содержание подарка
            boxofgit.PrintList();
            //интервал по сахару
            Console.WriteLine("содержания сахара ");
            foreach (var item in boxofgit.FindAllSugar(3,9))
            {
                Console.WriteLine("Название - {0}, содержание сахара - {1}", item.Name,item.Sugar);
            }
            Console.WriteLine("первая конфета по модержанию сахара:{0} {1}", boxofgit.FirstSugar(5, 10).Name,
                boxofgit.FirstSugar(5, 10).Sugar);
            //сотрировка
            Console.WriteLine("сортировка сладостей по содержанию углеводов ");
            foreach (var item in boxofgit.SortCarbohydrates())
            {
                Console.WriteLine("Название - {0}, содержание углеводов - {1}", item.Name,item.NutritionalValue.Carbohydrates);
            }

            Console.ReadLine();
        }
    }
}
