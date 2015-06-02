using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WordProcessing
{
    public class Parser
    {
        
       
        public static Text CreateText(string text)
        {
            ICollection<Sentence> listSentences = new List<Sentence>();
            var sentences = new Sentence();
            text = Regex.Replace(text.Replace("\t", " ").Replace("\r\n", " "), " +", " ");
            string[] val = text.Split(' ');
            foreach (var item in val)
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
        public static Text CreateText(string path,Encoding encoding)
        {
            ICollection<Sentence> listSentences = new List<Sentence>();
            try
            {
               
                var sentences = new Sentence(); 
                using (var sr = new StreamReader(path, encoding))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        line = Regex.Replace(line.Replace("\t", " ").Replace("\r\n", " "), " +", " ");


                        string[] val = line.Split(' ');
                        foreach (string item in val)
                        {
                            sentences.AddRange(CreateItemSentences(item));
                            if (sentences.TypeSentences != TypeSentences.SetOfWords)
                            {
                                listSentences.Add(sentences);
                                sentences = new Sentence();
                            }
                        }

                    }
                    // If only the words, there is no sign of the end of the offer
                    if ((listSentences.Count == 0) && (sentences.Count > 0))
                    {
                        listSentences.Add(sentences);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                Environment.Exit(1);
            }
            return new Text(listSentences);
        }

        private static IList<IItemSentences> CreateItemSentences(string str)
        {
            IList<IItemSentences> itemsSentences=new List<IItemSentences>();
            // если перед словом стоит знак препинания(без пробела) например (
            var i = 0;
            Character charcter;
            var word = new Word();
            var punctuation = new PunctuationMark();
            while (PunctuationMark.IsPunctuation(str[i]))
            {
                charcter = new Character()
                    {
                        Value = str[i]
                    };

                var punct = new PunctuationMark() { BeforeWord = true };
                punct.Add(charcter);
                itemsSentences.Add(punct);
                i++;
            }
            // We pass all the characters and write the object of the word or punctuation
            //-------------------------------------------------------------------------------------------------
            for (var j = i; j < str.Length - 1; j++)
            {
                charcter = new Character()
                        {
                            Value = str[j]
                        };
                // Check that it is not deffis or appostraf, t.e.p punctuation marks can not be in the middle of a word
                if ((PunctuationMark.IsPunctuation(str[j]))
                    && (PunctuationMark.IsPunctuation(str[j + 1])))
                   
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
        
    }
}
