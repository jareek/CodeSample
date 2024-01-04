using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace FactFinderQuestions.Question2
{
    internal sealed class HeaderMarkdownParser : MarkdownParser, IMarkdownParser, IFactoryMethod<HeaderMarkdownParser>
    {
        private const string LeadingGroup = "leading";
        private const string MarkerGroup = "marker";
        private const string SpacesGroup = "spaces";
        private const string TextGroup = "text";
        private const string TrailingGroup = "trailing";
        private const string HeaderTag = "h";

        private HeaderMarkdownParser()
        {
        }

        private string Pattern => $@"^(?<{LeadingGroup}>\s*)(?<{MarkerGroup}>{this.Config!.Marker}{{{this.Config.MarkerMinLength},{this.Config.MarkerMaxLength}}})(?<{SpacesGroup}>\s{{1,}})(?<{TextGroup}>[^#]*?)(?<{TrailingGroup}>\s*)$";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HeaderMarkdownParser Create() => new();

        protected override string? ParseMarkdownInternals(string? line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return line;
            }

            var match = Regex.Match(line, this.Pattern);

            return match.Success ? this.ProcessMatch(match, line) : line;
        }

        private string? ProcessMatch(Match match, string? line)
        {
            var getGroupValue = (string groupName) => {
                var group = match.Groups[groupName];
                return group?.Value;
            };
            var lineGroupValues = new LineGroupValues(
                LeadingSpaces: getGroupValue(LeadingGroup),
                HeaderLevel: getGroupValue(MarkerGroup)?.Length ?? 0,
                Spaces: getGroupValue(SpacesGroup),
                HeaderText: getGroupValue(TextGroup),
                TrailingSpaces: getGroupValue(TrailingGroup));

            var canParse = lineGroupValues.Spaces?.Length == 1;

            return canParse ?
                this.GetParsedLine(lineGroupValues) :
                $"{line} (too many spaces between)";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetParsedLine(LineGroupValues v) => $"{v.LeadingSpaces}<{HeaderTag}{v.HeaderLevel}>{v.HeaderText}{v.TrailingSpaces}</{HeaderTag}{v.HeaderLevel}>";

        private record class LineGroupValues(string? LeadingSpaces, int HeaderLevel, string? Spaces, string? HeaderText, string? TrailingSpaces);
    }
}
