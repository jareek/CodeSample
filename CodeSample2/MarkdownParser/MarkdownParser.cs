using System.Runtime.CompilerServices;

namespace FactFinderQuestions.Question2
{
    internal abstract class MarkdownParser : IMarkdownParser
    {
        protected MarkdownParser() { }

        internal IMarkdownParserConfig? Config { get;  set; }

        public string? ParseMarkdown(string? line)
        {
            this.ValidateConfiguration();
            var result = this.ParseMarkdownInternals(line);

            return result;
        }

        protected abstract string? ParseMarkdownInternals(string? line);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected virtual void ValidateConfiguration()
        {
            _ = this.Config ?? throw new InvalidOperationException($"{nameof(this.Config)} property not set.");
        }
    }
}
