namespace PostHaste.Formatting
{
    using System;
    using System.Linq;
    using Core;

    public class LineSplitter
    {
        public static string[] TextAsLines(string text)
        {
            Guard.ArgumentNotNull(nameof(text), text);

            return text.Split(new[] { CodeLine.NewLine }, StringSplitOptions.None);
        }

        public static CodeLine[] TextAsCodeLines(string text, int spacesPerTab)
        {
            Guard.ArgumentNotNull(nameof(text), text);

            var lines = TextAsLines(text).Select(l => new CodeLine(l, spacesPerTab)).ToArray();

            return lines;
        }
    }
}
