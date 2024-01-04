using FactFinderQuestions.Question2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactFinderQuestionTests.Question1
{
    [TestClass]
    public class MarkdownParserTests
    {
        [TestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow("   ", "   ")]
        [DataRow("Header", "Header")]
        [DataRow("# Header", "<h1>Header</h1>")]
        [DataRow("### Header", "<h3>Header</h3>")]
        [DataRow("###### Header", "<h6>Header</h6>")]
        [DataRow("###### Header  ", "<h6>Header  </h6>")]
        [DataRow("####### Header", "####### Header")]
        [DataRow("#  Header", "#  Header (too many spaces between)")]
        [DataRow("   #  Header", "   #  Header (too many spaces between)")]
        [DataRow("   ## Header   ", "   <h2>Header   </h2>")]
        [DataRow(" #Header ", " #Header ")]
        [DataRow(" ##Header ", " ##Header ")]
        [DataRow(" ## ", " <h2></h2>")]
        [DataRow("    ##  ", "    ##   (too many spaces between)")]
        [DataRow(" ## 1", " <h2>1</h2>")]
        [DataRow(" ## # ", " ## # ")]
        [DataRow(" (## Text", " (## Text")]
        [DataRow(" 1## Text ", " 1## Text ")]
        [DataRow(" 1 ## Text ", " 1 ## Text ")]
        [DataRow(" #2# Text ", " #2# Text ")]
        [DataRow("##### 1234567890!@$%^&*()abCD,.;:'\" ?? asd   ", "<h5>1234567890!@$%^&*()abCD,.;:'\" ?? asd   </h5>")]
        [DataRow(" ### Te(xt  aaaa ", " <h3>Te(xt  aaaa </h3>")]
        [DataRow(" ## Te(x#t aaaa", " ## Te(x#t aaaa")]
        [DataRow("  ##  Te(xt ", "  ##  Te(xt  (too many spaces between)")]

        public void WhenInputStringIsNotEmptyThenOutputIsParsed(string input, string expected)
        {

            var markdownParserFactory = new HeaderMarkdowParserBuilder();
            var markdownParser = markdownParserFactory.Build();

            var output = markdownParser.ParseMarkdown(input);

            Assert.IsTrue(string.Equals(output, expected));
        }
    }
}