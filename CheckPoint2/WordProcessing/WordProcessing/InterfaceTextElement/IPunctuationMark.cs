
namespace WordProcessing
{
    public interface IPunctuationMark:IItemSentences
    {
        bool BeforeWord { get; }
        bool EndSentence { get; }
    }
}
