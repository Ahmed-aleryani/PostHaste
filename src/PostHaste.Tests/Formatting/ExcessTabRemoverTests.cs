namespace PostHaste.Tests.Formatting
{
    using PostHaste.Formatting;
    using Should;

    public class ExcessTabRemoverTests : FormattingTestsBase
    {
        public void NullString()
        {
            var result = ExcessTabRemover.RemoveExcessTabs(null, TabCount);

            result.ShouldBeNull();
        }

        public void EmptyString()
        {
            var result = ExcessTabRemover.RemoveExcessTabs(string.Empty, TabCount);

            result.ShouldBeEmpty();
        }

        public void NegativeSpacesPerTab()
        {
            var result = ExcessTabRemover.RemoveExcessTabs(AnyString, -1);

            result.ShouldEqual(AnyString);
        }

        public void OneCodeLineNoTabs()
        {
            var input = $"{AnyString}{AnyString}{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual(input);
        }

        public void OneLineEndingWithNewLine()
        {
            var input = $"{AnyString}{CodeLine.NewLine}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual(input);
        }

        public void TwoLinesNoExcessTabs()
        {
            var input = $"{AnyString}{CodeLine.NewLine}{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual(input);
        }

        public void OneLineExcessTab()
        {
            var input = $"{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual(AnyString);
        }

        public void OneLineExcessTabs()
        {
            var input = $"{TabString}{TabString}{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual(AnyString);
        }

        public void TwoLinesExcessTabs()
        {
            var input = $"{TabString}{AnyString}{CodeLine.NewLine}{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual($"{AnyString}{CodeLine.NewLine}{AnyString}");
        }

        public void ThreeLinesExcessTabs()
        {
            var input = $"{TabString}{TabString}{AnyString}{CodeLine.NewLine}{TabString}{TabString}{AnyString}{CodeLine.NewLine}{TabString}{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual($"{AnyString}{CodeLine.NewLine}{AnyString}{CodeLine.NewLine}{AnyString}");
        }

        public void TwoLinesExcessVariedTabs()
        {
            var input = $"{TabString}{AnyString}{CodeLine.NewLine}{TabString}{TabString}{AnyString}";

            var result = ExcessTabRemover.RemoveExcessTabs(input, TabCount);

            result.ShouldEqual($"{AnyString}{CodeLine.NewLine}{TabString}{AnyString}");
        }
    }
}
