using System.Collections.Generic;


namespace WordProcessing
{
    public interface IItemSentences:IList<Character>
    {
        string Value{get;}
    }
}
