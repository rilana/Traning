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
            bool EndSentence= false;
            Sentence sentences = new Sentence(); ;
            foreach (string item in val)
            {
                //if (PunctuationMark.EndSentence(strWork))
                if (EndSentence)
                {
                    listSentences.Add(sentences);
                    sentences = new Sentence();
                    EndSentence=false;
                }

                Word word = new Word();
                PunctuationMark punctuation = new PunctuationMark();
                // если перед словом стоит знак припенания(без пробела) например (
                int i = 0;
                if (PunctuationMark.IsPunctuation(item[i]))
                {
                    
                    PunctuationMark punct = new PunctuationMark() { BeforeWord=true};
                    punct.Add(
                        new Character() 
                         {
                             Value=item[i]
                         }
                        );
                    sentences.Add(punct);
                    i++;
                }
                // проходим все символы и записываем в объект слово либо зн.пунктуации
                //-------------------------------------------------------------------------------------------------
                for (int  j = i; j <item.Length-1 ; j++)
                {
                    if ((PunctuationMark.IsPunctuation(item[j]))
                        &&(PunctuationMark.IsPunctuation(item[j+1])))// проверка что это не деффис или аппостраф,т.е.п знак препинание не мб в середине слова
                    {
                        
                        punctuation.Add(
                            new Character()
                            {
                                Value = item[j]
                            }
                           );
                    }
                    else
                    {

                        word.Add(
                            new Character()
                            {
                                Value = item[j]
                            }
                            );
                    }

                }
                if (PunctuationMark.IsPunctuation(item[item.Length - 1]))
                {
                    punctuation.Add(
                         new Character()
                         {
                             Value = item[item.Length - 1]
                         }
                        );
                }
                else
                {
                    word.Add(
                            new Character()
                            {
                                Value = item[item.Length - 1]
                            }
                            );
                }
                //-----------------------------------------------------------------------------------------
                sentences.Add(word);
                if (punctuation.Value != "")
                {
                    sentences.Add(punctuation);
                    EndSentence = punctuation.EndSentence;
                }

            }
            // если только слова,нет признака конца предложения
            if ((listSentences.Count==0)&&(sentences.Count>0))
            {
                listSentences.Add(sentences);
            }
            return listSentences;
        }
        public static void PrintText(ICollection<Sentence> listSentences)
        {
            foreach (var item in listSentences)
            {
<<<<<<< HEAD
                Console.WriteLine(item.ToString());
=======
                Console.WriteLine(item.Value);
>>>>>>> origin/master

            }
        }
        //private void FilCharacterWordOrPunctuation(char ch,Word word, PunctuationMark punctuation)
        //{
 
        //}
    }
}
