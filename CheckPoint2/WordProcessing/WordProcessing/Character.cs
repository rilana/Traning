using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Character
    {
        public char Value { get; set; }
        public bool? IsVowel
        {
            get
            {
                char[] masVowel = { 'а', 'у', 'е', 'ы', 'о', 'э', 'я', 'и', 'а', 'ю' };
                if (PunctuationMark.IsPunctuation(Value))
                {
                    return null;
                }
                else if (Array.IndexOf(masVowel, Value) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
