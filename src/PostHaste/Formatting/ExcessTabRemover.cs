namespace PostHaste.Formatting
{
    using System.Text;

    public class ExcessTabRemover
    {
        public static string RemoveExcessTabs(string input, int spacesPerTab)
        {
            if (input == null || spacesPerTab <= 0)
            {
                return input;
            }

            var result = input;

            var inputAsCodeLines = LineSplitter.TextAsCodeLines(input, spacesPerTab);

            var excessTabDepth = ExcessTabDetector.DetectExcessTabDepth(inputAsCodeLines);

            if (excessTabDepth > 0)
            {
                result = TrimExcessTabs(inputAsCodeLines,
                    excessTabDepth,
                    spacesPerTab,
                    StringEndsWithNewLine(input));
            }

            return result;
        }

        private static bool StringEndsWithNewLine(string input)
        {
            return input.EndsWith(CodeLine.NewLine);
        }

        private static string TrimExcessTabs(CodeLine[] codeLines,
            int excessTabDepth,
            int spacesPerTab,
            bool endsWithNewLine)
        {
            var numberOfSpacesToTrim = excessTabDepth * spacesPerTab;

            var builder = new StringBuilder();

            for (var i = 0; i < codeLines.Length; i++)
            {
                builder.Append(codeLines[i].Line.Substring(numberOfSpacesToTrim));

                if (endsWithNewLine || i < codeLines.Length - 1)
                {
                    builder.Append(CodeLine.NewLine);
                }
            }

            return builder.ToString();
        }
    }
}
