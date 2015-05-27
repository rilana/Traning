using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public class Word : ItemSentences
    {
        public void ToLower()
        {
            foreach (var item in this)
            {
                item.Value = Char.ToLower(item.Value);
            }
        }
    }
}
