namespace PostHaste.Formatting
{
    using System;
    using System.Linq;
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
            var linesWithoutEmptyStartAndEnd = RemoveFirstAndLastBlankLines(codeLines);

            var numberOfSpacesToTrim = excessTabDepth * spacesPerTab;

            var builder = new StringBuilder();

            for (var i = 0; i < linesWithoutEmptyStartAndEnd.Length; i++)
            {
                if (linesWithoutEmptyStartAndEnd[i].IsEmpty)
                {
                    builder.Append(CodeLine.NewLine);
                    continue;
                }

                builder.Append(linesWithoutEmptyStartAndEnd[i].Line.Substring(numberOfSpacesToTrim));

                if (endsWithNewLine || i < linesWithoutEmptyStartAndEnd.Length - 1)
                {
                    builder.Append(CodeLine.NewLine);
                }
            }

            return builder.ToString();
        }

        private static CodeLine[] RemoveFirstAndLastBlankLines(CodeLine[] codeLines)
        {
            if (codeLines == null 
                || codeLines.Length <= 1
                || codeLines.All(cl => cl.IsEmpty))
            {
                return codeLines;
            }

            var startIsEmpty = codeLines[0].IsEmpty;
            var endIsEmpty = codeLines[codeLines.Length - 1].IsEmpty;

            if (!endIsEmpty && !startIsEmpty)
            {
                return codeLines;
            }

            var index = startIsEmpty ? 1 : 0;
            var length = endIsEmpty ? codeLines.Length - 1 : codeLines.Length;

            if (startIsEmpty)
            {
                length--;
            }

            var result = new CodeLine[length];
            Array.Copy(codeLines, index, result, 0, length);
            return result;
        }
    }
}
