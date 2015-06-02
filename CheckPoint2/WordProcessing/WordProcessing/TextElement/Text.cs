using System.Collections.Generic;
using System.Linq;

namespace WordProcessing
{
    public class Text:IList<Sentence>
    {
        private readonly IList<Sentence> _listSentences;

        public Text(IEnumerable<Sentence> listSentences)
        {
            this._listSentences = new List<Sentence>(listSentences);
        }

        public override string ToString()
        {
            string str= _listSentences.Aggregate("", (current, item) => current + item.ToString() + " ");
            str=str.TrimEnd();
            return str; 
            
                
        }
        public IEnumerable<IWord> SelectWord(int length, TypeSentences typeSentences)
        {
           
            return _listSentences.Where(x => x.TypeSentences == typeSentences)
                .SelectMany(x => x.GetItemSentences<IWord>())
                .Where(z => z.Count == length)
                .GroupBy(x => x.Value).Select(g => g.First());
           
            

         }
        public bool RemoveWords(int length, bool isVowel)
        {
            bool delete = false;
            foreach (var item in _listSentences)
            {
                delete = true;
                item.RemoveAll(x => x.Count == length && x[0].IsVowel == isVowel);
            }
            return delete;
        }
        #region IList
        public void Add(Sentence item)
        {
            _listSentences.Add(item);
        }

        public void Clear()
        {
            _listSentences.Clear();
        }

        public bool Contains(Sentence item)
        {
            return _listSentences.Contains(item);
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            _listSentences.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return _listSentences.Count; }
        }

        public bool IsReadOnly
        {
            get { return _listSentences.IsReadOnly; }
        }

        public bool Remove(Sentence item)
        {
            return _listSentences.Remove(item);
        }

        public IEnumerator<Sentence> GetEnumerator()
        {
            return _listSentences.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
        public Sentence this[int index]
        {
            get
            {
                return _listSentences[index];
            }
            set
            {
                _listSentences[index] = value;
            }
        }

        public int IndexOf(Sentence item)
        {
            return _listSentences.IndexOf(item);
        }

        public void Insert(int index, Sentence item)
        {
           _listSentences.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            _listSentences.RemoveAt(index);
        }
        #endregion
    }
}
