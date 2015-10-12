namespace PostHaste.Tests.Formatting
{
    using System.Collections.Generic;
    using System.Linq;
    using PostHaste.Formatting;
    using Should;

    public class ExcessTabDetectorTests : FormattingTestsBase
    {
        public void EmptyList()
        {
            var result = ExcessTabDetector.DetectExcessTabDepth(new CodeLine[0]);

            result.ShouldEqual(0);
        }

        public void ListWithNoTabs()
        {
            var codeLines = new[]
            {
                $"{AnyString}",
                $"{AnyString}{TabString}"
            };

            var result = ExcessTabDetector.DetectExcessTabDepth(StringsAsCodeLines(codeLines));

            result.ShouldEqual(0);
        }

        public void ListWithOneTabAndZeroTab()
        {
            var codeLines = new[]
            {
                $"{AnyString}",
                $"{TabString}{AnyString}",
            };

            var result = ExcessTabDetector.DetectExcessTabDepth(StringsAsCodeLines(codeLines));

            result.ShouldEqual(0);
        }

        public void ListWithOneTab()
        {
            var codeLines = new[]
            {
                $"{TabString}{AnyString}",
                $"{TabString}{AnyString}{AnyString}{TabString}"
            };

            var result = ExcessTabDetector.DetectExcessTabDepth(StringsAsCodeLines(codeLines));

            result.ShouldEqual(1);
        }

        public void ListWithMultipleTabs()
        {
            var codeLines = new[]
            {
                $"{TabString}{TabString}{AnyString}",
                $"{TabString}{TabString}{AnyString}{AnyString}{TabString}"
            };

            var result = ExcessTabDetector.DetectExcessTabDepth(StringsAsCodeLines(codeLines));

            result.ShouldEqual(2);
        }

        public void ListWithVariableTabs()
        {
            var codeLines = new[]
            {
                $"{TabString}{TabString}{AnyString}",
                $"{TabString}{TabString}{TabString}{AnyString}{AnyString}{TabString}",
                $"{TabString}{AnyString}"
            };

            var result = ExcessTabDetector.DetectExcessTabDepth(StringsAsCodeLines(codeLines));

            result.ShouldEqual(1);
        }

        private IList<CodeLine> StringsAsCodeLines(IEnumerable<string> input)
        {
            return input?.Select(s => new CodeLine(s, TabCount)).ToArray() ?? new CodeLine[0];
        }
    }
}
