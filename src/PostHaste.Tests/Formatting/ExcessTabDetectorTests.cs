namespace PostHaste.Tests.Formatting
{
    using PostHaste.Formatting;
    using Should;

    public class ExcessTabDetectorTests : FormattingTestsBase
    {
        public void EmptyList()
        {
            var result = ExcessTabDetector.DetectExcessTabDepth(new CodeLine[0]);

            result.ShouldEqual(0);
        }
    }
}
