using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordProcessing
{
    public class Worker
    {
        public static ICollection<Sentence> ConstructSentencesList(string text)
        {
            // удаляем лишние пробелы и удаляем знаки табуляции
            text = Regex.Replace(text.Replace("\t", " "), " +", " ");

            ICollection<Sentence> listSentences = new List<Sentence>();
            string[] val = text.Split(' ');
            string strWork = "";
            Sentence sentences = new Sentence(); ;
            foreach (string item in val)
            {
                if (PunctuationMark.EndSentence(strWork))
                {
                    listSentences.Add(sentences);
                    sentences = new Sentence();
                    strWork = "";
                }

                Word word = new Word();
                PunctuationMark punctuation = new PunctuationMark();
                foreach (char ch in item)
                {
                    if (PunctuationMark.IsPunctuation(ch))
                    {
                        punctuation.Add(
                            new Character()
                            {
                                Value = ch
                            }
                           );
                    }
                    else
                    {

                        word.Add(
                            new Character()
                            {
                                Value = ch
                            }
                            );
                    }

                }
                sentences.Add(word);
                if (punctuation.Value != "")
                {
                    sentences.Add(punctuation);
                    strWork = punctuation.Value;
                }



            }
            return listSentences;
        }
    }
}
