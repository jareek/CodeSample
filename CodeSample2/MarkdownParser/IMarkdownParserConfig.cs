
namespace FactFinderQuestions.Question2
{
    public interface IMarkdownParserConfig
    {
        string Marker { get; }

        int MarkerMinLength { get; }

        int MarkerMaxLength { get; }
    }
}
