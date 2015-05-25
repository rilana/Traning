using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Sentence : IList<ItemSentences>
    {
        public List<ItemSentences> itemSentences = new List<ItemSentences>();


        public string Value
        {
            get
            {
                return Print();
            }

        }
        private string Print()
        {
            string str = "";
            foreach (var item in itemSentences)
            {
                var workItem = item as PunctuationMark;
                if ((workItem != null) && (workItem.BeforeWord==false))
                {
                    str = str.Trim();
                }
                str = str + item.Value+" ";
                if ((workItem != null) && (workItem.BeforeWord))
                {
                    str = str.Trim();
                }
                
            }
            return str;
        }
        private IEnumerable<Word> GetWord()
        {
            foreach (var item in itemSentences)
            {
                var word = item as Word;
                if (word != null)
                {
                    yield return word;
                }
            }
        }
    
        public int CountWord
        {
            get
            {
              return GetWord().Count();
            }
        }
        public int RemoveAll(Predicate<ItemSentences> match)
        {
            return itemSentences.RemoveAll(match);
        }
        //----------------
        public void Add(ItemSentences item)
        {
            itemSentences.Add(item);

        }

        public void Clear()
        {
            itemSentences.Clear();
        }

        public bool Contains(ItemSentences item)
        {
            return itemSentences.Contains(item);
        }

        public void CopyTo(ItemSentences[] array, int arrayIndex)
        {
            itemSentences.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return itemSentences.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ItemSentences item)
        {
            return itemSentences.Remove(item);
        }

        public IEnumerator<ItemSentences> GetEnumerator()
        {
            return itemSentences.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int IndexOf(ItemSentences item)
        {
            return itemSentences.IndexOf(item);
        }

        public void Insert(int index, ItemSentences item)
        {
           itemSentences.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            itemSentences.RemoveAt(index);
        }

        public ItemSentences this[int index]
        {
            get
            {
               return itemSentences[index];
            }
            set
            {
                itemSentences[index]=value;
            }
        }
    }
}
