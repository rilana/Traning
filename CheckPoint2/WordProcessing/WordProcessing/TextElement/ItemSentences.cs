using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public abstract class ItemSentences : IItemSentences
    {
        private List<Character> listChart = new List<Character>();
        public string Value
        {
            get
            {
                string str = "";
                foreach (var item in listChart)
                {
                    str = str + item.Value;
                }
                return str;
            }
        }
        #region IList
        public void Add(Character item)
        {
            listChart.Add(item);
        }

        public void Clear()
        {
            listChart.Clear();
        }

        public bool Contains(Character item)
        {
            return listChart.Contains(item);
        }

        public void CopyTo(Character[] array, int arrayIndex)
        {
            listChart.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return listChart.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Character item)
        {
            return listChart.Remove(item);
        }

        public IEnumerator<Character> GetEnumerator()
        {
            return listChart.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int IndexOf(Character item)
        {
            return listChart.IndexOf(item);
        }

        public void Insert(int index, Character item)
        {
           listChart.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
           listChart.RemoveAt(index);
        }

        public Character this[int index]
        {
            get
            {
               return listChart[index];
            }
            set
            {
               listChart[index]=value;
            }
        }

        public void AddRange(IEnumerable<Character> collection)
        {
            listChart.AddRange(collection);
        }
        #endregion

    }
}
