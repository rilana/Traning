using System.Collections.Generic;
using System.Linq;

namespace WordProcessing
{
    public abstract class ItemSentences : IItemSentences
    {
        private readonly List<Character>  _characters = new List<Character>();
        public string Value
        {
            get
            {
                return _characters.Aggregate("", (current, item) => current + item.Value);
            }
        }
        public void AddRange(string str)
        {
            foreach (var item in str)
            {
                _characters.Add(
                    new Character()
                    {
                      Value = item
                     });
            }
        }
        #region IList
        public void Add(Character item)
        {
            
            _characters.Add(item);
        }

        public void Clear()
        {
            _characters.Clear();
        }

        public bool Contains(Character item)
        {
            return _characters.Contains(item);
        }

        public void CopyTo(Character[] array, int arrayIndex)
        {
            _characters.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _characters.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Character item)
        {
            return _characters.Remove(item);
        }

        public IEnumerator<Character> GetEnumerator()
        {
            return _characters.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(Character item)
        {
            return _characters.IndexOf(item);
        }

        public void Insert(int index, Character item)
        {
           _characters.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
           _characters.RemoveAt(index);
        }

        public Character this[int index]
        {
            get
            {
               return _characters[index];
            }
            set
            {
               _characters[index]=value;
            }
        }

        public void AddRange(IEnumerable<Character> collection)
        {
            _characters.AddRange(collection);
        }
        #endregion

    }
}
