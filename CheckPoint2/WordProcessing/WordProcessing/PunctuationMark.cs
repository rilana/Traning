using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class PunctuationMark : ItemSentences
    {

        
        public PunctuationMark()
        {

        }
        public PunctuationMark(char[] value)
        {

        }
        public static bool IsPunctuation(char ch)
        {
            char[] masPunctuation = { '.', '.', '?', '!', ';', ':','(',')' };
            if (Array.IndexOf(masPunctuation, ch) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool EndSentence(string str)
        {
            char[] EndPunctuation = { '.', '?', '!' };
            if (str.IndexOfAny(EndPunctuation) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
