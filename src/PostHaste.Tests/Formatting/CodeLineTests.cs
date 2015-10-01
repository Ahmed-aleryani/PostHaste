namespace PostHaste.Tests.Formatting
{
    using System;
    using PostHaste.Formatting;
    using Should;

    public class CodeLineTests : FormattingTestsBase
    {
        public void PassEmptyString()
        {
            var result = new CodeLine(string.Empty, TabCount);

            result.TabCount.ShouldEqual(0);
            result.Line.ShouldEqual(string.Empty);
        }

        public void PassZeroThrows()
        {
            try
            {
                var result = new CodeLine(AnyString, 0);
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain("cannot be zero");
            }
        }

        public void EndsWithTab_NotCounted()
        {
            var result = new CodeLine($"{AnyString}{TabString}", TabCount);

            result.TabCount.ShouldEqual(0);
        }

        public void StartsWithFullTab_Counted()
        {
            var result = new CodeLine($"{TabString}{AnyString}", TabCount);

            result.TabCount.ShouldEqual(1);
        }

        public void StartsWithThreeTabs_Counted()
        {
            var result = new CodeLine($"{TabString}{TabString}{TabString}{AnyString}", TabCount);

            result.TabCount.ShouldEqual(3);
        }

        public void StartsWithOneTab_ReturnsCorrectNumberOfSpaces()
        {
            var result = new CodeLine($"{TabString}{AnyString}", TabCount);

            result.SpaceCount.ShouldEqual(TabCount);
        }

        public void StartsWithSpace_ReturnsCorrectSpaceCount()
        {
            var result = new CodeLine($" {AnyString}", TabCount);

            result.SpaceCount.ShouldEqual(1);
        }

        public void ContainsSpacesInsideCode()
        {
            var result = new CodeLine($" {AnyString} {AnyString} 7;", TabCount);

            result.SpaceCount.ShouldEqual(1);
        }

        public void StartsWithSpace_TabCountZero()
        {
            var result = new CodeLine($" {AnyString}", TabCount);

            result.TabCount.ShouldEqual(0);
            result.SpaceCount.ShouldEqual(1);
        }

        public void PassNull_Throws()
        {
            try
            {
                var result = new CodeLine(null, TabCount);
            }
            catch (ArgumentNullException ex)
            {
                ex.Message.ShouldContain("value");
            }
        }
    }
}
