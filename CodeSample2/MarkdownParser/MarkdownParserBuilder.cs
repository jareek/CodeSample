namespace FactFinderQuestions.Question2
{
    public abstract class MarkdownParserBuilder
    {
        protected MarkdownParserBuilder() { }

        public abstract IMarkdownParser Build();

        protected virtual T CreateParserInstance<T>() where T : IMarkdownParser, IFactoryMethod<T> => T.Create();

        protected abstract IMarkdownParserConfig GetMarkdownParserConfig();
    }
}
