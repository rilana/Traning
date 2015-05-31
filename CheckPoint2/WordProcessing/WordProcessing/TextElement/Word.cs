using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Word : ItemSentences,IWord
    {
        public void ToLower()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Character ch = this[i];
                ch.Value=Char.ToLower(ch.Value);
                this[i] = ch; 
            }
             
        }
    }
}
