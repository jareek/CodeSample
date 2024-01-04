namespace FactFinderQuestions.Question2
{
    internal record class HeaderMarkdowParserConfig(string Marker, int MarkerMinLength, int MarkerMaxLength) : IMarkdownParserConfig;
}
