using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public interface IPunctuationMark:IItemSentences
    {
        bool BeforeWord { get; }
        bool EndSentence { get; }
    }
}
