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
        private static Sentence CreateItemSentences(string str)
        {
            Sentence itemsSentences = new Sentence
            {
                CreateItem(str, false, true),
                CreateItem(str, true, true),
                CreateItem(str, false, false)
            };
            return itemsSentences;
        }
        //start punctuation
        private const string PatternStartWord = @"\A[(.)]+";
        //end punctuation
        private const string PatternEndWord = @"[(.,?!:;)]+\Z";

        private static ItemSentences CreateItem(string str, bool isWord, bool beforeWord)
        {
            ItemSentences item;
            var strReturn = string.Empty;
            var pattern=PatternEndWord;
            if (isWord)
            {
                strReturn = Regex.Replace(Regex.Replace(str, PatternEndWord, ""), PatternStartWord, "");
                item = new Word();
            }
            else 
            {
                if (beforeWord) pattern = PatternStartWord;
                foreach (Match ch in Regex.Matches(str, pattern))
	            {
                    strReturn = ch.Value;
	            }
                item = new PunctuationMark() { BeforeWord = beforeWord };
            }
            item.AddRange(strReturn);
            return item;
        }

        
    }
}
