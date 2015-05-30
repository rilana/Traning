using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordProcessing
{
    public class Parser
    {
        
       
        public static Text CreateText(string text)
        {
            ICollection<Sentence> listSentences = new List<Sentence>();
            Sentence sentences = new Sentence();
            text = Regex.Replace(text.Replace("\t", " ").Replace("\r\n", " "), " +", " ");
            string[] val = text.Split(' ');
            foreach (string item in val)
            {
                sentences.AddRange(CreateItemSentences(item));
                if (sentences.TypeSentences != TypeSentences.SetOfWords)
                {
                    listSentences.Add(sentences);
                    sentences = new Sentence();
                }
            }
            if ((listSentences.Count == 0) && (sentences.Count > 0))
            {
                listSentences.Add(sentences);
            }
            return new Text(listSentences);
        }
        public static Text CreateText(string patch,Encoding encoding)
        {
            ICollection<Sentence> listSentences = new List<Sentence>();
            Sentence sentences = new Sentence(); ;
            using (StreamReader sr = new StreamReader("text.txt",encoding))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    line = Regex.Replace(line.Replace("\t", " ").Replace("\r\n", " "), " +", " ");


                    string[] val = line.Split(' ');
                    foreach (string item in val)
                    {
                        sentences.AddRange(CreateItemSentences(item));
                        if (sentences.TypeSentences!=TypeSentences.SetOfWords)
                        {
                            listSentences.Add(sentences);
                            sentences = new Sentence();
                        }
                    }
                    
                }
                // если только слова,нет признака конца предложения
                if ((listSentences.Count == 0) && (sentences.Count > 0))
                {
                    listSentences.Add(sentences);
                }
            }
            return new Text(listSentences);
        }

        private static IList<ItemSentences> CreateItemSentences(string str)
        {
            IList<ItemSentences> itemsSentences=new List<ItemSentences>();
            // если перед словом стоит знак препинания(без пробела) например (
            int i = 0;
            Character charcter;
            Word word = new Word();
            PunctuationMark punctuation = new PunctuationMark();
            while (PunctuationMark.IsPunctuation(str[i]))
            {
                charcter = new Character()
                    {
                        Value = str[i]
                    };

                PunctuationMark punct = new PunctuationMark() { BeforeWord = true };
                punct.Add(charcter);
                itemsSentences.Add(punct);
                i++;
            }
            // проходим все символы и записываем в объект слово либо зн.пунктуации
            //-------------------------------------------------------------------------------------------------
            for (int j = i; j < str.Length - 1; j++)
            {
                charcter = new Character()
                        {
                            Value = str[j]
                        };
                if ((PunctuationMark.IsPunctuation(str[j]))
                    && (PunctuationMark.IsPunctuation(str[j + 1])))// проверка что это не деффис или аппостраф,т.е.п знак препинание не мб в середине слова
                {

                    punctuation.Add(charcter);
                }
                else
                {

                    word.Add(charcter);
                }

            }
            charcter = new Character()
            {
                Value = str[str.Length - 1]
            };
            if (PunctuationMark.IsPunctuation(str[str.Length - 1]))
            {
                punctuation.Add(charcter);
            }
            else
            {
                word.Add(charcter);
            }

            itemsSentences.Add(word);
            if (punctuation.Value != "")
            {
                itemsSentences.Add(punctuation);
               // EndSentence = punctuation.EndSentence;
            }
            //-----------------------------------------------------------------------------------------
            return itemsSentences;
        }
        //private void FilCharacterWordOrPunctuation(char ch,Word word, PunctuationMark punctuation)
        //{
 
        //}
    }
}
