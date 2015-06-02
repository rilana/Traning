using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class PunctuationMark : ItemSentences,IPunctuationMark
    {
        public PunctuationMark()
        {
            BeforeWord = false;
        }

        // If punctuation is before the word and do not share a space, for example, (
        public bool BeforeWord { get; set; }

        public static bool IsPunctuation(char ch)
        {
            char[] masPunctuation = { '.', ',', '?', '!', ';', ':','(',')' };
            if (Array.IndexOf(masPunctuation, ch) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        public bool EndSentence

        {
            get
            {
                char[] endPunctuation = { '.', '?', '!' };
                if (this.Value.IndexOfAny(endPunctuation) > -1)
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
}
