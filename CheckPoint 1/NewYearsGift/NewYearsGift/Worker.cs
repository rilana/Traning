using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift
{
    class Worker
    {
        public static void FillBoxOfGift(BoxOfGift boxofgit)
        {

            Bonbon bonbon = new Bonbon
               ("Красная шапочка",
               Manufacturer.Kammunarka,
               new NutritionalValue(12, 45, 95),
               4, 45, 15, true,
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
                Sugar = 2,
                NutritionalValue = new NutritionalValue(0, 0, 74),
                BasedSugar = BasedSugar.Sucrose
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
                BasedSugar = BasedSugar.Glucose
            });

            boxofgit.Add(new Chocolate()
            {
                Name = "Горький-элитный пористый",
                Manufacturer = Manufacturer.Spartak,
                Sugar = 3,
                NutritionalValue = new NutritionalValue(10, 39, 38),
                EnergyValue = 550,
                Gramm = 100,
                Cocao = 72

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
        }
    }
}
