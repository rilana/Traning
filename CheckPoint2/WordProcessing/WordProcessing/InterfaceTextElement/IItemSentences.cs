using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordProcessing
{
    public interface IItemSentences:IList<Character>
    {
        string Value{get;}
    }
}
