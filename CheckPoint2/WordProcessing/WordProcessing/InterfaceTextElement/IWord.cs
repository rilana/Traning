using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public interface IWord:IItemSentences
    {
        void ToLower();
    }
}
