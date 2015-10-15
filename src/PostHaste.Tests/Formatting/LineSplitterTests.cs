namespace PostHaste.Tests.Formatting
{
    using PostHaste.Formatting;
    using Should;

    public class LineSplitterTests : FormattingTestsBase
    {
        public void SingleLine()
        {
            var result = LineSplitter.TextAsCodeLines(AnyString, TabCount);

            result.Length.ShouldEqual(1);
            result[0].Line.ShouldEqual(AnyString);
        }

        public void EmptyString()
        {
            var result = LineSplitter.TextAsCodeLines(string.Empty, TabCount);

            result[0].Line.ShouldBeEmpty();
        }

        public void SingleLineWithTab()
        {
            var line = $"{TabString}{AnyString}";

            var result = LineSplitter.TextAsCodeLines(line, TabCount);

            result[0].TabCount.ShouldEqual(1);
            result[0].Line.ShouldEqual(line);
        }

        public void TwoLineString()
        {
            var line = $"{AnyString}{CodeLine.NewLine}{TabString}{AnyString}";

            var result = LineSplitter.TextAsCodeLines(line, TabCount);

            result.Length.ShouldEqual(2);
            result[0].Line.ShouldEqual(AnyString);
            result[1].Line.ShouldEqual($"{TabString}{AnyString}");
            result[1].TabCount.ShouldEqual(1);
            result[0].TabCount.ShouldEqual(0);
        }

        public void ThreeLineString()
        {
            var line =
                $"{AnyString}{CodeLine.NewLine}{TabString}{TabString}{AnyString}{CodeLine.NewLine}{TabString}{AnyString}";

            var result = LineSplitter.TextAsCodeLines(line, TabCount);

            result.Length.ShouldEqual(3);

            result[0].Line.ShouldEqual(AnyString);
            result[1].Line.ShouldEqual($"{TabString}{TabString}{AnyString}");
            result[2].Line.ShouldEqual($"{TabString}{AnyString}");
        }
    }
}
