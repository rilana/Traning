using System;
using System.Collections.Generic;
using System.Linq;


namespace WordProcessing
{
    public class Sentence : IList<IItemSentences>
    {
        private readonly List<IItemSentences> _sentences = new List<IItemSentences>();

        private string Print()
        {
            var str = "";
            foreach (var item in _sentences)
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
            foreach (var item in _sentences)
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
               var endSentences=GetItemSentences<PunctuationMark>().FirstOrDefault(x =>x.EndSentence);
               
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
       
        public bool ReplaceWordSubstring(Predicate<IItemSentences> match,Sentence replaceStr)
        {
            bool action = false;
            int index = _sentences.FindIndex(match);
            while ( index>-1)
            {
                _sentences.RemoveAt(index);
                _sentences.InsertRange(index, replaceStr);
                index = _sentences.FindIndex(index, match);
                action = true;
            }
            return action;

        }

        public int RemoveAll(Predicate<IItemSentences> match)
        {
            return _sentences.RemoveAll(match);
        }
        public void AddRange(IEnumerable<IItemSentences> collection)
        {
            _sentences.AddRange(collection);
        }
        #region IList
        public void Add(IItemSentences item)
        {
            if (item.Value!=String.Empty) _sentences.Add(item);

        }

        public void Clear()
        {
            _sentences.Clear();
        }

        public bool Contains(IItemSentences item)
        {
            return _sentences.Contains(item);
        }

        public void CopyTo(IItemSentences[] array, int arrayIndex)
        {
            _sentences.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _sentences.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IItemSentences item)
        {
            return _sentences.Remove(item);
        }

        public IEnumerator<IItemSentences> GetEnumerator()
        {
            return _sentences.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(IItemSentences item)
        {
            return _sentences.IndexOf(item);
        }

        public void Insert(int index, IItemSentences item)
        {
            _sentences.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _sentences.RemoveAt(index);
        }

        public IItemSentences this[int index]
        {
            get
            {
                return _sentences[index];
            }
            set
            {
                _sentences[index] = value;
            }
        }
        #endregion
    }
}
