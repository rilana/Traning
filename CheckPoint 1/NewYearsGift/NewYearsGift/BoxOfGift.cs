using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewYearsGift
{
    public class BoxOfGift : ICollection<IConfection>
    {
        public string Name { get; set; }

        #region ICollection<IConfection>
        public BoxOfGift(string Name)
        {
            this.Name = Name;
        }
        private ICollection<IConfection> boxOfGift = new List<IConfection>();


        public void Add(IConfection item)
        {
            boxOfGift.Add(item);
        }

        public void Clear()
        {
            boxOfGift.Clear();
        }

        public bool Contains(IConfection item)
        {
            return boxOfGift.Contains(item);
        }

        public void CopyTo(IConfection[] array, int arrayIndex)
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

        public bool Remove(IConfection item)
        {
            return boxOfGift.Remove(item);
        }

        public IEnumerator<IConfection> GetEnumerator()
        {
            return boxOfGift.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
        #endregion

        public override string ToString()
        {
            return  "Набор конфет - " + this.Name + "\n" + "Количество конфет - " + boxOfGift.Count() +
                "\n" + "Вес - " + Weight + " гр. (вес карамели - " + 
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
            return boxOfGift.Where(x => x.Sugar >= min && x.Sugar <= max);
            
        }
        public IConfection FirstSugar(int min, int max)
        {
            return boxOfGift.First(x => x.Sugar >= min && x.Sugar <= max);
       
        }
        public IEnumerable<IConfection> SortCarbohydrates()
        {
            var newList = boxOfGift.OrderBy(x => x.NutritionalValue.Carbohydrates);
            return newList;
        }
        public int Weight
        {
            get
            {
                return boxOfGift.Sum(x => x.Gramm);
            }
        }
    }
}
