using System;

namespace WordProcessing
{
    public class Word : ItemSentences,IWord
    {
        public void ToLower()
        {
            for (var i = 0; i < Count; i++)
            {
                Character ch = this[i];
                ch.Value=Char.ToLower(ch.Value);
                this[i] = ch; 
            }
             
        }
    }
}
