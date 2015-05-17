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

            Bonbon bonbon = new Bonbon
                ("Красная шапочка",
                Manufacturer.Kammunarka,
                new NutritionalValue(12, 45, 95),
                4,45,15,true,
                 CandyMasses.Cream
                );
            
                           
            boxofgit.Add(bonbon);
            boxofgit.Add(bonbon);

            boxofgit.Add(new Caramel()
            {
                Name = "LOLLIPOPS",
                Manufacturer = Manufacturer.Spartak,
                Gramm = 14,
                EnergyValue = 305,
                Sugar =2,
                NutritionalValue = new NutritionalValue(0, 0, 74),
                BasedSugar=BasedSugar.Sucrose
            });

            boxofgit.Add(new Caramel()
            {
                Name = "Фрутомелька",
                Manufacturer = Manufacturer.Kammunarka,
                Gramm = 7,
                EnergyValue = 356,
                Sugar = 7,
                NutritionalValue = new NutritionalValue(0.1, 0.1, 95.6),
                Stuffing = new Stuffing("вкус клубника-сливки"),
                BasedSugar=BasedSugar.Glucose
            });

            boxofgit.Add(new Chocolate() 
            {
                Name = "Горький-элитный пористый",
                Manufacturer=Manufacturer.Spartak,
                Sugar=3,
                NutritionalValue=new NutritionalValue(10,39,38),
                EnergyValue=550,
                Gramm=100,
                Cocao=72

            });
            boxofgit.Add(new Wafer()
            {
                Name = "СЛАДКАЯ ПАРОЧКА",
                Manufacturer = Manufacturer.Spartak,
                Sugar = 19,
                NutritionalValue = new NutritionalValue(5.9, 31.8, 57.6),
                EnergyValue = 536,
                Gramm = 40,
                Stuffing = new Stuffing("КОФЕЙНО-ЛИМОННЫМ АРОМАТОМ")
            });

            Console.WriteLine(boxofgit.ToString());
            //вывод на экран содержание подарка
            boxofgit.PrintList();
            //интервал по сахару
            Console.WriteLine("содержания сахара ");
            foreach (var item in boxofgit.FindAllSugar(3,9))
            {
                Console.WriteLine("Название - {0}, содержание сахара - {1}", item.Name,item.Sugar);
            }
            Console.WriteLine("первая конфета по модержанию сахара:{0} {1}", boxofgit.FirstSugar(5, 10).Name, boxofgit.FirstSugar(5, 10).Sugar);
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
