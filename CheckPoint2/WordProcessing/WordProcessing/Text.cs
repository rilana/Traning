using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Text:ICollection<Sentence>
    {
        private ICollection<Sentence> listSentences;
      
        public Text(string textFromFile)
        {
            listSentences = new List<Sentence>(Worker.ConstructSentencesList(textFromFile));
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
        public IEnumerable<Word> SelectWord(int length, TypeSentences TypeSentences, bool NoRepeatWordText)
        {
            //без повторений в каждом предложении
            var query = listSentences.Where(x => x.TypeSentences == TypeSentences.Interrogative)
                .SelectMany(x => x.GetItemSentences<Word>().Where(z => z.Count == length)
                .GroupBy(z => z.Value).Select(g => g.First()));
            //без повторений во всём тексте
            if (NoRepeatWordText)
            {
                query = listSentences.Where(x => x.TypeSentences == TypeSentences)
                .SelectMany(x => x.GetItemSentences<Word>())
                .Where(z => z.Count == length)
                .GroupBy(x => x.Value).Select(g => g.First());
            }
            return query;

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
        #region ICollection
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
        #endregion
    }
}
