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
                var endsWithNewLine = input.EndsWith(CodeLine.NewLine);

                var numberOfSpacesToTrim = excessTabDepth * spacesPerTab;

                var builder = new StringBuilder();

                for (var i = 0; i < inputAsCodeLines.Length; i++)
                {
                    builder.Append(inputAsCodeLines[i].Line.Substring(numberOfSpacesToTrim));

                    if (endsWithNewLine || i < inputAsCodeLines.Length - 1)
                    {
                        builder.Append(CodeLine.NewLine);
                    }
                }

                result = builder.ToString();
            }

            return result;
        }
    }
}
