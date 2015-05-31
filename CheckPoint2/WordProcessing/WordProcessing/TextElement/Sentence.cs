using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Sentence : IList<IItemSentences>
    {
        private List<IItemSentences> itemSentences = new List<IItemSentences>();

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
            str=str.TrimEnd();
            return str;
        }
        public override string ToString()
        {
            return Print();
        }
        public IEnumerable<T> GetItemSentences<T>()
            where T :class, IItemSentences
        {
            foreach (var item in itemSentences)
            {
                var word = (item as T);
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
                return GetItemSentences<Word>().Count();
            }
        }
        public TypeSentences TypeSentences
        {
            get 
            {
               var endSentences=GetItemSentences<PunctuationMark>().FirstOrDefault(x =>((PunctuationMark)x).EndSentence==true);
               
               if (endSentences == null)
               {
                   return TypeSentences.SetOfWords;
               }
               else if (endSentences.Value.Contains('?'))
               {
                   return TypeSentences.Interrogative;
               }
               else if (endSentences.Value.Contains('!'))
               {
                   return TypeSentences.Exclamatory;
               }
               else
               {
                   return TypeSentences.Narrative;
               }
              
            }
        }
       
        public bool ReplaceWordSubstring(Predicate<IItemSentences> match,Sentence ReplaceStr)
        {
            bool action = false;
            int index=itemSentences.FindIndex(match);
            while ( index>-1)
            {
                itemSentences.RemoveAt(index);
                itemSentences.InsertRange(index, ReplaceStr);
                index = itemSentences.FindIndex(index,match);
                action = true;
            }
            return action;

        }

        public int RemoveAll(Predicate<IItemSentences> match)
        {
            return itemSentences.RemoveAll(match);
        }
        public void AddRange(IEnumerable<IItemSentences> collection)
        {
            itemSentences.AddRange(collection);
        }
        #region IList
        public void Add(IItemSentences item)
        {
            itemSentences.Add(item);

        }

        public void Clear()
        {
            itemSentences.Clear();
        }

        public bool Contains(IItemSentences item)
        {
            return itemSentences.Contains(item);
        }

        public void CopyTo(IItemSentences[] array, int arrayIndex)
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

        public bool Remove(IItemSentences item)
        {
            return itemSentences.Remove(item);
        }

        public IEnumerator<IItemSentences> GetEnumerator()
        {
            return itemSentences.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int IndexOf(IItemSentences item)
        {
            return itemSentences.IndexOf(item);
        }

        public void Insert(int index, IItemSentences item)
        {
           itemSentences.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            itemSentences.RemoveAt(index);
        }

        public IItemSentences this[int index]
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
        #endregion
    }
}
