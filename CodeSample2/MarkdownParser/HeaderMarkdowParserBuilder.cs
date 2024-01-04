using System.Runtime.CompilerServices;

namespace FactFinderQuestions.Question2
{
    public sealed class HeaderMarkdowParserBuilder : MarkdownParserBuilder
    {
        public override IMarkdownParser Build()
        {
            var mardownParser = this.CreateParserInstance<HeaderMarkdownParser>();
            mardownParser.Config = this.GetMarkdownParserConfig();

            return mardownParser;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IMarkdownParserConfig GetMarkdownParserConfig() => new HeaderMarkdowParserConfig(Marker: "#", MarkerMinLength: 1, MarkerMaxLength: 6);
    }
}
