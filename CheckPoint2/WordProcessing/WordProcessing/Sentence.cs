using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Sentence : ICollection<ItemSentences>
    {
        private ICollection<ItemSentences> itemSentences = new List<ItemSentences>();


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
            get { return itemSentences.IsReadOnly; }
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
    }
}
