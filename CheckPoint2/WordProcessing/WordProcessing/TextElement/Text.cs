using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Text:IList<Sentence>
    {
        private IList<Sentence> listSentences;

        public Text(IEnumerable<Sentence> listSentences)
        {
            this.listSentences = new List<Sentence>(listSentences);
        }

        public override string ToString()
        {
            string str="";
            foreach (var item in listSentences)
	        {
		        str=str+item.ToString()+" ";
	        }
            str=str.TrimEnd();
            return str; 
            
                
        }
        public IEnumerable<Word> SelectWord(int length, TypeSentences TypeSentences)
        {
           
            return listSentences.Where(x => x.TypeSentences == TypeSentences)
                .SelectMany(x => x.GetItemSentences<Word>())
                .Where(z => z.Count == length)
                .GroupBy(x => x.Value).Select(g => g.First());
           
            

         }
        public bool RemoveWords(int length, bool IsVowel)
        {
            bool delete = false;
            foreach (var item in listSentences)
            {
                delete = true;
                item.RemoveAll(x => x.Count == length && x[0].IsVowel == IsVowel);
            }
            return delete;
        }
        #region IList
        public void Add(Sentence item)
        {
            listSentences.Add(item);
        }

        public void Clear()
        {
            listSentences.Clear();
        }

        public bool Contains(Sentence item)
        {
            return listSentences.Contains(item);
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            listSentences.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return listSentences.Count; }
        }

        public bool IsReadOnly
        {
            get { return listSentences.IsReadOnly; }
        }

        public bool Remove(Sentence item)
        {
            return listSentences.Remove(item);
        }

        public IEnumerator<Sentence> GetEnumerator()
        {
            return listSentences.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
       
        public Sentence this[int index]
        {
            get
            {
                return listSentences[index];
            }
            set
            {
                listSentences[index] = value;
            }
        }

        public int IndexOf(Sentence item)
        {
            return listSentences.IndexOf(item);
        }

        public void Insert(int index, Sentence item)
        {
           listSentences.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            listSentences.RemoveAt(index);
        }
        #endregion
    }
}
