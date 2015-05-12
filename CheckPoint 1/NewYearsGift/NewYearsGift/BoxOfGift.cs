using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class BoxOfGift : ICollection<IGiftItems>
    {
        public string Name { get; set; }
        public BoxOfGift(string Name)
        {
            this.Name = Name;
        }
        private ICollection<IGiftItems> boxOfGift= new List<IGiftItems>();


        public void Add(IGiftItems item)
        {
            boxOfGift.Add(item);
        }

        public void Clear()
        {
            boxOfGift.Clear();
        }

        public bool Contains(IGiftItems item)
        {
            return boxOfGift.Contains(item);
        }

        public void CopyTo(IGiftItems[] array, int arrayIndex)
        {
            boxOfGift.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return boxOfGift.Count(); }
        }

        public bool IsReadOnly
        {
            get { return boxOfGift.IsReadOnly; }
        }

        public bool Remove(IGiftItems item)
        {
            return boxOfGift.Remove(item);
        }

        public IEnumerator<IGiftItems> GetEnumerator()
        {
            return boxOfGift.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private  IEnumerable<IConfection> GetConfection()
        {
            foreach (var item in boxOfGift)
            {
                var sweety = (item as IConfection);
                if (sweety != null)
                {
                    yield return sweety;
                }
            }
        }
        private IEnumerable<ICaramel> GetCaramel()
        {
            foreach (var item in boxOfGift)
            {
                var sweety = (item as ICaramel);
                if (sweety != null)
                {
                    yield return sweety;
                }
            }
        }
        public override string ToString()
        {
            return  "Набор конфет - " + this.Name + "\n" + "Количество конфет - " + boxOfGift.Count() +
                "\n" + "Вес - " + GetConfection().Sum(x => x.Gramm) + " гр. (вес карамели - " + 
                GetCaramel().Sum(x=>x.Gramm)+" гр.)";
       
        }
        public void PrintList()
        {
            var listview = from item in boxOfGift
                     group item by 
                     new 
                     {
                         item.Name, item.Manufacturer 
                     } into g
                     select new 
                     { 
                         Name = g.Key.Name, manafucter = g.Key.Manufacturer, Count = g.Count() 
                     };
            Console.WriteLine("Содержание подарка:");
            foreach (var item in listview)
            {
                Console.WriteLine("Название - {0}, производитель - {1}, количество - {2}", item.Name, item.manafucter, item.Count);
            }
        }
        public IEnumerable<IConfection> FindAllSugar(int min, int max)
        {
            foreach (var i in GetConfection())
            {
                if (i.Sugar >= min && i.Sugar <= max)
                {
                    yield return i;
                }
            }
        }
        public IConfection FindSugar(int min, int max)
        {
            foreach (var i in GetConfection())
            {
                if (i.Sugar >= min && i.Sugar <= max)
                {
                    return i;
                }
            }
            return null;
        }
        public IEnumerable<IConfection> SortCarbohydrates()
        {
            var newList = GetConfection().OrderBy(x => x.NutritionalValue.Carbohydrates);
            return newList;
        }
    }
}
