﻿using System;
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
            Bonbon bonbon = new Bonbon()
            {
                Name = "Красная шапочка",
                Manufacturer = Manufacturer.Kammunarka,
                Gramm = 15,
                glazed = true,
                EnergyValue = 45,
                CandyMasses = CandyMasses.Cream,
                Sugar = 4,
                NutritionalValue = new NutritionalValue(12, 45, 95)
            };
            boxofgit.Add(bonbon);
            boxofgit.Add(bonbon);

            boxofgit.Add(new Lollipop()
            {
                Name = "LOLLIPOPS",
                Manufacturer = Manufacturer.Spartak,
                Gramm = 14,
                EnergyValue = 305,
                Sugar =2,
                NutritionalValue = new NutritionalValue(0, 0, 74),
                BasedSugar=BasedSugar.Sucrose
            });

            boxofgit.Add(new CaramelwithFillings()
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
                cocao=72

            });
            Console.WriteLine(boxofgit.ToString());

            boxofgit.PrintList();

            Console.WriteLine("содержания сахара ");
            
            foreach (var item in boxofgit.FindAllSugar(3,9))
            {
                Console.WriteLine("Название - {0}, содержание сахара - {1}", item.Name,item.Sugar);
            }

            Console.WriteLine("сортировка сладостей по содержанию углеводов ");
            foreach (var item in boxofgit.SortCarbohydrates())
            {
                Console.WriteLine("Название - {0}, содержание углеводов - {1}", item.Name,item.NutritionalValue.Carbohydrates);
            }

            Console.ReadLine();
        }
    }
}
